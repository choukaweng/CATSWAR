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
    class Hamster : Obj
    {
        

        public Hamster(Vector2 pos) : base(pos)
        {
            position = pos;
            spriteName = "tile";
        }

        protected int attack { get; set; }
        protected int hp { get; set; }

    }
}
