<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="addCase.aspx.cs" Inherits="addCase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <!-- Form Start -->
    <form id="form1" runat="server">
        <div class="container-fluid pt-4 px-4" >
            <div class="row g-4">

                <div class="col-sm-12 col-xl-6">
                    <div class="bg-light rounded h-100 p-4" style="width: 200%">
                        <h6 class="mb-4">Add Case</h6>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtClientID" TextMode="Number" class="form-control" placeholder="Mr. Name Surname" runat="server"></asp:TextBox>
                            <label for="floatingInput">Client ID</label>
                        </div>
                        <div class="form-floating mb-3">
                            <asp:DropDownList ID="txtDDL_Court_Type" class="form-select" runat="server" Style="height: 60px">
                                <asp:ListItem Value="1">District Court</asp:ListItem>
                                <asp:ListItem Value="2">High Court</asp:ListItem>
                                <asp:ListItem Value="3">Supreme Court</asp:ListItem>
                            </asp:DropDownList>
                            <label for="floatingSelect" style="font-size: large; color: #979fd0; font-weight: 500">Court Type : </label>
                        </div>
                        <div class="form-floating mb-3">
                            <asp:DropDownList ID="txtDDL_Case_Type" class="form-select" runat="server" Style="height: 60px">
                                <asp:ListItem Value="1">Civil Case</asp:ListItem>
                                <asp:ListItem Value="2">Criminal Case</asp:ListItem>
                                <asp:ListItem Value="3">Bankruptcy Case</asp:ListItem>
                            </asp:DropDownList>
                            <label for="floatingSelect" style="font-size: large; color: #979fd0; font-weight: 500">Case Type : </label>
                        </div>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtCaseFees" TextMode="Number"  class="form-control" placeholder="+91" runat="server" required ></asp:TextBox>
                            <label for="txtCaseFees">Case Fees</label>
                        </div>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtOppoName" type="text" class="form-control" placeholder="Mr. Name Surname" runat="server"></asp:TextBox>
                            <label for="txtOppoName">Opposition Name</label>
                        </div>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtOppoAddress" class="form-control" Style="min-height: 100px; text-align: start" TextMode="MultiLine" placeholder="name@example.com" runat="server"></asp:TextBox>
                            <label for="txtOppoAddress">Opposition Address</label>
                        </div>
                        <div class="form-floating mb-3" >
                            <asp:TextBox ID="txtCaseCourtSession" runat="server" CssClass="form-control"  TextMode="Number" required></asp:TextBox>
                            <label for="txtCaseDate" style="color:black">Case Session</label>
                        </div>
                        <div class="form-floating mb-3" >
                            <asp:TextBox ID="txtCaseDate" runat="server" CssClass="form-control"  TextMode="Date"  required></asp:TextBox>
                            <label for="txtCaseDate" style="color:black">Case Date</label>
                        </div>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtCourtNo" TextMode="Number" class="form-control" placeholder="Mr. Name Surname" runat="server" required></asp:TextBox>
                            <label for="txtCourtNo">Court Number :</label>
                        </div>                       
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtCaseNumber" TextMode="Number" class="form-control" placeholder="Case Number" runat="server" required ></asp:TextBox>
                            <label for="txtCaseNumber">Case Number</label>
                        </div>                      
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="txtCaseDescription" class="form-control" TextMode="MultiLine" Style="min-height: 100px; text-align: start" placeholder="name@example.com" runat="server"></asp:TextBox>
                            <label for="txtCaseDescription">Add Description Here !!</label>
                        </div>
                        <div class="form-floating mb-3">
                            <div class="m-n2">
                               <asp:Button ID="btnSaveCase" runat="server" Text="ADD CASE" BackColor="Green" BorderColor="Green" ForeColor="White" Font-Bold="true" cssClass="btn btn-outline-primary w-100 m-2" OnClick="btnSaveCase_Click" width="90%" />
                                <asp:Button ID="btnResetClient" runat="server" Text="RESET" CssClass="btn btn-primary w-100 m-2" OnClick="btnResetClient_Click"  />
                            </div>                           
                        </div>      
                    </div>
            </div>
        </div>
        </div>
    </form>
    <!-- Form End -->
            <!-- Form End -->


</asp:Content>

