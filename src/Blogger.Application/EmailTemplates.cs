namespace Blogger.Application;
public static class EmailTemplates
{
    public static string GetConfirmEngagementEmail(string clientName, string approvedLink)
    {
        return ConfirmEngagementEmail.Replace("{{ClientName}}", clientName)
                                     .Replace("{{ApprovedLink}}", approvedLink);
    }

    private const string ConfirmEngagementEmail = """
        <!DOCTYPE html>
        <html lang="en">
        <head>
            <meta charset="UTF-8">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <title>Confirm Your Engagement</title>
            <style>
                body {
                    font-family: 'Arial', sans-serif;
                    background-color: #f9f9f9;
                    color: #333;
                    margin: 0;
                    padding: 0;
                }
                .container {
                    max-width: 600px;
                    margin: 20px auto;
                    background-color: #ffffff;
                    padding: 30px;
                    border-radius: 8px;
                    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                }
                .header {
                    text-align: center;
                    padding-bottom: 20px;
                    border-bottom: 1px solid #eeeeee;
                }
                .header h1 {
                    margin: 0;
                    color: #2a9d8f;
                    font-size: 24px;
                }
                .content {
                    padding: 20px 0;
                    line-height: 1.6;
                }
                .content p {
                    margin: 15px 0;
                }
                .btn {
                    display: inline-block;
                    padding: 12px 20px;
                    font-size: 16px;
                    color: #ffffff;
                    background-color: #2a9d8f;
                    text-decoration: none;
                    border-radius: 5px;
                    margin: 20px 0;
                    text-align: center;
                }
                .btn:hover {
                    background-color: #21867a;
                }
                .footer {
                    text-align: center;
                    padding-top: 20px;
                    border-top: 1px solid #eeeeee;
                    font-size: 12px;
                    color: #777777;
                }
            </style>
        </head>
        <body>
            <div class="container">
                <div class="header">
                    <h1>Confirm Your Engagement</h1>
                </div>
                <div class="content">
                    <p>Dear {{ClientName}},</p>
                    <p>Thank you for your comment on our article. To ensure that your comment is genuine, we require you to confirm your engagement by clicking the button below.</p>
                    <p><a href="{{ApprovedLink}}" class="btn">Confirm Comment</a></p>
                    <p>If you did not make this comment, you can safely ignore this email.</p>
                    <p>Thank you,<br>The Team</p>
                </div>
                <div class="footer">
                    <p>&copy; 2024 Your Company. All rights reserved.</p>
                </div>
            </div>
        </body>
        </html>
        """;
}
