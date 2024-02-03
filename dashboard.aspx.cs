using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class dashboard : System.Web.UI.Page
{
    string conStr = @"Data Source=VERMA-LAPTOP\AMDGULMSSQLSERVE;Initial Catalog=caseDiary;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        txtValueA.Text = totalClient().ToString();
        txtValueB.Text = totalCase().ToString();
        txtValueC.Text = todayHearing().ToString();
        txtValueD.Text = (todayHearing() + weakHearing() + afterWeakHearing()).ToString();


        todayHearing();
        weakHearing();
        afterWeakHearing();
        panelFoundItem.Visible = false;
    }
    protected int totalClient()
    {   
        SqlConnection sqlCon = new SqlConnection(conStr);
        string cmdStr = @"SELECT [client_ID] FROM [dbo].[client_Detail] WHERE [isDeleted] = 0 ";
        SqlDataAdapter clientDataAdp = new SqlDataAdapter(cmdStr, sqlCon);
        DataSet clientDataSet = new DataSet();
        clientDataAdp.Fill(clientDataSet);
        int i = clientDataSet.Tables[0].Rows.Count;
        //txtValueA.Text = i.ToString();
        return i;
    }
    protected int totalCase()
    {
        
        SqlConnection sqlCon = new SqlConnection(conStr);
        string cmdStr = @"SELECT [case_ID] FROM [dbo].[case_detail] JOIN [dbo].client_Detail ON case_detail.client_ID = client_Detail.client_ID WHERE [case_detail].[isDeleted] = 0   ";
        SqlDataAdapter clientDataAdp = new SqlDataAdapter(cmdStr, sqlCon);
        DataSet clientDataSet = new DataSet();
        clientDataAdp.Fill(clientDataSet);
        int i = clientDataSet.Tables[0].Rows.Count;
        //txtValueA.Text = i.ToString();
        return i;
    }

    protected int  todayHearing()
    {
        SqlConnection sqlConNotify = new SqlConnection(conStr);
        string cmdStrNotify = @"select client_Detail.client_ID,  client_Detail.client_Name,client_Detail.client_Mobile1,client_Detail.client_Mobile2,case_detail.opponent_Name, case_detail.case_ID,CONVERT(VARCHAR,hearingCase.nextHearingDate,105) AS nextHearingDate ,
                                hearingCase.nextHearingTime  from client_Detail join case_detail on client_Detail.client_ID=case_detail.client_ID join hearingCase on 
                                hearingCase.caseID = case_detail.case_ID where DATEDIFF(day, GETDATE(), hearingCase.nextHearingDate) = 0 AND [hearingCase].[isDeleted] = 0  order by nextHearingDate DESC ,nextHearingTime;";
        SqlDataAdapter notifyDataAdp = new SqlDataAdapter(cmdStrNotify, sqlConNotify);
        DataTable notifyDT = new DataTable();
        notifyDataAdp.Fill(notifyDT);

        if (notifyDT.Rows.Count > 0)
        {
            GridViewTodayNotification.DataSource = notifyDT;
            GridViewTodayNotification.DataBind();
            lblTodaysHearing.Text = "";
            return notifyDT.Rows.Count;

        }
        else 
        {
            lblTodaysHearing.Text = "THERE IS NO HEARING TODAY !";
            return 0;
        }


    }



    protected int weakHearing()
    {
        SqlConnection sqlConNotify2 = new SqlConnection(conStr);
        string cmdStrNotify2 = @"select client_Detail.client_ID,  client_Detail.client_Name,client_Detail.client_Mobile1,client_Detail.client_Mobile2,case_detail.opponent_Name, case_detail.case_ID,CONVERT(VARCHAR,hearingCase.nextHearingDate,105) AS nextHearingDate ,
                                hearingCase.nextHearingTime  from client_Detail join case_detail on client_Detail.client_ID=case_detail.client_ID join hearingCase on 
                                hearingCase.caseID = case_detail.case_ID where DATEDIFF(day, GETDATE(), hearingCase.nextHearingDate) between 1 and 6 AND [hearingCase].[isDeleted] = 0 order by nextHearingDate DESC ,nextHearingTime;";
        SqlDataAdapter notifyDataAdp2 = new SqlDataAdapter(cmdStrNotify2, sqlConNotify2);
        DataTable notifyDT2 = new DataTable();
        notifyDataAdp2.Fill(notifyDT2);
        if (notifyDT2.Rows.Count > 0)
        {
            GridViewHearingNotifyWeak.DataSource = notifyDT2;
            GridViewHearingNotifyWeak.DataBind();
            lblWeakHearing.Text = "";
            return notifyDT2.Rows.Count;
        }
        else 
        {
            lblWeakHearing.Text = "THERE IS NO HEARING IN THIS WEAK !";
            return 0;
        }


    }



    protected int afterWeakHearing()
    {
        SqlConnection sqlConNotify3 = new SqlConnection(conStr);
        string cmdStrNotify3 = @"select client_Detail.client_ID,  client_Detail.client_Name,client_Detail.client_Mobile1,client_Detail.client_Mobile2,case_detail.opponent_Name, case_detail.case_ID,CONVERT(VARCHAR,hearingCase.nextHearingDate,105) AS nextHearingDate ,
                                hearingCase.nextHearingTime  from client_Detail join case_detail on client_Detail.client_ID=case_detail.client_ID join hearingCase on 
                                hearingCase.caseID = case_detail.case_ID where DATEDIFF(day, GETDATE(), hearingCase.nextHearingDate) > 6 AND [hearingCase].[isDeleted] = 0 order by nextHearingDate DESC ,nextHearingTime;";
        SqlDataAdapter notifyDataAdp3 = new SqlDataAdapter(cmdStrNotify3, sqlConNotify3);
        DataTable notifyDT3 = new DataTable();
        notifyDataAdp3.Fill(notifyDT3);
        if (notifyDT3.Rows.Count > 0)
        {
            GridViewHearingNotifyAfter.DataSource = notifyDT3;
            GridViewHearingNotifyAfter.DataBind();
            lblAfterHearing.Text = "";
            return notifyDT3.Rows.Count;

        }
        else 
        {
            lblAfterHearing.Text = "THERE IS NO HEARING AFTER THIS WEAK !";
            return 0;
        }


    }





    protected void btnSearchClient_Click(object sender, EventArgs e)
    {
        panelFoundItem.Visible = true;

        string searchClient = txtSearchClient.Text.Trim().ToString();
        if (searchClient != "")
        {
            string searchClient2 = "%" + searchClient + "%";
            
            SqlConnection sqlConSearchClient = new SqlConnection(conStr);
            string cmdStrSearchClient = @"SELECT [client_ID],[client_Name],[client_Gender],CONVERT(VARCHAR,[client_DOB],105) AS [client_DOB],[client_Address],[client_Mobile1],[client_Mobile2],[comments],[files] FROM [dbo].[client_Detail] 
                                     WHERE client_ID LIKE '" + searchClient2 + "' OR client_Name LIKE '" + searchClient2 + "' OR client_Address LIKE '" + searchClient2 + "' OR client_Mobile1 LIKE '" + searchClient2 + "' OR client_Mobile2 LIKE '" + searchClient2 + "' OR comments LIKE '" + searchClient2 + "' AND [client_Detail].[isDeleted] = 0";
            SqlDataAdapter searchClientAdp = new SqlDataAdapter(cmdStrSearchClient, sqlConSearchClient);
            DataTable searchClientDT = new DataTable();
            searchClientAdp.Fill(searchClientDT);
            if (searchClientDT.Rows.Count > 0)
            {
                GridViewSearchClient.DataSource = searchClientDT;
                GridViewSearchClient.DataBind();
                lblSearchClient.Text = "";

            }
            
            else
            {
                lblSearchClient.Text = "NO CLIENT FOUND RELETED TO ABOVE SEARCH";
                //lblSearchClient.ForeColor = System.Drawing.Color.Red;

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
            string cmdStrSearchCase = @"SELECT [case_ID],[case_detail].[client_ID],[court_Type],[case_Type],[case_Fess],[opponent_Name],[opponent_Address],[case_Court_Session],[case_Date],[case_Court_No],[case_No],[description],[client_Detail].[client_Name]  FROM [dbo].[case_detail] JOIN [dbo].[client_Detail] ON [client_Detail].[client_ID] = [case_detail].[client_ID]
                                      WHERE [case_ID] LIKE '" + searchCase2 + "' OR [case_detail].[client_ID] LIKE '" + searchCase2 + "' OR [opponent_Name]  LIKE '" + searchCase2 + "' OR [opponent_Address]  LIKE '" + searchCase2 + "' OR [case_Court_Session] LIKE '" + searchCase2 + "'  OR [case_Date]  LIKE '" + searchCase2 + "' OR [case_Court_No]  LIKE '" + searchCase2 + "' OR [case_No]  LIKE '" + searchCase2 + "' OR [description]  LIKE '" + searchCase2 + "' AND [case_detail].[isDeleted] = 0  ";
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
}