using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using comp2084_lesson8.Models;

namespace comp2084_lesson8
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            GetStudents();

        }

        protected void GetStudents()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var studs = from d in db.Students
                           select d;

                grdStudents.DataSource = studs.ToList();
                grdStudents.DataBind();
            }
        }

        protected void grdStudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStudents.PageIndex = e.NewPageIndex;
            GetStudents();
        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[e.RowIndex].Values["StudentID"]);

            using (DefaultConnection db = new DefaultConnection())
            {
                Student stud = (from d in db.Students
                                  where d.StudentID == StudentID
                                  select d).FirstOrDefault();

                db.Students.Remove(stud);
                db.SaveChanges();

                GetStudents();
            }
        }
    }
}