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
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        //Load the main form after 4 seconds
        private void splashTimer_Tick(object sender, EventArgs e)
        {
            //Create new instance of the main form
            MainForm mainForm = new MainForm();

            //Show the main form
            mainForm.Show();

            //Hide the splash screen
            this.Hide();

            //Disable the timer 
            splashTimer.Enabled = false;
        }

    }
}
