using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class signin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        // -- CHECK PASSWORD AND ID IS CORRECT OR NOT !!
        if (txtPassword.Text.ToString() == "password" && txtUserID.Text.ToString() == "person123")
        {
            Response.Write("btn clicked ");

            Response.Write("<script>alert('loged in successfully')</script>");
            Response.Redirect("dashboard.aspx");
        }
        else
        {
            Response.Write("<script>alert('password or user id is incorrect')</script>");
        }
    }
    protected void exampleCheck1_Click(object sender, EventArgs e)
    {
        
    }
}