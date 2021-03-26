using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class RockDestroyer : Monster, IDestroyer
    {
        public RockDestroyer(char drawChar) : base(drawChar)
        {
            DrawChar = drawChar;
        }

        public void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}
