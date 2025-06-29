using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Scan_Box.Common
{
    class SQL_Execute
    {
        private SqlConnection connection;

        private void Connect(string server)
        {
            string TextConnect = "";
            if (server == "10.80.1.46")
            {
                TextConnect = @"Data Source=" + server + " ; database = PIMD; Uid = pim; Pwd = pimpass; MultipleActiveResultSets=True";
            }
            else if (server == "10.80.1.69")
            {
                TextConnect = @"Data Source=" + server + " ; database = PIMD; Uid = pim; Pwd = pimpass; MultipleActiveResultSets=True";
            }
            else if (server == "10.80.1.48" || server == "10.80.56.2")
            {
                TextConnect = @"Data Source=" + server + " ; database = PIMV; Uid = pim; Pwd = pimpass; MultipleActiveResultSets=True";
            }

            //string TextConnect = WebConfigurationManager.ConnectionStrings["Str_Conn"].ToString();

            try
            {
                connection = new SqlConnection(TextConnect);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch
            {
                Console.WriteLine("Loi khong ket noi duoc toi ");
            }
        }

        private void CloseConnect()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public bool PingServer(string IPAddress_)
        {
            try
            {
                var ping = new Ping();
                var pingReply = ping.Send(IPAddress_);
                if (pingReply.Status == IPStatus.Success)
                    return true;
                else return false;
            }
            catch { return false; }
        }
        public void Execute_NonSQL(string server, string sql)
        {
            try
            {
                this.Connect(server);
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                this.CloseConnect();
            }
        }

        #region Store Procedure TuanVH

        public DataTable Execute_StoreProcedure_NoAsync(string server, string spName, string[] parameters, string[] values)
        {
            DataTable dt;
            try
            {
                this.Connect(server);
                SqlCommand cmd = new SqlCommand(spName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p;
                if (parameters.Length > 0)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        p = new SqlParameter(parameters[i], values[i]);
                        cmd.Parameters.Add(p);
                    }
                }
                SqlDataReader reader = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            finally
            {
                this.CloseConnect();
            }
        }

        public async Task<DataTable> Execute_StoreProcedure_Async(string server, string spName, string[] parameters, string[] values)
        {
            DataTable dt;
            try
            {
                this.Connect(server);
                SqlCommand cmd = new SqlCommand(spName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p;
                if (parameters.Length > 0)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        p = new SqlParameter(parameters[i], values[i]);
                        cmd.Parameters.Add(p);
                    }
                }
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            finally
            {
                this.CloseConnect();
            }
        }

        public void ExecuteSP_NoAsync(string server, string sp_name, string[] parameters, object[] values)
        {
            try
            {
                this.Connect(server);
                SqlCommand cmd = new SqlCommand(sp_name, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter p;
                for (int i = 0; i < parameters.Length; i++)
                {
                    p = new SqlParameter(parameters[i], values[i]);
                    cmd.Parameters.Add(p);
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnect();
            }
        }

        public async Task ExecuteSP_Async(string server, string sp_name, string[] parameters, string[] values)
        {
            try
            {
                this.Connect(server);
                SqlCommand cmd = new SqlCommand(sp_name, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter p;
                for (int i = 0; i < parameters.Length; i++)
                {
                    p = new SqlParameter(parameters[i], values[i]);
                    cmd.Parameters.Add(p);
                }
                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnect();
            }
        }

        public DateTime GetNow(string server)
        {
            try
            {
                this.Connect(server);
                var cmd = new SqlCommand("SELECT GETDATE()", connection);
                var dt = (DateTime)cmd.ExecuteScalar();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnect();
            }
        }

        public DataTable Execute_DataTable(string server, string sqlQuery)
        {
            this.Connect(server);
            try
            {
                using (SqlDataAdapter dap = new SqlDataAdapter(sqlQuery, connection))
                {
                    using (DataSet ds = new DataSet())
                    {
                        dap.Fill(ds);
                        return ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnect();
            }
        }

        public DataTable Execute_DataTable_Paging(string server, string sqlQuery, int firstRow, int pageSize, string table)
        {
            this.Connect(server);
            try
            {
                using (SqlDataAdapter dap = new SqlDataAdapter(sqlQuery, connection))
                {
                    using (DataSet ds = new DataSet())
                    {
                        dap.Fill(ds, firstRow, pageSize, table);
                        return ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnect();
            }
        }

        public string Connection(string server)
        {
            string TextConnect = "";
            if (server == "10.80.1.48" || server == "10.80.56.2")
            {
                TextConnect = @"Data Source=" + server + " ; database = PIMV; Uid = pim; Pwd = pimpass; MultipleActiveResultSets=True";
            }
            else
            {
                TextConnect = @"Data Source=" + server + " ; database = PIMD; Uid = pim; Pwd = pimpass; MultipleActiveResultSets=True";
            }
            //string TextConnect = WebConfigurationManager.ConnectionStrings["Str_Conn"].ToString();
            return TextConnect;
        }



    }
    #endregion
}
