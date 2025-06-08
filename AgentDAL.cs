using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SQL
{
    internal class AgentDAL
    {
        string stringConnection =
            "server=localhost;" +
            "user=root;" +
            "database=egaleeyedb;" +
            "port=3306;";

       
        public AgentDAL() { }

        public void AddAgent(Agent agent)
        {
            
           

            string query = "INSERT INTO agents(codeName, realName, location, status, missionsCompleted)" +
                "VALUES(@codeName, @realName, @location, @status, @missionsCompleted)";
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@codeName", agent.CodeName);
            cmd.Parameters.AddWithValue("@realName", agent.RealName);
            cmd.Parameters.AddWithValue("@location", agent.Location);
            cmd.Parameters.AddWithValue("@status", agent.Status);
            cmd.Parameters.AddWithValue("@missionsCompleted", agent.MissionsCompleted);

            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public List<Agent> GetAllAgents()
        {
            List < Agent > agents = new List < Agent >();

            string query = "SELECT * FROM agents;";
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            
            
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                agents.Add(new Agent(
                    reader.GetString("codeName"),
                    reader.GetString("realName"),
                    reader.GetString("location"),
                    reader.GetString("status"),
                    reader.GetInt32("missionsCompleted")
                    )
                    );

            }
            reader.Close();
            conn.Close();
            return agents;
            
          


            
            

        }


        public void UpdateAgentLocation(int agentId, string newLocation)
        {
            
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            string query = "UPDATE agent SET location = @location WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", agentId);
            cmd.Parameters.AddWithValue("@location", newLocation);
            cmd.ExecuteNonQuery();
            conn.Close();
            


        }
        public void DeleteAgent(int agentId)
        {
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            string query = "DELETE FROM agents WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", agentId);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public List<Agent> SearchAgentByCode(string codeName)
        {
            List<Agent> agents = new List<Agent>();
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            string query = "SELECT * FROM agents WHERE codeName = @codeName";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@codename", codeName);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                agents.Add(new Agent
                    (
                    reader.GetString("codeName"),
                    reader.GetString("realName"),
                    reader.GetString("location"),
                    reader.GetString("status"),
                    reader.GetInt32("missionscompleted")

                    ));

            }

            conn.Close();
            return agents;

        }

        public Dictionary<string, int> CountAgentsbystaus(string status)
        {
            Dictionary<string, int> countByStatus = new Dictionary<string, int>();
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            string query = "SELECT status, COUNT(status) as counter FROM agents WHERE status = @status;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@status", status);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                countByStatus.Add(reader.GetString("status"), reader.GetInt32("counter"));
            }

            
            
            return countByStatus;

            
        }

        public void AddMissionCount(int missionId, int missionsTuAdd)
        {
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            string query = null;
            MySqlCommand cmd = new MySqlCommand(query, conn);
        }
    }
}

