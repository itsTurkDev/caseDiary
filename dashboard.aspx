<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


            <form id="form1" runat="server">


            <!-- Sale & Revenue Start -->
            <div class="container-fluid pt-4 px-4" >
                <div class="row g-4">
                    <div class="col-sm-6 col-xl-3">
                        <div class="bg-light rounded d-flex align-items-center justify-content-between p-4">
                            <i class="fa fa-chart-line fa-3x text-primary"></i>
                            <div class="ms-3">
                                <p class="mb-2">Total Client</p>

                                <h6 class="mb-0"  ><a runat="server" href="viewClient.aspx" > <asp:Label ID="txtValueA" runat="server"></asp:Label> Persons </a>  </h6>  
                                    <%--<asp:Literal runat="server" id="txtValueA" EnableViewState="false" /> --%>
                                   
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-xl-3">
                        <div class="bg-light rounded d-flex align-items-center justify-content-between p-4">
                            <i class="fa fa-chart-bar fa-3x text-primary"></i>
                            <div class="ms-3">
                                <p class="mb-2">Total Cases</p>
                                <h6 class="mb-0"><a runat="server" href="viewCase.aspx"  > <asp:Label ID="txtValueB" runat="server"></asp:Label> Cases </a> </h6>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-xl-3">
                        <div class="bg-light rounded d-flex align-items-center justify-content-between p-4">
                            <i class="fa fa-chart-area fa-3x text-primary"></i>
                            <div class="ms-3">
                                <p class="mb-2">Today's Hearing</p>
                                <h6 class="mb-0"><a runat="server" href="#"  > <asp:Label ID="txtValueC" runat="server"></asp:Label> Hearings </a> </h6>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-xl-3">
                        <div class="bg-light rounded d-flex align-items-center justify-content-between p-4">
                            <i class="fa fa-chart-pie fa-3x text-primary"></i>
                            <div class="ms-3">
                                <p class="mb-2">Total Hearings</p>
                                <h6 class="mb-0"><a runat="server" href="#"  > <asp:Label ID="txtValueD" runat="server"></asp:Label> Hearings </a> </h6>                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Sale & Revenue End -->
                <br />
    <hr />
    <br />

            <!-- SEARCH BOX FOR CLIENT -->
          <div class="container-fluid pt-4 px-4">
        <div class="row g-4">
             <div class="col-sm-12 col-xl-6">
                      <div class="bg-light rounded h-100 p-4" style="height:75px !important;padding-bottom:50px" >
                          
                            <%--<div class="m-n2">--%>
                               <span> <asp:TextBox runat="server" id="txtSearchClient" cssClass="form-control border-0" type="search" width="80%" placeholder="Search Client" > </asp:TextBox>
                                <%--<input class="form-control bg-dark border-0" type="search" placeholder="Search Client"/>--%>
                                   </span>
                          <span>
                                <asp:Button ID="btnSearchClient" runat="server" Text="SEARCH" style="float:right;" type="button" cssClass="btn btn-outline-primary m-2" OnClick="btnSearchClient_Click" />
                               <%-- <button type="button" class="btn btn-outline-primary m-2">Primary</button>--%>
                                </span>
                            </div>
                        </div>
             <div class="col-sm-12 col-xl-6">
                      <div class="bg-light rounded h-100 p-4" style="height:75px !important;padding-bottom:50px" >
                          
                            <%--<div class="m-n2">--%>
                               <span> <asp:TextBox runat="server" id="txtSearchCase" cssClass="form-control border-0" type="search" width="80%" placeholder="Search Case" > </asp:TextBox>
                              
                                   </span>
                          <span>
                                <asp:Button ID="btnSearchCase" runat="server" Text="SEARCH" style="float:right;" type="button" cssClass="btn btn-outline-primary m-2" OnClick="btnSearchCase_Click"  />
                             
                                </span>
                            </div>
                        </div>
                 </div>
            </div>
                <asp:Panel ID="panelFoundItem" runat="server">
              <div class="col-12" style="padding:20px">
                        <div class="bg-light rounded h-100 p-4">
                            <%-- <h6 class="mb-4">Cliend Detail</h6>--%>
                            <div class="table-responsive">
                                <asp:Label ID="lblSearchClient" ForeColor="Red" Font-Bold="true" runat="server" ></asp:Label>
                            <asp:GridView ID="GridViewSearchClient" runat="server" AutoGenerateColumns="False" CssClass="table" >
                                <Columns>
                                    <asp:ImageField DataImageUrlField="files" HeaderText="picture" ControlStyle-Height="80px" ControlStyle-BorderColor="red"> </asp:ImageField>
                                    <asp:TemplateField HeaderText="Client_ID" >
                                        <ItemTemplate>
                                            <a href='clientProfile.aspx?cmd=Profile&&Cid=<%# Eval("client_ID")%>'> <%# Eval("client_ID") %> </a>                                         
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="client_Name" HeaderText="NAME" SortExpression="client_Name" ItemStyle-ForeColor="Black" ></asp:BoundField>
                                    <asp:BoundField DataField="client_Gender" HeaderText="GENDER" SortExpression="client_Gender"></asp:BoundField>
                                    <asp:BoundField DataField="client_DOB" HeaderText="DoB" SortExpression="client_DOB"></asp:BoundField>
                                    <asp:BoundField DataField="client_Address" HeaderText="ADDRESS" SortExpression="client_Address"></asp:BoundField>
                                    <asp:BoundField DataField="client_Mobile1" HeaderText="Mobile1" SortExpression="client_Mobile1"></asp:BoundField>
                                    <asp:BoundField DataField="client_Mobile2" HeaderText="Mobile2" SortExpression="client_Mobile2"></asp:BoundField>
                                    <asp:BoundField DataField="comments" HeaderText="comments" SortExpression="comments"></asp:BoundField>
                                                                        
                                </Columns>
                            </asp:GridView>
                                <asp:GridView ID="GridViewSearchCase" runat="server" AutoGenerateColumns="False" cssClass="table text-start align-middle table-bordered table-hover mb-0" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="CASE ID" >
                                        <ItemTemplate>
                                            <a href='caseProfile.aspx?cmd=Profile&&CaseID=<%# Eval("case_ID")%>'> <%# Eval("case_ID") %> </a>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <%-- <asp:BoundField DataField="case_ID" HeaderText="case_ID" InsertVisible="False" ReadOnly="True" SortExpression="case_ID" />--%>
                                        <asp:TemplateField HeaderText="CLIENT ID" >
                                            <ItemTemplate>
                                                <a href='clientProfile.aspx?cmd=Profile&&Cid=<%# Eval("client_ID")%>'> <%# Eval("client_ID") %> </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:BoundField DataField="court_Type" HeaderText="COURT TYPE" SortExpression="court_Type" />
                                        <asp:BoundField DataField="case_Type" HeaderText="CASE TYPE" SortExpression="case_Type" />
                                        <%--<asp:BoundField DataField="case_Fess" HeaderText="FESS" SortExpression="case_Fess" />--%>
                                        <asp:BoundField DataField="client_Name" HeaderText="CLIENT NAME" SortExpression="opponent_Name" />
                                        <asp:TemplateField HeaderText="Vs">
                                            <ItemTemplate >
                                                <a href="#">Vs</a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="opponent_Name" HeaderText="OPPONENT NAME" SortExpression="opponent_Name" />
                                        <asp:BoundField DataField="opponent_Address" HeaderText="OPPONENT ADDRESS" SortExpression="opponent_Address" />
                                        
                                        <%--<asp:BoundField DataField="case_Court_Session" HeaderText="case_Court_Session" SortExpression="case_Court_Session" />
                                        <asp:BoundField DataField="case_Date" HeaderText="case_Date" SortExpression="case_Date" />
                                        <asp:BoundField DataField="case_Court_No" HeaderText="case_Court_No" SortExpression="case_Court_No" />
                                        <asp:BoundField DataField="case_No" HeaderText="case_No" SortExpression="case_No" />--%>
                                        <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                                    </Columns>
                                </asp:GridView>
                        </div>
                    </div>
                  </div>
                    </asp:Panel>
                
             
                   


    <br />
    <hr />
    <br />
        <!-- MY WORK HEARING NITIFY GRIDVIEW -->
                    <!-- 
                CLIENT NAME VS OPPONENT 
                DATE AND TIME 
                MOBILE NUMBER 1  2
                CASE LINK 
                CLIENT CASE 


            -->
      <div class="bg-light rounded h-100 p-4" style="margin:23px">
           <div  class="table-responsive">
               <h4  > TODAY'S HEARING </h4>
               <asp:Label ID="lblTodaysHearing" runat="server" ForeColor="Red"></asp:Label>
            <asp:GridView ID="GridViewTodayNotification" runat="server" AutoGenerateColumns="False"  CssClass="table text-start align-middle table-bordered table-hover mb-0" > <%--ForeColor="#333333"---CellPadding="4"
               <AlternatingRowStyle BackColor="White" /> --%>
                <Columns>
        

                    <asp:BoundField DataField="client_Name" HeaderText="CLIENT NAME" SortExpression="client_Name" /> 
                    <asp:TemplateField>
                        <ItemTemplate>
                           <a href="caseProfile.aspx?cmd=Profile&&CaseID=<%# Eval("case_ID")%>" >Vs</a> 
                        </ItemTemplate>
                    </asp:TemplateField>          
                    <asp:BoundField DataField="opponent_Name" HeaderText="OPPONENT NAME" SortExpression="opponent_Name" />
                    <asp:BoundField DataField="client_Mobile1" HeaderText="CLIENT MOBILE 1" SortExpression="client_Mobile1" />
                    <asp:BoundField DataField="client_Mobile2" HeaderText="CLIENT MOBILE 2" SortExpression="client_Mobile2" />
                    <asp:BoundField DataField="nextHearingDate" HeaderText="HEARING DATE" SortExpression="nextHearingDate" />
                    <asp:BoundField DataField="nextHearingTime" HeaderText="HEARING TIME" SortExpression="nextHearingTime" />
                    <asp:TemplateField HeaderText="VIEW">
                        <ItemTemplate>
                            <a href='clientProfile.aspx?cmd=Profile&&Cid=<%# Eval("client_ID")%>'> CLIENT </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="VIEW">
                        <ItemTemplate>
                            <a href='caseProfile.aspx?cmd=Profile&&CaseID=<%# Eval("case_ID")%>'>CASE </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                  <%--  <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#8B0000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>

            </asp:GridView>
       </div>
