using System;
using System.IO;
using Wacther;
using System.Text.RegularExpressions;
namespace Task4
{
    class MyClassCS
    {
        static void Main()
        {
            var mode = RequestStartMode();
            if (mode is ModeType.Observation)
            {
                Console.WriteLine("Press any key to exit.");
                FileObservation.Observation();
            }
            else if (mode is ModeType.RollBackChanges)
            {
                DateTime date;
                do
                {
                    Console.Write("Enter date (dd.mm.yyyy hh:mm:ss): ");
                } while (!DateTime.TryParse(Console.ReadLine(), out date));
                FileObservation.RollBackChanges(date);
            }
        }
        public enum ModeType
        {
            None,
            Observation,
            RollBackChanges,
        }

        public static ModeType RequestStartMode()
        {
            int mode;
            do
            {
                Console.WriteLine("Выберите режим: \n\r1. Наблюдение\n\r2. Откат изменений ");
            } while (int.TryParse(Console.ReadLine(), out mode) && mode is not (1 or 2));

            return (ModeType)mode;
        }
    }
}