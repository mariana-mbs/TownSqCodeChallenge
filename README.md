# TownSq Code Challenge

C# console application that calculates the percentage of registered owners who have logged into a condominium system.

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Run the application

From the project root:

```bash
dotnet run
```

Menu options:

- `1`: View community details.
- `2`: View owners grouped by unit.
- `3`: View login statistics.
- `0`: Exit.

## Run the tests

From the project root:

```bash
dotnet test TownSqCodeChallenge.Tests/TownSqCodeChallenge.Tests.csproj
```

The project includes automated tests covering partial login,
no login, all owners logged in, empty communities, units without
owners, multiple units, and owners associated with multiple units.

## Main method

```csharp
public double CalculateLoginPercentage(Community community)
```

Usage:

```csharp
double percentage = new CommunityStatistics().CalculateLoginPercentage(community);
```

This method returns the login percentage by calling
`GetLoginStatistics`, which centralizes the owner counting logic.

`GetLoginStatistics` returns a `LoginStatistics` object with all results
together (total owners, owners who have logged in, unit ownerships and
percentage), so all values always come from the same calculation.

The percentage is calculated as:

```text
Owners who have logged in / Total distinct owners × 100
```

## Rules and assumptions

- An owner has logged in if `LastLoginDate` is not null.
- The calculation measures whether an owner has ever logged in,
  not whether they are currently online.
- The percentage goes from 0 to 100 (e.g. `50.0` means 50%).
- When there are no owners, the percentage is zero instead of an error.
- A null community causes an `ArgumentNullException`.
- Units and owners are expected to be valid objects with initialized lists.
- Owners are deduplicated by object reference using `HashSet<Owner>`.
  The same Owner object associated with multiple units is counted once.
  Separate Owner objects with the same email are counted separately.
  Email was not used as an identifier because it may be empty or shared
  between people.
- Total ownerships counts owner entries across all units.
- The method returns the full, unrounded value. The console rounds it
  to two decimal places only for display.

## Sample data

The application uses fictional data already loaded in memory.
It does not implement registration, authentication, or a database.

Stark Tower contains two units:

- Unit 101: Tony Stark and Pepper Potts.
- Unit 102: Bruce Banner and the same Pepper Potts object.

Tony and Bruce have a last login date. Pepper does not.

Expected statistics:

```text
Total owners: 3
Unit ownerships: 4
Owners who have logged in: 2
Login percentage: 66.67%
```

The decimal separator follows the computer's culture settings.

## Project organization

| File | Purpose |
|---|---|
| `Community.cs`, `Unit.cs`, `Owner.cs`, `Address.cs` | Domain data described in the challenge |
| `CommunityStatistics.cs` | Counting and statistics calculation |
| `LoginStatistics.cs` | Immutable statistics result with a calculated percentage |
| `Program.cs` | Sample data and console menu |
| `TownSqCodeChallenge.Tests/` | Automated tests using xUnit |

The test project is inside the main project folder, so the main `.csproj`
excludes it from compilation with
`<Compile Remove="TownSqCodeChallenge.Tests/**/*.cs" />`.