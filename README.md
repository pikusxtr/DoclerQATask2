Tests should be executed from Visual Studio 2017<br>
Download Chromedriver 2.27 and copy chromedriver.exe to C:\bins<br>
chromedriver location for download:<br>
https://chromedriver.storage.googleapis.com/index.html?path=2.27/<br>
Install then following extensions:<br>
-SpecFlow for Visual Studio 2017<br>
-NUnit 3 test adapter<br>
Open DoclerQATask.sln with VS 2017<br>
Under solution, right click on DoclerQATask project,<br> 
select Manage NuGet Packages...<br>
Install all packages displayed in Updates tab, especially:<br>
-SpecFlow.NUnit<br>
-SpecFlow<br>
-NUnit<br>
<br>
From main menu select Build -> Build Solution<br>
From main menu select Test -> Run -> All Tests<br>
Test Explorer window will open, wait until all tests are executed<br>
From Solution Explorer select DoclerQaSiteNavigation.feature file, right click,<br>
Select Run SpecFlow Scenarios from context menu.<br>
