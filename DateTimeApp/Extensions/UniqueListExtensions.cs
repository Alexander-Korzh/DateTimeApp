using System;


namespace DateTimeApp
{
    public static class UniqueListExtensions
    {
        public static long GetTicks(this UniqueList<DateTime> dateTimeList, int index) =>
            
            dateTimeList[index].Ticks;
    }
}
