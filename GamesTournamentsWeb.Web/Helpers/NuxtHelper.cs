namespace GamesTournamentsWeb.Web.Helpers;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading.Tasks;


public static class NuxtHelper
{
   private static Uri DevelopmentServerEndpoint { get; } = new Uri($"http://localhost:{Constants.ClientAppPort}");
   private static TimeSpan Timeout { get; } = TimeSpan.FromSeconds(30);
   // done message of 'npm run dev' command.
   private const string DoneMessage = "DONE Compiled successfully in";

   public static void UseNuxtDevelopmentServer(this ISpaBuilder spa)
   {
       spa.UseProxyToSpaDevelopmentServer(async () =>
       {
           var loggerFactory = spa.ApplicationBuilder.ApplicationServices.GetService<ILoggerFactory>();
           var logger = loggerFactory.CreateLogger("Nuxt");
           // if 'npm dev' command was executed yourself, then just return the endpoint.
           if (IsRunning())
           {
              return DevelopmentServerEndpoint;
           }
           
           string currentDirectory = Directory.GetCurrentDirectory();
           
           // launch Nuxt development server
           var processInfo = new ProcessStartInfo
           {
              FileName = "cmd",
              Arguments = $"/c {Constants.ClientAppRunCommand}",
              WorkingDirectory = Path.Combine(currentDirectory, Constants.ClientAppFolder),
              RedirectStandardError = true,
              RedirectStandardInput = true,
              RedirectStandardOutput = true,
              UseShellExecute = false,
           };
           var process = Process.Start(processInfo);
           var tcs = new TaskCompletionSource<int>();
           _ = Task.Run(() =>
           {
              try
              {
                  string line;
                  while ((line = process.StandardOutput.ReadLine()) != null)
                  {
                      logger.LogInformation(line);
                      if (!tcs.Task.IsCompleted && line.Contains(DoneMessage))
                      {
                          tcs.SetResult(1);
                      }
                  }
              }
              catch (EndOfStreamException ex)
              {
                  logger.LogError(ex.ToString());
                  tcs.SetException(new InvalidOperationException("Command failed.", ex));
              }
           });
           _ = Task.Run(() =>
           {
              try
              {
                  string line;
                  while ((line = process.StandardError.ReadLine()) != null)
                  {
                      logger.LogError(line);
                  }
              }
              catch (EndOfStreamException ex)
              {
                  logger.LogError(ex.ToString());
                  tcs.SetException(new InvalidOperationException("Command failed.", ex));
              }
           });
           var timeout = Task.Delay(Timeout);
           if (await Task.WhenAny(timeout, tcs.Task) == timeout)
           {
              throw new TimeoutException();
           }
           return DevelopmentServerEndpoint;
       });
   }

   private static bool IsRunning() => IPGlobalProperties.GetIPGlobalProperties()
           .GetActiveTcpListeners()
           .Select(x => x.Port)
           .Contains(Constants.ClientAppPort);
}

