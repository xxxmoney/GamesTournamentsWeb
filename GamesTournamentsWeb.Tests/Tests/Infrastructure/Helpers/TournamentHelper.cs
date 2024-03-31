namespace GamesTournamentsWeb.Tests.Tests.Infrastructure.Helpers;

public class TournamentHelper
{
    [Test]
    [TestCase(2, 3)]
    [TestCase(3, 5)]
    [TestCase(4, 7)]
    [TestCase(5, 9)]
    public void CalculateTotalMatchesCount_Test(int initialMatchesCount, int expectedTotalMatchesCount)
    {
        // Arrange
        
        // Act
        var result = GamesTournamentsWeb.Infrastructure.Helpers.TournamentHelper.CalculateTotalMatchesCount(initialMatchesCount);
        
        // Assert
        Assert.That(result, Is.EqualTo(expectedTotalMatchesCount));
    }
}