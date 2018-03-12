using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnakeGame.Classes;
using SnakeGame.DAL;


namespace SnakeGame
{
    public partial class Leaderboard : Form
    {
        BindingSource top100binding = new BindingSource();
       

        public Leaderboard()
        {
            LeaderboardDAL leaderboard = new LeaderboardDAL();
            List<Person> list = leaderboard.GetTop100();
            InitializeComponent();
            
            top100binding.DataSource = leaderboard.GetTop100();
            top100List.DataSource = top100binding;

            top100List.DisplayMember = "Display";
            top100List.DisplayMember = "Display";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
