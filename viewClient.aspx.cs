using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class viewClient : System.Web.UI.Page
{
    string conStr = @"Data Source=VERMA-LAPTOP\AMDGULMSSQLSERVE;Initial Catalog=caseDiary;Integrated Security=True";
    long clientID;
    protected void Page_Load(object sender, EventArgs e)
    {
        showClientDetail();
        if (Request.QueryString.HasKeys())
        {


            if (!IsPostBack)
            {
                Response.Redirect("viewClient.aspx");
            }
        }
    }
    protected void showClientDetail()
    {

        SqlConnection sqlCon = new SqlConnection(conStr);
        string cmdStr = @"SELECT [client_ID],[client_Name],[client_Gender],convert(varchar,[client_DOB],105) as [client_DOB], [client_Address],[client_Mobile1],[client_Mobile2],
                            [comments],[files] FROM [dbo].[client_Detail] WHERE [client_Detail].[isDeleted]= 0 ";
        SqlDataAdapter clientDataAdp = new SqlDataAdapter(cmdStr, sqlCon);
        DataSet clientDataSet = new DataSet();
        clientDataAdp.Fill(clientDataSet);
        if (clientDataSet.Tables[0].Rows.Count > 0)
        {
            clientDataGridview.DataSource = clientDataSet;
            clientDataGridview.DataBind();
        }
    }

    protected void clientDataGridview_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            ClientDB client_Obj = new ClientDB();
            client_Obj._clientID = Convert.ToInt32(e.CommandArgument.ToString());
            int res = client_Obj.deleteClientData();
            Response.Write("<script>alert('CLIENT DATA REMOVE SUCCESSFULY')</script>");
            Response.Redirect("viewClient.aspx");
        }
        else 
        {
            Response.Write("<script>alert('error occured')</script>");
        }
    }
    protected void clientDataGridview_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}