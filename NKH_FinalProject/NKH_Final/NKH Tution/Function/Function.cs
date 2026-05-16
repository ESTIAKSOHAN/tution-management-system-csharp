using System.Data;
using Microsoft.Data.SqlClient;

namespace NKH_Tution.Function
{
    public class Functions
    {
        // CONNECTION STRING

        private readonly string ConStr =
           "Data Source=(LocalDB)\\MSSQLLocalDB;" +
           "AttachDbFilename=\"C:\\Users\\Estiak\\Documents\\NKH DB.mdf\";" +
           "Integrated Security=True;" +
           "Connect Timeout=30;";
        

        public DataTable GetData(string query, SqlParameter[]? parameters = null)
        {
            using SqlConnection con = new SqlConnection(ConStr);
            using SqlCommand cmd = new SqlCommand(query, con);
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            using SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }  //query + optional peramiter nibe

        public int ExecuteQuery(string query, SqlParameter[]? parameters = null)
        {
            using SqlConnection con = new SqlConnection(ConStr);
            using SqlCommand cmd = new SqlCommand(query, con);
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public bool TestConnection()
        {
            try
            {
                using SqlConnection con = new SqlConnection(ConStr);
                con.Open();
                return true;
            }
            catch { return false; }
        }
    }
}
