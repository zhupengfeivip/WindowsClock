using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsClock
{
    /// <summary>
    /// 
    /// </summary>
    public class DateTimeDS
    {
        #region 根据年月获得当月天数
        public int daysInMonth(int year, int month)
        {
            int days = 0;
            switch (month)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12: days = 31; break;
                case 4: case 6: case 9: case 11: days = 30; break;
                case 2:
                    if ((year % 100 != 0 && year % 4 == 0) || (year % 400 == 0)) days = 29;
                    else days = 28;
                    break;
                default: days = 0; break;
            }
            return days;
        }
        #endregion

        #region 根据日期获得节气
        public string getLunarDay(int year, int month, int day)
        {
            string[] lunarstr1 = { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };
            string[] lunarstr2 = { "初", "十", "廿", "卅" };
            string[] lunarmonthstr = { "正月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "冬月", "腊月" };
            ChineseLunisolarCalendar calendar = new ChineseLunisolarCalendar();
            DateTime datetime = new DateTime(year, month, day);
            int lunaryear = calendar.GetYear(datetime);
            int lunarmonth = calendar.GetMonth(datetime);
            int lunarday = calendar.GetDayOfMonth(datetime);
            int leapmonth = calendar.GetLeapMonth(lunaryear);
            if (leapmonth > 0)
            {
                if (leapmonth <= lunarmonth)
                {
                    lunarmonth--;
                }
            }
            if (lunarday == 1)
            {
                return lunarmonthstr[lunarmonth - 1].ToString();
            }
            else
            {
                if (lunarday > 1 && lunarday <= 10)
                {
                    return lunarstr2[0].ToString() + lunarstr1[lunarday - 1].ToString();
                }
                else if (lunarday > 10 && lunarday < 20)
                {
                    return lunarstr2[1].ToString() + lunarstr1[lunarday % 10 - 1].ToString();
                }
                else if (lunarday == 20)
                {
                    return "二十";
                }
                else if (lunarday > 20 && lunarday < 30)
                {
                    return lunarstr2[2].ToString() + lunarstr1[lunarday % 10 - 1].ToString();
                }
                else if (lunarday == 30)
                {
                    return "三十";
                }
                else
                {
                    return "卅一";
                }
            }
        }
        #endregion

        #region 根据日期获得节气
        public string terms(DateTime date)
        {
            string[] SolarTerm = new string[] { "小寒", "大寒", "立春", "雨水", "惊蛰", "春分", "清明", "谷雨", "立夏", "小满", "芒种", "夏至", "小暑", "大暑", "立秋", "处暑", "白露", "秋分", "寒露", "霜降", "立冬", "小雪", "大雪", "冬至" };
            int[] sTermInfo = new int[] { 0, 21208, 42467, 63836, 85337, 107014, 128867, 150921, 173149, 195551, 218072, 240693, 263343, 285989, 308563, 331033, 353350, 375494, 397447, 419210, 440795, 462224, 483532, 504758 };
            DateTime baseDateAndTime = new DateTime(1900, 1, 6, 2, 5, 0); //#1/6/1900 2:05:00 AM#
            DateTime newDate;
            double num;
            int y;
            string tempStr = "";

            y = date.Year;

            for (int i = 1; i <= 24; i++)
            {
                num = 525948.76 * (y - 1900) + sTermInfo[i - 1];
                newDate = baseDateAndTime.AddMinutes(num);
                if (newDate.DayOfYear == date.DayOfYear)
                {
                    tempStr = SolarTerm[i - 1];
                    break;
                }
            }
            return tempStr;
        }
        #endregion

    }
}
