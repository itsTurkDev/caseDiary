using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class addCase : System.Web.UI.Page
{
    //string clientID;
    long caseID;
    string conStr = @"Data Source=VERMA-LAPTOP\AMDGULMSSQLSERVE;Initial Catalog=caseDiary;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.HasKeys())
        {


            // FOR EDIT A CASE

            if (Request.QueryString["case"].ToString() == "Edit")
            {
                caseID = Convert.ToInt64( Request.QueryString["CaseID"].ToString());
                btnSaveCase.Text = "UPDATE CASE DETAIL";
               

                // data fill function call
                fetchCaseData();

                if (!IsPostBack)
                {
                        // sir query
                }
            }




            // FOR ADD NEW CASE

            if (Request.QueryString["case"].ToString() == "view")
            {

                txtClientID.Text = Request.QueryString["Cid"].ToString();

                if (!IsPostBack)
                {
                    //Response.Write("<script>alert('profile fetched successfully')</script>");

                   
                }
            }
        }
    }
    
    protected void btnResetClient_Click(object sender, EventArgs e)
    {
        txtClientID.Text = "";
        txtCourtNo.Text = "";
        txtCaseNumber.Text = "";
        txtCaseFees.Text = "";
        txtCaseDate.Text = "";
        txtCaseDescription.Text = "";
        txtOppoAddress.Text = "";
        txtOppoName.Text = "";
    }
    //protected void addCaseDetail()
    //{
    //    //caseDBClass caseObj = new caseDBClass();
    //    //caseObj._clientID = Convert.ToInt32(txtClientID.Text.ToString());
    //    //caseObj._courtType = txtDDL_Court_Type.Text.Trim();
    //    //caseObj._caseType = txtDDL_Case_Type.Text.Trim();
    //    //caseObj._caseFees = Convert.ToInt32(txtCaseFees.Text.ToString());
    //    //caseObj._oppoName = txtOppoAddress.Text.Trim();
    //    //caseObj._oppoAddress = txtOppoAddress.Text.Trim();
    //    //caseObj._caseCourtSession = Convert.ToInt32(txtCaseCourtSession.Text.ToString());
    //    //caseObj._caseDate = txtCaseDate.Text.Trim();
    //    //caseObj._caseCourtNo = Convert.ToInt32(txtCourtNo.Text.ToString());
    //    //caseObj._caseNo = Convert.ToInt32(txtCaseNumber.Text.ToString());
    //    //caseObj._description = txtCaseDescription.Text.Trim();
    //    //int result = caseObj.insertCaseDetail();
    //    //if (result==1)
    //    //{
    //    //    Response.Write("<script>alert('CASE ADDED SUCCESSFULLY')</script>");
    //    //}
        


    //}
    protected void btnSaveCase_Click(object sender, EventArgs e)
    {
        if (btnSaveCase.Text == "UPDATE CASE DETAIL")
        {
            updateCase();
        }
        else
        {
            caseDBClass caseObj = new caseDBClass();

            caseObj._clientID = Convert.ToInt32(txtClientID.Text.ToString());
            caseObj._courtType = txtDDL_Court_Type.SelectedItem.Text.Trim();
            caseObj._caseType = txtDDL_Case_Type.SelectedItem.Text.Trim();
            caseObj._caseFees = Convert.ToInt32(txtCaseFees.Text.ToString());
            caseObj._oppoName = txtOppoName.Text.Trim();
            caseObj._oppoAddress = txtOppoAddress.Text.Trim();
            caseObj._caseCourtSession = Convert.ToInt32(txtCaseCourtSession.Text.ToString());
            caseObj._caseDate = txtCaseDate.Text.Trim();
            caseObj._caseCourtNo = Convert.ToInt32(txtCourtNo.Text.ToString());
            caseObj._caseNo = Convert.ToInt32(txtCaseNumber.Text.ToString());
            caseObj._description = txtCaseDescription.Text.Trim();
            int result = caseObj.insertCaseDetail();
            // CHECK DATE 
            if (result == 1)
            {
                Response.Write("<script>alert('CASE ADDED SUCCESSFULLY')</script>");
            }
            else if (result == 0)
            {
                Response.Write("<script>alert('CLIENT ID IS NOT FOUND')</script>");
            }
        }
        Response.Redirect("clientProfile.aspx?cmd=Profile&&Cid="+txtClientID.Text);


    }


    protected void updateCase()
    {
        caseDBClass caseObj = new caseDBClass();
        caseObj._clientID = Convert.ToInt32(txtClientID.Text.ToString());
        caseObj._courtType = txtDDL_Court_Type.SelectedItem.Text.Trim();
        caseObj._caseType = txtDDL_Case_Type.SelectedItem.Text.Trim();
        caseObj._caseFees = Convert.ToInt32(txtCaseFees.Text.ToString());
        caseObj._oppoName = txtOppoName.Text.Trim();
        caseObj._oppoAddress = txtOppoAddress.Text.Trim();
        caseObj._caseCourtSession = Convert.ToInt32(txtCaseCourtSession.Text.ToString());
        caseObj._caseDate = txtCaseDate.Text.Trim();
        caseObj._caseCourtNo = Convert.ToInt32(txtCourtNo.Text.ToString());
        caseObj._caseNo = Convert.ToInt32(txtCaseNumber.Text.ToString());
        caseObj._description = txtCaseDescription.Text.Trim();

        int result = caseObj.updateCaseDetail();
        if (result == 1)
        {
            Response.Write("<script>alert('CASE UPDATED SUCCESSFULLY')</script>");
        }
        else if (result == 0)
        {
            Response.Write("<script>alert('ERROR OCCUR IN CASE DETAIL UPDATE')</script>");
        }

    }


    protected void fetchCaseData()
    {
        SqlConnection sqlCon = new SqlConnection(conStr);
        sqlCon.Open();

        string cmdStr = @"SELECT [case_ID],[client_ID],[court_Type],[case_Type],[case_Fess],[opponent_Name],[opponent_Address],[case_Court_Session],convert(varchar,[case_Date],105) as case_Date
                        ,[case_Court_No],[case_No],[description] FROM [dbo].[case_detail] WHERE [case_ID] = " + caseID + " ";
        DataTable caseDT = new DataTable();
        SqlDataAdapter caseDataAdp = new SqlDataAdapter(cmdStr, sqlCon);
        caseDataAdp.Fill(caseDT);

        if (caseDT.Rows.Count > 0)
        {
            txtClientID.Text = caseDT.Rows[0]["client_ID"].ToString();
            txtDDL_Court_Type.Text = caseDT.Rows[0]["court_Type"].ToString();
            txtDDL_Case_Type.Text = caseDT.Rows[0]["case_Type"].ToString();
            txtCaseFees.Text = caseDT.Rows[0]["case_Fess"].ToString();
            txtOppoName.Text = caseDT.Rows[0]["opponent_Name"].ToString();
            txtOppoAddress.Text = caseDT.Rows[0]["opponent_Address"].ToString();
            txtCaseCourtSession.Text = caseDT.Rows[0]["case_Court_Session"].ToString();
            DateTime caseDate = DateTime.Parse(caseDT.Rows[0]["case_Date"].ToString());

            //Response.Write(caseDT.Rows[0]["case_Date"].ToString());
            txtCaseDate.Text = caseDate.ToString("yyyy-MM-dd");
            txtCourtNo.Text = caseDT.Rows[0]["case_Court_No"].ToString();
            txtCaseNumber.Text = caseDT.Rows[0]["case_No"].ToString();
            txtCaseDescription.Text = caseDT.Rows[0]["description"].ToString();
            

 
        }



 
    }


}