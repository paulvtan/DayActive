# DayActive
A SteelSeries Rival 700 mouse custom add-on code to display amount of time left in your day in percentage format.

## Table of Contents

## Introduction
Wouldn't it be nice to be able to keep track of your remaining productive time in a simpler format? DayActive takes advantage of SteelSeries Rival 700 side display, and represents the hours remaining in your day (24 hours period).

The purpose of this is to allow you to quantify the hours left in your day quickly by simply taking glance at the display. 

The application is written in C# under window service application project. After installation this add-on will run as a background process with mininal load.

## Installation
Install using the command line Visual Studio Dev tool.
1. Navigate to the DayActive.Engine.App.exe location.
2. In VS Command line Dev tool type "installutil DayActive.Engine.App.exe"
3. Start the DayActive process in Service Manager.

## Features & Usages
**Version 1.0.0**
1. Automatically display time remaining out of 24 hours-local time in percentage.

**Version 1.1.0**
1. Added an set up wizard for a simple installation/uninstallation process.

## Contributing


## Credits
Paul Tanchareon

## License
MIT

