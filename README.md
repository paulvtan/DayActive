# DayActive
A SteelSeries Rival 700 mouse custom add-on code to display amount of time left in your day in percentage format.

## Table of Contents

## Introduction
Wouldn't it be nice to be able to keep track of your remaining productive time in a simpler format? DayActive takes advantage of SteelSeries Rival 700 side display, and represents the hours remaining in your day (24 hours period).

The purpose of this is to allow you to quantify the hours left in your day quickly by simply taking glance at the display. 

The application is written in C# under window service application project. After installation this add-on will run as a background process with mininal load.

<p>
<img src="img/1.jpg"  width="300"/>
<img src="img/2.jpg"  width="300"/>
</p>
<img src="img/DayActiveDemoGIF.gif"  width="600"/>


## Installation
Install using the command line Visual Studio Dev tool.
1. Navigate to the DayActive.Engine.App.exe location.
2. In VS Command line Dev tool type "installutil DayActive.Engine.App.exe"
3. Start the DayActive process in Service Manager.

OR

- Simply install using the installer in release section.

*For the app to run, SteelSeries Engine 3 is required.

## Features & Usages
**Version 1.0.0**
1. Automatically display time remaining out of 24 hours-local time in percentage.

**Version 1.1.0**
1. Added an setup wizard for a simple installation/uninstallation process.

**Version 2.0.0**
1. Auto recovery if exception is thrown. 
2. First launch intro animation added.

**Version 2.1.0**
1. Bug fix - after device restart delay program lauch to minimize POST request error.

## Contributing


## Credits
Paul Tanchareon

## License
MIT

