//Computer Science ISU by : Harsh Mistry,Bradley Oosterbroek, and Logan Sikora-Beder
//Infinity Pokedex - A better pokedex
//December 15th, 2014 - January 19th, 2015 
//A Infinity Computing Production 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Runtime.InteropServices;

namespace Pokedex
{
    public partial class MainForm : Form
    {
        //Declare connection Variables 
        bool connectionBoolean = false; //Connection (Stores connection status)
        int counterInteger; //Counter variable
        HttpWebResponse result; //Result of web connection 

        //Declare Database variables
        public static DataSet pokemonDataSet;
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter adapter;

        //Declare Variables for pokemon stats
        int statInteger = 0;
        bool complexName = true, searchBoolean = false, transferBoolean = false;
        public static string typeString;
        string evolvedString;
        bool mainScreenBoolean = true;

        //Declare background thread for multi-threading
        BackgroundWorker pokemonBackgroundWork  = new BackgroundWorker();

        
 

        public MainForm()
        {
            InitializeComponent();

            //Load the animated pikachu cursor
            try
            {
                this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, "cursor.ani"));
            }

            //Catch any exceptions and display an error
            catch
            {
                MessageBox.Show("Cursor Load Error! Default windows cursor will be used instead", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

      

        //Form Load (Contact server and set default properties for objects on forms)
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Declare variables
            string accessString = @"C:\temp\isu.accdb";

            //Delete the access file if it already exist
            if (File.Exists(accessString))
            {
                //Delete file
                File.Delete(accessString);
                
                //Write to the console
                Console.WriteLine("Old File Deleted");
            }

            //Contact server and declare server connect variables 
            try
            {
                //Request index web page from server
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://infcomp.x10.mx");
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();

                //Write to the console
                Console.WriteLine("Server is Online");
            }

            //Catch Exception if server is offline 
            catch (WebException)
            {
                MessageBox.Show("Connection error : Refer to manual for further guidance",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Set background color of listboxes
            pokemonListBox.BackColor = Color.FromArgb(70, 70, 70);

            //Download latest database file from FTP Server 
            FTPConnect();

            //Write to the console
            Console.WriteLine("Downloaded Database");

            //Copy Database contents into the databaseDataset
            accessConnect();

            //Write to the console
            Console.WriteLine("Database loaded");

        }

        //Open and Read Access Database
        private void accessConnect()
        {
            //Assign values to access database variables 
            connection = new OleDbConnection();
            command = new OleDbCommand();
            adapter = new OleDbDataAdapter();
            pokemonDataSet = new DataSet(); 

            //Assign location of database to connection variable 
            connection.ConnectionString =
                @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\temp\isu.accdb;" +
                "Persist Security Info=False";

            //Establish connection with database
            command.Connection = connection;

            //Copy all tables into a c# dataset 
            try
            {
                //Select the pokedex table in the database
                command.CommandText = "SELECT * FROM Pokedex";
                adapter.SelectCommand = command;

                //Copy table into dataset 
                adapter.Fill(pokemonDataSet, "Pokedex");

              
            }

            //catch exception and display error if application fails to read database 
            catch (OleDbException)
            {
              // Error code goes here 
                Console.WriteLine("OLEDB Error");

            }



        }

        //Connect to ftp server and download the access database 
        private void FTPConnect()
        {
            //Attempt to download the file from the server
            try
            {
                //Declare Connection Variables and assign values 
                int read;
                FtpWebRequest requestFtpWebRequest = (FtpWebRequest)WebRequest.Create("ftp://ftp.infcomp.x10.mx/isu.accdb"); //Server address 
                requestFtpWebRequest.Method = WebRequestMethods.Ftp.DownloadFile; // Connection action
                requestFtpWebRequest.Credentials = new NetworkCredential("attendance@infcomp.x10.mx", "1234567"); //Username and Pass
                FtpWebResponse responderFtpWebResponse = (FtpWebResponse)requestFtpWebRequest.GetResponse();
                Stream responseStream = responderFtpWebResponse.GetResponseStream();
                FileStream databaseFileStream = File.Create(@"C:\temp\isu.accdb");
                responseStream.ReadTimeout = 10000;
                byte[] downloadBufferByte = new byte[32 * 1024];




                //Download file in 32mb Chunks
                while ((read = responseStream.Read(downloadBufferByte, 0, downloadBufferByte.Length)) > 0)
                {
                    //Read the File and Write it to the buffer 
                    databaseFileStream.Write(downloadBufferByte, 0, read);
                }

                //Close the file 
                databaseFileStream.Close();

                //Close the connection
                responseStream.Close();
                responderFtpWebResponse.Close();
            }

            //Catch any exceptions 
            catch
            {
                Console.WriteLine("FTP Error");
            }

        }

        //Display list of all pokemon 
        private void pokemonLabel_Click(object sender, EventArgs e)
        {
            //Declare variables
            int lengthInteger = 0;

            //set mainscreen variable to false
            mainScreenBoolean = false;

            //Change Form background image
            this.BackgroundImage = Pokedex.Properties.Resources.all;

            //Hide Button labels
            pokemonLabel.Visible = false;
            sortLabel.Visible = false;
            toolLabel.Visible = false;

            //Clear picturebox
            previewPictureBox.Image = null;

            //Display List Box  and preview picture box 
            pokemonListBox.Visible = true;
            previewPictureBox.Visible = true;

            //Enable listbox
            pokemonListBox.Enabled = true;

            //Set listbox sorted property to false
            pokemonListBox.Sorted = false;

            //Clear the Listbox
            pokemonListBox.Items.Clear();

            //Get the length of the database 
            lengthInteger = pokemonDataSet.Tables[0].Rows.Count;

            //Fill list with all pokemon names 
            for (int rowCounterInteger = 0; rowCounterInteger <= lengthInteger; rowCounterInteger++)
            {

                 //Loop through the dataset until the dexnumber matches the row counter 
                foreach (DataRow pokemonDatarow in pokemonDataSet.Tables[0].Rows)
                {
                    //Add pokemon to list if a match is found
                    if (pokemonDatarow["Dex Num"].ToString() == rowCounterInteger.ToString())
                    {
                        //Add Each Pokemon name to the list the name column is not empty 
                        if (pokemonDatarow["Name"].ToString() == "")
                        {
                            //No Name In current record
                            Console.WriteLine("No Name");
                        }
                        else
                        {
                            //Add Name to List 
                            pokemonListBox.Items.Add(pokemonDatarow["Dex Num"].ToString() + " -- " + pokemonDatarow["Name"].ToString());
                        }
                    }
                }
                
            }

        }

        //Displauy search bar to search all pokemon
        private void sortLabel_Click(object sender, EventArgs e)
        {
            //Change Form background image
            this.BackgroundImage = Pokedex.Properties.Resources.all;

            //Set search boolean to true
            searchBoolean = true;

            //Set complex name to true
            complexName = true;

            //set mainscreen variable to false
            mainScreenBoolean = false;

            //Hide Button labels
            pokemonLabel.Visible = false;
            sortLabel.Visible = false;
            toolLabel.Visible = false;

            //Clear picturebox
            previewPictureBox.Image = null;

            //Display List Box  and preview picture box 
            pokemonListBox.Visible = true;
            previewPictureBox.Visible = true;

            //Display search bar
            searchTextBox.Visible = true;
           
            //Enable listbox
            pokemonListBox.Enabled = true;

            //Set sorted property to false
            pokemonListBox.Sorted = false;

            //Clear the Listbox
            pokemonListBox.Items.Clear();

            //Fill list with all pokemon names 
            foreach (DataRow pokemonDataRow in pokemonDataSet.Tables[0].Rows)
            {
                //Add Each Pokemon name to the list the name column is not empty 
                if (pokemonDataRow["Name"].ToString() == "")
                {
                    //No Name In current record
                    Console.WriteLine("No Name");
                }
                else
                {
                    //Add Name to List 
                    pokemonListBox.Items.Add(pokemonDataRow["Dex Num"].ToString() + " -- " + pokemonDataRow["Name"].ToString());
                }
            }

    
        }

        //Display tools and extras tab
        private void toolLabel_Click(object sender, EventArgs e)
        {
            //Hide all main screen labels
            pokemonLabel.Visible = false;
            sortLabel.Visible = false;
            toolLabel.Visible = false;

            //Display tool screen labels
            aboutLabel.Visible = true;
            extraLabel.Visible = true;
            backLabel.Visible = true;
        
        }


        
        //Display GIF of selected pokemon 
        private void pokemonListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //show the loading image
            loadingPictureBox.Visible = true;
            previewPictureBox.Visible = false;

            //Download and display gif using a background thread
            System.Windows.Forms.Application.DoEvents();
            pokemonBackgroundWorker_DoWork(null,null);
            pokemonBackgroundWorker_RunWorkerCompleted(null,null);

           
        }

        //Return to previous screen
        private void closePictureBox_Click(object sender, EventArgs e)
        {
            if (statInteger == 0)
            {
                //Change Form background image
                this.BackgroundImage = Pokedex.Properties.Resources.MainScreen;

                //Show Button labels
                pokemonLabel.Visible = true;
                sortLabel.Visible = true;
                toolLabel.Visible = true;

                //Hide List Box  and preview picture box 
                pokemonListBox.Visible = false;
                previewPictureBox.Visible = false;
                statPictureBox.Visible = false;

                //Hide stat labels
                type2Label.Visible = false;
                typeLabel.Visible = false;
                pictureBoxType1.Visible = false;
                pictureBoxType2.Visible = false;
                hpLabel.Visible = false;
                attackLabel.Visible = false;
                defenseLabel.Visible = false;
                spaAttackLabel.Visible = false;
                spDefenseLabel.Visible = false;
                speedLabel.Visible = false;
                evolveLabel.Visible = false;

                //set mainscreen variable to true
                mainScreenBoolean = true;

                
            }
            else if (statInteger == 1)
            {
                //Change Form background image
                this.BackgroundImage = Pokedex.Properties.Resources.all;

                //Set stat integer to 1
                statInteger = 0;

                //Hide stat labels
                type2Label.Visible = false;
                typeLabel.Visible = false;
                pictureBoxType1.Visible = false;
                pictureBoxType2.Visible = false;
                hpLabel.Visible = false;
                attackLabel.Visible = false;
                defenseLabel.Visible = false;
                spaAttackLabel.Visible = false;
                spDefenseLabel.Visible = false;
                speedLabel.Visible = false;
                evolveLabel.Visible = false;

                //show List Box  and preview picture box 
                pokemonListBox.Visible = true;
                previewPictureBox.Visible = true;
                statPictureBox.Visible = false;

                //Enable the listbox
                pokemonListBox.Enabled = true;

                //Clear the type pictureboxs
                pictureBoxType1.Image = null;
                pictureBoxType2.Image = null;

          

            }


            //Display the search textbox if the search boolean is equal to true
            if (searchBoolean == true)
            {
                searchTextBox.Visible = false;
            }


            //Reset focus
            this.Focus();
        }

        //Exit application if exit button is clicked
        private void exitPictureBox_Click(object sender, EventArgs e)
        {
            //Declare variables 
            DialogResult exitDialogResult;

            //Prompt user to exit application
            exitDialogResult = MessageBox.Show("Do you wish to close The Infinity Pokedex", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //If result is yes then exit the application
            if (exitDialogResult == DialogResult.Yes)
            {
                Application.Exit(); 
            }
        }

        //Register Key Press Events and excute corresponding events 
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                //Move joystick up
                joystickPictureBox.Image = Pokedex.Properties.Resources.up;
            }
            else if (e.KeyCode == Keys.Down) 
            {
                //Move joystick down
                joystickPictureBox.Image = Pokedex.Properties.Resources.down;
            }
            else if (e.KeyCode == Keys.Left) 
            {
                //Move joystick left
                joystickPictureBox.Image = Pokedex.Properties.Resources.left;
            }
            else if (e.KeyCode == Keys.Right) 
            {
                //Move joystick right
                joystickPictureBox.Image = Pokedex.Properties.Resources.right;
            }
        }

        //Reset joystick image upon key release
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            joystickPictureBox.Image = Pokedex.Properties.Resources.center; 
        }

