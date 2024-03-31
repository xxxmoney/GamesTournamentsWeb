namespace GamesTournamentsWeb.Infrastructure.Helpers;

public static class TournamentHelper
{
    /// <summary>
    /// Calculates the total number of matches in a tournament brackets based on number of initial matches
    /// </summary>
    /// <param name="initialMatchesCount"></param>
    /// <returns></returns>
    public static int CalculateTotalMatchesCount(int initialMatchesCount)
    {
        var totalMatches = 0;
        var matchesInRound = initialMatchesCount;

        // Calculate the total number of matches by summing up the matches in each round
        while (matchesInRound > 0)
        {
            totalMatches += matchesInRound;
            // Next round has half the matches
            matchesInRound = (int)Math.Floor((double)matchesInRound / 2);
        }
    
        // Add 1 if the initial matches count is odd
        if (initialMatchesCount % 2 != 0)
        {
            totalMatches++;
        }

        return totalMatches;
    }
}