using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;


/// <summary>
/// Summary description for DataLayer
/// </summary>
public class DataLayer
{
	public static void AddKeyword(string keyword, int id,string path)
    {
        OleDbConnection conn = GetConnection(path);
        string strAccessInsert = "insert into tbl_Keywords(Keyword,UserID) values(@keyword,@id)";
        OleDbCommand command = conn.CreateCommand();
        command.Parameters.AddWithValue("keyword", keyword.ToLower()).DbType = DbType.String;
        command.Parameters.AddWithValue("id", id).DbType = DbType.Int32;
        command.CommandText = strAccessInsert;
        command.Connection = conn;
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }

    public static string[] GetKeywords(int id, string path)
    {
        OleDbConnection conn = GetConnection(path);
        string strAccess = "select keyword from tbl_Keywords where UserID=@id";
        OleDbCommand command = conn.CreateCommand();
        command.Parameters.AddWithValue("id", id).DbType = DbType.Int32;
        command.CommandText = strAccess;
        command.Connection = conn;
        conn.Open();
        OleDbDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select count(*) from  tbl_Keywords where UserID=@uid";
            cmd.Parameters.AddWithValue("uid", id).DbType = DbType.Int32;
            int count = (int)cmd.ExecuteScalar();
            string[] result = new string[count];
            int i = 0;
            while (reader.Read())
            {
                result[i++] = reader.GetString(0);
            }
            conn.Close();
            return result;
        }
        else
        {
            conn.Close();
            return null;
        }
        
    }

    public static OleDbConnection GetConnection(string path)
    {
        //string strAccessConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\BugTypes.MDB";
        string strAccessConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
               
        OleDbConnection myAccessConn = null;
        try
        {
                myAccessConn = new OleDbConnection(strAccessConn);
        }
        catch(Exception ex)
        {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                return null;
        }
        return myAccessConn;
    }
}