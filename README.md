# Part2Tests

  Selenium UI automation Tests
  
  Creation of .Net Unit Test Project using c# as the language for automating a sample hotel booking form using chrome browser

## Components:
  
  Test Class : Consists of Test Initialize, Test Method and Test Cleanup methods for the Create, Verify and Delete Booking Scenario.
  
  Page Object factory: Reservation Page class is created for Web Element Locators and page methods.

## Unit Testing Framework: 
  
  MSTest Framework
  
## Execution Instructions

Open the solution file (.sln) using Visual Studio editor to build and execute the test methods via test explorer
https://visualstudio.microsoft.com/

Alternatively use MSBuild and MsTest to execute the solution via command line

MSBuild.exe **MYPROJ**.sln /p:outdir="Z:\output\\",OutputPath="Z:\output\\",webprojectoutputdir="Z:\output\\",configuration=DEBUG  /t:Clean;Build 

MSTest /testcontainer:\**MYPROJ**.sln\Tests\Debug\proj.dll


## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.


