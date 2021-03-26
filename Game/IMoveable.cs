using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IMoveable
    {
        void MoveRight();
        void MoveDown();
        void MoveLeft();
        void MoveUp();
    }
}
