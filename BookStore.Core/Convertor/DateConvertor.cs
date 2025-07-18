using System.Globalization;

namespace BookStore.Core.Convertor
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            return $"{pc.GetYear(dateTime)}/{pc.GetMonth(dateTime):00}/{pc.GetDayOfMonth(dateTime):00}";
        }
    }
}
