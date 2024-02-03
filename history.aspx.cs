using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class history : System.Web.UI.Page
{
    string conStr = @"Data Source=VERMA-LAPTOP\AMDGULMSSQLSERVE;Initial Catalog=caseDiary;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        panelFoundItem.Visible = false;
    }
    protected void btnSearchClient_Click(object sender, EventArgs e)
    {
        panelFoundItem.Visible = true;

        string searchClient = txtSearchClient.Text.Trim().ToString();
        if (searchClient != "")
        {
            string searchClient2 = "%" + searchClient + "%";

            SqlConnection sqlConSearchClient = new SqlConnection(conStr);
            string cmdStrSearchClient = @"SELECT [client_ID],[client_Name],[client_Gender],convert(varchar,[client_DOB],105) as [client_DOB], [client_Address],[client_Mobile1],[client_Mobile2],[comments],[files],[deleted_on] FROM [dbo].[client_Detail]
                                       WHERE [client_Detail].[isDeleted] = 1 AND ([client_ID] LIKE '" + searchClient2 + "' OR [client_Name] LIKE '" + searchClient2 + "' OR [client_Address] LIKE '" + searchClient2 + "' OR [client_Mobile1] LIKE '" + searchClient2 + "' OR [client_Mobile2] LIKE '" + searchClient2 + "' OR [comments] LIKE '" + searchClient2 + "') ";
            SqlDataAdapter searchClientAdp = new SqlDataAdapter(cmdStrSearchClient, sqlConSearchClient);
            DataTable searchClientDT2 = new DataTable();
            searchClientAdp.Fill(searchClientDT2);
            if (searchClientDT2.Rows.Count > 0)
            {
                GridViewSearchClient.DataSource = searchClientDT2;
                GridViewSearchClient.DataBind();
                lblSearchClient.Text = "";

            }

            else
            {
                lblSearchClient.Text = "NO CLIENT FOUND RELETED TO ABOVE SEARCH";

            }
        }
        else
        {
            lblSearchClient.Text = "FIRST FILL ABOVE FIELD !!!  ";
        }
    }
    protected void btnSearchCase_Click(object sender, EventArgs e)
    {
        panelFoundItem.Visible = true;

        string searchCase = txtSearchCase.Text.Trim().ToString();
        if (searchCase != "")
        {
            string searchCase2 = "%" + searchCase + "%";

            SqlConnection sqlConSearchCase = new SqlConnection(conStr);
            string cmdStrSearchCase = @"SELECT [case_ID],[client_ID],[court_Type],[case_Type],[case_Fess],[opponent_Name],[opponent_Address],[case_Court_Session],CONVERT(VARCHAR,[case_Date],105) AS [case_Date],
                                      [case_Court_No],[case_No],[description],CONVERT(VARCHAR,[deleted_on],105) AS [deleted_on] FROM [dbo].[case_detail] WHERE [case_detail].[isDeleted] = 1 AND  ([case_ID] LIKE '" + searchCase2 + "' OR [client_ID] LIKE '" + searchCase2 + "' OR [opponent_Name]  LIKE '" + searchCase2 + "' OR [opponent_Address]  LIKE '" + searchCase2 + "' OR [case_Court_Session] LIKE '" + searchCase2 + "'  OR [case_Date]  LIKE '" + searchCase2 + "' OR [case_Court_No]  LIKE '" + searchCase2 + "' OR [case_No]  LIKE '" + searchCase2 + "' OR [description]  LIKE '" + searchCase2 + "') ";
            SqlDataAdapter searchCaseAdp = new SqlDataAdapter(cmdStrSearchCase, sqlConSearchCase);
            DataTable searchCaseDT = new DataTable();
            searchCaseAdp.Fill(searchCaseDT);
            if (searchCaseDT.Rows.Count > 0)
            {
                GridViewSearchCase.DataSource = searchCaseDT;
                GridViewSearchCase.DataBind();
                lblSearchClient.Text = "";

            }
            else
            {
                lblSearchClient.Text = "NO CASE FOUND RELETED TO THE ABOVE SEARCH";
            }
        }
        else
        {
            lblSearchClient.Text = "FIRST FILL ABOVE FIELD !!!";
        }
    }

    protected void GridViewSearchClient_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "restore")
        {
            ClientDB client_Obj = new ClientDB();
            client_Obj._clientID = Convert.ToInt32(e.CommandArgument.ToString());
            int res = client_Obj.restoreClient();
            Response.Write("<script>alert('CLIENT DATA REMOVE SUCCESSFULY')</script>");
            Response.Redirect("history.aspx");
        }
        else
        {
            Response.Write("<script>alert('error occured')</script>");
        }
    }

    protected void GridViewSearchCase_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "restore")
        {
            caseDBClass case_Obj = new caseDBClass();
            long caseID2 = Convert.ToInt32(e.CommandArgument.ToString());
            int res = case_Obj.revokeDeletedCase(caseID2);
            Response.Write("<script>alert('CLIENT DATA REMOVE SUCCESSFULY')</script>");
            Response.Redirect("history.aspx");
        }
        else
        {
            Response.Write("<script>alert('error occured')</script>");
        }
    }



   
}