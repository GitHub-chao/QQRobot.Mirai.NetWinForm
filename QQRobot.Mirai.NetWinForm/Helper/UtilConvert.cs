using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QQRobot.Mirai.NetWinForm.Helper
{
    //
    public static class UtilConvert
    {
        /// <summary>
        /// 对象转int
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static int ToInt(this object thisValue)
        {
            int reval = 0;
            if (thisValue == null) return 0;
            if (thisValue != null && thisValue != DBNull.Value && int.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return reval;
        }
        /// <summary>
        /// 尝试转换thisValue为int，成功返回thisValue 失败返回errorValue
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="errorValue"></param>
        /// <returns></returns>
        public static int ToInt(this object thisValue, int errorValue)
        {
            int reval = 0;
            if (thisValue != null && thisValue != DBNull.Value && int.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return errorValue;
        }
        /// <summary>
        /// 对象转long
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static long ObjToLong(this object thisValue)
        {
            long reval = 0;
            if (thisValue == null) return 0;
            if (thisValue != null && thisValue != DBNull.Value && long.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return reval;
        }
        /// <summary>
        /// 尝试转换thisValue为long，成功返回thisValue 失败返回errorValue
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="errorValue"></param>
        /// <returns></returns>
        public static long ObjToLong(this object thisValue, long errorValue)
        {
            long reval = 0;
            if (thisValue != null && thisValue != DBNull.Value && long.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return errorValue;
        }

        /// <summary>
        /// 对象转double 更多用于钱转换
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static double ObjToDouble(this object thisValue)
        {
            double reval = 0;
            if (thisValue != null && thisValue != DBNull.Value && double.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return 0;
        }
        /// <summary>
        /// 尝试转换thisValue为Double，成功返回thisValue 失败返回errorValue
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="errorValue"></param>
        /// <returns></returns>
        public static double ObjToDouble(this object thisValue, double errorValue)
        {
            double reval = 0;
            if (thisValue != null && thisValue != DBNull.Value && double.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return errorValue;
        }
        /// <summary>
        /// 对象转string
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static string ToStr(this object thisValue)
        {
            if (thisValue != null) return thisValue.ToString().Trim();
            return "";
        }
        /// <summary>
        /// 尝试转换thisValue为string，
        /// 如果thisValue为null,返回errorValue；否则返回thisValue
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="errorValue"></param>
        /// <returns></returns>
        public static string ToStr(this object thisValue, string errorValue)
        {
            if (thisValue != null) return thisValue.ToString().Trim();
            return errorValue;
        }
        /// <summary>
        /// 对象转Decimal
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static Decimal ObjToDecimal(this object thisValue)
        {
            Decimal reval = 0;
            if (thisValue != null && thisValue != DBNull.Value && decimal.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return 0;
        }
        /// <summary>
        /// 尝试转换thisValue为Decimal，
        /// 成功返回thisValue；否则返回errorValue
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="errorValue"></param>
        /// <returns></returns>
        public static Decimal ObjToDecimal(this object thisValue, decimal errorValue)
        {
            Decimal reval = 0;
            if (thisValue != null && thisValue != DBNull.Value && decimal.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return errorValue;
        }
        /// <summary>
        /// 对象转DateTime
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static DateTime ObjToDate(this object thisValue)
        {
            DateTime reval = DateTime.MinValue;
            if (thisValue != null && thisValue != DBNull.Value && DateTime.TryParse(thisValue.ToString(), out reval))
            {
                reval = Convert.ToDateTime(thisValue);
            }
            return reval;
        }
        /// <summary>
        /// 尝试转换thisValue为DateTime，
        /// 成功返回thisValue；否则返回errorValue
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="errorValue"></param>
        /// <returns></returns>
        public static DateTime ObjToDate(this object thisValue, DateTime errorValue)
        {
            DateTime reval = DateTime.MinValue;
            if (thisValue != null && thisValue != DBNull.Value && DateTime.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return errorValue;
        }
        /// <summary>
        /// 对象转布尔
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static bool ObjToBool(this object thisValue)
        {
            bool reval = false;
            if (thisValue != null && thisValue != DBNull.Value && bool.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return reval;
        }
        /// <summary>
        /// 是否为空; ture 为空
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static bool IsEmpty(this object thisValue)
        {
            if (thisValue != null && thisValue != DBNull.Value && !string.IsNullOrWhiteSpace(thisValue.ToString()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 扩展 string.Format
        /// </summary>
        /// <param name="text"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatString(this string text, params object[] args)
        {
            return string.Format(text, args);
        }
        /// <summary>
        /// 将字符串转为安全字符，过滤常见的一些语法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToSafeSqlStr(this object str)
        {
            str = str.IsEmpty() ? "" : str.ToStr().Replace("'", "''");
            str = new Regex("exec", RegexOptions.IgnoreCase).Replace(str.ToStr(), "exec");
            str = new Regex("xp_cmdshell", RegexOptions.IgnoreCase).Replace(str.ToStr(), "xp_cmdshell");
            str = new Regex("select", RegexOptions.IgnoreCase).Replace(str.ToStr(), "select");
            str = new Regex("insert", RegexOptions.IgnoreCase).Replace(str.ToStr(), "insert");
            str = new Regex("update", RegexOptions.IgnoreCase).Replace(str.ToStr(), "update");
            str = new Regex("delete", RegexOptions.IgnoreCase).Replace(str.ToStr(), "delete");

            str = new Regex("drop", RegexOptions.IgnoreCase).Replace(str.ToStr(), "drop");
            str = new Regex("create", RegexOptions.IgnoreCase).Replace(str.ToStr(), "create");
            str = new Regex("rename", RegexOptions.IgnoreCase).Replace(str.ToStr(), "rename");
            str = new Regex("truncate", RegexOptions.IgnoreCase).Replace(str.ToStr(), "truncate");
            str = new Regex("alter", RegexOptions.IgnoreCase).Replace(str.ToStr(), "alter");
            str = new Regex("exists", RegexOptions.IgnoreCase).Replace(str.ToStr(), "exists");
            str = new Regex("master.", RegexOptions.IgnoreCase).Replace(str.ToStr(), "master.");
            str = new Regex("restore", RegexOptions.IgnoreCase).Replace(str.ToStr(), "restore");
            return str.ToStr();
        }
        /// <summary>
        /// 时间转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime? ObjToDateNull<T>(this T source)
        {
            bool flag = source == null;
            DateTime? result;
            if (flag)
            {
                result = null;
            }
            else
            {
                bool flag2 = source.Equals(DBNull.Value);
                if (flag2)
                {
                    result = null;
                }
                else
                {
                    DateTime value;
                    bool flag3 = DateTime.TryParse(source.ToString(), out value);
                    if (flag3)
                    {
                        result = new DateTime?(value);
                    }
                    else
                    {
                        result = null;
                    }
                }
            }
            return result;
        }

        public static object RowToObject(this DataRow dr)
        {
            string a = JsonHelper.DataRowToJson(dr);

            dynamic dobj = new System.Dynamic.ExpandoObject();
            var columnNames = dr.Table.Columns;
            foreach (DataColumn column in columnNames)
            {
                ((IDictionary<string, object>)dobj)[column.ColumnName] = dr[column.ColumnName].ToStr();
            }

            return dobj;
        }
    }
}
