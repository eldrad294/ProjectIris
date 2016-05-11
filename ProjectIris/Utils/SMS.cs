using System;
using System.IO;
using System.Net;
using System.Text;

namespace ProjectIris.Utils
{
    public class SMS
    {
        public static void SMSConfirmation(string ContactNumber, string Amount, string AccountNumber)
        {
            const string URI = "https://targlets.com/api/Send";
            const string apikey = "a1bc2b3c-6104-4969-9c8d-9b01b3bb2ce7";
            string recipients = "356"+ContactNumber;
            const string senderid = "35699522140";
            string message = "This is an automated message. A transaction of amount " + Amount + " euro has been made from account number " + AccountNumber + ". Thank you for purchasing under IrisScheme.";
            const string type = "0";
            const string rateid = "5d6be126-5ad8-4caa-b79a-b073fdf427de";
            string myParameters = "apikey=" + apikey + "&recipients=" + recipients + "&senderid=" + senderid + "&message=" + message + "&type=" + type + "&rateid=" + rateid + "";

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(URI, myParameters);
            }
        }
    }
}