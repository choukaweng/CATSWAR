using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Project.Hamsters
{
    class hamDefender : Hamster
    {
        public hamDefender(Vector2 pos) : base(pos)
        {
            position = pos;
            attack = 3;
            hp = 40;
            //speed = 2;
            spriteName = "hamDefender";
        }

        
    }
}
