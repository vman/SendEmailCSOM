using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SendEmailCSOM
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ClientContext clientContext = new ClientContext("https://yoursite.sharepoint.com/"))
            {
                SecureString passWord = new SecureString();

                foreach (char c in "password".ToCharArray()) passWord.AppendChar(c);

                clientContext.Credentials = new SharePointOnlineCredentials("loginname@yoursite.onmicrosoft.com", passWord);

                EmailProperties emailProps = new EmailProperties();

                List<string> toList = new List<string>() { "user@yoursite.onmicrosoft.com" };
                
                emailProps.To = toList;

                emailProps.From = "loginname@yoursite.onmicrosoft.com";
                
                emailProps.Body = "Body of the email";
                
                emailProps.Subject = "Email from CSOM";

                Microsoft.SharePoint.Client.Utilities.Utility.SendEmail(clientContext, emailProps);

                Console.WriteLine("Executing Query...");

                clientContext.ExecuteQuery();

                Console.WriteLine("done");

                Console.ReadLine();
            }
        }
    }
}
