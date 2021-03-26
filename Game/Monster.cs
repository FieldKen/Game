using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Monster : MapElement, IMoveable
    {
        public Monster(char drawChar) : base(drawChar)
        {
            DrawChar = drawChar;
        }

        public void MoveDown()
        {
            throw new NotImplementedException();
        }

        public void MoveLeft()
        {
            throw new NotImplementedException();
        }

        public void MoveRight()
        {
            throw new NotImplementedException();
        }

        public void MoveUp()
        {
            throw new NotImplementedException();
        }
    }
}
