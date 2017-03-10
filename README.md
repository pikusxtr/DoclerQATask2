Software installed:<br>
-Visual Studio 2017 for C# development<br>
-Chrome browser<br>
Tests should be executed from Visual Studio 2017<br>
Download Chromedriver 2.27 and copy chromedriver.exe (after unzipping downloaded zip file) to C:\bins<br>
chromedriver can be found under:<br>
https://chromedriver.storage.googleapis.com/index.html?path=2.27/<br><br>
Install then following extensions in VS 2017(from Tools -> Extensions and Updates menu):<br>
-SpecFlow for Visual Studio 2017<br>
-NUnit 3 test adapter<br>
Clone the project DoclerQATask2 from github to your local drive folder<br>
Open DoclerQATask.sln in VS 2017<br>
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
Check tests results in Test Explorer window
