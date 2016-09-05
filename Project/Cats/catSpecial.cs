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
    class catSpecial : Cat
    {
        protected MouseState mouse = new MouseState();
        protected KeyboardState keyboard = new KeyboardState();


        public catSpecial()
        {
            hp = 50;
            attack = 10;
            spd = 0.2f;
            spriteName = "powercat";
        }

        public catSpecial(Vector2 pos) : base (pos)
        {
            position = pos;
            hp = 50;
            attack = 10;
            spd = 0.2f;
            spriteName = "powercat";
        }

       

        public override void Update()
        {
            
            position.X -= spd;

            base.Update();
        }
    }
}
