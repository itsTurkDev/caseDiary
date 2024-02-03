using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class viewCase : System.Web.UI.Page
{
    string conStr = @"Data Source=VERMA-LAPTOP\AMDGULMSSQLSERVE;Initial Catalog=caseDiary;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        displayCase();
    }

    protected void displayCase()
    {
        SqlConnection sqlcon = new SqlConnection(conStr);
        string cmdStr = @"SELECT [case_ID],case_detail.[client_ID],client_Detail.[client_Name],[court_Type],[case_Type],[case_Fess],[opponent_Name],[opponent_Address],
                        [case_Court_Session],[case_Date],[case_Court_No],[case_No],[description] FROM [dbo].[case_detail] JOIN [dbo].client_Detail ON 
                        case_detail.client_ID = client_Detail.client_ID WHERE [case_detail].[isDeleted] = 0 " ;
        SqlDataAdapter sqlAdp = new SqlDataAdapter(cmdStr,sqlcon);
        DataTable caseDT = new DataTable();
        sqlAdp.Fill(caseDT);

        if (caseDT.Rows.Count > 0)
        {
            GridView1.DataSource = caseDT;
            GridView1.DataBind();
        }



    }

    protected void Gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Response.Write("<script>alert('cmd to delete case is fired ')</script>");

        if (e.CommandName == "delete")
        {
            caseDBClass case_Obj = new caseDBClass();
            case_Obj._caseID= Convert.ToInt32(e.CommandArgument.ToString());
            int res = case_Obj.deleteCaseDetail();
            Response.Write("<script>alert(res+'CASE DATA REMOVE SUCCESSFULY')</script>");
            Response.Redirect("viewCase.aspx");
        }
        else
        {
            Response.Write("<script>alert('error occured')</script>");
        }
    }



    
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }


}