﻿<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="course-details.aspx.cs" Inherits="comp2084_lesson8.course_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Course Details</h1>
    <h5>All fields are required</h5>

    <div class="form-group">
        <label for="txtTitle" class="col-sm-2">Title:</label>
        <asp:TextBox runat="server" ID="txtTitle" required MaxLength="100" />
    </div>
    <div class="form-group">
        <label for="txtCredits" class="col-sm-2">Credits:</label>
        <asp:TextBox runat="server" ID="txtCredits" required  type="number" />
    </div>
        <div class="form-group">
        <label for="ddlDepartment" class="col-sm-2">Department:</label>
        <asp:DropDownList ID="ddlDepartment" runat="server" DataTextField="Name" DataValueField="DepartmentID"></asp:DropDownList>
        <asp:RangeValidator runat="server" ControlToValidate="ddlDepartment" Type="Integer" MinimumValue="1" MaximumValue="1000" ErrorMessage="Required" CssClass="label label-danger" />
    </div>
    <div class="col-sm-offset-2">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>

    <asp:Panel ID="pnlEnrollments" runat="server">
        <h2>Student Enrollments</h2>

        <asp:GridView ID="grdEnrollments" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
            <Columns>
                <asp:BoundField DataField="Student.LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="Student.FirstMidName" HeaderText="First Name" />
                <asp:BoundField DataField="Grade" HeaderText="Grade" />

            </Columns>
        </asp:GridView>
    </asp:Panel>

</asp:Content>
