using Task2.Common;
using System;

namespace Task2.Interfaces
{
    public interface IMovable
    {
        void MoveUp(Point to);
        void MoveDown(Point to);
        void MoveLeft(Point to);
        void MoveRight(Point to);

    }
}
