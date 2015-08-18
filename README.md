![logo](https://github.com/hmtinc/Infinity-Pokedex/raw/master/Pokedex/Icon.ico)
# Infinity Pokedex
The infinity pokédex is a simple application which scrapes an online based pokemon database to allow users to display Pokémon stats and view information about their subsequent evolution. The application makes use of the .net framework to filter through 600+ data entries and download gif’s from various Pokémon sources on the internet to ensure the user has all the Pokémon information they need in one place.

# Setup
- Due to server up keep issues, there is no longer a demo server online, but the application can be configured to pull data of another server. 

To point Infinity to your server, edit the following lines lines in MainForm.cs with your apportiate server and database information. 

Line 73
```c#
 string accessString = @"C:\temp\isu.accdb";
```

Lines 89-90
```c#
   //Request index web page from server
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://infcomp.x10.mx");
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
```

Lines 169-177
```c#
//Declare Connection Variables 
                int read;
                FtpWebRequest requestFtpWebRequest = (FtpWebRequest)WebRequest.Create("ftp://ftp.infcomp.x10.mx/isu.accdb"); //Server address 
                requestFtpWebRequest.Method = WebRequestMethods.Ftp.DownloadFile; // Connection action
                requestFtpWebRequest.Credentials = new NetworkCredential("attendance@infcomp.x10.mx", "1234567"); //Username and Password
                FtpWebResponse responderFtpWebResponse = (FtpWebResponse)requestFtpWebRequest.GetResponse();
                Stream responseStream = responderFtpWebResponse.GetResponseStream();
                FileStream databaseFileStream = File.Create(@"C:\temp\isu.accdb");
                responseStream.ReadTimeout = 10000;
                byte[] downloadBufferByte = new byte[32 * 1024];
```



In addition to changing the server info, ensure there is a access file on your server named isu.accdb to allow the application  to store/manage data. A sample database file in included in the repository,



#Goals
The Goal of the infinity pokedex was to design a application which would scrape information and images of the internet and then display the information in a nice presentable format 

#People
Harsh Mistry - Programmer/UI Design 

Bradley Oosterbroek - Programmer/Data Entry 

Logan Sikora-Beder - Testing



