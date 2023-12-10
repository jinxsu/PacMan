using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pacman_07354.Classes.Entities;

namespace Pacman_07354
{
    public partial class Form_Exit : Form
    {
        public Form_Exit(string message)
        {
            InitializeComponent();
            this.label_Title.Text = message;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Restart_Click(object sender, EventArgs e)
        {
            Game_Manager.Start_Game();
            this.Close();//close the Exit Form
        }

        private void Form_Exit_Load(object sender, EventArgs e)
        {

        }
    }
}
