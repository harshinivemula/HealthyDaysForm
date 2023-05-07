<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HealthyDaysForm.aspx.cs" Inherits="HealthyDaysFormApp.HealthyDaysForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Healthy Days</title>
    <link href="healthydaysform.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="text-align:center;">Healthy Days</h1>
            <h3 style="text-align: center;">Questions (2-5) Required Unless Answer to Discharge Question (1) is yes</h3>
            <asp:Label ID="lblDischarge" runat="server" Text="1. Was discharge completed without client present? "></asp:Label>
            <asp:RadioButtonList ID="rblDischarge" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblDischarge_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="Yes (unable to assess)" Value="Yes"></asp:ListItem>
                <asp:ListItem Text="No" Value="No"></asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Panel ID="pnlQuestions" runat="server" Visible="false">
            <asp:Label ID="lblHealth" runat="server" Text="2. Would you say in general your health is: "></asp:Label>
            <asp:RadioButtonList ID="rblHealth" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Excellent (5)" Value="5"></asp:ListItem>
                <asp:ListItem Text="Very good (4)" Value="4"></asp:ListItem>
                <asp:ListItem Text="Good (3)" Value="3"></asp:ListItem>
                <asp:ListItem Text="Fair (2)" Value="2"></asp:ListItem>
                <asp:ListItem Text="Poor (1)" Value="1"></asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Label ID="lblPhysicalHealth" runat="server" Text="3. Now thinking about your physical health, which includes physical illness and injury, for how many days during the past 30 days was your physical health not good? Ans: 0 to 30 "></asp:Label>
            <asp:TextBox ID="txtPhysicalHealth" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="lblMentalHealth" runat="server" Text="4. How thinking about your mental health, which includes stress, depression, and problems with emotions, for how many days during the past 30 days was your mental health not good? Ans: 0 to 30 "></asp:Label>
            <asp:TextBox ID="txtMentalHealth" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="lblTimeOfDay" runat="server" Text="5. During what time of day do you experience physical or mental health issues? (Select all that apply)"></asp:Label>
            <asp:CheckBoxList ID="cblTimeOfDay" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Morning" Value="Morning"></asp:ListItem>
                <asp:ListItem Text="Mid-Afternoon" Value="Mid-Afternoon"></asp:ListItem>
                <asp:ListItem Text="Night" Value="Night"></asp:ListItem>
            </asp:CheckBoxList>
            <br />
            </asp:Panel>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />  
          </div>
        <br />
    </form>
</body>
</html>
