using System;
using System.Data;
using System.Data.SqlClient;

namespace SmfRewriteProject
{
	/// <summary>
	/// WebAppDataHandler handles all database operation request
	/// on the AppData database.
	/// </summary>
    public class WebAppDataHandler
    {

        private string _strCon;
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        public string ErrorMsgs;
        public enum DB_HITS { QUERY, INSERT, UPDATE, DELETE };

        #region Constructor

        public WebAppDataHandler()
        {
            _strCon = System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"];
        }

        public WebAppDataHandler(string ConnectionString)
        {
            _strCon = ConnectionString;
        }

        #endregion

        public void SQLexecute(string sql)
        {

            try
            {
                using ( _connection = new SqlConnection(_strCon))
                {
                    _connection.Open();

                    using ( _command = new SqlCommand(sql, _connection))
                    {
                         _reader = _command.ExecuteReader();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public bool NonQueryRequest(Object o)
        {
            IStorable data = o as IStorable;
            if (data != null)
            {
                using (_connection = new SqlConnection(_strCon))
                {

                    try
                    {
                        if (_connection.State == ConnectionState.Closed)
                        {
                            _connection.Open();
                        }                        
                        foreach (string sql in data.getNonQueryRequest())
                        {
                            using (_command = new SqlCommand(sql, _connection))
                            {
                                _command.ExecuteNonQuery();
                            }
                        }
                        return true;
                    }
                    catch (Exception ex)
                    {
                        this.ErrorMsgs = ex.Message;
                        return false;
                    }
                    finally
                    {
                        if (_connection.State == ConnectionState.Open)
                            _connection.Close();
                    }
                }
            }
            else
                return false;
        }

        public DataSet QueryRequest(Object o)
        {            		
			IStorable data = o as IStorable;
			if(data != null)
            {
				using (_connection = new SqlConnection(_strCon))
                {
				    try{
					       if(_connection.State ==  ConnectionState.Closed)
                           {
						        _connection.Open();
                           }
                           DataSet ds = new DataSet();
    					    foreach(string sql in data.getQueryRequest())
                            {
						        using ( _command = new SqlCommand(sql, _connection))
						        {
						            DataTable tbl = new DataTable();
                                    tbl.Load( _command.ExecuteReader());
                                    ds.Tables.Add(tbl);
                                }
                            }
						    return ds;
				        }
                    catch(Exception ex)
                        {
					        ErrorMsgs = ex.Message;
					        return null;
				        }
                    finally
                        {
					        if(_connection.State == ConnectionState.Open)
						        _connection.Close();
				        }
                }
			}
            else
            {
				return null;
		    }
        }

        public DataTable CreateTable(string sql)
        {
            DataTable dt;

            if (sql.Length == 0)
            {
                return null;
            }

            using (_connection = new SqlConnection(_strCon))
            {
                try
                {
                    if (_connection.State == ConnectionState.Closed)
                    {
                        _connection.Open();
                    }
                    using (_command = new SqlCommand(sql, _connection))
                    {
                        dt = new DataTable();
                        dt.Load(_command.ExecuteReader());                        
                    }
                }
                catch (Exception ex)
                {
                    this.ErrorMsgs = ex.Message;
                    return null;
                }
                finally
                {
                    if (_connection.State == ConnectionState.Open)
                        _connection.Close();
                }
            }

            return dt;
        }

        public DataSet CreateReport(Object o)
        {
            IReporter data = o as IReporter;
            if (data != null)
            {
                using (_connection = new SqlConnection(_strCon))
                {
                    try
                    {
                        if (_connection.State == ConnectionState.Closed)
                        {
                            _connection.Open();
                        }
                        DataSet ds = new DataSet();
                        foreach (string sql in data.getQueryRequest())
                        {
                            using (_command = new SqlCommand(sql, _connection))
                            {
                                DataTable tbl = new DataTable();
                                tbl.Load(_command.ExecuteReader());
                                ds.Tables.Add(tbl);
                            }
                        }
                        return ds;
                    }
                    catch (Exception ex)
                    {
                        this.ErrorMsgs = ex.Message;
                        return null;
                    }
                    finally
                    {
                        if (_connection.State == ConnectionState.Open)
                            _connection.Close();
                    }
                }
            }
            else
                return null;
        }

    }

}