</div>
               <!-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:caseDiaryConnectionString %>" SelectCommand="SELECT * FROM [hearingCase]"></asp:SqlDataSource> -->

    <br />
    <hr />
    <br />
 <div class="bg-light rounded h-100 p-4" style="margin:23px">
           <div  class="table-responsive">
               <h4  >HEARING IN THIS WEAK </h4>
               <asp:Label ID="lblWeakHearing" runat="server" ForeColor="Red"></asp:Label>
            <asp:GridView ID="GridViewHearingNotifyWeak" runat="server" AutoGenerateColumns="False"  CssClass="table text-start align-middle table-bordered table-hover mb-0" > <%--ForeColor="#333333"---CellPadding="4"
               <AlternatingRowStyle BackColor="White" /> --%>
                <Columns>
        

                    <asp:BoundField DataField="client_Name" HeaderText="CLIENT NAME" SortExpression="client_Name" /> 
                    <asp:TemplateField>
                        <ItemTemplate>
                           <a href="caseProfile.aspx?cmd=Profile&&CaseID=<%# Eval("case_ID")%>" >Vs</a> 
                        </ItemTemplate>
                    </asp:TemplateField>          
                    <asp:BoundField DataField="opponent_Name" HeaderText="OPPONENT NAME" SortExpression="opponent_Name" />
                    <asp:BoundField DataField="client_Mobile1" HeaderText="CLIENT MOBILE 1" SortExpression="client_Mobile1" />
                    <asp:BoundField DataField="client_Mobile2" HeaderText="CLIENT MOBILE 2" SortExpression="client_Mobile2" />
                    <asp:BoundField DataField="nextHearingDate" HeaderText="HEARING DATE" SortExpression="nextHearingDate" />
                    <asp:BoundField DataField="nextHearingTime" HeaderText="HEARING TIME" SortExpression="nextHearingTime" />
                    <asp:TemplateField HeaderText="VIEW">
                        <ItemTemplate>
                            <a href='clientProfile.aspx?cmd=Profile&&Cid=<%# Eval("client_ID")%>'> CLIENT </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="VIEW">
                        <ItemTemplate>
                            <a href='caseProfile.aspx?cmd=Profile&&CaseID=<%# Eval("case_ID")%>'>CASE </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                  <%--  <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#8B0000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>

            </asp:GridView>
       </div>
