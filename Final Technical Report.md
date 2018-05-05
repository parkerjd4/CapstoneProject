# Game Logger
# Joseph Dillon Parker
# Due: 5/6/2018 

### Table of Contents 
1. [Abstract](#abstract)
2. [Introduction and Project Overview](#introduction-and-project-overview)
3. [Design Development and Test](#design-development-and-test)
   * [Design](#design) 
   * [Development](#development)
   * [Testing](#testing)
4. [Results](#results)
5. [Conclusions and Future Work](#conclusions-and-future-work)
6. [References](#references)
# Abstract

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; This project’s main goal was to create an Windows application to log peoples game collection. There are four main task that are needed in order to achieve this goal. The first task would be having a GUI to hold a list of games that the user will add. The GUI will have a listview to hold all the names of the games that the user will add. The second task would be to have buttons for the users to add and remove games from the listview and the XML file that holds the information. An XML stands for eXtensible Markup Languages and is used to store data. The menus for adding and removing games will appear in another window. When adding games, the user will have to enter the name of the game and select a status form the combo box. The remove games will just require the name of the game.\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; The third task would be having a XML file that holds tags like name of game, release date, developers, publishers, platforms, genres, status, description, and images. The XML file will help with displaying the information of the game that the user clicks on within the listview. The fourth task would be able to recommend games based on the game that you are viewing. A window will pop up with a TableLayoutPanel that holds four games. [3] The one task that was out of this projects scope is to be able to launch the game using my application. All the main tasks were completed, but the visuals of the project are not great.  The methods that was used to complete this project was Visual Studio 2017 for development, the language was C#, and the database was Giant Bombs api. 
Keywords: 
	Windows, GUI, listview, XML, Visual Studio 2017, C#, Giant Bomb, TableLayoutPanel, combo box, api

	

# Introduction and Project Overview
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; This project will address the problem of being able to organize game collections and allows users to customize the collection within a desktop application in a windows environment. This project will allow users to add PC games as well as consoles games. Many users would like the ability to look at their collection as a whole and gain more information about the games or get recommendations for the game to further expand their gaming repertoire. The customers of Game Logger would be mainly focused on gamers that want to keep a collection of their games on their computers and possibly learn about different games based on the kinds of games they play. An issue would be the lack of knowledge of Visual Studio 2017, C#, and Giant Bombs api. [2] This was solved researching those topics and messing up and learning from those mistakes. Another issue that affected this project would be trying to make it stand out from other solutions but also capturing the great features that the other solutions offer. 
Some of the other alternative solutions are LaunchBox and EmulationStation. LaunchBox is what this project looked at for inspiration and what it sought to improve upon. The major strengths that both LaunchBox and EmulationStation has are the visual aspects for GUI and the ability to play the games that you add to your collection. They also have different options for different kinds of views and ways to display your game collection. The main weakness that both LaunchBox and EmulationStation have is the lack of a menu that recommends games based on the game that the users have stored in their application. 
This project tried to capitalize on the lack of the ability to recommend games and view different kinds of information. It could not compete with the visuals and the ability to customize the users game collection to their preferences. The main reason users would try Game logger would be to see different kinds of information and seeing other games that match that user’s preferences. It could also be appealing to someone that just wants a very minimalist view.  Another source of value would be the size of the program is relatively small compared to the other solutions, so it would be great for someone that needs to conserve space on their hard drive.\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Some of the problems that existed in this project that did not get addressed is the visual appeal and the lack of support to be able to play the games in the application.  The reasoning that these problems did not get addressed would be that they were very time consuming and did not seem very important for a bare bones project to store a user’s collections. The visual appeals can be improved on later. Playing the games would just take a lot of time to tie into Game logger and would require the users to download additional programs. Problems that did get address would include the ability to add/remove games, listing the games in the main window, providing more information on the games, and recommending games.  

# Design, Development, and Test 
## Design 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; The design of the projects can be organized by breaking it into two parts, the database connection and the Windows application. The windows application is composed of many forms, windows, tables, and views. The database is a api from Giant Bomb which allows the application to go and fetch the XML tags that the windows application needs to display the information for the user to see.\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Giant Bomb is a website that reviews video games and has information on them, and the api allows users to access this information. The Giant Bomb api was easy to install enough to install, all that is needed to type this command in the package manager console `Install-Package GiantBomb.Api`. [1] The GiantBomb-CSharp github page has the instructions on how to connect to the api. The Giant Bomb documentation of the api will give further information on how to access specific fields. [2] Here is an example of using the api to locate Fallout 4.\
`var client = new GiantBombRestClient("your-api-key");`\
`var result = client.SearchForGames(“Fallout 4”).ToList();`\
`var Game = client.GetGame(result.First().Id);`\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; After getting the “Game” variable it can be used to acquire the tags of the XML file. The Giant Bomb api is used anywhere that the application would need to find a game or information about the game like for example searching for the games and after finding the game it would then be used to get the information that is necessary. It is also used to recommend games based on the “Game” variable.\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; The windows application side of had four forms that adds, removes, edit the status, recommending games. It also includes making an image larger when the user clicks on the image. The application has one MainWindow.xaml, which is the main window that the user will be interacting with, because of the file drop down menu has access to the other forms.
</br> 
 <figure>
  <img src="https://github.com/parkerjd4/CapstoneProject/blob/master/Images/Gamelist.png" alt="XML File">
  <figcaption>Figure 2</figcaption>
</figure> 
</br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Adding games will happen when the user clicks File->Add Games and a menu will appear for that user to enter a games name and select a status for the game. The status has five items which are playing, plan to play, completed, on hold, and dropped. Removing games will happen when the user clicks File->Remove Games and will just require the name of the game. Both adding and removing games will edit a XML file that will contain all the information for that game. When adding or removing games from the listview the user will need to click File->Refresh GameList to change the contents of the listview. The information of the game will appear when the user clicks on the game within the listview. It will make a window appear with the all the information that is in the XML file, this window is called the game view. This window will also allow the user to change the status of the game to something else using another menu. All the user needs to do to change the status is click on the status. After this it will pop-up with a menu that lets the users to choose a new status. The game view window will also hold the recommend games button to allow the user to see four other games that are similar to that game. Recommend games window will be a table that will hold three columns. The columns are the name of the game, game cover image, and a description of the game.
## Development 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; I started with building the basic main window and designing the basic structure of the file drop down menu. After developing the main window, the process of adding and removing games could start. I created the add games form first and then started on the remove games form. Adding games had the risk areas of XML file editing and connecting to the Giant Bomb api. Both of those are needed for the rest of the application to function. The XML file included:
</br> 
 <figure>
  <img src="https://github.com/parkerjd4/CapstoneProject/blob/master/Images/Gamelist.png" alt="XML File" style="display: block;margin-left: auto;margin-right: auto;">
  <figcaption>Figure 2</figcaption>
</figure> 
</br>
When editing and looking at the XML the application needs XMLDocument and XMLNodeList. [5] [6] The XMLDocument is needed to load the XML file so that it can be edited. XMLNodeList is needed to loop though the XML file tags, this is used to create and look at information of the XML file. After completing the adding and removing games forms, the games need a container to hold the name of the games on the main window. The container is a listview because it was very easy to just add the name of the game to it. Another reason to use listview would be that it can add items dynamically. The next step after that would be making it where a form pops up with the user clicks on a list view cell. <br> 
 <figure>
  <img src="https://github.com/parkerjd4/CapstoneProject/blob/master/Images/GameView.png" alt="Game View" style="display: block;margin-left: auto;margin-right: auto;">
  <figcaption>Figure 3</figcaption>
</figure> 
<br>
The form is the GameView form and it displays the XML tags and the four images. After this form was developed a button was added to recommend games to user based on that game. The recommend games form has a TableLayoutPanel that stores four games as rows with three tags as columns. [3] The tags are the name, image of game cover, and a short description of the game. One the risk areas of this part would have to be if the game does not have four games that are similar to that game. This problem was fixed by adding “Missing Game” to the name and description. The image field has a question mark instead of just being blank.  
## Testing 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; The main things that was tested were operations that grabbed information from the Giant Bomb api and methods that added to the XML. There are three methods that check the XML files and the other four test methods test grabbing developers, genre, platforms, and publishers. The reasoning those need to be test is that all those fields are list and the application turns them into a string with a “ ,” in-between each object. To those methods I needed to just run the methods and compare the output to the correct output using `Assert.AreEqual() `. [7] Checking if the XML files are created the correct way you need to use the test files that are on this GitHub folder. It checks the XML file by adding two different games to another XML file and having a XML file that looks like it should. Doing this was a trouble area but was easily solved by just comparing the hashes of the files.\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; The UI of Game logger was not tested due to the fact that I did not have access to Visual Studio 2017 Enterprise on my laptop. UI testing framework was only on Visual Studio 2017 Enterprise and not Visual Studio 2017 Community, which is the version I have. I also do not think that it would have worked anyway because the UI testing used timing of the clicks and if that action happens, my application could take longer depending on the internet so this could cause it to fail when it really was working. 


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
		<td>Refresh Listview</td>
		<td>Did Implement</td>
	</tr>
		<tr> 
		<td>Having Categories</td>
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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Most of the planned features did make it in to the final product, but of course it is missing some of the features that would improve the overall quality of the application. Adding and removing games was a simple process of just editing the XML with XMLDocument and XMLNodeList. The game view is when the user clicks on a cell in the listview that has a game and it will pop-up with information on the game corresponding to the tags in the XML file. Recommending the games took a little longer because encountering a lot of bugs with the images. The application would be saying that the images were already downloaded, so the solution was to check before downloading the images. Another problem was the file names were the same for some of the images, just had to change some of them to different names.  One of the problems that was encountered and took a very long time to fix would be the listview refreshing. Adding and removing games from the listview would not result in it being removed from the listview but only from the XML file. The solution to this problem was to use ItemsSource of the listview and databind an array to the listview. After doing this it would not work, but after adding to the drop-down menu of the application a button that would refresh the listview it worked. The problem was more in likely to do with methods and the listview being in different threads.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Creating the categories for the games with very easy because the users are choosing the status of the games when they add the games in the add game form. The status would just be added to the XML for referencing later on in the game view form. Changing the status is done by just clicking the status in the game view form and selecting another predefined status. Sorting by the categories was a problem because of the amount of time it took to get listview working that it was going to break everything which would take a lot of time to fix it. An idea of how to fix this problem would be to sort the databind source and refresh the list.  ESRB ratings was troubling because the Giant Bomb api would sometimes not have them or it would be in PEGI which is the Europe game rating system. Did not want to use this because of the inconsistency and not having the correct ESRB rating.<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Playing the games in the application did not get implemented because it would have taken a long time to tie in support. Having the user know the file path of the emulator and then having to keep that information would have added more work onto a busy schedule. Also, the most popular emulator, RetroArch, would be very difficult because it would also require the user to know the core that he/she wants to run. Having the listview cells have both game name and image of the cover was a problem because of needing to edit the listview to a custom cell. The custom cell would require changing how the listview would fetch the data which would take too much time to change this feature. 


# Conclusions and Future Work
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; The problem that was addressed by this project would be allowing people to store their gaming collection in a windows application. The approach that was used was a combination of Visual Studio 2017 with C# and using the Giant Bomb api. Visual Studio 2017 with C# was used to create the application. The Giant Bomb api was used to get information about various games that the users will add to the application. Some of the basic features would be adding and removing games for the listview, which displays the games to main window. Having a menu pop-up when the user clicks on a listview cell that has information about the game contained in the listview cell. That menu will also have a button lets users see four other games that are like that game. The main lesson that can be learned from this would to be able to stop working on something that is not necessary and move on to the next thing. A lot of time was spent trying to get the listview to dynamically update instead of using the option of having a button update it. If all that time was not wasted the application could have had other useful features like playing the games, sorting the listview, and many more. Another lesson learned was that developing a bare bone application and adding to the application was great. By having a bare bone application, it is easy to see where the other features are going to be and how to develop more features.\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; The utility of the final result is just what was envisioned, just not that visually pleasing. The ability to add and remove games from the application and then view them is just what the application was designed to be. Being able to view games that are similar is a bonus because I went into the project with the mindset that it would not happen. The only problem with the final result is that it’s not that great to look at.\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If work was to be continued on this project it would include improving the visuals and being able to play the games in the application. Improving the visuals would require learning more about creating a custom cell for listview and how to tie it into my listview. To be able to play the games I would have to decide on what emulators I would support and how to incorporate them into the application.

# References 
[1] kamranayub, Aug 18, 2017.’ A .NET GiantBomb API built on top of RestSharp Portable’. GitHub. https://github.com/kamranayub/GiantBomb-CSharp <br>
[2] Giant Bomb, 2018. ‘Documentation’. Giant Bomb. https://www.giantbomb.com/api/ <br>
[3] Microsoft, 2018, ‘TableLayoutPanel.Controls Property’. Microsoft.   https://msdn.microsoft.com/en-us/library/system.windows.forms.tablelayoutpanel.controls(v=vs.110).aspx <br>
[4] Microsoft, 2018, ‘ListView Properties’. Microsoft. https://msdn.microsoft.com/en-us/library/system.windows.forms.listview_properties(v=vs.110).aspx <br>
[5] Microsoft, 2018, ‘XmlDocument Class’. Microsoft. https://msdn.microsoft.com/en-us/library/system.XML.XMLdocument(v=vs.110).aspx <br>
[6] Microsoft, 2018, ‘XmlNodeList Class’. Microsoft. https://msdn.microsoft.com/en-us/library/system.XML.XMLnodelist(v=vs.110).aspx <br>
[7] Microsoft, 2018, ‘Assert.AreEqual Method’. Microsoft. https://msdn.microsoft.com/en-us/library/microsoft.visualstudio.testtools.unittesting.assert.areequal.aspx <br>
