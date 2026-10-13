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

double loginPercentage = statistics.CalculateLoginPercentage(community);


Console.WriteLine($"Community: {community.Name}");
Console.WriteLine($"City: {community.Address.City}");
Console.WriteLine($"Units in the community: {community.Units.Count}");

Console.WriteLine();

Console.WriteLine($"Unit: {unit.Name}");
Console.WriteLine($"Owners in the unit: {unit.Owners.Count}");
Console.WriteLine($"Owner: {owner.Name}");
Console.WriteLine($"Email: {owner.Email}");
Console.WriteLine($"Last login: {owner.LastLoginDate}");

Console.WriteLine();

Console.WriteLine($"Owner: {secondOwner.Name}");
Console.WriteLine($"Email: {secondOwner.Email}");
Console.WriteLine("Last login: Never");

Console.WriteLine();

Console.WriteLine($"Unit: {secondUnit.Name}");
Console.WriteLine($"Owners in the unit: {secondUnit.Owners.Count}");
Console.WriteLine($"Owner: {thirdOwner.Name}");
Console.WriteLine($"Email: {thirdOwner.Email}");
Console.WriteLine($"Last login: {thirdOwner.LastLoginDate}");


Console.WriteLine($"Login percentage: {loginPercentage:F2}%");
