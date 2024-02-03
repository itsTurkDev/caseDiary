using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class addHearing : System.Web.UI.Page
{
    long HearingID;
    string conStr = @"Data Source=VERMA-LAPTOP\AMDGULMSSQLSERVE;Initial Catalog=caseDiary;Integrated Security=True";
    int caseID;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.HasKeys())
        {
            if (Request.QueryString["cmd"].ToString() == "new")
            {
                caseID = Convert.ToInt32(Request.QueryString["caseID"].ToString());
                //cleanTextBox();
                txtCaseID.Text = caseID.ToString();
            }

            if (Request.QueryString["cmd"].ToString() == "edit")
            {

                HearingID = Convert.ToInt64(Request.QueryString["HearingID"].ToString());


                if (!IsPostBack)
                {
                    
                    fetchHearingData();
                    btnSaveCaseHearing.Text = "UPDATE HEARING DATA";
             
                }
            }
        }

    }

    protected void saveHearing()
    {
        int result;


        // ASIGN PROPERTIS

        HearingDB hearingObj = new HearingDB();
        hearingObj._caseID = Convert.ToInt32(txtCaseID.Text.Trim());
        hearingObj._courtNumber = Convert.ToInt64(Convert.ToString(txtCourtNumber12.Text)); 
        hearingObj._hearingDate = txtHearingDate.Text.Trim();
        hearingObj._hearingStatus = txtHearingStatus.Text.Trim();
        hearingObj._magistrateName = txtMagistrateName.Text.Trim();
        hearingObj._nextHearingDate = txtNxtHearingDate.Text.Trim();
        hearingObj._nextHearingTime = txtNxtHearingTime.Text.Trim();
        
        // CHECK DATE OF HEARINGS 

        var hearingDate = DateTime.Parse(txtHearingDate.Text);
        var today = DateTime.Now;
        var difDate =today - hearingDate ;
        int check = difDate.Days;
        if (check > 3)
        {
            Response.Write("<script>alert('HEARING DATE IS NOT CORRECT ')</script>");
            result = 0;
        }
        else
        {

            var nxtHearingDate = DateTime.Parse(txtNxtHearingDate.Text);
            var diffInHearingDate = hearingDate - nxtHearingDate;
            int check2 = diffInHearingDate.Days;
            if(check2 > 0)
            {
                Response.Write("<script>alert('NEXT HEARING DATE CANNOT BEFORE TODAYS'S HEARING')</script>");

            }
            else
            {
                result = hearingObj.saveHearingData();

                if (result == 1)
                {
                    Response.Write("<script>alert('CASE HEARING ADD  SUCCESSFULLY')</script>");
                    
                    Response.Redirect("caseProfile.aspx?cmd=Profile&&CaseID=" + caseID + "");
                }
                else
                {
                    Response.Write("<script>alert('CASE ID IS NOT CORRECT')</script>");
                }
            }
        }
        
    }

    protected void cleanTextBox()
    {
        txtCaseID.Text = "";
        txtCourtNumber12.Text = "";
        txtHearingDate.Text = "";
        txtHearingStatus.Text = "";
        txtMagistrateName.Text = "";
        txtNxtHearingDate.Text = "";
        txtNxtHearingTime.Text = "";

    }



    protected void btnSaveCaseHearing_Click(object sender, EventArgs e)
    {
        if (btnSaveCaseHearing.Text == "UPDATE HEARING DATA")
        {
            int res;
               
            // ASIGN PROPERTIES

            HearingDB hearingObj = new HearingDB();
            hearingObj._hearingID = HearingID;
            hearingObj._caseID = Convert.ToInt32(txtCaseID.Text.Trim());            
            hearingObj._courtNumber = Convert.ToInt64(Convert.ToString(txtCourtNumber12.Text));           
            hearingObj._hearingDate = txtHearingDate.Text.Trim();
            hearingObj._hearingStatus = txtHearingStatus.Text.Trim();
            hearingObj._magistrateName = txtMagistrateName.Text.Trim();
            hearingObj._nextHearingDate = txtNxtHearingDate.Text.Trim();
            hearingObj._nextHearingTime = txtNxtHearingTime.Text.Trim();

            // CHECK DATE OF HEARINGS 

            var hearingDate = DateTime.Parse(txtHearingDate.Text);
            var today = DateTime.Now;
            var difDate = today - hearingDate;
            int check = difDate.Days;
            if (check > 3)
            {
                Response.Write("<script>alert('HEARING DATE IS NOT CORRECT ')</script>");
                res = 0;
            }
            else
            {

                var nxtHearingDate = DateTime.Parse(txtNxtHearingDate.Text);
                var diffInHearingDate = hearingDate - nxtHearingDate;
                int check2 = diffInHearingDate.Days;
                if (check2 > 0)
                {
                    Response.Write("<script>alert('NEXT HEARING DATE CANNOT BEFORE TODAYS'S HEARING')</script>");

                }
                else
                {
                    res = hearingObj.updateHearingData();

                    if (res == 1)
                    {
                        Response.Write("<script>alert('CASE HEARING UPDATE SUCCESSFULLY')</script>");



                        // GO TO CASE PROFILE 

                        Response.Redirect("dashboard.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('CASE ID IS NOT CORRECT')</script>");
                    }
                }
            }
           
        }
        else
        {
            saveHearing();
        }
    }

    protected void btnResetCaseHearing_Click(object sender, EventArgs e)
    {
        cleanTextBox();
    }

    protected void fetchHearingData()
    {

        SqlConnection sqlcon = new SqlConnection(conStr);
        string cmdStrHearing = @"SELECT [caseID],[courtNumber],[hearingDate] ,[magistrateName],[hearingStatus],[nextHearingDate],[nextHearingTime]
                                FROM [dbo].[hearingCase] WHERE [HearingID] = " + HearingID + "  ";
        DataTable HearingDT = new DataTable();
        SqlDataAdapter sqlHearingAdp = new SqlDataAdapter(cmdStrHearing, sqlcon);
        sqlHearingAdp.Fill(HearingDT);

        if (HearingDT.Rows.Count > 0)
        {
            
            txtCaseID.Text = HearingDT.Rows[0]["caseID"].ToString();
            txtCourtNumber12.Text = HearingDT.Rows[0]["courtNumber"].ToString();
            DateTime hearingDate = DateTime.Parse(HearingDT.Rows[0]["hearingDate"].ToString());
            txtHearingDate.Text = hearingDate.ToString("yyyy-MM-dd");
            txtHearingStatus.Text = HearingDT.Rows[0]["hearingStatus"].ToString();
            txtMagistrateName.Text = HearingDT.Rows[0]["magistrateName"].ToString();
            DateTime nextHearingDate = DateTime.Parse(HearingDT.Rows[0]["nextHearingDate"].ToString());
            txtNxtHearingDate.Text = nextHearingDate.ToString("yyyy-MM-dd");
            txtNxtHearingTime.Text = HearingDT.Rows[0]["nextHearingTime"].ToString();

        }
        
    }

}