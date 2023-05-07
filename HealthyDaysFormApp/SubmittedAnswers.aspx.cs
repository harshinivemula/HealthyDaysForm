using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HealthyDaysFormApp
{
    public partial class SubmittedAnswers : System.Web.UI.Page
    {
        protected Label lblsubmittedAnswers;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SubmittedAnswers"] != null)
            {
                lblsubmittedAnswers.Text = Session["SubmittedAnswers"].ToString(); 
            }
        }
    }
}
