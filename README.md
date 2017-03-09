Tests should be executed from Visual Studio 2017
Download Chromedriver 2.27 and copy chromedriver.exe to C:\bins
Install then following extensions:
-SpecFlow for Visual Studio 2017
-NUnit 3 test adapter
Open DoclerQATask.sln with VS 2017
Under solution, right click on DoclerQATask project, 
select Manage NuGet Packages...
Install all packages displayed in Updates tab

From main menu select Build -> Build Solution
From Solution Explorer select DoclerQaSiteNavigation.feature file, right click,
Select Run SpecFlow Scenarios from context menu.