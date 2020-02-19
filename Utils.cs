using System;
using System.Text;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using MedalynxAPI.Models;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace MedalynxAPI {
    public static class Utils {
        private static Guid ForEmptyGuid(bool canCreate) {
            if (canCreate) {return Guid.NewGuid();}
            else {return new Guid();}
        }

        public static Guid ToGuid (string stringGuid, bool canCreate = true) {
            try
            {
                Guid newGuid = Guid.Parse(stringGuid);
                return newGuid;
            }
            catch (ArgumentNullException)
            {
                return ForEmptyGuid(canCreate);
            }
            catch (FormatException)
            {
                return ForEmptyGuid(canCreate);
            }
        }

        public static bool CopyPropertyValues<T>(T src, T dest){
            bool updated = false;
            PropertyInfo[] srcPropsInfo = src.GetType().GetProperties();
            foreach (PropertyInfo pi in srcPropsInfo) {
                var srcPropValue = pi.GetValue(src);

                if (srcPropValue == null) { continue; } // value is not initialized

                var propType = pi.PropertyType;
                if (propType == typeof(DateTime)){
                    // check the value required
                    if ((DateTime) srcPropValue == DateTime.MinValue)
                    {
                        // unassigned (i.e. date time is null)
                        continue;
                    }
                }

                var destPropValue = pi.GetValue(dest);

                if (srcPropValue == destPropValue) { continue; } // value is same. nothing to update

                pi.SetValue(dest, srcPropValue);

                updated = true;
            }

            return updated; // object changed
        }

        public static bool IsEmpty<T>(T obj){
            if (obj == null) {
                return true;
            }
            PropertyInfo[] srcPropsInfo = obj.GetType().GetProperties();
            foreach (PropertyInfo pi in srcPropsInfo) {
                var srcPropValue = pi.GetValue(obj);

                if (srcPropValue != null) { return false; }
            }

            return true;
        }

        public static bool HasProperty<T>(string propertyName, Type propertyType){
            return typeof(T).GetProperty(propertyName, propertyType) != null;
        }

        public static bool ValidateSession (IHeaderDictionary headers, out string userId) {
            StringValues sessionIdHeaders;
            headers.TryGetValue("Session-Id", out sessionIdHeaders);
 
            if (sessionIdHeaders.Count == 0) {
                userId = (new Guid()).ToString("B");
                return false;
            }

            // check that sessin exists
            Session session = Program.MedialynxData.sessionDBAPI.Get(sessionIdHeaders[0]);
            if (session != null) {
                userId = session.UserId;
                return true;
            }
            userId = (new Guid()).ToString("B");
            return false;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                    RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool IsValidPassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one lower case letter";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one upper case letter";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Password should not be less than 8 or greater than 15 characters";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one numeric value";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one special case characters";
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Guid GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();

            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            foreach (byte b in byteHash) {
                hash += string.Format("{0:x2}", b);
            }

            return new Guid(hash);
        }
    }
}