Game Logger\
Joseph Dillon Parker\
Due: 5/6/2018


## Abstract

This project’s main goal was to create an Windows application to log peoples game collection. There are four main task that are needed to achieve this goal. The first task would be having a GUI to hold a list of games that the user will add. The GUI will have a listview to hold all the names of the games that the user will add. The second task would be to have buttons for the users to add and remove games form the listview and the xml file that holds the information. The menus for adding and removing games will appear in another window. When adding games, the user will have to enter the name of the game and select a status form the combo box. The remove games will just require the name of the game. The third task would be having a xml file that holds tags like name of game, release date, developers, publishers, platforms, genres, status, description, and images. The xml file will help with displaying the information of the game that the user clicks on within the listview. The fourth task would be able to recommend games based on the game that you are viewing. A window will pop up with a TableLayoutPanel that holds four games. The one task that was out of this projects scope was being able to accomplish would to be able to play the game using my application. All the main tasks were completed, but the visuals of the project are not great.  The methods that was used to complete this project was Visual Studio 2017 for development, the language was C#, and the database was Giant Bomb. 
Keywords: 
	Windows, GUI, listview, xml, Visual Studio 2017, C#, Giant Bomb, TableLayoutPanel, combo box
	
	

## Introduction and Project Overview
This project will address the problem of being able to organize game collections and allows users to customize the collection within a desktop application in a windows environment. This project will allow users to add PC games and consoles games. Many users would like the ability to look at their collection and gain more information about the games or get recommendations for the game to further expand their gaming repertoire. The customers of Game Logger would be mainly focused on gamers that want to keep a collection of their games on their computers and possibly learn about different games based on the kinds of games they play. An issue would be the lack of knowledge of Visual Studio 2017 and C#. This was solved my researching those topics and messing up and learning from those mistakes. Another issue that affect this project would be trying to make it stand out from other solutions but also capturing the great features that the other solutions offer. 
Some of the other alternative solutions are LaunchBox and EmulationStation.  LaunchBox is what this project looked at for inspiration and what it sought to improve upon. The major strengths that both LaunchBox and EmulationStation has are the visual aspects for GUI and the ability to play the games that you add to your collection. They also have different options for different kinds of views and ways to display your game collection. The main weakness that both LaunchBox and EmulationStation have is the lack of a menu that recommends games based on the game that the users has stored in their application. 
This project tried to capitalize on the lack of the ability to recommend games and view different kinds of information. It could not compete with the visuals and the ability to customize the users game collection to their preferences. The main reason users would try Game logger would be to see different kinds of information and seeing other games that match that user’s preferences. It could also be appealing to someone that just wants a very minimalist view.  Another source of value would be the size of the program is relatively smaller than the other solutions, so it would be great for someone that needs to conserve space on their hard drive. 
Some of the problems that existed in this project that did not get addressed is the visual appeal and the lack of support to be able to play the games in the application.  The reasoning that these problems did not get addressed would be that they were very time consuming and did not seem very important for a bare bones project to store user’s collections. The visual appeals can be approved on later. Playing the games would just take a lot of time to tie into Game logger and would require the users to download additional programs. Problems that did get address would include the ability to add/remove games, listing the games in the main window, providing more information on the games, and recommending games.  
Adding games will happen when the user clicks File->Add Games and a menu will appear for that user to enter a games name and select a status for the game. Removing games will happen when the user clicks File->Remove Games and will just require the name of the game. Both adding and removing games will edit a xml file that will contain all the information for that game. When adding or removing games form the listview the user will need to click File->Refresh GameList to change the contents of the listview. The information of the game will appear when the user clicks on the game within the listview. It will make a window appear with the all the information that is in the xml file, this window is called the game view. This window will also allow the user to change the status of the game to something else using another menu. All the user needs to do to change the status is click on the status. The game view window will also hold the recommend games button to allow the user to see four other games that are similar to that game. Recommend games window will be a table that will hold three columns. The columns are the name of the game, game cover image, and a description of the game.\

