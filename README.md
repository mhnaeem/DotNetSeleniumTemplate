# DotNetSeleniumTemplate

A simple opinionated project template written in C# using .NET to quickly start writing tests using Selenium.

## Features

1. Zero setup, mostly plug and play
2. Cross platform support for both Mac OS and Windows
3. Written with [Selenium 4](https://www.selenium.dev/) and [.NET 7](https://dotnet.microsoft.com/en-us/download)
4. Integrates [ExtentReports](https://www.extentreports.com/) for custom reporting
5. Utilises [NUnit](https://nunit.org/) to run tests and integrate with Visual Studio
6. Provides helper classes and utilities to make writing tests super simple

## Steps for Setup

1. Download [Visual Studio](https://visualstudio.microsoft.com/downloads/) - any version >10.x should work
2. [Fork](https://docs.github.com/en/get-started/quickstart/fork-a-repo) and then [Clone](https://docs.github.com/en/repositories/creating-and-managing-repositories/cloning-a-repository) this repo to your computer
3. Open the `DotNetSeleniumTemplate.sln` solution file in Visual Studio
4. AND that's it!

## Steps to Run Tests

1. Open the `DotNetSeleniumTemplate.sln` solution file in Visual Studio
2. Open the [Test Explorer](https://learn.microsoft.com/en-us/visualstudio/test/run-unit-tests-with-test-explorer) in Visual Studio
3. Double click the test name you want to run - [more info](https://learn.microsoft.com/en-us/visualstudio/test/run-unit-tests-with-test-explorer)

## Extra Info

Currently only the `envsettings.json` is copied to the output directory, so modify it to change settings
