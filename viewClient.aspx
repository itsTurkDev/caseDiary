<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="viewClient.aspx.cs" Inherits="viewClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form2" runat="server">
        <div class="col-12" style="padding:20px">
                        <div class="bg-light rounded h-100 p-4"  >
                            <h6 class="mb-4">Cliend Detail</h6>
                            <div class="table table-hover">
                            <asp:GridView ID="clientDataGridview" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" OnRowCommand="clientDataGridview_RowCommand" OnRowDeleting="clientDataGridview_RowDeleting" >
                                <Columns>
                                    <asp:ImageField DataImageUrlField="files" HeaderText="picture" ControlStyle-Height="80px" ControlStyle-BorderColor="red"> </asp:ImageField>
                                    <asp:TemplateField HeaderText="Client_ID" >
                                        <ItemTemplate>
                                            <a href='clientProfile.aspx?cmd=Profile&&Cid=<%# Eval("client_ID")%>'> <%# Eval("client_ID") %> </a>
                                           <!--<asp:HyperLink NavigateUrl="https://google.com" runat="server" Text="myedit" ></asp:HyperLink> <asp:BoundField DataField="client_ID" HeaderText="client_ID" ReadOnly="True" InsertVisible="False" SortExpression="client_ID"></asp:BoundField> -->
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="client_Name" HeaderText="NAME" SortExpression="client_Name" ItemStyle-ForeColor="black" ></asp:BoundField>
                                    <asp:BoundField DataField="client_Gender" HeaderText="GENDER" SortExpression="client_Gender"></asp:BoundField>
                                    <asp:BoundField DataField="client_DOB" HeaderText="DoB" SortExpression="client_DOB"></asp:BoundField>
                                    <%--<asp:BoundField DataField="client_Address" HeaderText="ADDRESS" SortExpression="client_Address"></asp:BoundField>
                                    <asp:BoundField DataField="client_Mobile1" HeaderText="Mobile1" SortExpression="client_Mobile1"></asp:BoundField>
                                    <asp:BoundField DataField="client_Mobile2" HeaderText="Mobile2" SortExpression="client_Mobile2"></asp:BoundField>--%>
                                    <asp:BoundField DataField="comments" HeaderText="comments" SortExpression="comments"></asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CommandName="delete" CommandArgument='<%# Eval("client_ID") %>'>Delete</asp:LinkButton>
                                        </ItemTemplate>                                        
                                    </asp:TemplateField>                                    
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
        
    <!-- <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:caseDiaryConnectionString %>' SelectCommand="SELECT * FROM [client_Detail]"></asp:SqlDataSource> -->
    </form>
        
</asp:Content>

