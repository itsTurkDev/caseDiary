using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class addClient2 : System.Web.UI.Page
{
    string conStr = @"Data Source=VERMA-LAPTOP\AMDGULMSSQLSERVE;Initial Catalog=caseDiary;Integrated Security=True";
    long clientID;

    protected void Page_Load(object sender, EventArgs e)
    {

        panelUpload.Visible = true;
        panelImage.Visible = false;

        if (Request.QueryString.HasKeys())
        {
            if (Request.QueryString["case"].ToString() == "view")
            {

                clientID = Convert.ToInt64(Request.QueryString["Cid"].ToString());

                if (!IsPostBack)
                {
                    //Response.Write("<script>alert('profile fetched successfully')</script>");

                    fillClientDetail();
                }
            }
        }

    }





    protected void btnSaveClient_Click(object sender, EventArgs e)
    {

        // CHECK THE CONDITION WEATHER THE BUTTON USED FOR UPDATE OR INSERT 


        if (btnSaveClient.Text == "UPDATE DETAIL")
        {
            Response.Write("<script>alert('update method call now by text' )</script>");
            updateClientDetail();
        }
        else
        {

            string verFilePath = "~\\ClientFile\\" + txtFileUpload.FileName;

            // ASIGN VALUES TO PROPERTY 

            ClientDB client = new ClientDB();
            client._clientName = txtClientName.Text.Trim();
            client._clientGender = txtClientGender.SelectedItem.Text;

            // CODE FOR DATE DIFFERARENCE 

            var varDoB = DateTime.Parse(txtClientDoB.Text); //15 July 2021
            var today = DateTime.Now;

            //get difference of dates
            var diffOfDates = today - varDoB;
            int Age = diffOfDates.Days;
            if (Age > 0)
            {

                client._clientDoB = txtClientDoB.Text.Trim();
                client._clientAddress = txtClientAddress.Text.Trim();
                client._clientComment = txtCommentClient.Text.Trim();
                client._clientFile = verFilePath;
                if (((txtClientMobile1.Text.ToString()).Length == 10) && ((txtClientMobile2.Text.ToString()).Length == 10))
                {
                    client._clientMobile1 = Convert.ToInt64(txtClientMobile1.Text.ToString());
                    client._clientMobile2 = Convert.ToInt64(txtClientMobile2.Text.ToString());
                    int result = client.insertClientData();
                    if (result == 1)
                    {
                        Response.Write("<script>alert('client added succesfully' )</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error occur in saving Client' )</script>");
                    }

                    // SAVE FILE IN CLIENT FOLDER 

                    if (txtFileUpload.HasFile)
                    {
                        string actFilePath = Server.MapPath(verFilePath);
                        txtFileUpload.SaveAs(actFilePath);
                        //sqlCon.Close();
                    }
                    cleanTextBox();
                    //Response.Redirect("viewClient.aspx");

                    
                }
                else
                {
                    Response.Write("<script>alert('Mobile 1 or 2 is not in correct format' )</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Date of birth is not Correct' )</script>");
            }
        }
    }



    // TO EMPTY TEXT BOX -------------------------------------------------------------------------

    protected void cleanTextBox()
    {
       
        txtClientName.Text = "";
        txtClientGender.SelectedItem.Text= "";
        txtClientDoB.Text= "";
        txtClientAddress.Text= "";
        txtClientMobile1.Text= "";
        txtClientMobile2.Text= "";     
        txtCaseDate.Text= "";
        txtCommentClient.Text = "";
        
    }

    // RESET BUTTON IS CLICKED ----- BUTTON EVENT ----------------------------------------

    protected void btnResetClient_Click(object sender, EventArgs e)
    {
        cleanTextBox();
    }



    //  FETCH THE DATA OF CLIENT AND FILLED IT TO CLIENT TEXTBOX PAGE -------------------------------

    protected void fillClientDetail()
    {
        SqlConnection sqlCon = new SqlConnection(conStr);
        string cmdStr = @"SELECT [client_ID],[client_Name],[client_Gender],convert(varchar,[client_DOB],105) as [client_DOB],[client_Address],[client_Mobile1],[client_Mobile2],
                            [comments],[files] FROM [dbo].[client_Detail] WHERE  [client_ID] = " + clientID;
        SqlDataAdapter clientDataAdp = new SqlDataAdapter(cmdStr, sqlCon);
        DataTable clientDataTable = new DataTable();
        clientDataAdp.Fill(clientDataTable);
        if (clientDataTable.Rows.Count > 0)
        {

            // FILL DATA OF CLIENT IN TEXTBOXES

            
            txtClientName.Text = clientDataTable.Rows[0]["client_Name"].ToString().ToUpper();
            txtClientAddress.Text = clientDataTable.Rows[0]["client_Address"].ToString();                

            DateTime DoB = DateTime.Parse(clientDataTable.Rows[0]["client_DOB"].ToString());
            txtClientDoB.Text = DoB.ToString("yyyy-MM-dd");            
            txtClientGender.SelectedItem.Text = clientDataTable.Rows[0]["client_Gender"].ToString();
            txtClientMobile1.Text = clientDataTable.Rows[0]["client_Mobile1"].ToString();
            txtClientMobile2.Text = clientDataTable.Rows[0]["client_Mobile2"].ToString();
            txtCommentClient.Text = clientDataTable.Rows[0]["comments"].ToString();
            string imageOldPath =clientDataTable.Rows[0]["files"].ToString(); 
            imgClientProfilePic.ImageUrl = clientDataTable.Rows[0]["files"].ToString();           
            btnSaveClient.Text = "UPDATE DETAIL";
            panelImage.Visible = true;
            panelUpload.Visible = false;
            


        }

        //Response.Write("<script>alert('profile fetched successfully')</script>");
    }

    // UPDATE METHOD IS CALLED NOW --------- CONSTRUCT THE OBJECT FOR CLASS -----------------------------------------------

    protected void updateClientDetail()
    {

        string verFilePath = "~\\ClientFile\\" + txtFileUpload.FileName;

      
        // ASIGN VALUES TO PROPERTY 

        ClientDB client = new ClientDB();

        client._clientID = clientID;
        client._clientName = txtClientName.Text.Trim();
        client._clientGender = txtClientGender.SelectedItem.Text.Trim();
        client._clientDoB = txtClientDoB.Text.Trim();
        client._clientAddress = txtClientAddress.Text.Trim();
        client._clientMobile1 = Convert.ToInt64(txtClientMobile1.Text.ToString());
        client._clientMobile2 = Convert.ToInt64(txtClientMobile2.Text.ToString());
        client._clientComment = txtCommentClient.Text.Trim();

        int res = 0;

        // UPDATE METHOD OF CLASS IS CALLED
         if (txtFileUpload.HasFile)
        {   
            client._clientFile = verFilePath;
            res = client.updateClientData();
        }
        else
        {
            res = client.updateClientDataWithoutFile();
        }

        
        if (txtFileUpload.HasFile)
        {
            
            //Response.Write("<script>alert(' image save as call now')</script>");
            string actFilePath = Server.MapPath(verFilePath);
            txtFileUpload.SaveAs(actFilePath);
        }
       
        if (res == 1)
        {
            Response.Write("<script>alert(' update successful')</script>");
        }
        // TO EMPTY THE TEXT BOX 

        cleanTextBox();
        
        // RETURN BACK TO CLIENT UPDATED PROFILE
        
        Response.Redirect("clientProfile.aspx?cmd=Profile&&Cid="+clientID+"");
    }

    // BUTTON EVENT FOR CHANGE PANEL IMAGE TO FILE UPLOAD ---------------

    protected void btnChangePanel_Click(object sender, EventArgs e)
    {
        panelImage.Visible = false;
        panelUpload.Visible = true;
    }
}