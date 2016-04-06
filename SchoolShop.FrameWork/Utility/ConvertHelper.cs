using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolShop.FrameWork.Utility
{
    public class ConvertHelper
    {

        public static object DBNullToStr(object obj)
        {
            return obj == System.DBNull.Value ? "" : obj;
        }

        public static string ToString(object obj)
        {
            string result = string.Empty;
            if (obj != null && obj != DBNull.Value)
            {
                result = obj.ToString();
            }
            return result;
        }

        public static DateTime ToDate(object datetime)
        {
            DateTime result;
            if (datetime != null && DateTime.TryParse(datetime.ToString(), out result))
                return result;
            else
                return new DateTime(1900, 1, 1);
        }

        public static string ToDateStr(object datetime)
        {
            DateTime result;
            if (datetime != null && DateTime.TryParse(datetime.ToString(), out result) && (result != new DateTime(1900, 1, 1) && result != new DateTime(1, 1, 1)))
                return result.ToString("yyyy-MM-dd").Replace("1753-01-01", "").Replace("1753-1-1", "").Replace("9999-12-31", "");
            else
                return string.Empty;
        }

        public static string ToDateStrByDot(object datetime)
        {
            DateTime result;
            if (datetime != null && DateTime.TryParse(datetime.ToString(), out result) && (result != new DateTime(1900, 1, 1) && result != new DateTime(1, 1, 1)))
                return result.ToString("yyyy.MM.dd");
            else
                return string.Empty;
        }

        public static string ToDateLongStr(object datetime)
        {
            DateTime result;
            if (datetime != null && DateTime.TryParse(datetime.ToString(), out result) && (result != new DateTime(1900, 1, 1, 0, 0, 0) && result != new DateTime(1, 1, 1, 0, 0, 0)))
                return result.ToString("yyyy-MM-dd HH:mm:ss");
            else
                return string.Empty;
        }

        public static int ToInt(object value)
        {
            int result;
            if (value != null && int.TryParse(value.ToString(), out result))
                return result;
            else
                return 0;
        }

        public static double ToDouble(object value)
        {
            double result;
            if (value != null && double.TryParse(value.ToString().Replace(",", ""), out result))
                return result;
            else
                return 0.0;
        }

        public static float ToFloat(object value)
        {
            float result;
            if (value != null && float.TryParse(value.ToString().Replace(",", ""), out result))
                return result;
            else
                return 0.0f;
        }

        public static Decimal ToDecimal(object value)
        {
            Decimal result;
            if (value != null && Decimal.TryParse(value.ToString().Replace(",", ""), out result))
                return result;
            else
                return new Decimal(0);
        }

        public static Guid ToGuid(object value)
        {
            Guid result;
            if (value != null && Guid.TryParse(value.ToString(), out result))
                return result;
            else
                return Guid.Empty;
        }

        public static bool ToBool(object value)
        {
            bool result;
            if (value != null && bool.TryParse(value.ToString(), out result))
                return result;
            else
                return false;
        }

        public static string ToBoolStr(object value)
        {
            bool result;
            if (value != null && bool.TryParse(value.ToString(), out result))
                return result.ToString().ToLower();
            else
                return "false";
        }

        public static string ToUpperMoney(string moneyString)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖";
            string str2 = "分角元拾佰仟万拾佰仟亿拾佰仟兆拾佰仟";
            string[] strArray = moneyString.Split('.');
            string str3 = moneyString;
            string str4 = "";
            string str5 = "";
            if (strArray.Length > 1)
            {
                str3 = strArray[0];
                str4 = strArray[1];
            }
            string str6 = (str4 + "00").Substring(0, 2);
            string str7 = str3 + str6;
            try
            {
                int index1 = str7.Length - 1;
                if (index1 <= 0 || index1 >= 18)
                    return "";
                for (int index2 = 0; index2 <= index1; ++index2)
                {
                    int index3 = (int)str7[index2] - 48;
                    int num = index2 + 1 >= index1 ? (int)str7[index1] - 48 : (int)str7[index2 + 1] - 48;
                    if (index3 == 0)
                    {
                        if (index1 - index2 == 2 || index1 - index2 == 6 || index1 - index2 == 10 || index1 - index2 == 14)
                            str5 = str5 + (object)str2[index1 - index2];
                        else if (num != 0)
                            str5 = str5 + (object)str1[index3];
                    }
                    else
                        str5 = str5 + (object)str1[index3] + (string)(object)str2[index1 - index2];
                }
                return str5.Replace("兆亿万", "兆").Replace("兆亿", "兆").Replace("亿万", "亿").TrimStart('元').TrimStart('零');
            }
            catch
            {
                return "";
            }
        }

        public static string ToUpperMoney(Decimal money)
        {
            return ConvertHelper.ToUpperMoney(money.ToString());
        }

        public static string ToUpperDate(DateTime date)
        {
            StringBuilder stringBuilder1 = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            StringBuilder stringBuilder3 = new StringBuilder();
            foreach (char ch in date.Year.ToString().ToCharArray())
            {
                switch (ch)
                {
                    case '0':
                        stringBuilder1.Append("〇");
                        break;
                    case '1':
                        stringBuilder1.Append("一");
                        break;
                    case '2':
                        stringBuilder1.Append("二");
                        break;
                    case '3':
                        stringBuilder1.Append("三");
                        break;
                    case '4':
                        stringBuilder1.Append("四");
                        break;
                    case '5':
                        stringBuilder1.Append("五");
                        break;
                    case '6':
                        stringBuilder1.Append("六");
                        break;
                    case '7':
                        stringBuilder1.Append("七");
                        break;
                    case '8':
                        stringBuilder1.Append("八");
                        break;
                    default:
                        stringBuilder1.Append("九");
                        break;
                }
            }
            int num1 = date.Month;
            if (date.Month > 9)
            {
                stringBuilder2.Append("十");
                num1 = date.Month - 10;
            }
            switch (num1)
            {
                case 1:
                    stringBuilder2.Append("一");
                    break;
                case 2:
                    stringBuilder2.Append("二");
                    break;
                case 3:
                    stringBuilder2.Append("三");
                    break;
                case 4:
                    stringBuilder2.Append("四");
                    break;
                case 5:
                    stringBuilder2.Append("五");
                    break;
                case 6:
                    stringBuilder2.Append("六");
                    break;
                case 7:
                    stringBuilder2.Append("七");
                    break;
                case 8:
                    stringBuilder2.Append("八");
                    break;
                case 9:
                    stringBuilder2.Append("九");
                    break;
            }
            int num2 = date.Day;
            if (date.Day > 29)
            {
                stringBuilder3.Append("三十");
                num2 = date.Day - 30;
            }
            else if (date.Day > 19)
            {
                stringBuilder3.Append("二十");
                num2 = date.Day - 20;
            }
            else if (date.Day > 9)
            {
                stringBuilder3.Append("十");
                num2 = date.Day - 10;
            }
            switch (num2)
            {
                case 1:
                    stringBuilder3.Append("一");
                    break;
                case 2:
                    stringBuilder3.Append("二");
                    break;
                case 3:
                    stringBuilder3.Append("三");
                    break;
                case 4:
                    stringBuilder3.Append("四");
                    break;
                case 5:
                    stringBuilder3.Append("五");
                    break;
                case 6:
                    stringBuilder3.Append("六");
                    break;
                case 7:
                    stringBuilder3.Append("七");
                    break;
                case 8:
                    stringBuilder3.Append("八");
                    break;
                case 9:
                    stringBuilder3.Append("九");
                    break;
            }
            return string.Format("{0}年{1}月{2}日", (object)((object)stringBuilder1).ToString(), (object)((object)stringBuilder2).ToString(), (object)((object)stringBuilder3).ToString());
        }
    }
}
