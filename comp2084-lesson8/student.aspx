<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="comp2084_lesson8.student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Student Details</h1>
    <h5>All Fields are required</h5>
     <div class="form-group">
        <label for="txtFName" class="col-sm-2">First Name: </label>
        <asp:TextBox ID="txtFName" runat="server" MaxLength="50" required />
    </div>
    <div class="form-group">
        <label for="txtLName" class="col-sm-2">Last Name: </label>
        <asp:TextBox ID="txtLName" runat="server" MaxLength="50" required />
    </div>
    <div class="form-group">
        <label for="txtEnrollmentDate" class="col-sm-2">Enrollment Date: </label>
        <asp:TextBox ID="txtEnrollmentDate" runat="server" required type="date"/>
    </div>
    <div class="col-sm-offset-2">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click"/>
    </div>

    <asp:Panel ID="pnlCourseEnrollments" runat="server">
        <h2>Course Enrollments</h2>

        <asp:GridView ID="grdCourseEnrollments" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
            <Columns>
                <asp:BoundField DataField="Course.Title" HeaderText="Course" />
                <asp:BoundField DataField="Course.Credits" HeaderText="Credits" />
                <asp:BoundField DataField="Grade" HeaderText="Grade" />

            </Columns>
        </asp:GridView>
    </asp:Panel>

</asp:Content>
