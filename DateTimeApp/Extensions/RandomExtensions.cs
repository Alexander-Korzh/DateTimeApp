using System;


namespace DateTimeApp
{
    public static class RandomExtensions
    {
        public static DateTime NextDate(this Random random)
        {
            DateTime start = new DateTime(1452, 4, 15); //Др Леонардо Да Винчи

            int range = (DateTime.Today - start).Days;

            return start.AddDays(random.Next(range));
        }
    }
}
