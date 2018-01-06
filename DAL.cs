using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace RealtyInterface
{
    public class DAL
    {
        public SqlConnection conn()
        {
            SqlConnection con = new SqlConnection(@"server=LAPTOP-HOQN5AAA\SQLEXPRESS; database=RealtyDB; integrated security=true;");
            con.Open();
            return con;
        }
        public SqlCommand cmd(string cmdLine)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn();
            cmd.CommandText = cmdLine;
            return cmd;
        }
        public int ExecuteCommand(string cmdLine)
        {
            return cmd(cmdLine).ExecuteNonQuery();
        }
        public int ExecuteCommand(string cmdLine, List<Parameters> parameters)
        {
            var command = cmd(cmdLine);
            foreach (var item in parameters)
            {
                command.Parameters.AddWithValue(item.Name, item.Value);
            }
            return command.ExecuteNonQuery();
        }

        public DataTable getDataTable(string cmdLine)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmdLine, conn());
            adp.Fill(dt);
            return dt;

        }
        public DataTable getDataTable(string cmdLine, int id)
        {
            var command = cmd(cmdLine);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmdLine, conn());
            adp.SelectCommand.Parameters.AddWithValue("@ID",id);
            adp.Fill(dt);
            return dt;

        }

    }

    public class Parameters
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
}
