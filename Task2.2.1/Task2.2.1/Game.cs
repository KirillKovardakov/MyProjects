using System;
using Task2.Common;
using Task2.Interfaces;

namespace Task2
{
    public class Game : IMovable
    {

        private static readonly int _width = 118;
        public int Width { get => _width; }
        private static readonly int _height = 26;
        public int Height { get => _height; }
        private char[,] _field = new char[_height, _width];
        private static int _scores = 1;
        public int Scores { get => _scores; set { _scores = value; } }
        public Point PLayer { get; set; }
        private Point _monster = new Point(_height - 1, _width - 1);
        public Point Monster { get => _monster; set { _monster = value; } }
        public char[,] Field
        {
            get => _field;
            set { _field = value; }
        }
        public Game()
        {
        }
        public Game(Point temp)
        {
            PLayer = temp;
        }
        public void Preparation()
        {
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Field[i, j] = '.';
                }
            }

        }
        public void CreateObstacle(int number)
        {
            for (int ofNumber = 0; ofNumber < number; ofNumber++)
            {
                var rand = new Random();
                int k1 = rand.Next(1, _height - 5);
                int k2 = rand.Next(1, _width - 5);
                for (int i = k1; i < k1 + 5 && i < _height; i++)
                {
                    for (int j = k2; j < k2 + 5 && j < _width; j++)
                    {
                        Field[i, j] = 'O';
                    }
                }
            }
        }
        public void CreateBuff(int number)
        {
            _scores = number;
            for (int ofNumber = 0; ofNumber < number; ofNumber++)
            {
                var rand = new Random();
                int k1,k2;
                do
                {
                    k1 = rand.Next(_height);
                    k2 = rand.Next(_width);
                } while (Field[k1, k2] == 'O');
                this.Field[k1, k2] = '&';
            }
        }
        public void Positions()
        {
            Field[PLayer.X, PLayer.Y] = 'P';
            Field[Monster.X, Monster.Y] = 'M';
        }
        public void PLayerPosition(int i, int j)
        {

        }
        public void MoveUp(Point to)
        {
            if (Field[PLayer.X - 1, PLayer.Y] == '&') _scores--;
            if (Field[PLayer.X - 1, PLayer.Y] != 'O')
            {
                Field[PLayer.X, PLayer.Y] = '.';
                this.PLayer = new Point(PLayer.X - 1, PLayer.Y);
                Field[PLayer.X, PLayer.Y] = 'P';
            }
            if (Field[Monster.X + 1, Monster.Y] != 'O')
            {
                Field[Monster.X, Monster.Y] = '.';
                this.Monster = new Point(Monster.X - 1, Monster.Y);
                Field[Monster.X, Monster.Y] = 'M';
            }
        }

        public void MoveDown(Point to)
        {
            if (Field[PLayer.X + 1, PLayer.Y] == '&') _scores--;
            if (Field[PLayer.X + 1, PLayer.Y] != 'O')
            {
                Field[PLayer.X, PLayer.Y] = '.';
                this.PLayer = new Point(PLayer.X + 1, PLayer.Y);
                Field[PLayer.X, PLayer.Y] = 'P';
            }
            if (Field[Monster.X - 1, Monster.Y] != 'O')
            {
                Field[Monster.X, Monster.Y] = '.';
                this.Monster = new Point(Monster.X - 1, Monster.Y);
                Field[Monster.X, Monster.Y] = 'M';
            }
        }

        public void MoveLeft(Point to)
        {
            if (Field[PLayer.X, PLayer.Y - 1] == '&') _scores--;
            if (Field[PLayer.X, PLayer.Y - 1] != 'O')
            {
                Field[PLayer.X, PLayer.Y] = '.';
                this.PLayer = new Point(PLayer.X, PLayer.Y - 1);
                Field[PLayer.X, PLayer.Y] = 'P';
            }
            if (Field[Monster.X, Monster.Y + 1] != 'O')
            {
                Field[Monster.X, Monster.Y] = '.';
                this.Monster = new Point(Monster.X, Monster.Y + 1);
                Field[Monster.X, Monster.Y] = 'M';
            }
        }

        public void MoveRight(Point to)
        {
            if (Field[PLayer.X, PLayer.Y + 1] == '&') _scores--;
            if (Field[PLayer.X, PLayer.Y + 1] != 'O')
            {
                Field[PLayer.X, PLayer.Y] = '.';
                this.PLayer = new Point(PLayer.X, PLayer.Y + 1);
                Field[PLayer.X, PLayer.Y] = 'P';
            }
            if (Field[Monster.X, Monster.Y - 1] != 'O')
            {
                Field[Monster.X, Monster.Y] = '.';
                this.Monster = new Point(Monster.X, Monster.Y - 1);
                Field[Monster.X, Monster.Y] = 'M';
            }
        }

    }
}
