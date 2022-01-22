using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MyEnum;
using Points;


namespace Task2
{
    class Program
    {

        public static void Main(string[] args)
        {
            List<Figure> figures = new List<Figure>();


            int actionVariable;
            do
            {
                PrintBegin();
                switch (actionVariable = int.Parse(Console.ReadLine()))
                {

                    case 1:
                        figures.Add(CreateFigure(InputFigureType()));
                        break;
                    case 2:
                        for (int i = 0; i < figures.Count(); i++)
                        {
                            Console.WriteLine(figures[i].Print());
                        }
                        break;
                    case 3:
                        figures = RemoveFigures();
                        break;
                    default: break;
                }
            }
            while (actionVariable != 4);
            Console.ReadKey();
        }
        public static void PrintBegin()
        {
            Console.WriteLine(String.Format("Выберите действие\n\r\t" +
                "1.Добавить фигуру\n\r\t2.Вывести фигуры\n\r\t" +
                "3.Очистить холст \n\r\t4.Выход"));


        }

        public static Figure CreateFigure(FigureType type)
        {
            switch (type)
            {
                case FigureType.Circle:
                    Console.WriteLine("Введите: центр окружности X и Y, а также радиус R");
                    return new Circle(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));

                case FigureType.Ring:
                    Console.WriteLine("Введите: центр кольца X и Y, а также внутренний радиус r и внешний радиус R");
                    return new Ring(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
                case FigureType.Rectangle:
                    Console.WriteLine("Введите две стороны прямоугольник: длину и ширину");
                    return new Rectangle(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
                case FigureType.Triangle:
                    Console.WriteLine("Введите: точка 1: X и Y\n\r точка 2: X и Y\n\r точка 3: X и Y\n\r");
                    return new Triangle(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
                default:
                    return null;
            }
        }
        private static FigureType InputFigureType()
        {

            FigureType result;
            do
            {
                Console.WriteLine("Выберите тип фигуры:\n\r1. Окружность\n\r2. Кольцо\n\r3. Прямоугольник\n\r4. Треугольник");
            } while (!Enum.TryParse<FigureType>(Console.ReadLine(), out result));

            return result;
        }
        private static List<Figure> RemoveFigures() => new List<Figure>();
    }
}
