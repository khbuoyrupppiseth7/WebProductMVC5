using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
public class Dbaccess_StoredProcedure
{

    private SqlConnection cnn = new SqlConnection();

    private bool handleErrors = false;
    private string strLastError = "";

    private SqlCommand cmd;
    public Dbaccess_StoredProcedure()
    {
        cnn = new System.Data.SqlClient.SqlConnection();
        string strConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //strConnectionString = "Data Source=ROTHA-PC\\SQLEXPRESS;Initial Catalog=Att_DB;Persist Security Info=True;User ID=sa;Password=piseth123;";
        
        cnn.ConnectionString = strConnectionString;
        cmd = new SqlCommand();
        cmd.Connection = cnn;
        cmd.CommandType = CommandType.StoredProcedure;
        //Type of Store
    }
    public void open()
    {
        if (cnn.State == ConnectionState.Closed)
        {
                cnn.Open();
        }
    }
    public void close()
    {
        cnn.Close();
    }


    public int ExecuteNoneQuery(string CommandText)
    {
        cmd.CommandText = CommandText;
        this.open();
        int i = cmd.ExecuteNonQuery();
        this.close();
        return i;
    }
    public int ExecuteNoneQuery_Keep_Connection(string CommandText)
    {
        cmd.CommandText = CommandText;
        int i = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        return i;
    }

    public DataTable ExecuteNoneQuery_Keep_Connection_Return_DataTable(string CommandText)
    {
        //cmd.CommandText = CommandText
        //Dim i As Integer = cmd.ExecuteNonQuery()
        //cmd.Parameters.Clear()
        //Return i
        cmd.CommandText = CommandText;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        da.Fill(ds);
        cmd.Parameters.Clear();
        return ds.Tables[0];
    }

    public DataSet ExecuteDataSet()
    {
        SqlDataAdapter da = null;
        DataSet ds = null;
        try
        {
            da = new SqlDataAdapter();
            da.SelectCommand = (SqlCommand)cmd;
            ds = new DataSet();
            da.Fill(ds);
        }
        catch (Exception ex)
        {
            if (handleErrors)
                strLastError = ex.Message;
            else
                throw;
        }
        catch
        {
            throw;
        }

        return ds;
    }

    //------------------dataset
    public DataSet ExecuteDataSet(string commandtext)
    {
        DataSet ds = null;
        try
        {
            cmd.CommandText = commandtext;
            ds = this.ExecuteDataSet();
        }
        catch (Exception ex)
        {
            if (handleErrors)
                strLastError = ex.Message;
            else
                throw;
        }
        catch
        {
            throw;
        }
        return ds;
    }
    //----------------------------

    public object ExecuteScalar(string CommandText)
    {
        cmd.CommandText = CommandText;
        this.open();
        object obj = null;
        obj = cmd.ExecuteScalar();

        this.close();
        return obj;
    }

    public SqlDataReader ExecuteDataReader(string CommandText)
    {
        cmd.CommandText = CommandText;
        this.open();
        SqlDataReader dr = null;
        dr = cmd.ExecuteReader();
        this.close();
        return dr;
    }
    public void AddParameter(string ParamName, object ObjParam)
    {
        cmd.Parameters.AddWithValue(ParamName, ObjParam);
    }

    public void AddParameter(SqlParameter ObjParam)
    {
        cmd.Parameters.Add(ObjParam);
    }


    public void _AA_Update_To_tblLogin_Time(int EmployeeID, string ClocK_Log)
    {
        //fsfdf()
        //Dim strConnectionString As String = ""
        //Dim cnn As New SqlConnection()
        //strConnectionString = "data source=" + My.Settings.DataSource + ";Database=" + My.Settings.Database + ";uid=" + My.Settings.UserName + ";Password=" + My.Settings.Password
        //cnn = New SqlClient.SqlConnection
        //cnn.ConnectionString = strConnectionString
        //cnn.Open()
        //Dim Str As String = "AA_Update_To_tblLogin_Time"
        //Dim cmd As SqlCommand = New SqlCommand()
        //cmd.Connection = cnn
        //cmd.CommandType = CommandType.StoredProcedure
        //cmd.Parameters.Add(New SqlParameter("@EmpID", EmployeeID))
        //cmd.Parameters.Add(New SqlParameter("@ClockLog", ClocK_Log))
        //cmd.CommandText = Str
        //Try
        //    cmd.ExecuteNonQuery()
        //Catch ex As Exception

        //End Try
        //cnn.Close()
    }
}