        //Display Selected pokemon stats 
        private void aPictureBox_Click(object sender, EventArgs e)
        {
            //Declare variables
            string selectedNameString, formatString;
            int evoDexInteger = 0;

            //stop if user is on the main screen
            if (mainScreenBoolean == true) 
            {
                //Exit method
                return;
            }


            //Get selected name 
            if (transferBoolean == false)
            {
                if (pokemonListBox.SelectedIndex > -1)
                {
                    //Assign name
                    selectedNameString = pokemonListBox.SelectedItem.ToString();
                }
                else
                {
                    //Display error
                    MessageBox.Show("Error : Please select a pokemon", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //Exit method
                    return;
                }
            }
            else
            {
                //Get name of evolved pokemon 
                selectedNameString = evolvedString;
            }

            transferBoolean = false;

            //Set stat integer to 1
            statInteger = 1;

            //Hide the list box and preview picturebox
            pokemonListBox.Visible = false;
            previewPictureBox.Visible = false;

            //Hide the search text box 
            searchTextBox.Visible = false;

            //Disable listbox
            pokemonListBox.Enabled = false;

            //Change the form background image
            this.BackgroundImage = Pokedex.Properties.Resources.stats;

            //display the stat labels
            type2Label.Visible = true;
            typeLabel.Visible = true;
            pictureBoxType1.Visible = true;
            pictureBoxType2.Visible = true;
            hpLabel.Visible = true;
            attackLabel.Visible = true;
            defenseLabel.Visible = true;
            spaAttackLabel.Visible = true;
            spDefenseLabel.Visible = true;
            speedLabel.Visible = true;
            evolveLabel.Visible = true;

            //Display loading picture
            loadingPictureBox.Visible = true;

            //Display the stat picturebox
            statPictureBox.Visible = true;

            //Display pokemon name
            nameLabel.Text = selectedNameString;

            //Loop through the database till pokemon is found
            foreach (DataRow pokemonDataRow in pokemonDataSet.Tables[0].Rows)
            {
                //Set format string based on value of the comples boolean 
                if (complexName == false)
                {
                    formatString = pokemonDataRow["Name"].ToString() + " -- " + pokemonDataRow["Dex Num"].ToString();
                }
                else
                {
                    formatString = pokemonDataRow["Dex Num"].ToString() + " -- " + pokemonDataRow["Name"].ToString();
                }

                //when match is found update stats
                if (formatString == selectedNameString )
                {
                    //Display stats
                    hpLabel.Text = pokemonDataRow["HP"].ToString();
                    attackLabel.Text = pokemonDataRow["Atk"].ToString();
                    defenseLabel.Text = pokemonDataRow["Def"].ToString();
                    spaAttackLabel.Text = pokemonDataRow["Sp Atk"].ToString();
                    spDefenseLabel.Text = pokemonDataRow["Sp Def"].ToString();
                    speedLabel.Text = pokemonDataRow["Speed"].ToString();

                    //Display gif
                    try
                    {
                        statPictureBox.Load(pokemonDataRow["Gif"].ToString());
                    }

                    //Catch any exceptions
                    catch
                    {
                        //Display no image found in place of pokemon gif
                        statPictureBox.Image = Pokedex.Properties.Resources.noImage;
                    }

                    //Display an image for the pokemon's type
                    switch (pokemonDataRow["Type 1"].ToString())
                    {
                        case "Normal":
                            pictureBoxType1.Image = Pokedex.Properties.Resources.normal;
                            break;
                        case "Bug":
                            pictureBoxType1.Image = Pokedex.Properties.Resources.bug;
                            break;
                        case "Fire":
                            pictureBoxType1.Image = Pokedex.Properties.Resources.fire;
                            break;
                        case "Ice":
                            pictureBoxType1.Image = Pokedex.Properties.Resources.ice;
                            break;
                        case "Water":
                            pictureBoxType1.Image = Pokedex.Properties.Resources.water;
                            break;
                        case "Grass":
                            pictureBoxType1.Image = Pokedex.Properties.Resources.grass;
                            break;
                        case "Psychic":
                            pictureBoxType1.Image = Pokedex.Properties.Resources.psychic;
                            break;
                        case "Fairy":
                            pictureBoxType1.Image = Pokedex.Properties.Resources.fairy;
                            break;
                        case "Dragon":
                            pictureBoxType1.Image = Pokedex.Properties.Resources.dragon;
                            break;
                        case "Fighting":
                            pictureBoxType1.Image = Pokedex.Properties.Resources.fighting;
                            break;
                        case "Rock":
                            pictureBoxType1.Image = Pokedex.Properties.Resources.rock;
                            break;
                        case "Ground":
                            pictureBoxType1.Image = Pokedex.Properties.Resources.ground;
                            break;
                        case "Steel":
                            pictureBoxType1.Image = Pokedex.Properties.Resources.steel;
                            break;
                        case "Flying":
                            pictureBoxType1.Image = Pokedex.Properties.Resources.flying;
                            break;
                        case "Ghost":
                            pictureBoxType1.Image = Pokedex.Properties.Resources.ghost;
                            break;
                        case "Electric":
                            pictureBoxType1.Image = Pokedex.Properties.Resources.electric;
                            break;
                        case "Poison":
                            pictureBoxType1.Image = Pokedex.Properties.Resources.poison;
                            break;
                        case "Dark":
                            pictureBoxType1.Image = Pokedex.Properties.Resources.dark;
                            break;
                       
                    }

                    //Display an image for the pokemon's 2nd type 
                    switch (pokemonDataRow["Type 2"].ToString())
                    {
                        case "Normal":
                            pictureBoxType2.Image = Pokedex.Properties.Resources.normal;
                            break;
                        case "Bug":
                            pictureBoxType2.Image = Pokedex.Properties.Resources.bug;
                            break;
                        case "Fire":
                            pictureBoxType2.Image = Pokedex.Properties.Resources.fire;
                            break;
                        case "Ice":
                            pictureBoxType2.Image = Pokedex.Properties.Resources.ice;
                            break;
                        case "Water":
                            pictureBoxType2.Image = Pokedex.Properties.Resources.water;
                            break;
                        case "Grass":
                            pictureBoxType2.Image = Pokedex.Properties.Resources.grass;
                            break;
                        case "Psychic":
                            pictureBoxType2.Image = Pokedex.Properties.Resources.psychic;
                            break;
                        case "Fairy":
                            pictureBoxType2.Image = Pokedex.Properties.Resources.fairy;
                            break;
                        case "Dragon":
                            pictureBoxType2.Image = Pokedex.Properties.Resources.dragon;
                            break;
                        case "Fighting":
                            pictureBoxType2.Image = Pokedex.Properties.Resources.fighting;
                            break;
                        case "Rock":
                            pictureBoxType2.Image = Pokedex.Properties.Resources.rock;
                            break;
                        case "Ground":
                            pictureBoxType2.Image = Pokedex.Properties.Resources.ground;
                            break;
                        case "Steel":
                            pictureBoxType2.Image = Pokedex.Properties.Resources.steel;
                            break;
                        case "Flying":
                            pictureBoxType2.Image = Pokedex.Properties.Resources.flying;
                            break;
                        case "Ghost":
                            pictureBoxType2.Image = Pokedex.Properties.Resources.ghost;
                            break;
                        case "Electric":
                            pictureBoxType2.Image = Pokedex.Properties.Resources.electric;
                            break;
                        case "Poison":
                            pictureBoxType2.Image = Pokedex.Properties.Resources.poison;
                            break;
                        case "Dark":
                            pictureBoxType2.Image = Pokedex.Properties.Resources.dark;
                            break;
                        
                    }
                    //Display next evolouton of pokemon, if pokemon evolves
                    if (pokemonDataRow["Evolves"].ToString() == "True")
                    {
                        //Get evo dex number
                        evoDexInteger = int.Parse(pokemonDataRow["Evolution Dex Num"].ToString());

                        //Loop through the database till match is found
                        foreach (DataRow pokemonDataRow2 in pokemonDataSet.Tables[0].Rows)
                        {
                            if (pokemonDataRow2["Dex Num"].ToString() == evoDexInteger.ToString())
                            {
                                //Display the pokemon name
                                evolveLabel.Text = pokemonDataRow2["Name"].ToString();
                            }

                        }

                    }
                    else
                    {
                        evolveLabel.Text = "Nothing";
                    }
                }

            }

            //Display nothing for type 2 if its blank
            if (type2Label.Text == "")
            {
                type2Label.Text = "Nothing";
            }

            //Hide loading picturebox 
            loadingPictureBox.Visible = false;
            
            
        }

        //Register Key events when listbox is in focus 
        private void pokemonListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                //Display pokemon stats
                aPictureBox_Click(null, null); 
            }
            else if (e.KeyCode == Keys.X)
            {
                //Organize pokemon by name
                xPictureBox_Click(null, null);
            }
            else if (e.KeyCode == Keys.Y)
            {
                //Organize pokemon by dex number
                yPictureBox_Click(null, null);
            }
            else if (e.KeyCode == Keys.B)
            {
                //Organize pokemon by type
                bPictureBox_Click(null, null);
            }
        }

        //Organize pokemon by name
        private void xPictureBox_Click(object sender, EventArgs e)
        {
            //Declare variables
            DialogResult confirmDialogResult;

            //Only resume if the listbox is visible
            if (pokemonListBox.Visible == false)
            {
                //exit method
                return;
            }

            //Confrim action 
            confirmDialogResult = MessageBox.Show("Do you want to view all pokemon in alphabetical order?", "Organize by Name? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //Organize pokemon by name if result is yes
            if (confirmDialogResult == DialogResult.Yes)
            {
                //Set complex boolean to false
                complexName = false;

                //Clear listbox
                pokemonListBox.Items.Clear();

                //Fill list with all pokemon names 
                foreach (DataRow pokemonDataRow in pokemonDataSet.Tables[0].Rows)
                {
                    //Add Each Pokemon name to the list the name column is not empty 
                    if (pokemonDataRow["Name"].ToString() == "")
                    {
                        //No Name In current record
                        Console.WriteLine("No Name");
                    }
                    else
                    {
                        //Add Name to List 
                        pokemonListBox.Items.Add( pokemonDataRow["Name"].ToString() + " -- " + pokemonDataRow["Dex Num"].ToString());
                    }
                }

                //Sort the listbox
                pokemonListBox.Sorted = true;
            }

        }

        //Organize pokemon by dex number 
        private void yPictureBox_Click(object sender, EventArgs e)
        {

            //Declare variables
            DialogResult confirmDialogResult;

            //Only resume if the listbox is visible
            if (pokemonListBox.Visible == false)
            {
                //exit method
                return;
            }

            //Confrim action 
            confirmDialogResult = MessageBox.Show("Do you want to view all pokemon in order of dex number?", "Organize by Dex Number? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //Organize pokemon by name if result is yes
            if (confirmDialogResult == DialogResult.Yes)
            {
                //Set complex boolean to true
                complexName = true;

                //Clear listbox
                pokemonListBox.Items.Clear();

                //Set sorted to false
                pokemonListBox.Sorted = false ;

                //Fill list with all pokemon names 
                pokemonLabel_Click(null, null);

                
            }
        }

        //Display Type selection screen and organize pokemon by type
        private void bPictureBox_Click(object sender, EventArgs e)
        {
            //Declare variables
            DialogResult confirmDialogResult;

            //Only resume if the listbox is visible
            if (pokemonListBox.Visible == false)
            {
                //exit method
                return;
            }

            //Confrim action 
            confirmDialogResult = MessageBox.Show("Do you want to organize pokemon by type", "Organize by type? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //Organize pokemon by type if result is yes
            if (confirmDialogResult == DialogResult.Yes)
            {
                //Create new instance of the type form
                TypeForm typeForm = new TypeForm();
                
                //Display type selection form
                typeForm.ShowDialog(); 

                //Set complex boolean to true
                complexName = false;

                //Clear listbox
                pokemonListBox.Items.Clear();

                //Set sorted to true
                pokemonListBox.Sorted = true;

                //Fill list with all pokemon names 
                foreach (DataRow pokemonDataRow in pokemonDataSet.Tables[0].Rows)
                {
                    //Add Each Pokemon name to the list the name column is not empty 
                    if (pokemonDataRow["Name"].ToString() == "")
                    {
                        //No Name In current record
                        Console.WriteLine("No Name");
                    }
                    else
                    {
                        //Add Name to List only if type matchs selected type
                        if (pokemonDataRow["Type 1"].ToString() == typeString || pokemonDataRow["Type 2"].ToString() == typeString)
                        {
                            pokemonListBox.Items.Add(pokemonDataRow["Name"].ToString() + " -- " +pokemonDataRow["Dex Num"].ToString());
                        }
                    }
                }


            }
        }

        //Filter pokemon list 
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            //set complex name to true
            complexName = true; 

            //Update student list 
            sortLabel_Click(null, null);

            //Create a list with searchable student/class names 
            var pokemonList = pokemonListBox.Items.Cast<string>().ToList();

            //Begin update 
            pokemonListBox.BeginUpdate();

            //Clear listbox 
            pokemonListBox.Items.Clear();


            //Filter items based on text in search textbox only if its not blank 
            if (!string.IsNullOrEmpty(searchTextBox.Text))
            {
                foreach (string str in pokemonList)
                {
                    if (str.Contains(searchTextBox.Text))
                    {
                        pokemonListBox.Items.Add(str);
                    }
                }
            }
            else
            {
                //Reset listbox to default list 
                sortLabel_Click(null, null);
            }

            //End update 
            pokemonListBox.EndUpdate();
        }

        //Clear contents of the search textbox
        private void searchTextBox_Click(object sender, EventArgs e)
        {
            searchTextBox.Text = "";
        }

        //Display the about form
        private void aboutLabel_Click(object sender, EventArgs e)
        {
            //Create new instance of the about form
            AboutBox1 aboutForm = new AboutBox1();

            //Display the aboutform
            aboutForm.ShowDialog();
        }

        //Display the main screen
        private void backLabel_Click(object sender, EventArgs e)
        {
            //Display all main screen labels
            pokemonLabel.Visible = true;
            sortLabel.Visible = true;
            toolLabel.Visible = true;

            //Hide tool screen labels
            aboutLabel.Visible = false;
            extraLabel.Visible = false;
            backLabel.Visible = false;
        }

        //Load the next pokemon that the current pokemon evolves into
        private void evolveLabel_Click(object sender, EventArgs e)
        {
            //Declare variables
            string evolvedDexString = "";

            if (evolveLabel.Text != "Nothing")
            {
                //Get the dex number of the selected pokemon
                foreach (DataRow pokemonDataRow in pokemonDataSet.Tables[0].Rows)
                {
                    if (pokemonDataRow["Name"].ToString() == evolveLabel.Text)
                    {
                        //Assign the dex number if match is found
                        evolvedDexString = pokemonDataRow["Dex Num"].ToString();
                    }
                }
                
                //Set format string based on value of the comples boolean 
                if (complexName == false)
                {
                    evolvedString = evolveLabel.Text + " -- " + evolvedDexString;
                }
                else
                {
                    evolvedString = evolvedDexString + " -- " + evolveLabel.Text; 
                }

                //Set transfer boolean to true
                transferBoolean = true;

                //Clear Pictureboxes 
                pictureBoxType1.Image = null;
                pictureBoxType2.Image = null;

                //Load new pokemons stats 
                aPictureBox_Click(null,null);
            }
            else
            {
                MessageBox.Show("This pokemon does not evolve.", "Error: Final Evolution",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        //Display data in a datagridview 
        private void extraLabel_Click(object sender, EventArgs e)
        {
            //Change the background image
            this.BackgroundImage = Pokedex.Properties.Resources.grid;

            //Hide tool screen labels
            aboutLabel.Visible = false;
            extraLabel.Visible = false;
            backLabel.Visible = false;
            pokemonLabel.Visible = false;
            sortLabel.Visible = false;
            toolLabel.Visible = false;

            //Show the back picturebox
            backPictureBox.Visible = true;

            //Display Dataset in the datagrid view control
            pokemonDataGridView.Visible = true;
            pokemonDataGridView.AutoGenerateColumns = true;
            pokemonDataGridView.DataSource = pokemonDataSet; 
            pokemonDataGridView.DataMember = "Pokedex"; 
        }

        //Go back to the tools menu
        private void backPictureBox_Click(object sender, EventArgs e)
        {
            //Change the background image
            this.BackgroundImage = Pokedex.Properties.Resources.MainScreen;

            //show tool screen labels
            aboutLabel.Visible = true;
            extraLabel.Visible = true;
            backLabel.Visible = true;

            //hide the back picturebox
            backPictureBox.Visible = false;

            //hide the datagridview control
            pokemonDataGridView.Visible = false;
            
        }

        //Download and display gif
        private void pokemonBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            //Declare variables
            string selectedPokemonString, formatString;

            //Get selected pokemon name
            if (pokemonListBox.SelectedIndex > -1)
            {

                selectedPokemonString = pokemonListBox.SelectedItem.ToString();

            }
            else
            {
                //Display Error
                MessageBox.Show("Error : No Pokemon Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Exit method
                return;
            }

            //Loop through dataset till name is found
            foreach (DataRow pokemonDataRow in pokemonDataSet.Tables[0].Rows)
            {
                //Set format string based on value of the comples boolean 
                if (complexName == false)
                {
                    formatString = pokemonDataRow["Name"].ToString() + " -- " + pokemonDataRow["Dex Num"].ToString();
                }
                else
                {
                    formatString = pokemonDataRow["Dex Num"].ToString() + " -- " + pokemonDataRow["Name"].ToString();
                }

                //Check if record matchs selected name
                if (formatString == selectedPokemonString)
                {
                    //Update preview picture box with selected pokemon's GIF
                    try
                    {


                        //Disable listbox
                        pokemonListBox.Enabled = false;

                        //Download and display gif
                        previewPictureBox.Load(pokemonDataRow["Gif"].ToString());
                      

                        Console.WriteLine("Picture Loaded");

                        //enable listbox
                        pokemonListBox.Enabled = true;
                    }

                    //Catch any exceptions
                    catch
                    {
                        //Display no image found in the preview picture box
                        previewPictureBox.Image = Pokedex.Properties.Resources.noImage;
                        Console.WriteLine("Error");

                        //Re enable listbox
                        pokemonListBox.Enabled = true;





                    }
                }
            }

            //Set focus to listbox
            pokemonListBox.Focus();
        }

        //Hide loading image 
        private void pokemonBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            

            //hide the loading image
            loadingPictureBox.Visible = false;
            previewPictureBox.Visible = true;
        }

        

    }

    //Advanced Cursor Class : Loads animated cursors using user32.dll
    public class AdvancedCursors
    {
        //Import User32.dll
        [DllImport("User32.dll")]

        //Declare variable to hold cursor location
        private static extern IntPtr LoadCursorFromFile(String str);

        //Load the cursor from the .ani file
        public static Cursor Create(string filename)
        {
            //Declare cursor variables
            IntPtr hCursor = LoadCursorFromFile(filename);

            //Load cursort only if cursor was successfully created from the file. 
            if (!IntPtr.Zero.Equals(hCursor))
            {
                return new Cursor(hCursor);
            }
            else
            {
                throw new ApplicationException("Could not create cursor from file " + filename);
            }
        }
    }  
}
