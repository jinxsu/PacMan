using Pacman.Classes.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form_Exit : Form
    {
        public Form_Exit(string message)
        {
            InitializeComponent();
            this.Title.Text=message;
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            GameManager.StartGame();
            this.Close();
        }


        private void Form_Exit_Load(object sender, EventArgs e)
        {

        }

        
    }
}
