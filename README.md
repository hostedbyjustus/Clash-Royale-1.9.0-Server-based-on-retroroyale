# Clash Royale 1.9.0 - 1.9.3 (2017)
[![clash royale](https://img.shields.io/badge/Clash%20Royale-1.9.2-brightred.svg?style=flat")](https://clash-royale.en.uptodown.com/android/download/1632865)
[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
![Build Status](https://action-badges.now.sh/retroroyale/ClashRoyale)

#### A .NET Core Clash Royale Server (v1.9.x)
##### Need help? Join our [Discord](https://discord.gg/8cHkNE6)

## Battles
The server supports battles, for those a patched client is neccessary.

[See the wiki for a tutorial](https://github.com/retroroyale/ClashRoyale/wiki/Patch-for-battles)

## How to start

#### Requirements:
  - [.NET Core SDK 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
  - MySql Database (on Debian i suggest LAMP with PhpMyAdmin)

for Ubuntu use these commands to set it up:

###### Main Server:
```
mkdir ClashRoyale
git clone https://github.com/retroroyale/ClashRoyale.git && cd ClashRoyale/src/ClashRoyale

dotnet publish "ClashRoyale.csproj" -c Release -o app
```
###### Battle Server:
```
mkdir ClashRoyaleBattles
git clone https://github.com/retroroyale/ClashRoyale.git ClashRoyaleBattles && cd ClashRoyaleBattles/src/ClashRoyale.Battles

dotnet publish "ClashRoyale.Battles.csproj" -c Release -o app
```
To configurate your server, such as the database you have to edit the ```config.json``` file.

#### Run the server:

###### Main Server:
```dotnet app/ClashRoyale.dll```

###### Battle Server:
```dotnet app/ClashRoyale.Battles.dll```

#### Update the server:
###### Main Server:
```git pull && dotnet publish "ClashRoyale.csproj" -c Release -o app && dotnet app/ClashRoyale.dll```

###### Battle Server:
```git pull && dotnet publish "ClashRoyale.Battles.csproj" -c Release -o app && dotnet app/ClashRoyale.Battles.dll```

## Need help?
Contact me on Discord (@justus61), join our server or open an issue.
