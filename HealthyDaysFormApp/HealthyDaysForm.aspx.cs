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

                Response.Write(result);
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

                bool isPhysicalHealthValid = int.TryParse(txtPhysicalHealth.Text, out _);
                bool isMentalHealthValid = int.TryParse(txtMentalHealth.Text, out _);
                if (!isPhysicalHealthValid || !isMentalHealthValid)
                {
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
