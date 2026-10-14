public class CommunityStatistics
{
    public int TotalOwners { get; private set; }
    public int LoggerdInOwners { get; private set; }
    public double CalculateLoginPercentage(Community community)
    {
        
        int totalOwners = 0;
        int loggedInOwners = 0;

        foreach (Unit unit in community.Units)
        {
            foreach (Owner owner in unit.Owners)
            {
                totalOwners++;

                if (owner.LastLoginDate != null)
                {
                    loggedInOwners++;
                }
            }
        }

        TotalOwners = totalOwners;
        LoggerdInOwners = loggedInOwners;

        if (totalOwners == 0)
        {
            return 0;
        }

        double loginPercentage = (double)loggedInOwners / totalOwners * 100;

        return loginPercentage;
    }

}