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
    class hamAttacker : Hamster
    {
        
        public hamAttacker(Vector2 pos) : base(pos)
        {
            position = pos;
            attack = 5;
            hp = 50;
            //speed = 2;
            spriteName = "hamAttacker";
        }

       

    }
}
