<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="addHearing.aspx.cs" Inherits="addHearing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form3" runat="server">
        <div class="container-fluid pt-4 px-4" >
            <div class="row g-4">
                <div class="col-sm-12 col-xl-6">
                    <div class="bg-light rounded h-100 p-4" style="width: 200%;">
                        <h6 class="mb-4">Add Hearing</h6>
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtCaseID" TextMode="Number"  cssClass="form-control" runat="server"></asp:TextBox>
                                <label for="txtCaseID">Case ID</label>
                            </div>
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtCourtNumber12" cssClass="form-control" runat="server" required ></asp:TextBox>
                                <label for="txtCourtNumber">Court Number</label>
                            </div>
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtHearingDate" TextMode="Date"  cssClass="form-control" runat="server" required></asp:TextBox>
                                <label for="txtHearingDate">Hearing Date</label>
                            </div>                            
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtMagistrateName" cssClass="form-control" runat="server"></asp:TextBox>
                                <label for="txtMagistrateName">Judge Name</label>
                            </div>
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtHearingStatus" cssClass="form-control" runat="server" TextMode="MultiLine" ></asp:TextBox>
                                <label for="txtHearingStatus">Hearing Status</label>
                            </div>  
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtNxtHearingDate" TextMode="Date" cssClass="form-control" runat="server" required></asp:TextBox>
                                <label for="txtNxtHearingDate" style="color:black; font-weight:bold" > Next Hearing Date </label>
                            </div>  
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtNxtHearingTime" TextMode="Time"  cssClass="form-control" ForeColor="Black" runat="server"></asp:TextBox>
                                <label for="txtNxtHearingTime" style="color:black; font-weight:bold" >Next Hearing Time</label>
                            </div>   

                       <%-- 
                        add zone 
                        argument 
                        final 
                        others - reason
                        --%>
                      
                                                    
                            <div class="form-floating mb-3">
                            <div class="m-n2">
                                <asp:Button ID="btnSaveCaseHearing" runat="server" Text="ADD CASE HEARING" BackColor="Green" BorderColor="Green" ForeColor="White" Font-Bold="true" cssClass="btn btn-outline-primary w-100 m-2" width="90%" OnClick="btnSaveCaseHearing_Click" />
                                <asp:Button ID="btnResetCaseHearing" runat="server" Text="RESET" CssClass="btn btn-primary w-100 m-2" OnClick="btnResetCaseHearing_Click"  />
                            </div>                           
                        </div> 
                    </div>
                </div>
             </div>
        </div>
    </form>
</asp:Content>

