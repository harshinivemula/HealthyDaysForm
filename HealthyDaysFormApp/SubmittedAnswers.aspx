<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmittedAnswers.aspx.cs" Inherits="HealthyDaysFormApp.SubmittedAnswers" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Submitted Answers</title>
    <link href="healthydaysform.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Submitted Answers</h1>
            <asp:Label ID="lblsubmittedAnswers" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>