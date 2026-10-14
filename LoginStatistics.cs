namespace TownSqCodeChallenge;

public record LoginStatistics(int TotalOwners, int LoggedInOwners, int TotalOwnerships)
{
    public double Percentage
    {
        get
        {
            if (TotalOwners == 0)
            {
                return 0;
            }

            return (double)LoggedInOwners / TotalOwners * 100;
        }
    }
}