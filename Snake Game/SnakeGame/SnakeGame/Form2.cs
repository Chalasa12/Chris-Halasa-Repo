using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnakeGame.DAL;
using SnakeGame.Classes;

namespace SnakeGame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBoxForName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string entry = "";
            LeaderboardDAL leaderboard = new LeaderboardDAL();
            string name = textBoxForName.Text;
            if (name=="")
            {
                name ="Unknown";
            }
            if (GameSettings.Score==0)
            {
                entry = "Sorry, you do not qualify for the leaderboard";
            }
            else if (GameSettings.Score>0)
            {
                entry = $"Congratulations {name}, your score of {GameSettings.Score} has been entered!";
                leaderboard.NewScore(name, GameSettings.Score);
            }

            MessageBox.Show(entry);

        }

        private void quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
   
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
