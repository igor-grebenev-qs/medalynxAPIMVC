using System;
using System.Reflection;

namespace MedalynxAPI {
    public static class Utils {
        private static  Guid ForEmptyGuid(bool canCreate) {
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

                var destPropValue = pi.GetValue(dest);

                if (srcPropValue == destPropValue) { continue; } // value is same. nothing to update

                pi.SetValue(dest, srcPropValue);

                updated = true;
            }

            return updated; // object changed
        }
    }
}