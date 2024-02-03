<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="addClient2.aspx.cs" Inherits="addClient2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Form Start -->
    <form id="form1" runat="server">
        <div class="container-fluid pt-4 px-4" >
            <div class="row g-4">
                <div class="col-sm-12 col-xl-6">
                    <div class="bg-light rounded h-100 p-4" style="width: 200%">
                        <h6 class="mb-4">Add Client Detial</h6>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtClientName" type="text" class="form-control" placeholder="Mr. Name Surname" runat="server"></asp:TextBox>
                            <label for="floatingInput">CLient Name</label>
                        </div>
                        <div class="form-floating mb-3">
                            <asp:DropDownList ID="txtClientGender" class="form-select" runat="server" Style="height: 60px">
                                <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Transgender"></asp:ListItem>
                            </asp:DropDownList>
                            <label for="txtClientGender" style="font-size: large; color: #979fd0; font-weight: 500">Gender : </label>
                        </div>
                        <div class="form-floating mb-3" >
                            <asp:TextBox ID="txtClientDoB" runat="server" CssClass="form-control"  TextMode="Date" required ></asp:TextBox>
                            <label for="txtClientDoB" style="color:black">Date of Birth</label>
                        </div>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtClientAddress" class="form-control"  TextMode="MultiLine" Style="min-height: 100px; text-align: start" placeholder="name@example.com" runat="server"></asp:TextBox>
                            <label for="txtClintAddress">Address</label>
                        </div>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtClientMobile1" TextMode="Phone" class="form-control" placeholder="+91" runat="server" required></asp:TextBox>
                            <label for="txtClientMobile1">Moblie Number 1</label>
                        </div>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtClientMobile2" TextMode="Phone"  class="form-control" placeholder="+91" runat="server" required></asp:TextBox>
                            <label for="txtClientMobile2">Moblie Number 2</label>
                        </div>
                     <!--   <div class="form-floating mb-3">
                            <asp:TextBox ID="txtCaseFees" TextMode="Number"  class="form-control" placeholder="+91" runat="server"></asp:TextBox>
                            <label for="txtCaseFees">Case Fees</label>
                        </div>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtOppoName" type="text" class="form-control" placeholder="Mr. Name Surname" runat="server"></asp:TextBox>
                            <label for="txtOppoName">Opposition Name</label>
                        </div>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtOppoAddress" class="form-control" Style="min-height: 100px; text-align: start" placeholder="name@example.com" runat="server"></asp:TextBox>
                            <label for="txtOppoAddress">Opposition Address</label>
                        </div>
                        <div class="form-floating mb-3" >
                            <asp:TextBox ID="txtCaseDate" runat="server" CssClass="form-control"  TextMode="Date" BackColor="WhiteSmoke" ></asp:TextBox>
                            <label for="txtCaseDate" style="color:black">Case Date</label>
                        </div> -->
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtCommentClient" class="form-control" TextMode="MultiLine" Style="min-height: 100px; text-align: start" placeholder="name@example.com" runat="server"></asp:TextBox>
                            <label for="txtCommentClient">Add Comment Here !!</label>
                        </div>
                        <asp:Panel ID="panelUpload" runat="server">
                        <div class="form-floating mb-3">
                                <%--<label for="txtFileUpload" class="form-label" style="padding-bottom:30px" >Upload Files</label>--%>
                                <asp:FileUpload ID="txtFileUpload" runat="server" cssClass="form-control bg-white" style="height:100px" />
                                  
                            </div>                        
                        </asp:Panel>
                        <asp:Panel ID="panelImage" runat="server">
                            <asp:Image ID="imgClientProfilePic" runat="server" CssClass="img-fluid rounded-circle mx-auto mb-4" height="100px" Width="100px" />
                            <div style="float:right;"> 
                            <asp:Button ID="btnChangePanel" runat="server" Text="CHANGE PHOTO"  cssClass="btn btn-primary m-2" Width="180px" OnClick="btnChangePanel_Click"   /> 
                            </div>  
                        </asp:Panel>
                        <div class="form-floating mb-3">
                            <div class="m-n2">
                               <asp:Button ID="btnSaveClient" runat="server" Text="SAVE CLIENT" BackColor="Green" BorderColor="Green" ForeColor="White" Font-Bold="true" cssClass="btn btn-outline-primary w-100 m-2" OnClick="btnSaveClient_Click" />
                                <asp:Button ID="btnResetClient" runat="server" Text="RESET" CssClass="btn btn-primary w-100 m-2" OnClick="btnResetClient_Click" />
                            </div>                           
                        </div>
                        
                    </div>
            </div>


        </div>
        </div>
    </form>
    <!-- Form End -->
</asp:Content>

