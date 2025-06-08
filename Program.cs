using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace SQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AgentDAL agentDAL = new AgentDAL();
            List<Agent> agents = new List<Agent>()
            {
               new Agent("12", "berale", "bny brak", "active", 2),
               new Agent("13", "berale2", "bny brak", "active", 4),
               new Agent("14", "berale3", "bny brak", "active", 6),
            };
            foreach (Agent agent in agents)
            {
                agentDAL.AddAgent(agent);

            }
            agentDAL.DeleteAgent(4);

            List<Agent> agents1 = new List<Agent>();
            agents1 = agentDAL.SearchAgentByCode("12");
            foreach (Agent agent1 in agents1)
            {
                Console.WriteLine(agent1.RealName);
            }

            foreach(KeyValuePair<string, int> keyValuePair in agentDAL.CountAgentsbystaus("active"))
            {
                Console.WriteLine(keyValuePair.Key +" = "+ keyValuePair.Value);
            }




        }
    }
}
            //string connectionString =
            //    "server=localhost;" +
            //    "user=root;"+
            //    "database=murder;"+
            //    "port=3306;";
            //MySqlConnection connection = new MySqlConnection(connectionString);
            //string sql = "SELECT * FROM hospital_report";

            //try
            //{
            //    connection.Open();
            //    MySqlCommand cmd = new MySqlCommand(sql, connection);

            //    MySqlDataReader reader = cmd.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        Console.WriteLine($"{reader["id"]} - {reader["diagnosis"]} ");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


           
