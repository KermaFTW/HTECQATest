# Structure

Solution has two projects. 

First one includes code for opening browser and using Selenium framework code.

Second project only has tests. Test are written in The Visual Studio Unit Testing Framework. 
It has reference to first project.

## Running the tests and writing report

One way of running the test is from Visual Studio and Checking Test Explorer

Other is from command console:

You need to use VSTest.console.exe located at (my computer): C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\CommonExtensions\Microsoft\TestWindow

and use command: vstest.console.exe {Project path}\SandboxTests\bin\Debug\netcoreapp2.2\SandboxTests.dll /logger:trx /settings:"{Project path}\SandboxTests\HTEC.runsettings

Tests will be run and results will be saved in {Project path}\SandboxTests\TestResults - folder 

## Enviroment settings

Enviroment settings are set in .runsetting file (HTEC.runsettings).

 <Parameter name="baseUrl" value="" /> - URL of application 
 <Parameter name="email" value="" /> - Email address of existing user
 <Parameter name="password" value="" /> - Password for that user account


