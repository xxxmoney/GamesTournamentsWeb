using System.ComponentModel.DataAnnotations;

namespace GamesTournamentsWeb.Infrastructure.ViewModels.Dashboard;

public class ModuleWinLossRatioRequest
{
    [Required]
    public int AccountId { get; set; }
}