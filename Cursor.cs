using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Project
{
    class Cursor : Obj
    {
        private MouseState mouse;
        public bool clicked = false;


        public Cursor(Vector2 pos, bool click) : base(pos)
        {
            
            position = pos;
            if(click)
            {
                spriteName = "cursor";
            }
            
            else
            {
                spriteName = "cursorclicked";
            }
            
        }

        public Cursor() { }

        public override void Update()
        {
            mouse = Mouse.GetState();
            position = new Vector2(mouse.X, mouse.Y);

          
            base.Update();
        }

      
       
    }
}
