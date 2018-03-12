using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SnakeGame.DAL
{
    public class LeaderboardDAL
    {
        private const string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=SnakeGame;Integrated Security=True";
        private string top100 = "SELECT TOP 100 * FROM Leaderboards";
        private string insertHighScore = "INSERT INTO Leaderboards VALUES (@Name, @Score, @Date)";

        public List<Person> GetTop100()
        {
            List<Person> topList = new List<Person>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(top100, conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Person person = new Person();
                        person.ID = Convert.ToInt32(reader["ID"]);
                        person.Name = Convert.ToString(reader["Name"]);
                        person.Score = Convert.ToInt32(reader["Score"]);
                        person.Date = Convert.ToDateTime(reader["Date"]);

                        topList.Add(person);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return topList;
        }

        public void NewScore(string name, int score)
        {
            Person person = new Person();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(insertHighScore, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Score", score);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);




                    cmd.ExecuteNonQuery();
                   
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
