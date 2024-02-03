<%@ Page Title="" Language="C#" MasterPageFile="~/master.master" AutoEventWireup="true" CodeFile="caseProfile.aspx.cs" Inherits="caseProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="caseProfileform" runat="server">
        <br />
        <div class="col-sm-12 col-xl-6" style="padding-left: 20px; width: 98.3%; height: auto !important">
            <div class="bg-light rounded h-100 p-4">
                <h6 class="mb-4">Case Profile</h6>
                <div class="owl-carousel testimonial-carousel">
                    <div class="testimonial-item text-center">

                        <h4>
                            <asp:Label runat="server" ID="Label1"></asp:Label></h4>

                        <h5 class="mb-4">
                            <asp:Label ForeColor="RED" runat="server" ID="lblCaseID">Case ID :</asp:Label></h5>
                        <br />
                        <h4>
                            <asp:Label runat="server" ID="lblClientName2"></asp:Label>
                            <span style="color: red; font-size: 40px">Vs</span>
                            <asp:Label runat="server" ID="lblOppoName"></asp:Label>
                        </h4>
                        <asp:DataList runat="server" ID="dataListCaseDetail" />
                        <table class="table table-striped">
                            <tbody>


                                <tr>
                                    <td>COURT TYPE : </td>
                                    <td>
                                        <asp:Literal runat="server" ID="lblCourtType" EnableViewState="false" />

                                    </td>

                                </tr>
                                <tr>
                                    <td>CASE TYPE : </td>
                                    <td>
                                        <asp:Literal runat="server" ID="lblCaseType" EnableViewState="false" /></td>
                                </tr>
                                <tr>
                                    <td>CASE FEES : </td>
                                    <td>
                                        <asp:Literal runat="server" ID="lblCaseFees" EnableViewState="false" /></td>
                                </tr>
                                <tr>
                                    <td>OPPONANT NAME : </td>
                                    <td>
                                        <asp:Literal runat="server" ID="lblOppoName1" EnableViewState="false" /></td>
                                </tr>
                                <tr>
                                    <td>OPPONANT ADDRESS : </td>
                                    <td>
                                        <asp:Literal runat="server" ID="lblOppoAddress" EnableViewState="false" /></td>
                                </tr>
                                <tr>
                                    <td>COURT SESSION : </td>
                                    <td>
                                        <asp:Literal runat="server" ID="lblCourtSession" EnableViewState="false" /></td>
                                </tr>
                                <tr>
                                    <td>CASE DATE : </td>
                                    <td>
                                        <asp:Literal runat="server" ID="lblCaseDate" EnableViewState="false" /></td>
                                </tr>
                                <tr>
                                    <td>COURT NUMBER : </td>
                                    <td>
                                        <asp:Literal runat="server" ID="lblCourtNumber" EnableViewState="false" /></td>
                                </tr>
                                <tr>
                                    <td>CASE NO : </td>
                                    <td>
                                        <asp:Literal runat="server" ID="lblCaseNumber" EnableViewState="false" /></td>
                                </tr>
                                <tr>
                                    <td>DESCRIPTION : </td>
                                    <td>
                                        <asp:Literal runat="server" ID="lblCaseDescription" EnableViewState="false" /></td>
                                </tr>

                            </tbody>
                        </table>
                        </asp:DataList> 
                                    <div style="float: right">
                                        <asp:Button ID="btnEditCase" runat="server" Text="EDIT" CssClass="btn btn-primary m-2" Width="180px" OnClick="btnEditCase_Click" />
                                    </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <hr />
        <br />
        <!--                                             HEARING PARTITION                            -->
        <div class="col-sm-12 col-xl-6" style="padding-left: 20px; width: 98.3%; height: auto !important">
            <div class="bg-light rounded h-100 p-4">
                <h6 class="mb-4">Case Hearing</h6>
                <div class="col-12" style="padding-left: 20PX; padding-top: 20PX; width: 95%">
                    <div class="table-responsive">
                        <asp:GridView ID="HearingGridview" runat="server" AutoGenerateColumns="False" OnRowCommand="HearingGridview_RowCommand"
                            OnRowDeleting="HearingGridview_RowDeleting" CssClass="table text-start align-middle table-bordered table-hover mb-0"
                            BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Height="120px" Width="1288px">
                            <Columns>

                                <asp:BoundField DataField="hearingDate" HeaderText="Hearing Date" SortExpression="hearingDate" ItemStyle-Width="45px" />
                                <asp:BoundField DataField="courtNumber" HeaderText="Court No." SortExpression="courtNumber" ItemStyle-Width="45px" />
                                <asp:BoundField DataField="magistrateName" HeaderText="Judge Name" SortExpression="magistrateName" ItemStyle-Width="45px" />
                                <asp:BoundField DataField="hearingStatus" HeaderText="Status" SortExpression="hearingStatus" ItemStyle-Width="45px" />
                                <asp:BoundField DataField="nextHearingDate" HeaderText="Next Hearing Date" SortExpression="nextHearingDate" ItemStyle-Width="32px" />
                                <asp:BoundField DataField="nextHearingTime" HeaderText="Next Hearing Time" SortExpression="nextHearingTime" ItemStyle-Width="45px" />
                                <asp:TemplateField HeaderText="Edit" ItemStyle-Width="45px" ControlStyle-ForeColor="DarkBlue">
                                    <ItemTemplate>
                                        <a href='addHearing.aspx?cmd=edit&&HearingID=<%# Eval("HearingID")%>'>Edit</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="REMOVE" ItemStyle-Width="45px" ControlStyle-ForeColor="Red">
                                    <ItemTemplate>
                                        <asp:LinkButton id="btnDeleteCase" runat="server" commandname="delete" commandargument='<%# Eval("HearingID") %>'>Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>

                    </div>
                    <asp:Button ID="btnAddHearing" runat="server" Text="ADD HEARING" CssClass="btn btn-primary m-2" Width="180px" OnClick="btnAddHearing_Click" />
                </div>
            </div>
            <br />
            <hr />
            <br />
    </form>

</asp:Content>