</div>
 <br />
    <hr />
    <br />



 <div class="bg-light rounded h-100 p-4" style="margin:23px">
           <div  class="table-responsive">
               <h4  >HEARINGS AFTER THIS WEAK</h4>
               <asp:Label ID="lblAfterHearing" runat="server" ForeColor="Red"></asp:Label>
            <asp:GridView ID="GridViewHearingNotifyAfter" runat="server" AutoGenerateColumns="False"  CssClass="table text-start align-middle table-bordered table-hover mb-0" > <%--ForeColor="#333333"---CellPadding="4"
               <AlternatingRowStyle BackColor="White" /> --%>
                <Columns>
        

                    <asp:BoundField DataField="client_Name" HeaderText="CLIENT NAME" SortExpression="client_Name" /> 
                    <asp:TemplateField>
                        <ItemTemplate>
                           <a href="caseProfile.aspx?cmd=Profile&&CaseID=<%# Eval("case_ID")%>" >Vs</a> 
                        </ItemTemplate>
                    </asp:TemplateField>          
                    <asp:BoundField DataField="opponent_Name" HeaderText="OPPONENT NAME" SortExpression="opponent_Name" />
                    <asp:BoundField DataField="client_Mobile1" HeaderText="CLIENT MOBILE 1" SortExpression="client_Mobile1" />
                    <asp:BoundField DataField="client_Mobile2" HeaderText="CLIENT MOBILE 2" SortExpression="client_Mobile2" />
                    <asp:BoundField DataField="nextHearingDate" HeaderText="HEARING DATE" SortExpression="nextHearingDate" />
                    <asp:BoundField DataField="nextHearingTime" HeaderText="HEARING TIME" SortExpression="nextHearingTime" />
                    <asp:TemplateField HeaderText="VIEW">
                        <ItemTemplate>
                            <a href='clientProfile.aspx?cmd=Profile&&Cid=<%# Eval("client_ID")%>'> CLIENT </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="VIEW">
                        <ItemTemplate>
                            <a href='caseProfile.aspx?cmd=Profile&&CaseID=<%# Eval("case_ID")%>'>CASE </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                  <%--  <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#8B0000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>

            </asp:GridView>
       </div>
</div>
 <br />
    <hr />
    <br />
            


          


            </form>


</asp:Content>

