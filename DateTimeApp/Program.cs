using System;
using System.Collections.Generic;


namespace DateTimeApp
{
    class Program
    {
        // В Main описана работа консольного приложения, которое все делает автоматом
        static void Main(string[] args)
        {

            #region Запрашиваем длину входного списка рандомных дат

            Console.WriteLine("\n\t Введите длину массива \n");

            int collectionLength = MyConsole.ReadInt32();

            #endregion

            Random random = new Random();

            #region Получаем лист из рандомных дат

            List<DateTime> dateList = new List<DateTime>();

            dateList.CreateRandom(collectionLength, () => random.NextDate());

            //Продублируем какую-нибудь позицию, чтобы далее проверить уникальность
            int length = dateList.Count - 1;

            dateList.Insert(

                random.Next(length),

                dateList[
                    
                    random.Next(length) ] );


            Console.WriteLine("\n\t Рандомный лист сгенерирован \n\n");

            dateList.Print();

            #endregion

            #region Получаем лист уникальных отсортированных дат

            Console.WriteLine("\n\t Сортировка по уникальным значениям выполнена \n\n");

            List <string> sortedList = SortList(dateList);

            sortedList.Print(); 

            #endregion

            #region Запрашиваем тики

            Console.WriteLine(

                "\n" +
                "\tВведите номер строки, ( сверху вниз, начиная с 1 ) \n" +
                "\tколличество тиков которой хотите узнать \n"

                );

            int index = MyConsole.ReadInt32();

            #endregion

            #region Получаем тики

            UniqueList<DateTime> dateUniqueList = new UniqueList<DateTime>();

            foreach (var date in dateList)

                dateUniqueList.Add(date);

            dateUniqueList.Sort();

            Console.WriteLine("\n\t\t" + dateUniqueList[index].Ticks + " Тиков\n");

            //Можно и так: Console.WriteLine( dateUniqueList.GetTicks(index) );

            #endregion

            #region Запрашиваем колличество элементов в списке из дат

            Console.WriteLine(

                "\n" +
                "\t У отсортированного массива есть свойсвто Count.\n\n" +
                "\t Оно возвращает колличество элементов внутри. \n\n" +
                "\t Все точно так же, как и у обычного списка )\n\n" +
                "\t Давай проверим, как оно работает ?\n\n" +
                "\t ( Введите \"Да\" если согласны )\n\n"

                );

            while( Console.ReadLine() != "Да" )
 
                Console.WriteLine(@"

                ───────────────────────────────────────
                ───▐▀▄───────▄▀▌───▄▄▄▄▄▄▄─────────────
                ───▌▒▒▀▄▄▄▄▄▀▒▒▐▄▀▀▒██▒██▒▀▀▄──────────
                ──▐▒▒▒▒▀▒▀▒▀▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▀▄────────
                ──▌▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▄▒▒▒▒▒▒▒▒▒▒▒▒▀▄──────
                ▀█▒▒▒█▌▒▒█▒▒▐█▒▒▒▀▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▌─────
                ▀▌▒▒▒▒▒▒▀▒▀▒▒▒▒▒▒▀▀▒▒▒▒▒▒▒▒▒▒▒▒▒▒▐───▄▄
                ▐▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▌▄█▒█
                ▐▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒█▒█▀─
                ▐▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒█▀───
                ▐▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▌────
                ─▌▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▐─────
                ─▐▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▌─────
                ──▌▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▐──────
                ──▐▄▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▄▌──────
                ────▀▄▄▀▀▀▀▀▄▄▀▀▀▀▀▀▀▄▄▀▀▀▀▀▄▄▀────────

                    Напишите ""Да"", пожалуйста
                                
                ");

            #endregion

            #region Получаем колличество элементов в списке из дат

            Console.WriteLine("\n\t Колличество элементов: " + dateUniqueList.Count);

            #endregion

            Console.ReadKey();
        }


        // Если строго по заданию, все методы ниже:

        #region 1)

        public static int GetCount(List<DateTime> dateTimeList) => dateTimeList.Count;
       
        #endregion

        #region 2)

        private static Dictionary<int, string> months = new Dictionary<int, string>
        {

            {1, "января"    },
            {2, "февраля"   },
            {3, "марта"     },
            {4, "апреля"    },
            {5, "мая"       },
            {6, "июня"      },
            {7, "июля"      },
            {8, "августа"   },
            {9, "сентября"  },
            {10,"октября"   },
            {11,"ноября"    },
            {12,"декабря"   }

        };
         
        public static List<string> SortList(List<DateTime> inputDateList)
        {
            
            UniqueList<DateTime> dateUniqueList = new UniqueList<DateTime>();

            
            foreach (var date in inputDateList)

                dateUniqueList.Add(date);

            dateUniqueList.Sort();


            List<string> outputDateList = new List<string> (dateUniqueList.Count);

            for( int i = 0; i < dateUniqueList.Count; i++ )
            {

                outputDateList.Add(

                    dateUniqueList[i].Day            + " " +

                     months[dateUniqueList[i].Month] + " " +

                     dateUniqueList[i].Year          + " года" );

            }

            return outputDateList;
        }

        #endregion

        #region 3)

        public static List<long> GetTicks(List<DateTime> inputDateList)
        {
            List<long> TicksList = new List<long>();

            foreach (var date in inputDateList)

                TicksList.Add(date.Ticks);

            return TicksList;
        }

        #endregion
    }
}
