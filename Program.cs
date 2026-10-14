Community community = new Community();

community.Name = "Stark Tower";

community.Address.Street = "Fifth Avenue";
community.Address.Number = "100";
community.Address.City = "New York";

Unit unit = new Unit();

unit.Name = "101";
community.Units.Add(unit);

Unit secondUnit = new Unit();

secondUnit.Name = "102";
community.Units.Add(secondUnit);

Owner owner = new Owner();

owner.Name = "Tony Stark";
owner.Email = "tony.stark@example.com";
owner.LastLoginDate = new DateTime(2026, 10, 9);

unit.Owners.Add(owner);

Owner secondOwner = new Owner();

secondOwner.Name = "Pepper Potts";
secondOwner.Email = "pepper.potts@example.com";
secondOwner.LastLoginDate = null;

unit.Owners.Add(secondOwner);

Owner thirdOwner = new Owner();

thirdOwner.Name = "Bruce Banner";
thirdOwner.Email = "bruce.banner@example.com";
thirdOwner.LastLoginDate = new DateTime(2026, 10, 10);

secondUnit.Owners.Add(thirdOwner);

CommunityStatistics statistics = new CommunityStatistics();

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("=== STARK TOWER ===");
    Console.WriteLine("1 - View community");
    Console.WriteLine("2 - View owners");
    Console.WriteLine("3 - View statistics");
    Console.WriteLine("0 - Exit");
    Console.WriteLine();
    Console.Write("Choose an option: ");

    string option = Console.ReadLine() ?? string.Empty;

    Console.WriteLine();

    switch (option)
    {
        case "1":
            Console.WriteLine($"Community: {community.Name}");
            Console.WriteLine($"Address: {community.Address.Number} {community.Address.Street}, {community.Address.City}");
            Console.WriteLine($"Units: {community.Units.Count}");
            break;

        case "2":
            foreach (Unit currentUnit in community.Units)
            {
                Console.WriteLine();
                Console.WriteLine($"Unit: {currentUnit.Name}");
                Console.WriteLine($"Owners: {currentUnit.Owners.Count}");

                foreach (Owner currentOwner in currentUnit.Owners)
                {
                    Console.WriteLine($"Name: {currentOwner.Name}");
                    Console.WriteLine($"Email: {currentOwner.Email}");

                    if (currentOwner.LastLoginDate != null)
                    {
                        Console.WriteLine($"Last login: {currentOwner.LastLoginDate:yyy-MM-dd}");
                    }
                    else
                    {
                        Console.WriteLine("Last login: Never");
                    }

                    Console.WriteLine();

                }
            }

            break;

        case "3":
            {

            double percentage = statistics.CalculateLoginPercentage(community);

            Console.WriteLine($"Total owners: {statistics.TotalOwners}");
            Console.WriteLine($"Owners who have logged in: {statistics.LoggerdInOwners}");
            Console.WriteLine($"Login percentage: {percentage:F2}%");

            break;

            }

        case "0":
            running = false;
            Console.WriteLine("Goodbye!");
            break;

        default:
            Console.WriteLine("Invalid option. Please choose 1, 2, 3, or 0.");
            break;
    }
}

