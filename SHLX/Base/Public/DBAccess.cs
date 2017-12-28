﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CYQ.Data;

namespace Redsoft
{
    public class DBAccess
    {
        public static void ExecSP(string procName, List<IDbDataParameter> paras, ref List<IDbDataParameter> outparas)
        {
            MAction action = new MAction("login_user");

            SqlConnection conn = new SqlConnection(action.ConnectionString);
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;
            try
            {
                sqlCommand.CommandText = procName;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < paras.Count; i++)
                {
                    sqlCommand.Parameters.Add(paras[i]);

                }
                for (int i = 0; i < outparas.Count; i++)
                {
                    sqlCommand.Parameters.Add(outparas[i]);

                }
                sqlCommand.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            finally
            {

                conn.Close();
            }

        }
        public static DataSet Query(string sql)
        {
            MAction action = new MAction("login_user");
            SqlConnection mySql = new SqlConnection(action.ConnectionString);
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(sql, mySql);
            mySql.Open();
            DataSet ds = new DataSet();
            mySqlDataAdapter.Fill(ds, "Table1");
            return ds;
        }
        public static string ExecSP(string procName, List<IDbDataParameter> paras)
        {
            string result = string.Empty;
            MAction action = new MAction("login_user");

            SqlConnection conn = new SqlConnection(action.ConnectionString);
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            sqlCommand.Connection = conn;
            try
            {
                sqlCommand.CommandText = procName;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = sqlCommand;

                for (int i = 0; i < paras.Count; i++)
                {
                    sqlCommand.Parameters.Add(paras[i]);

                }
                sqlCommand.ExecuteNonQuery();
                if (ds != null)
                    adapter.Fill(ds);
                result = Convert.ToString(ds.Tables[0].Rows[0][0]);
            }
            catch
            {
                throw;
            }
            finally
            {

                conn.Close();
            }
            return result;
        }
        public static DataRow Query(string sql, List<IDbDataParameter> paras)
        {
            DataRow result;
            MAction action = new MAction("login_user");

            SqlConnection conn = new SqlConnection(action.ConnectionString);
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            sqlCommand.Connection = conn;
            try
            {
                sqlCommand.CommandText = sql;
                sqlCommand.CommandType = CommandType.Text;
                adapter.SelectCommand = sqlCommand;

                for (int i = 0; i < paras.Count; i++)
                {
                    sqlCommand.Parameters.Add(paras[i]);

                }
                sqlCommand.ExecuteNonQuery();
                if (ds != null)
                    adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                    result = ds.Tables[0].Rows[0];
                else
                    return null;
            }
            catch
            {
                throw;
            }
            finally
            {

                conn.Close();
            }
            return result;
        }
    }
}
