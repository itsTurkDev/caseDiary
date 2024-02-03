<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="viewCase.aspx.cs" Inherits="viewCase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <form id="form2" runat="server">
        <div class="col-12" style="padding-left:20PX; padding-top:20PX ; width:98.5% " >
                        <div class="bg-light rounded h-100 p-4">
                            <h6 class="mb-4">CASE Detail</h6>
                            <div class="table table-hover">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" cssClass="table text-start align-middle table-bordered table-hover mb-0" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="Gridview1_RowCommand"   >
                                    <Columns>
                                        <asp:TemplateField HeaderText="CASE ID" >
                                        <ItemTemplate>
                                            <a href='caseProfile.aspx?cmd=Profile&&CaseID=<%# Eval("case_ID")%>'> <%# Eval("case_ID") %> </a>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <%-- <asp:BoundField DataField="case_ID" HeaderText="case_ID" InsertVisible="False" ReadOnly="True" SortExpression="case_ID" />--%>
                                        <asp:BoundField DataField="client_ID" HeaderText="CLIENT ID" SortExpression="client_ID" />
                                        <asp:BoundField DataField="court_Type" HeaderText="COURT TYPE" SortExpression="court_Type" />
                                        <asp:BoundField DataField="case_Type" HeaderText="CASE TYPE" SortExpression="case_Type" />
                                        <asp:BoundField DataField="case_Fess" HeaderText="FESS" SortExpression="case_Fess" />
                                        <asp:BoundField DataField="client_Name" HeaderText="CLIENT NAME" SortExpression="opponent_Name" />
                                        <asp:TemplateField HeaderText="Vs">
                                            <ItemTemplate >
                                                <a href="#">Vs</a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="opponent_Name" HeaderText="OPPONENT NAME" SortExpression="opponent_Name" />
                                        <asp:BoundField DataField="opponent_Address" HeaderText="OPPONENT ADDRESS" SortExpression="opponent_Address" />
                                        <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDeleteCase" runat="server" CommandName="delete" CommandArgument='<%# Eval("case_ID") %>'>Delete</asp:LinkButton>
                                        </ItemTemplate>                                        
                                    </asp:TemplateField> 
                                        <%--<asp:BoundField DataField="case_Court_Session" HeaderText="case_Court_Session" SortExpression="case_Court_Session" />
                                        <asp:BoundField DataField="case_Date" HeaderText="case_Date" SortExpression="case_Date" />
                                        <asp:BoundField DataField="case_Court_No" HeaderText="case_Court_No" SortExpression="case_Court_No" />
                                        <asp:BoundField DataField="case_No" HeaderText="case_No" SortExpression="case_No" />
                                        <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />--%>
                                    </Columns>
                                </asp:GridView>
                               <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:caseDiaryConnectionString %>" SelectCommand="SELECT * FROM [case_detail]"></asp:SqlDataSource>--%>
                        </div>
                    </div>
                </div>
        
    
    </form>



</asp:Content>

