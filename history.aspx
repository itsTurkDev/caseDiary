<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="history.aspx.cs" Inherits="history" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
    <div class="container-fluid pt-4 px-4">
        <div class="row g-4">
             <div class="col-sm-12 col-xl-6">
                      <div class="bg-light rounded h-100 p-4" style="height:75px !important;padding-bottom:50px" >
                          <span> <asp:TextBox runat="server" id="txtSearchClient" cssClass="form-control border-0" type="search" width="80%" placeholder="Search Client" > </asp:TextBox>  </span>
                          <span> <asp:Button ID="btnSearchClient" runat="server" Text="SEARCH" style="float:right;" type="button" cssClass="btn btn-outline-primary m-2" OnClick="btnSearchClient_Click" />  </span>
                      </div>
              </div>
             <div class="col-sm-12 col-xl-6">
                      <div class="bg-light rounded h-100 p-4" style="height:75px !important;padding-bottom:50px" >
                          <span> <asp:TextBox runat="server" id="txtSearchCase" cssClass="form-control border-0" type="search" width="80%" placeholder="Search Case" > </asp:TextBox></span>
                          <span><asp:Button ID="btnSearchCase" runat="server" Text="SEARCH" style="float:right;" type="button" cssClass="btn btn-outline-primary m-2" OnClick="btnSearchCase_Click"  /></span>
                     </div>
             </div>
       </div>
   </div>
   <asp:Panel ID="panelFoundItem" runat="server">
              <div class="col-12" style="padding:20px">
                    <div class="bg-light rounded h-100 p-4">
                       <div class="table-responsive">
                            <asp:Label ID="lblSearchClient" ForeColor="Red" Font-Bold="true" runat="server" ></asp:Label>

                           <!-- CLIENT GRIDVEW -->

                            <asp:GridView ID="GridViewSearchClient" runat="server" AutoGenerateColumns="False" CssClass="table" OnRowCommand="GridViewSearchClient_RowCommand">
                                <Columns>
                                    <asp:ImageField DataImageUrlField="files" HeaderText="picture" ControlStyle-Height="80px" ControlStyle-BorderColor="red"> </asp:ImageField>
                                    <asp:TemplateField HeaderText="Client_ID">
                                        <ItemTemplate>
                                            <a href='clientProfile.aspx?cmd=DeletedProfile&&Cid=<%# Eval("client_ID")%>'> <%# Eval("client_ID") %> </a>                                         
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     
                                    <asp:BoundField DataField="client_Name" HeaderText="NAME" SortExpression="client_Name" ItemStyle-ForeColor="Black" ></asp:BoundField>
                                    <asp:BoundField DataField="client_Gender" HeaderText="GENDER" SortExpression="client_Gender"></asp:BoundField>
                                    <asp:BoundField DataField="client_DOB" HeaderText="DoB" SortExpression="client_DOB"></asp:BoundField>
                                    <asp:BoundField DataField="client_Address" HeaderText="ADDRESS" SortExpression="client_Address"></asp:BoundField>
                                    <asp:BoundField DataField="client_Mobile1" HeaderText="Mobile1" SortExpression="client_Mobile1"></asp:BoundField>
                                    <asp:BoundField DataField="client_Mobile2" HeaderText="Mobile2" SortExpression="client_Mobile2"></asp:BoundField>
                                    <asp:TemplateField HeaderText="RESTORE">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CommandName="restore" CommandArgument='<%# Eval("client_ID")%>' >RESTORE</asp:LinkButton>                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="comments" HeaderText="comments" SortExpression="comments"></asp:BoundField>                               
                                </Columns>
                            </asp:GridView>

                           <!-- CASE GRIDVIEW -->


                                <asp:GridView ID="GridViewSearchCase" runat="server" AutoGenerateColumns="False" cssClass="table text-start align-middle table-bordered table-hover mb-0" OnRowCommand="GridViewSearchCase_RowCommand" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="CASE ID" >
                                            <ItemTemplate>
                                                <a href='caseProfile.aspx?cmd=DeletedProfile&&CaseID=<%# Eval("case_ID")%>'> <%# Eval("case_ID") %> </a>
                                            </ItemTemplate>
                                    </asp:TemplateField>
                                        
                                        <asp:BoundField DataField="court_Type" HeaderText="COURT TYPE" SortExpression="court_Type" />
                                        <asp:BoundField DataField="case_Type" HeaderText="CASE TYPE" SortExpression="case_Type" />
                                
                                        <asp:TemplateField HeaderText="CLIENT ID" >
                                            <ItemTemplate>
                                                <a href='#'> <%# Eval("client_ID") %> </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Vs">
                                            <ItemTemplate >
                                                <a href="#">Vs</a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="opponent_Name" HeaderText="OPPONENT NAME" SortExpression="opponent_Name" />
                                        <asp:BoundField DataField="opponent_Address" HeaderText="OPPONENT ADDRESS" SortExpression="opponent_Address" />
                                         <asp:TemplateField HeaderText="RESTORE">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="restore" CommandArgument='<%# Eval("case_ID")%>' >RESTORE</asp:LinkButton>                                            
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="case_Court_Session" HeaderText="Session" SortExpression="case_Court_Session" />
                                        <asp:BoundField DataField="case_Date" HeaderText="case_Date" SortExpression="case_Date" />
                                        <asp:BoundField DataField="case_Court_No" HeaderText="Court_No" SortExpression="case_Court_No" />
                                        <asp:BoundField DataField="case_No" HeaderText="case_No" SortExpression="case_No" />
                                        <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                                        <asp:BoundField DataField="deleted_on" HeaderText="DELETED ON" SortExpression="deleted_on" />
                                    </Columns>
                                </asp:GridView>
                        </div>
                    </div>
                  </div>
                    </asp:Panel>

    </form>

</asp:Content>

