using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using comp2084_lesson8.Models;

namespace comp2084_lesson8
{
    public partial class courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            GetCourses();
        }



        protected void GetCourses()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var courses = from c in db.Courses
                              select c;

                grdCourses.DataSource = courses.ToList();
                grdCourses.DataBind();
            }
        }
    }
}