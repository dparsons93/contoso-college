using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using comp2084_lesson8.Models;

namespace comp2084_lesson8
{
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    GetStudent();
                    pnlCourseEnrollments.Visible = true;
                }
            }
        }

        protected void GetStudent()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                Student stud = (from d in db.Students where d.StudentID == StudentID select d).FirstOrDefault();

                txtLName.Text = stud.LastName;
                txtFName.Text = stud.FirstMidName;
                txtEnrollmentDate.Text = stud.EnrollmentDate.ToString();

                //populate student enrollment grid
                var Enrollments = from en in db.Enrollments
                                  where en.StudentID == StudentID
                                  select en;

                //bind to grid
                grdCourseEnrollments.DataSource = Enrollments.ToList();
                grdCourseEnrollments.DataBind();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                Student stud = new Student();

                if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    stud = (from d in db.Students where d.StudentID == StudentID select d).FirstOrDefault();
                }

                stud.LastName = txtLName.Text;
                stud.FirstMidName = txtFName.Text;
                stud.EnrollmentDate = Convert.ToDateTime(txtEnrollmentDate.Text);

                if (String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    db.Students.Add(stud);
                }
                db.Students.Add(stud);
                db.SaveChanges();

                Response.Redirect("students.aspx");
            }
        }
    }
}