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

namespace Pokedex
{
    public partial class TypeForm : Form
    {
        //Declare variables
        bool selectedBoolean = false;

        public TypeForm()
        {
            InitializeComponent();
        }

        //Select type and close dialog box 
        private void sortButton_Click(object sender, EventArgs e)
        {
            //Check if selection was made
            if (typeListBox.SelectedIndex < 0)
            {
                //Display error
                MessageBox.Show("Error : No Type selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Exit method
                return;
                
            }

            //Pass on type to the main form 
            MainForm.typeString = typeListBox.SelectedItem.ToString();

            //Set selected boolean to true
            selectedBoolean = true;

            //Close the type form
            this.Close();
        }

        //Stop toolbox from closing if selected boolean is false
        private void typeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (selectedBoolean == false)
            {
                e.Cancel = true;
            }
        }
    }
}
