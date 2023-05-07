using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace HealthyDaysFormApp
{
    public class HealthyDaysForm : System.Web.UI.Page
    {
        protected Panel pnlQuestions;
        protected RadioButtonList rblDischarge;
        protected RadioButtonList rblHealth;
        protected TextBox txtPhysicalHealth;
        protected TextBox txtMentalHealth;
        protected CheckBoxList cblTimeOfDay;

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlQuestions = (Panel)FindControl("pnlQuestions");
            if (!IsPostBack)
            {
                pnlQuestions.Visible = false;
            }
        }


        protected void rblDischarge_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlQuestions.Visible = rblDischarge.SelectedValue == "No";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValidForm())
            {
                string discharge = rblDischarge.SelectedItem.Text;
                string health = rblHealth.SelectedValue;
                string physicalHealth = txtPhysicalHealth.Text;
                string mentalHealth = txtMentalHealth.Text;
                string timeOfDay = string.Join(", ", GetSelectedTimeOfDay());

                string result = $"<h3>Submitted Answers</h3><br/>" +
                $"1. Was discharge completed without client present? {discharge}<br/>";

                if (pnlQuestions.Visible)
                {
                    result += $"2. Would you say in general your health is: {health}<br/>" +
                              $"3. Physical health not good days: {physicalHealth}<br/>" +
                              $"4. Mental health not good days: {mentalHealth}<br/>" +
                              $"5. Time of day experiencing health issues: {timeOfDay}<br/>";
                }

                Session["SubmittedAnswers"] = result; 
                Response.Redirect("SubmittedAnswers.aspx"); 
            }
            else
            {
                Response.Write("Please complete the required fields.");
            }

        }

        private bool IsValidForm()
        {
            if (string.IsNullOrEmpty(rblDischarge.SelectedValue))
            {
                return false;
            }

            if (pnlQuestions.Visible)
            {
                if (string.IsNullOrEmpty(rblHealth.SelectedValue) ||
                    string.IsNullOrEmpty(txtPhysicalHealth.Text) ||
                    string.IsNullOrEmpty(txtMentalHealth.Text))
                {
                    return false;
                }

                int physicalHealthDays = int.Parse(txtPhysicalHealth.Text);
                int mentalHealthDays = int.Parse(txtMentalHealth.Text);
                if ((physicalHealthDays < 0 && (mentalHealthDays < 0 || mentalHealthDays > 30)) || (mentalHealthDays < 0 && (physicalHealthDays < 0 || physicalHealthDays > 30)))
                {

                    Response.Write("Please select a positive value between 0 and 30 for questions 3 and 4.");
                    return false;
                }
                else if (physicalHealthDays > 30 && mentalHealthDays > 30)
                {
                    Response.Write("Please select a value between 0 and 30 for questions 3 and 4.");
                    return false;
                }
                else if (physicalHealthDays > 30)
                {
                    Response.Write("Please select a value between 0 and 30 for question 3.");
                    return false;
                }
                else if (mentalHealthDays > 30)
                {
                    Response.Write("Please select a value between 0 and 30 for question 4.");
                    return false;
                }
                else if (physicalHealthDays < 0)
                {
                    Response.Write("Please select a positive value between 0 and 30 for question 3.");
                    return false;
                }
                else if (mentalHealthDays < 0)
                {
                    Response.Write("Please select a positive value between 0 and 30 for question 4.");
                    return false;
                }
                else if (physicalHealthDays > 30 || mentalHealthDays > 30)
                {
                    Response.Write("Please select a value between 0 and 30 for questions 3 and 4.");
                    return false;
                }

            }

            return true;
        }

        private string[] GetSelectedTimeOfDay()
        {
            var selectedTimes = new List<string>();

            foreach (ListItem item in cblTimeOfDay.Items)
            {
                if (item.Selected)
                {
                    selectedTimes.Add(item.Value);
                }
            }

            return selectedTimes.ToArray();
        }
    }
}
