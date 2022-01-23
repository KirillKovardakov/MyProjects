using System;
using Task2.Common;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game = Start(game);
            bool tempButton = true;
            do
            {
                
                Print(game);
                Console.WriteLine("Choose where you will go: W, A, S, D. \n\rTo Exit, press Escape");
                switch (GetButton())
                {
                    case ConsoleKey.A:
                        game.MoveLeft(new Point());
                        break;
                    case ConsoleKey.D:
                        game.MoveRight(new Point());
                        break;
                    case ConsoleKey.S:
                        game.MoveDown(new Point());
                        break;
                    case ConsoleKey.W:
                        game.MoveUp(new Point());
                        break;
                    case ConsoleKey.Escape:
                        tempButton = false;
                        break;
                    default:
                        break;
                }
                if (game.PLayer.X == game.Monster.X && game.PLayer.Y == game.Monster.Y)
                {
                    Console.WriteLine("GAME OVER!");
                    tempButton = false;
                }
                if (game.Scores == 0)
                {
                    Console.WriteLine("YOU WON!!!");
                    tempButton = false;
                }
            } while (tempButton);
        }
        public static ConsoleKey GetButton()
        {
            var but = Console.ReadKey().Key;
            return but;
        }
        public static Game Start(Game game)
        {
            game.Preparation();
            game.CreateObstacle(15);
            game.CreateBuff(4);
            game.Positions();
            return game;
        }
        public static void Print(Game game)
        {
            for (int i = 0; i < game.Height; i++)
            {
                for (int j = 0; j < game.Width; j++)
                {
                    Console.Write(game.Field[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
