using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class clientProfile : System.Web.UI.Page
{
    long clientID, clientID2;
    public string conStr = @"Data Source=VERMA-LAPTOP\AMDGULMSSQLSERVE;Initial Catalog=caseDiary;Integrated Security=True";
    string clientName;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.HasKeys())
        {
            if (Request.QueryString["cmd"].ToString() == "Profile")
            {
                
                clientID = Convert.ToInt64(Request.QueryString["Cid"].ToString());
                
                if (!IsPostBack)
                {
                    //Response.Write("<script>alert('profile fetched successfully')</script>");
                    
                    fillClientProfile();
                    fetchCaseDetail();
                }
            }

            // for DELETED CLIENT 

            if (Request.QueryString["cmd"].ToString() == "DeletedProfile")
            {

                clientID2 = Convert.ToInt64(Request.QueryString["Cid"].ToString());

                if (!IsPostBack)
                {
                    //Response.Write("<script>alert('profile fetched successfully')</script>");

                    fillDeletedClientProfile();
                    fetchDeletedCaseDetail();
                }
            }


        }

        //lblClientName.Text = "person name ";
    }
    protected void fillClientProfile()
    {
        SqlConnection sqlCon = new SqlConnection(conStr);
        string cmdStr = @"SELECT [client_ID],[client_Name],[client_Gender],DATEDIFF(year, client_DOB, getdate()) as [client_DOB] ,[client_Address],[client_Mobile1],[client_Mobile2],
                            [comments],[files] FROM [dbo].[client_Detail] WHERE  [client_ID] = " + clientID;
        SqlDataAdapter clientDataAdp = new SqlDataAdapter(cmdStr, sqlCon);
        DataTable clientDataTable = new DataTable();
        clientDataAdp.Fill(clientDataTable);
        if (clientDataTable.Rows.Count > 0)
        {
            imgClientProfilePic.ImageUrl = clientDataTable.Rows[0]["files"].ToString();
            lblClientID.Text = clientDataTable.Rows[0]["client_ID"].ToString();
            lblClientName.Text = clientDataTable.Rows[0]["client_Name"].ToString().ToUpper();
            lblClientAddress.Text = clientDataTable.Rows[0]["client_Address"].ToString();

            //string clientDoBStr = clientDataTable.Rows[0]["client_DOB"].ToString();
            //DateTime clientDoB = Convert.ToDateTime(clientDoBStr);
            //DateTime persent = new DateTime();
            //persent = DateTime.Now;
            //DateTime age = (persent - clientDoB);
            //string age = (persent-clientDoB).ToString();
            //DateTime age2 = Convert.ToDateTime(age);
            //string age3 = "yyyy- "+age2.Year.ToString() +"mm- "+ age2.Month.ToString() +"dd- "+ age2.Day.ToString();


            lblClientDoB.Text = clientDataTable.Rows[0]["client_DOB"].ToString();        //clientDataTable.Rows[0]["client_DOB"].ToString();
            lblClientGender.Text = clientDataTable.Rows[0]["client_Gender"].ToString();
            lblClientMobile1.Text = clientDataTable.Rows[0]["client_Mobile1"].ToString();
            lblClientMobile2.Text = clientDataTable.Rows[0]["client_Mobile2"].ToString();
            lblClientComments.Text = clientDataTable.Rows[0]["comments"].ToString();

            clientName =  clientDataTable.Rows[0]["client_Name"].ToString().ToUpper();
           


            // if minor CASE
           
            int age = Convert.ToInt32(clientDataTable.Rows[0]["client_DOB"].ToString());
            if (age < 18)
            {
                lblIfMinor.Text = "(MINOR)";
            }

            



        }

    }
    protected void btnEditClient_Click(object sender, EventArgs e)
    {
        //Response.Write("<script>alert('btn clicked ')</script>");
        if (Request.QueryString.HasKeys())
        {
            if (Request.QueryString["cmd"].ToString() == "Profile")
            {

                Response.Redirect("addClient2.aspx?case=view&&Cid="+clientID+"");

                    //fillClientProfile();
            }

          
        }

 
    }

    protected void fetchCaseDetail()
    {
        SqlConnection sqlCon = new SqlConnection(conStr);
        string cmdStr = @"SELECT [case_ID],[client_ID],[court_Type],[case_Type],[case_Fess],[opponent_Name],[opponent_Address],[case_Court_Session],[case_Date],[case_Court_No],[case_No],[description] FROM [dbo].[case_detail] WHERE  [client_ID] = " + clientID;
        SqlDataAdapter caseDataAdp = new SqlDataAdapter(cmdStr, sqlCon);
        DataTable caseDataTable = new DataTable();
        caseDataAdp.Fill(caseDataTable);
        if (caseDataTable.Rows.Count > 0)
        {
            caseGridview.DataSource = caseDataTable;
            caseGridview.DataBind();
        }
    }



    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Request.QueryString.HasKeys())
        {
            if (Request.QueryString["cmd"].ToString() == "Profile")
            {

                Response.Redirect("addCase.aspx?case=view&&Cid=" + clientID + "");

                //fillClientProfile();
            }
        }    
    }

    // fetch DELETED CLIENT PROFILE

    protected void fillDeletedClientProfile()
    {
           SqlConnection sqlCon = new SqlConnection(conStr);
        string cmdStr = @"SELECT [client_ID],[client_Name],[client_Gender],DATEDIFF(year, client_DOB, getdate()) as [client_DOB] ,[client_Address],[client_Mobile1],[client_Mobile2],
                            [comments],[files],CONVERT(VARCHAR,[deleted_on],105) AS [deleted_on] FROM [dbo].[client_Detail] WHERE  [client_ID] = " + clientID2 + " AND  [client_Detail].[isDeleted] =1 ";
        SqlDataAdapter clientDataAdp = new SqlDataAdapter(cmdStr, sqlCon);
        DataTable clientDataTable = new DataTable();
        clientDataAdp.Fill(clientDataTable);
        if (clientDataTable.Rows.Count > 0)
        {
            imgClientProfilePic.ImageUrl = clientDataTable.Rows[0]["files"].ToString();
            lblClientID.Text = clientDataTable.Rows[0]["client_ID"].ToString();
            lblClientName.Text = clientDataTable.Rows[0]["client_Name"].ToString().ToUpper();
            lblClientAddress.Text = clientDataTable.Rows[0]["client_Address"].ToString();
            lblClientDoB.Text = clientDataTable.Rows[0]["client_DOB"].ToString();     
            lblClientGender.Text = clientDataTable.Rows[0]["client_Gender"].ToString();
            lblClientMobile1.Text = clientDataTable.Rows[0]["client_Mobile1"].ToString();
            lblClientMobile2.Text = clientDataTable.Rows[0]["client_Mobile2"].ToString();
            lblClientComments.Text = clientDataTable.Rows[0]["comments"].ToString();

            //clientName = clientDataTable.Rows[0]["client_Name"].ToString().ToUpper();
            string STATUS = "DELETD ON : " + clientDataTable.Rows[0]["deleted_on"].ToString();
            lblDeleted.Text = STATUS;
            Button3.Visible = false;
            btnEditClient.Visible = false;
            


            // if minor CASE

            int age = Convert.ToInt32(clientDataTable.Rows[0]["client_DOB"].ToString());
            if (age < 18)
            {
                lblIfMinor.Text = "(MINOR)";
            }
        }
    }

    // FETCH DELETED CASE DETAIL

    protected void fetchDeletedCaseDetail() 
    {
        SqlConnection sqlCon = new SqlConnection(conStr);
        string cmdStr = @"SELECT [case_ID],[client_ID],[court_Type],[case_Type],[case_Fess],[opponent_Name],[opponent_Address],[case_Court_Session],[case_Date],[case_Court_No],[case_No],[description] FROM [dbo].[Deleted_Case_Detail] WHERE  [client_ID] = " + clientID2;
        SqlDataAdapter caseDataAdp = new SqlDataAdapter(cmdStr, sqlCon);
        DataTable caseDataTable = new DataTable();
        caseDataAdp.Fill(caseDataTable);
        if (caseDataTable.Rows.Count > 0)
        {
            caseGridview.DataSource = caseDataTable;
            caseGridview.DataBind();
        }
 
    }


   
}