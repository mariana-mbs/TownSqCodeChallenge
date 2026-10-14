namespace TownSqCodeChallenge.Tests;

public class CommunityStatisticsTests
{
    [Fact]
    public void CalculateLoginPercentage_Returns50_WhenOneOfTwoOwnersHasLoggedIn()
    {
        Community community = new Community();

        Unit unit = new Unit();
        community.Units.Add(unit);

        Owner owner = new Owner();

        owner.LastLoginDate = new DateTime(2026, 10, 9);
        unit.Owners.Add(owner);

        Owner secondOwner = new Owner();
        secondOwner.LastLoginDate = null;
        unit.Owners.Add(secondOwner);

        CommunityStatistics statistics = new CommunityStatistics();

        double result = statistics.CalculateLoginPercentage(community);

        Assert.Equal(50.0, result);

    }

    [Fact]
    public void CalculateLoginPercentage_Returns0_WhenCommunityHasNoUnits()
    {
        Community community = new Community();

        CommunityStatistics statistics = new CommunityStatistics();

        double result = statistics.CalculateLoginPercentage(community);

        Assert.Equal(0.0, result);
    }

    [Fact]
    public void CalculateLoginPercentage_ReturnsTwoThirds_WhenTwoOfThreeOwnersHaveLoggedInAcrossUnits()
    {
        Community community = new Community();

        Unit firstUnit = new Unit();
        community.Units.Add(firstUnit);

        Owner firstOwner = new Owner();
        firstOwner.LastLoginDate = new DateTime(2026, 10, 9);
        firstUnit.Owners.Add(firstOwner);

        Owner secondOwner = new Owner();
        secondOwner.LastLoginDate = null;
        firstUnit.Owners.Add(secondOwner);

        Unit secondUnit = new Unit();
        community.Units.Add(secondUnit);

        Owner thirdOwner = new Owner();
        thirdOwner.LastLoginDate = new DateTime(2026, 10, 10);
        secondUnit.Owners.Add(thirdOwner);

        CommunityStatistics statistics = new CommunityStatistics();

        double result = statistics.CalculateLoginPercentage(community);

        Assert.Equal(66.66666666666667, result, 10);

    }

    [Fact]
    public void CalculateLoginPercentage_Returns0_WhenNoOwnersHaveLoggedIn()
    {
        Community community = new Community();

        Unit unit = new Unit();
        community.Units.Add(unit);

        Owner firstowner = new Owner();
        firstowner.LastLoginDate = null;
        unit.Owners.Add(firstowner);

        Owner secondOwner = new Owner();
        secondOwner.LastLoginDate = null;
        unit.Owners.Add(secondOwner);

        CommunityStatistics statistics = new CommunityStatistics();

        double result = statistics.CalculateLoginPercentage(community);

        Assert.Equal(0.0, result);
    }

    [Fact]

    public void CalculateLoginPercentage_Returns100_WhenAllOwnersHaveLoggedIn()
    {
        Community community = new Community();

        Unit unit = new Unit();
        community.Units.Add(unit);

        Owner firstOwner = new Owner();
        firstOwner.LastLoginDate = new DateTime(2026, 10, 9);
        unit.Owners.Add(firstOwner);

        Owner secondOwner = new Owner();
        secondOwner.LastLoginDate = new DateTime(2026, 10, 10);
        unit.Owners.Add(secondOwner);

        CommunityStatistics statistics = new CommunityStatistics();

        double result = statistics.CalculateLoginPercentage(community);

        Assert.Equal(100.00, result);

    }

    [Fact]
    public void CalculateLoginPercentage_Returns0_WhenUnitHasNoOwners()
    {
        Community community = new Community();

        Unit unit = new Unit();
        community.Units.Add(unit);

        CommunityStatistics statistics = new CommunityStatistics();

        double result = statistics.CalculateLoginPercentage(community);

        Assert.Equal(0.00, result);

    }

    [Fact]
    public void CalculateLoginPercentage_CountsOwnerOnce_WhenOwnerHasTwoUnits()
    {
        Community community = new Community();

        Unit firstUnit = new Unit();
        Unit secondUnit = new Unit();
        community.Units.Add(firstUnit);
        community.Units.Add(secondUnit);

        Owner ownerWithTwoUnits = new Owner();
        ownerWithTwoUnits.LastLoginDate = new DateTime(2026, 10, 9);
        firstUnit.Owners.Add(ownerWithTwoUnits);
        secondUnit.Owners.Add(ownerWithTwoUnits);

        Owner otherOwner = new Owner();
        otherOwner.LastLoginDate = null;
        secondUnit.Owners.Add(otherOwner);

        CommunityStatistics statistics = new CommunityStatistics();

        double result = statistics.CalculateLoginPercentage(community);

        Assert.Equal(50.0, result);
    }

    [Fact]
    public void GetLoginStatistics_ReturnsDistinctOwnersAndOwnerships_WhenOwnerHasTwoUnits()
    {
        Community community = new Community();

        Unit firstUnit = new Unit();
        Unit secondUnit = new Unit();
        community.Units.Add(firstUnit);
        community.Units.Add(secondUnit);

        Owner ownerWithTwoUnits = new Owner();
        ownerWithTwoUnits.LastLoginDate = new DateTime(2026, 10, 9);
        firstUnit.Owners.Add(ownerWithTwoUnits);
        secondUnit.Owners.Add(ownerWithTwoUnits);

        Owner otherOwner = new Owner();
        otherOwner.LastLoginDate = null;
        secondUnit.Owners.Add(otherOwner);

        CommunityStatistics statistics = new CommunityStatistics();

        LoginStatistics result = statistics.GetLoginStatistics(community);

        Assert.Equal(2, result.TotalOwners);
        Assert.Equal(3, result.TotalOwnerships);
        Assert.Equal(1, result.LoggedInOwners);
        
    }
} 