using System.Web;

namespace TechSol.StudentManagementSystem.Utility.Common
{
    public static class Common
    {
        public const int MaxFileSize = 25;
        public static string TrimEncryptedString(string value)
        {
            while (value.EndsWith("="))
                value = value.Substring(0, value.Length - 1);

            return value;
        }

        public static string FixLengthOfEncryptedString(string value)
        {
            if (value.Length % 4 > 0)
                value = value.PadRight(value.Length + 4 - value.Length % 4, '=');

            return value;
        }

        public static DateTime GetLocalDateTime(string TimeZone, DateTime dateFromDB)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TimeZone))
                    return DateTime.Now;


                DateTime utc = dateFromDB;
                TimeZoneInfo zone = TimeZoneInfo.FindSystemTimeZoneById(TimeZone);
                DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(utc, zone);
                return localDateTime;
            }
            catch
            {
                return DateTime.Now;
            }
        }

        public static bool IsNumericType(Type t)
        {
            Type underLyingType = Nullable.GetUnderlyingType(t);
            TypeCode typeCode = TypeCode.String;
            if (underLyingType == null)
                typeCode = Type.GetTypeCode(t);
            else
                typeCode = Type.GetTypeCode(underLyingType);
            switch (typeCode)
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsDateType(Type t)
        {
            Type underLyingType = Nullable.GetUnderlyingType(t);
            TypeCode typeCode = TypeCode.String;
            if (underLyingType == null)
                typeCode = Type.GetTypeCode(t);
            else
                typeCode = Type.GetTypeCode(underLyingType);
            switch (typeCode)
            {
                case TypeCode.DateTime:
                    return true;
                default:
                    return false;
            }
        }
        private static DateTime getLastSunday(DateTime aDate)
        {
            return aDate.AddDays(7 - (int)aDate.DayOfWeek).AddDays(-7);
        }

        public static string DecodeFromBase64(string encodedData)
        {
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);



            string returnValue = System.Text.Encoding.Unicode.GetString(encodedDataAsBytes);



            return returnValue;
        }
        public static string EncodeToBase64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.Encoding.Unicode.GetBytes(toEncode);



            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);



            return returnValue;
        }

        public static string EncodeForUrl(string toEncode)
        {
            return HttpUtility.UrlEncode(toEncode);
        }
        public static string DecodeFromUrl(string toEncode)
        {
            return HttpUtility.UrlDecode(toEncode);
        }

        public static string GetQueryString(Dictionary<string, string> dic)
        {
            string query = "_";
            foreach (var item in dic)
            {
                query += item.Key + "_" + item.Value + "_";
            }
            return query;
        }

        public static bool IsNumeric(string sNumber)
        {
            Decimal a;
            bool isNumeric = true;
            try
            {
                a = Decimal.Parse(sNumber);
            }
            catch
            {
                isNumeric = false;
            }
            return isNumeric;
        }
        public static bool IsBoolean(string sBool)
        {
            bool value;
            return bool.TryParse(sBool, out value);
        }

        public static bool ValidExtension(string ext)
        {
            ext = ext.Replace(".", "");
            if (ext == "txt" || ext == "csv" || ext == "pdf" || ext == "xlsx" || ext == "zip" || ext == "doc" || ext == "docx" || ext == "xml" || ext == "xls" || ext == "jpg" || ext == "jpeg" || ext == "png" || ext == "ppt" || ext == "rpt" || ext == "aci" || ext == "zap" || ext == "zoo")
            {
                return true;
            }
            return false;
        }
        public static string GetErrorMessage(Exception ex)
        {
            string message = "";
            string innerMessage = "";

            if (ex != null)
            {
                if (ex.InnerException != null)
                {
                    innerMessage = GetErrorMessage(ex.InnerException);
                }

                message = ex.Message + "\n" + innerMessage;
            }
            return message;
        }

        public static DateTime GetAppDate(string timezone = "")
        {
            DateTime AppDate = DateTime.UtcNow;

            //DateTime AppDate = System.DateTime.Today;

            //  DateTime AppDate = System.Data.SqlTypes.SqlDateTime.Today;

            //string Timezone = HttpContext.Current.Application["Timezone"].ToString();



            if (!String.IsNullOrEmpty(timezone))
            {
                foreach (TimeZoneInfo tzi in TimeZoneInfo.GetSystemTimeZones())
                {
                    if (tzi.Id == timezone)
                    {
                        AppDate = System.DateTime.UtcNow.AddHours(tzi.BaseUtcOffset.TotalHours).Date;
                    }
                }
            }



            return AppDate;
        }

        public static DateTime GetAppDateTime(string timezone = "")
        {
            DateTime AppDate = System.DateTime.Now;
            //string Timezone = HttpContext.Current.Application["Timezone"].ToString();
            double hoursToAdd = 0;
            if (!String.IsNullOrEmpty(timezone))
            {
                foreach (TimeZoneInfo tzi in TimeZoneInfo.GetSystemTimeZones())
                {
                    if (tzi.Id == timezone)
                    {
                        hoursToAdd = tzi.BaseUtcOffset.TotalHours;
                        if (tzi.IsDaylightSavingTime(AppDate))
                        {
                            hoursToAdd += 1;
                        }
                        AppDate = System.DateTime.UtcNow.AddHours(hoursToAdd);
                        break;
                    }
                }
            }



            return AppDate;
        }




        #region Helper Methods

        public static T GetValue<T>(string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (typeof(T) == typeof(long) || typeof(T) == typeof(long?))
                    {
                        if (long.TryParse(value, out long result))
                            return (T)(object)result;
                        else
                            return default(T);
                    }
                    if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
                    {
                        if (int.TryParse(value, out int result))
                            return (T)(object)result;
                        else
                            return default(T);
                    }
                    if (typeof(T) == typeof(double) || typeof(T) == typeof(double?))
                    {
                        if (double.TryParse(value, out double result))
                            return (T)(object)result;
                        else
                            return default(T);
                    }
                    if (typeof(T) == typeof(decimal?) || typeof(T) == typeof(decimal))
                    {
                        if (decimal.TryParse(value, out decimal result))
                            return (T)(object)result;
                        else
                            return default(T);
                    }

                    if (typeof(T) == typeof(DateTime?) || typeof(T) == typeof(DateTime))
                    {
                        if (DateTime.TryParse(value, out DateTime result))
                            return (T)(object)result;
                        else
                            return default(T);
                    }

                    if (typeof(T) == typeof(bool?) || typeof(T) == typeof(bool))
                    {
                        if (bool.TryParse(value, out bool result))
                            return (T)(object)result;
                        else
                            return default(T);
                    }
                    if (typeof(T) == typeof(Guid?) || typeof(T) == typeof(Guid))
                    {
                        if (Guid.TryParse(value, out Guid result))
                            return (T)(object)result;

                        else
                            return default(T);

                    }

                    return (T)(object)(value);
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception)
            {
                return default(T);
            }


        }

        #endregion
    }
}
    