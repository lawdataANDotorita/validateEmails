using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using ARSoft.Tools.Net.Spf;

namespace validateEmails
{
    public static class emailValidator
    {
        public static bool validate(string sEmail)
        {
            bool bIsValid;
            string sIP = "";
            string sDomain = sEmail.Contains("@") ? sEmail.Split("@".ToCharArray())[1] : "";
            bIsValid = validateSyntax(sEmail);
            if (bIsValid && sDomain != "") sIP = getIP(sDomain);
            bIsValid = bIsValid && sIP != "" ? validateDomainEmail(sIP,sDomain) : false;
            return bIsValid;
        }
        private static bool validateSyntax(string sEmail)
        {
            bool bIsValid = true;
            try
            {
                MailAddress oMailAddrs = new MailAddress(sEmail);
            }
            catch (Exception oErr)
            {
                bIsValid = false;
            }
            return bIsValid;
        }
        private static string getIP(string sDomain)
        {
            string sIP = "";
            try
            {
                IPAddress[] arIP = Dns.GetHostAddresses(sDomain);
                if (arIP.Length > 0) sIP = arIP[0].ToString();
            }
            catch (Exception e)
            {
            }
            return sIP;
        }
        static bool validateDomainEmail(string sIP, string sDomain)
        {
            var oValidator = new SpfValidator();
            var mailIpAddress = IPAddress.Parse(sIP);
            var domain = sDomain;
            var senderAddress = "example@"+sDomain;
            ValidationResult oRslt = oValidator.CheckHost(mailIpAddress, domain, senderAddress);
            return oRslt.Result.ToString().ToLower()=="pass" ? true : false;
        }


    }
}
