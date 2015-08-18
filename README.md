![logo](https://github.com/hmtinc/Emerald-Attendance/raw/master/Emerald%20Attendance/Resources/logo2.png)
# Infinity Pokedex
The infinity pokédex is a simple application which scrapes an online based pokemon database to allow users to display Pokémon stats and view information about their subsequent evolution. The application makes use of the .net framework to filter through 600+ data entries and download gif’s from various Pokémon sources on the internet to ensure the user has all the Pokémon information they need in one place.

# Setup
- Due to server up keep issues, there is no longer a demo server online, but the application can be configured to pull data of another server. 

To point Emerald Attendance to your server, edit the following lines lines in LoginForm.cs with your apportiate server information. 

Lines 84 - 85
```c#
//Request index web page from server
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://infcomp.x10.mx");
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
```

Lines 373 - 376
```c#
            String sourceFilePathString = "C:\\temp\\database.xml";
            String ftpString = "ftp://ftp.infcomp.x10.mx";
            String ftpUsernameString = "attendance@infcomp.x10.mx";
            String ftpPasswordString = "1234567";
```

In addition to changing the server info, ensure there is a XML file on your server named database.xml to ensure the application is able to store/manage data.



#Goals
The Goal of Emerald Attendance was to devlop a simple data management program that makes use of a server to store and manage data inputed by a user.

#People
Harsh Mistry - Programmer/UI Design 

Bradley Oosterbroek - Programmer/Data Entry 

Logan Sikora-Beder - Testing



