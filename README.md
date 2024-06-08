# Dota2RTD
> Just a small script using the Dota2GSI library

Uses the Gamestate integration library to pull real time match data and present it in a CLI.
I will eventually convert this into a GUI program, but its just a tiny script i wrote to learn a little about C#
and so i can get crucial data i dont get to usually see in real time during a match.

## Dependencies
1. Make sure you have Visual Studio installed with .NET desktop development workload and .Net 8.0 Runtime individual component.
2. You need the Dota2GSI C# integration written by antonpup. Link is [Here](https://github.com/antonpup/Dota2GSI?tab=readme-ov-file#implemented-game-events).
  1. You can install it using [nuget](https://www.nuget.org/packages/Dota2GSI), or the following command: `dotnet add package Dota2GSI --version 2.1.1.8897` in your .NET cli.

Documentation for the library is available on antonpups [github](https://github.com/antonpup/Dota2GSI?tab=readme-ov-file)
