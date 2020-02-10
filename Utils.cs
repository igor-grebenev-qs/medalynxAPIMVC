using System;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using MedalynxAPI.Models;

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

        public static bool ValidateSession (IHeaderDictionary headers) {
            StringValues sessionIdHeaders;
            headers.TryGetValue("Session-Id", out sessionIdHeaders);
 
            if (sessionIdHeaders.Count == 0) {
                return false;
            }
            // check that sessin exists
            Session session = Program.MedialynxData.sessionDBAPI.Get(sessionIdHeaders[0]);

            return session != null;
        }
    }
}