<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="clientProfile.aspx.cs" Inherits="clientProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <form id="form3" runat="server">
                    <div class="col-sm-12 col-xl-6" style="padding-left:20px; width:98.3%;height:auto !important"  >
                      <div class="bg-light rounded h-100 p-4"  >
                            <h6 class="mb-4">Client Profile </h6> 
                            
                        <%-- <div class="owl-carousel testimonial-carousel">--%>
                                <div class="testimonial-item text-center">
                                    <asp:Image ID="imgClientProfilePic" runat="server" CssClass="img-fluid rounded-circle mx-auto mb-4" height="100px" Width="100px" />
                                    <h4><asp:Label runat="server" id="lblClientName"></asp:Label></h4>
                                    <h5><asp:Label ID="lblDeleted" runat="server" ForeColor="Red"></asp:Label></h5>
                                    <h6><asp:Label ID="lblIfMinor" runat="server"></asp:Label></h6>
                                     <%--<div class="bg-secondary rounded h-100 p-4">--%>
                                        <h6 class="mb-4">
                                            <asp:Label  ForeColor="DarkBlue" runat="server" id="lblClientID"></asp:Label></h6>
                                        <table class="table table-striped">
                                            <tbody>
                                                <tr>                                                    
                                                    <td>GENDER : </td>
                                                    <td>
                                                        <asp:Label runat="server" id="lblClientGender"></asp:Label></td>
                                                </tr>
                                                <tr>                                                    
                                                    <td>AGE :  </td>
                                                    <td>
                                                        <asp:Literal runat="server" id="lblClientDoB" EnableViewState="false" /> Years</td>     
                                                </tr>
                                                <tr>                                                    
                                                    <td>ADDRESS : </td>
                                                    <td>
                                                        <asp:Literal runat="server" id="lblClientAddress" EnableViewState="false" /></td>     
                                                </tr>
                                                <tr>                                                    
                                                    <td>MOBILE 1 : </td>
                                                    <td>
                                                        <asp:Literal runat="server" id="lblClientMobile1" EnableViewState="false" /></td>     
                                                </tr>
                                                <tr>                                                    
                                                    <td>MOBILE 2 : </td>
                                                    <td>
                                                        <asp:Literal runat="server" id="lblClientMobile2" EnableViewState="false" /></td>     
                                                </tr>
                                                 <tr>                                                    
                                                    <td>COMMENTS : </td>
                                                     <td>
                                                         <asp:Literal runat="server" ID="lblClientComments" EnableViewState="false" /></td>     
                                                </tr>                                                
                                            </tbody>
                                        </table>
                                         <div style="float:right"> 
                                             <asp:Button ID="btnEditClient" runat="server" Text="EDIT"  cssClass="btn btn-primary m-2" Width="180px"  OnClick="btnEditClient_Click" /> 
                                         </div>                                
                                    </div>
                               </div> 
                    </div>
                      
            
        <br /> <hr /> <br />


       <%-------------------------------------------------------------------- CASE PARTITION -- DOWN PARTITION ------------------------------------------------------------%>
        
        
        <div class="col-sm-12 col-xl-6" style="padding-left:20px; width:98.3%; height:auto !important" >
                        <div class="bg-light rounded h-100 p-4"  >
                            <h6 class="mb-4">Client Case </h6> 
                            <div class="col-12" style="padding-left:20PX; padding-top:20PX ; width:98.5% " >
                            <div class="table-responsive">
                                <asp:GridView ID="caseGridview" runat="server" AutoGenerateColumns="False" cssClass="table text-start align-middle table-bordered table-hover mb-0" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="CASE ID" >
                                        <ItemTemplate>
                                            <a href='caseProfile.aspx?cmd=Profile&&CaseID=<%# Eval("case_ID")%>'> <%# Eval("case_ID") %> </a>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <%-- <asp:BoundField DataField="case_ID" HeaderText="case_ID" InsertVisible="False" ReadOnly="True" SortExpression="case_ID" />--%>
                                       
                                        <asp:BoundField DataField="court_Type" HeaderText="COURT TYPE" SortExpression="court_Type" />
                                        <asp:BoundField DataField="case_Type" HeaderText="CASE TYPE" SortExpression="case_Type" />
                                        <asp:BoundField DataField="case_Fess" HeaderText="FESS" SortExpression="case_Fess" />
                                        
                                        <asp:TemplateField HeaderText="Vs">
                                            <ItemTemplate >
                                                <a href="#">Vs</a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="opponent_Name" HeaderText="OPPONENT NAME" SortExpression="opponent_Name" />
                                        <asp:BoundField DataField="opponent_Address" HeaderText="OPPONENT ADDRESS" SortExpression="opponent_Address" />
                                        <asp:TemplateField>
                                        <ItemTemplate>
                                            <a href='caseProfile.aspx?cmd=Profile&&CaseID=<%# Eval("case_ID")%>'> VIEW</a>
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
                

                            <!-- gridview is added bcoz more then one case is show in short below client profile -->


                            <!-- case profile transfer to the next page  due to more then one case is not possibel to display -->                  


                            <asp:Panel ID="panelAddCase" runat="server">
                                
                                <asp:Button ID="Button3" runat="server" Text="ADD CASE"  cssClass="btn btn-primary m-2" Width="180px" OnClick="Button3_Click"/> 
               
                            </asp:Panel>
                               </div> 
             </div>
           
            
                       
              
                                         <%--<div style="float:right;"> 
                                             <asp:Button ID="Button1" runat="server" Text="EDIT"  cssClass="btn btn-primary m-2" Width="180px"  OnClick="btnEditClient_Click" /> 

                                         </div> --%>                               
                                   
                                
                     <%--  </div>
                  </div>
             </div>   --%>
        </form>        
</asp:Content>

