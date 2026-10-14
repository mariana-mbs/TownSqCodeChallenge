namespace TownSqCodeChallenge;

public class CommunityStatistics
{
    public LoginStatistics GetLoginStatistics(Community community)
    {
        ArgumentNullException.ThrowIfNull(community);

        HashSet<Owner> countedOwners = new HashSet<Owner>();
        int loggedInOwners = 0;
        int totalOwnerships = 0;

        foreach (Unit unit in community.Units)
        {
            foreach (Owner owner in unit.Owners)
            {
                totalOwnerships++;

                bool isNewOwner = countedOwners.Add(owner);

                if (isNewOwner && owner.LastLoginDate != null)
                {
                    loggedInOwners++;
                }
            }
        }

        return new LoginStatistics(countedOwners.Count,  loggedInOwners, totalOwnerships);
    }

    public double CalculateLoginPercentage(Community community)
    {
        return GetLoginStatistics(community).Percentage;
    }

}