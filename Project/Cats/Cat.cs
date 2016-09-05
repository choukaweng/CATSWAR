using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Project.Cats
{
    class Cat : Obj
    {
        protected int attack;
        protected int hp;
        protected float spd;

        public Cat() { }

        public Cat (Vector2 pos) : base(pos)
        {
            position = pos;
            spriteName = "tile";
        }
    }
}
