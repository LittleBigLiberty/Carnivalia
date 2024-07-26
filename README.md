# &#127758; Carnivalia

A second-generation custom server designed for LittleBigLiberty that focuses on ease of use and reliability. &#127758;&#127918;

[![Discord](https://img.shields.io/discord/1049223665243389953?label=Discord)](https://discord.gg/aaC32MWyst)


## &#128187; Running 

### &#128220; Legalities 
> [!WARNING]
> While Carnivalia is stable and mostly secure in our testing, we cannot make any guarantees about anything. You use Carnivalia at YOUR OWN RISK.
> Carnivalia is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
> See the [GNU Affero General Public License](https://github.com/LittleBigLiberty/Carnivalia/blob/main/LICENSE) for more details.

> [!NOTE]
> Carnivalia is free software: you can redistribute it and/or modify it under the terms of the [GNU Affero General Public License](https://github.com/LittleBigLiberty/Carnivalia/blob/main/LICENSE) as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

Anyway, with the legal disclaimers out of the way...

### &#128214; Instructions 

#### From Release 
1. [Find the latest release](https://github.com/LittleBigLiberty/Carnivalia/releases/latest) 
1. Download the artifact for your OS, extract it somewhere most convenient to you, and run it! 
1. Optionally, run through configuring `bunkum.json` and `CarnivaliaGameServer.json` to your liking. These files contain settings like instance name, announce text, whether or not registration is enabled, and more. 

To update, you can simply repeat this process, overwriting the previous files.

#### Using Docker (compose) 
1. [Find the latest release](https://github.com/LittleBigLiberty/Carnivalia/releases/latest) or checkout the source code 
1. Install Docker if not already installed 
1. Verify that the container works with your shell attached: `docker compose up` 
1. If Carnivalia starts successfully, start the docker container in the background: `docker compose up --detach` 

To update, you simply run a `git pull` to pull the latest changes,
and then run `docker compose up --build` to rebuild the image.

If you would like Carnivalia-web, head to [here](https://github.com/LittleBigLiberty/Carnivalia-web/actions) to view the latest artifacts, then grab them.
Once you've downloaded the artifact, browse to your data folder and create a folder called 'web' and extract the zip you've just downloaded to that folder.

## &#128293; It's on fire! What do I do? 
Carnivalia isn't perfect, so it's not exactly uncommon to run into bugs. If you'd like, you can [create an issue](https://github.com/LittleBigLiberty/Carnivalia/issues/new/choose) here on GitHub or join our [Discord](https://discord.gg/aaC32MWyst) for support. 

Wherever you choose to post, be sure to include details about how to trigger the bug, text logs (not screenshots!), your environment, the bug's symptoms, and anything else you might find relevant to the bug. 

When dealing with authentication problems, it can be particularly helpful to check your user's notifications (the bell on the web interface will take you there) as authentication errors are logged here. 

## &#128295; Building & Contributing 
To contribute to Carnivalia, it may be helpful to refer to our [contributing guide](CONTRIBUTING.md) to get a basic development environment set up. If you're a pro, feel free to skip this as it's just your bog-standard setting up C# guide. 

However, something important for all those involved: we also serve additional documentation relating to Carnivalia, Bunkum, and LittleBigPlanet in general in our [Docs repo](https://LittleBigLiberty.github.io/Docs/).

*Made with &#128153; for the LittleBigPlanet community*
*Forked with &#128153; from Refresh*


