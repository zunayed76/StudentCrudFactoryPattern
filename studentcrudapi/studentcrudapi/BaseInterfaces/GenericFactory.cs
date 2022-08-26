using studentcrudapi.BaseFactories;
using studentcrudapi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace studentcrudapi.BaseInterfaces
{
    public class GenericFactory<C, T> : iGenericFactory<T>
        where T : class
        where C : scDBEntities, new()
    {
        private C _dbctx = new C();
        protected C Context
        {
            get { return _dbctx; }
            set { _dbctx = value; }
        }

        /// <summary>
        /// Insert/Update/Delete Data To Database
        /// Get int Data after CRUD
        /// <para>Use it when to Insert/Update/Delete data through a stored procedure</para>
        /// </summary>

        public virtual string ExecuteCommandString(string spQuery, Hashtable ht, int iid)
        {
            string result = "successfull";

            var temp = false;
            try
            {
                //int value;
                if (iid == 0)
                {
                    using (_dbctx.Database.Connection)
                    {
                        _dbctx.Database.Connection.Open();
                        DbCommand cmd = _dbctx.Database.Connection.CreateCommand();
                        cmd.CommandText = spQuery;
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (object obj in ht.Keys)
                        {
                            string str = Convert.ToString(obj);
                            if (str == "id")
                                continue;
                            System.Data.SqlClient.SqlParameter parameter = new SqlParameter("@" + str, ht[obj]);
                            cmd.Parameters.Add(parameter);
                        }

                        IDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            result = Convert.ToString(dr.GetString(0));
                        }

                        //cmd.Parameters.Clear();
                        cmd.ExecuteNonQuery();
                        temp = true;
                    }
                }
                else
                {
                    using (_dbctx.Database.Connection)
                    {
                        _dbctx.Database.Connection.Open();
                        DbCommand cmd = _dbctx.Database.Connection.CreateCommand();
                        cmd.CommandText = "UpdateData";
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (object obj in ht.Keys)
                        {
                            string str = Convert.ToString(obj);
                            System.Data.SqlClient.SqlParameter parameter = new SqlParameter("@" + str, ht[obj]);
                            cmd.Parameters.Add(parameter);
                        }

                        IDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            result = Convert.ToString(dr.GetString(0));
                        }

                        //cmd.Parameters.Clear();
                        cmd.ExecuteNonQuery();
                        temp = true;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
                //e.Message.ToString();
                //e.StackTrace.ToString();
            }
            if (temp)
            {
                return result;
            }
            return " It didn't work";

        }
        //public virtual string ExecuteCommandString1(string spQuery, Hashtable ht)
        //{
        //    string result = "successfull";

        //    var temp = false;
        //    try
        //    {
        //        //int value;
        //            using (_dbctx.Database.Connection)
        //            {
        //                _dbctx.Database.Connection.Open();
        //                DbCommand cmd = _dbctx.Database.Connection.CreateCommand();
        //                cmd.CommandText = spQuery;
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                string str = "id";
        //                System.Data.SqlClient.SqlParameter parameter = new SqlParameter("@" + str, ht["id"]);
        //                cmd.Parameters.Add(parameter);
        //                IDataReader dr = cmd.ExecuteReader();
        //                if (dr.Read())
        //                {
        //                    result = Convert.ToString(dr.GetString(0));
        //                }

        //                //cmd.Parameters.Clear();
        //                cmd.ExecuteNonQuery();
        //                temp = true;
        //            }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //        //e.Message.ToString();
        //        //e.StackTrace.ToString();
        //    }
        //    if (temp)
        //    {
        //        return result;
        //    }
        //    return " It didn't work";

        //}






        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    _dbctx.Dispose();
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public List<Item> ExecuteQuery()
        {
           /* var db = new AngularUnitEntities();
            var data = db.ShowData();
            return data.ToList();*/
            
            List<Item> lst = new List<Item>();
            using (_dbctx.Database.Connection)
            {

                _dbctx.Database.Connection.Open();
                DbCommand cmd = _dbctx.Database.Connection.CreateCommand();
                cmd.CommandText = "ShowData";
                cmd.CommandType = CommandType.StoredProcedure;

              
                /*
                                    IDataReader dr = cmd.ExecuteReader();
                                    if (dr.Read())
                                    {
                                        result = Convert.ToString(dr.GetString(0));
                                    }
                    
                                    //cmd.Parameters.Clear();*/
                
                IDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    lst.Add(new Item
                    {
                        id=Convert.ToInt32(dr["id"]),
                        firstName = dr["firstName"].ToString(),
                        lastName = dr["lastName"].ToString(),
                        dob = dr["dob"].ToString(),
                        sub1 = dr["sub1"].ToString(),
                        num1 = Convert.ToInt32(dr["num1"]),
                        sub2 = dr["sub2"].ToString(),
                        num2 = Convert.ToInt32(dr["num3"]),
                        sub3 = dr["sub3"].ToString(),
                        num3 = Convert.ToInt32(dr["num3"]),
                        sub4 = dr["sub4"].ToString(),
                        num4 = Convert.ToInt32(dr["num4"])
                    });
                }
            
            }
            return lst;

        }
    }
}