using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class caseProfile : System.Web.UI.Page
{

    string conStr = @"Data Source=VERMA-LAPTOP\AMDGULMSSQLSERVE;Initial Catalog=caseDiary;Integrated Security=True";
    //long clientID;
    long caseID,caseID2;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.HasKeys())
        {
            if (Request.QueryString["cmd"].ToString() == "Profile")
            {

                caseID = Convert.ToInt64(Request.QueryString["CaseID"].ToString());
                

                if (!IsPostBack)
                {
                    //Response.Write("<script>alert('profile fetched successfully')</script>");

                    //fillClientProfile();
                    fetchCaseDetail();
                    getCaseHearing();
                }
            }


            // DELETED PRATITION


            if (Request.QueryString["cmd"].ToString() == "DeletedProfile")
            {

                caseID2 = Convert.ToInt64(Request.QueryString["CaseID"].ToString());
                btnAddHearing.Visible = false;
                btnEditCase.Text = "REVOKE";

                if (!IsPostBack)
                {
                    //Response.Write("<script>alert('profile fetched successfully')</script>");

                    //fillClientProfile();
                    fetchDeletedCaseDetail();
                    getCaseDeletedHearing();
                }
            }


        }

        //fetchCaseDetail();
    }

    protected void fetchCaseDetail()
    {
        SqlConnection sqlCon = new SqlConnection(conStr);
        string cmdStr = @"SELECT [case_ID],[client_ID],[court_Type],[case_Type],[case_Fess],[opponent_Name],[opponent_Address],[case_Court_Session],convert(varchar,[case_Date],105) as case_Date,[case_Court_No],[case_No],[description] FROM [dbo].[case_detail] WHERE  [case_ID] = " + caseID + " AND [case_detail].[isDeleted] = 0  ";
        SqlDataAdapter caseDataAdp = new SqlDataAdapter(cmdStr, sqlCon);
        DataTable caseDataTable = new DataTable();
        caseDataAdp.Fill(caseDataTable);
        if (caseDataTable.Rows.Count > 0)
        {
            dataListCaseDetail.DataSource = caseDataTable;
            dataListCaseDetail.DataBind();

            //panelAddCase.Visible = false;
            //panelCaseDisplay.Visible = true;

            

            int clientID =  Convert.ToInt32(caseDataTable.Rows[0]["client_ID"].ToString());
            string cmdStrClientName = @"SELECT [client_Name] FROM [dbo].[client_Detail] WHERE [client_ID] =" + clientID + " ";
            SqlDataAdapter clientNameDataAdp = new SqlDataAdapter(cmdStrClientName, sqlCon);
            DataTable clientNameDataTable = new DataTable();
            clientNameDataAdp.Fill(clientNameDataTable);
            lblClientName2.Text = clientNameDataTable.Rows[0]["client_Name"].ToString();            
            lblCaseID.Text = "Case ID : "+caseDataTable.Rows[0]["case_ID"].ToString();
            lblCourtType.Text = caseDataTable.Rows[0]["court_Type"].ToString();
            lblCourtSession.Text = caseDataTable.Rows[0]["case_Court_Session"].ToString();
            lblOppoAddress.Text = caseDataTable.Rows[0]["opponent_Address"].ToString();
            lblOppoName.Text = caseDataTable.Rows[0]["opponent_Name"].ToString();
            lblOppoName1.Text = caseDataTable.Rows[0]["opponent_Name"].ToString();
            lblCaseDate.Text = caseDataTable.Rows[0]["case_Date"].ToString();
            lblCaseDescription.Text = caseDataTable.Rows[0]["description"].ToString();
            lblCaseFees.Text = caseDataTable.Rows[0]["case_Fess"].ToString();
            lblCaseNumber.Text = caseDataTable.Rows[0]["case_No"].ToString();
            lblCaseType.Text = caseDataTable.Rows[0]["case_Type"].ToString();
            lblCourtNumber.Text = caseDataTable.Rows[0]["case_Court_No"].ToString();

            //Response.Write("<script>alert('string fetch more then 0 ')</script>");
        }

    }



    protected void btnEditCase_Click(object sender, EventArgs e)
    {
        Response.Write("<script>alert('edit btn clicked ')</script>");
        if (btnEditCase.Text == "REVOKE")
        {

           caseDBClass revokeCaseObj = new caseDBClass();
           int result = revokeCaseObj.revokeDeletedCase(caseID);
           if (result == 1)
           {
               Response.Write("<script>alert('CASE IS RECYCLE ')</script>");
           }
            
        }



        if (Request.QueryString.HasKeys())
        {
            if (Request.QueryString["cmd"].ToString() == "Profile")
            {

                Response.Redirect("addCase.aspx?case=Edit&&CaseID=" + caseID + "");

                //fillClientProfile();
            }


        }


    }
    protected void getCaseHearing()
    {
        SqlConnection sqlCon = new SqlConnection(conStr);
        string cmdStrHearing = @"SELECT [caseID],[courtNumber], convert(varchar, [hearingDate],105) as hearingDate,[magistrateName],[hearingStatus],convert(varchar,[nextHearingDate],105)as [nextHearingDate],[nextHearingTime],[HearingID]
                                FROM [dbo].[hearingCase] WHERE [caseID] = " + caseID + " AND [hearingCase].[isDeleted] = 0  ";
        SqlDataAdapter hearingAdp = new SqlDataAdapter(cmdStrHearing,sqlCon);
        DataTable hearingDT = new DataTable();
        hearingAdp.Fill(hearingDT);
        if (hearingDT.Rows.Count > 0)
        {
            HearingGridview.DataSource = hearingDT;
            HearingGridview.DataBind();
        }

    }

    protected void HearingGridview_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int hearingID;

        if (e.CommandName == "delete")
        {
            hearingID = Convert.ToInt32(e.CommandArgument.ToString());
            HearingDB OBJ = new HearingDB();
            OBJ._hearingID = hearingID;
            OBJ.deletedHearingData();
            Response.Redirect("caseProfile.aspx?cmd=Profile&&CaseID= " + caseID + " ");
            
        }


        if (e.CommandName == "edit")
        {
            hearingID = Convert.ToInt32(e.CommandArgument.ToString());            
            Response.Redirect("addHearing.aspx?Hearing=edit&&HearingID=" + hearingID + "");
        }
        
    }


    protected void btnAddHearing_Click(object sender, EventArgs e)
    {
        Response.Redirect("addHearing.aspx?cmd=new&&caseID=" + caseID + "");

    }


    protected void HearingGridview_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void fetchDeletedCaseDetail()
    {

        SqlConnection sqlCon = new SqlConnection(conStr);
        string cmdStr = @"SELECT [case_ID],[client_ID],[court_Type],[case_Type],[case_Fess],[opponent_Name],[opponent_Address],[case_Court_Session],convert(varchar,[case_Date],105) as case_Date,[case_Court_No],[case_No],[description],convert(varchar,[deleted_on],105) as [deleted_on] FROM [dbo].[case_detail] WHERE  [case_ID] = " + caseID2 + " AND [case_detail].[isDeleted] =1 ";
        SqlDataAdapter caseDataAdp = new SqlDataAdapter(cmdStr, sqlCon);
        DataTable caseDataTable = new DataTable();
        caseDataAdp.Fill(caseDataTable);
        if (caseDataTable.Rows.Count > 0)
        {
            dataListCaseDetail.DataSource = caseDataTable;
            dataListCaseDetail.DataBind();

            //panelAddCase.Visible = false;
            //panelCaseDisplay.Visible = true;



            int clientID = Convert.ToInt32(caseDataTable.Rows[0]["client_ID"].ToString());

            string cmdStrClientName2 = @"SELECT [client_Name] FROM [dbo].[client_Detail] WHERE [client_ID] =" + clientID + " ";
            SqlDataAdapter clientNameDataAdp2 = new SqlDataAdapter(cmdStrClientName2, sqlCon);
            DataTable clientNameDataTable2 = new DataTable();
            clientNameDataAdp2.Fill(clientNameDataTable2);
            if (clientNameDataTable2.Rows.Count > 0)
            {
                lblClientName2.Text = clientNameDataTable2.Rows[0]["client_Name"].ToString();
            }

            Label1.Text = "Deletd on : " + caseDataTable.Rows[0]["deleted_on"].ToString();
            lblCaseID.Text = "Case ID : " + caseDataTable.Rows[0]["case_ID"].ToString();
            lblCourtType.Text = caseDataTable.Rows[0]["court_Type"].ToString();
            lblCourtSession.Text = caseDataTable.Rows[0]["case_Court_Session"].ToString();
            lblOppoAddress.Text = caseDataTable.Rows[0]["opponent_Address"].ToString();
            lblOppoName.Text = caseDataTable.Rows[0]["opponent_Name"].ToString();
            lblOppoName1.Text = caseDataTable.Rows[0]["opponent_Name"].ToString();
            lblCaseDate.Text = caseDataTable.Rows[0]["case_Date"].ToString();
            lblCaseDescription.Text = caseDataTable.Rows[0]["description"].ToString();
            lblCaseFees.Text = caseDataTable.Rows[0]["case_Fess"].ToString();
            lblCaseNumber.Text = caseDataTable.Rows[0]["case_No"].ToString();
            lblCaseType.Text = caseDataTable.Rows[0]["case_Type"].ToString();
            lblCourtNumber.Text = caseDataTable.Rows[0]["case_Court_No"].ToString();

            //Response.Write("<script>alert('string fetch more then 0 ')</script>");
        }

 
    }



    protected void getCaseDeletedHearing()
    {
        SqlConnection sqlCon = new SqlConnection(conStr);
        string cmdStrHearing = @"SELECT [caseID],[courtNumber], convert(varchar, [hearingDate],105) as hearingDate,[magistrateName],
                                    [hearingStatus],convert(varchar,[nextHearingDate],105)as [nextHearingDate],[nextHearingTime],[HearingID],[deletedOnDate]
                                FROM [dbo].[hearingCase] WHERE [caseID] = " + caseID2 + " AND  [hearingCase].[isDeleted] = 1";
        SqlDataAdapter hearingAdp2 = new SqlDataAdapter(cmdStrHearing, sqlCon);
        DataTable hearingDT2 = new DataTable();
        hearingAdp2.Fill(hearingDT2);
        if (hearingDT2.Rows.Count > 0)
        {
            HearingGridview.DataSource = hearingDT2;
            HearingGridview.DataBind();
            btnAddHearing.Visible = false;
            btnEditCase.Visible = false;
        }

    }



}