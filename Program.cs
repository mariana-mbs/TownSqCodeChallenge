Owner owner = new Owner();

owner.Name = "Tony Stark";
owner.Email = "tony.stark@example.com";
owner.LastLoginDate = new DateTime(2026, 10, 9);

Owner secondOwner = new Owner();

secondOwner.Name = "Pepper Potts";
secondOwner.Email = "pepper.potts@example.com";
secondOwner.LastLoginDate = null;

Unit unit = new Unit();

unit.Name = "101";
unit.Owners.Add(owner);
unit.Owners.Add(secondOwner);

Community community = new Community();

community.Name = "Stark Tower";

community.Address.Street = "Fifth Avenue";
community.Address.Number = "100";
community.Address.City = "New York";

community.Units.Add(unit);

Console.WriteLine($"Owner: {owner.Name}");
Console.WriteLine($"Email: {owner.Email}");
Console.WriteLine($"Last login: {owner.LastLoginDate}");

Console.WriteLine($"Unit: {unit.Name}");
Console.WriteLine($"Owners in the unit: {unit.Owners.Count}");

Console.WriteLine($"Community: {community.Name}");
Console.WriteLine($"City: {community.Address.City}");
Console.WriteLine($"Units in the community: {community.Units.Count}");