## Design, Development, and Test 
### Design 
The design of the projects can be organized by breaking it into two parts, the database connection and the Windows application. The windows application is composed of many forms, windows, tables, and views. The database is a api form Giant Bomb which allows the application to go and fetch the xml tags that the windows application needs to display the information for the user to see.\
The Giant bomb was easy to install enough to install, all that is needed to type this command in the package manager console “Install-Package GiantBomb.Api”.() The GiantBomb-CSharp github page has the instructions on how to connect to the api. The Giant Bomb documentation of the api will give further information on how to accuses specific fields. () Here is an example of using the api to locate Fallout 4.\
“var client = new GiantBombRestClient("your-api-key");
var result = client.SearchForGames(“Fallout 4”).ToList();
var Game = client.GetGame(result.First().Id);”\
After getting the “Game” variable it can be used to acquire the tags of the xml file. The Giant Bomb api is used anywhere that the application would need to find a game or information about the game like for example searching for the games and after finding the game it would then be used to get the information that is necessary. It is also used to recommend games based on the “Game” variable.\ 
The windows application side of had six forms that adds, removes, edit the status, recommending games. It also includes making an image larger when the user clicks on the image. The application has one MainWindow.xaml, which is the main window that the user will be interacting with, because of the file drop down menu has access to the other forms. 
(ImageDropDown)
### Development 
Started with building the basic main window and designing the basic structed of the file drop down menu. After developing the main window, the process of adding and removing games could start. Created the add games form first and then started on the remove games form. Adding games had the risk areas of xml file editing and connecting to the Giant Bomb api. Both of those are needed for the rest of the application to function. The xml file included: (imageXML). When editing and looking at the xml the application needs XmlDocument and XmlNodeList. The XmlDocument is needed to load the xml file so that it can be edited. XmlNodeList is needed to loop though the xml file tags, this is used to create and look at information of the xml file. After completing the adding and removing games forms, the games need a container to hold the name of the games on the main window. The container is a listview because it was very easy to just add the name of the game to it. Another reason to use listview would be that it can add items dynamically. The next step after that would be making it where a form pops up with the user clicks on a list view cell. (imageGameView) The form is the GameView form and it displays the xml tags and the four images. After this form was developed a button was added to recommend games to user base on that game. The recommend games form has a TableLayoutPanel that stores four games as rows with three tags as columens. The tags are then name, image of game cover, and a short description of the game. One the risk areas of this part would have to be if the game does not have four games that are similar to that game. This problem was fixed by adding “Missing Game” to the name and description. The image field has a question mark instead of just being blank.  
### Testing 
The main things that was tested was operations that grabbed information form the Giant Bomb api and methods that added to the xml. There are three methods that check the xml files and the other four test methods test grabbing developers, genre, platforms, and publishers. The reasoning those need to be test is that all those fields are list and the application turns them into a string with a “ ,” in-between each object. So those the test method that look at the developers and others just compare to the xml files and the methods that go and get the information using Assert.AreEqual(). Checking if the xml files are created the correct way you need to use the test files that are on this GitHub folder. It checks the xml file by adding two different games to another xml file and having a xml file that looks like it should. Doing this was a trouble area but was easily solved by just comparing the hashes of the files.\

## Results 
<table> 
	<tr> 
		<td>Planned to implement</td>
		<td>Actual Results</td>
	</tr>
		<tr> 
		<td>Add Games</td>
		<td>Did Implement</td>
	</tr>
		<tr> 
		<td>Remove Games</td>
		<td>Did Implement</td>
	</tr>
		<tr> 
		<td>Planned to implement</td>
		<td>Did Implement</td>
	</tr>
		<tr> 
		<td>Game View</td>
		<td>Did Implement</td>
	</tr>
		<tr> 
		<td>Recommending Games</td>
		<td>Did Implement</td>
	</tr>
		<tr> 
		<td>Having a Categories</td>
		<td>Did Implement</td>
	</tr>
		<tr> 
		<td>Sorting by Categories</td>
		<td>Didn’t Implement</td>
	</tr>
		<tr> 
		<td>ESRB Ratings</td>
		<td>Didn’t Implement</td>
	</tr>
		<tr> 
		<td>Playing the games</td>
		<td>Didn’t Implement</td>
	</tr>
	<tr> 
		<td>List view cell has both game cover and name</td>
		<td>Didn’t Implement</td>
	</tr>
</table>
	
Most of the planned features did make it in to the final product, but of course it is missing some of the features that would improve the overall quality of the application. Adding and remove games was a simple process of just editing the xml with XmlDocument and XmlNodeList. The game view is when the user clicks on a cell in the listview that has a game and it will pop-up with information on the game corresponding to the tags in the xml file. Recommending the games took a little longer because entercoutering a lot of bugs with the images. The application would be saying that the images were already downloaded, so the solution was to check before downloading the images. Another problem was the file names was the same for some of the images, just had to change some of them to different names.  One of the problems that was encountered and took a very long time to fix would be the listview refreshing. Adding and removing games form the listview would not result in it being removed from the listview but only to the xml file. The solution to this problem was to use ItemsSource of the listview and databind an array to the listview. After doing this it would not work, but after adding to the drop-down menu of the application a button that would refresh the listview it worked. The problem was more in likely to do with methods and the listview being in different threads. ESRB ratings was troubling because the giantbomb api would sometimes not have them or it would be in PEGI which is the Europe game rating system. Did not want to use this because of the inconsistency and not having the correct ESRB rating. Playing the games in the application did not get impletment because it would have taken a long time to tie in support. Having the user know the file path of the emulator and then having to keep that information would have added more work onto a busy schedule. Also, the most popular emulator, RetroArch, would be very difficult because it would also require the user to know the core that he/she wants to run. 		
