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
    class Lane : Obj
    {
        int row;
        private MouseState mouse;
       
        
        

        public Lane(Vector2 pos, int row) : base(pos)
        {
            position = pos;
            spriteName = "lane";
            this.row = row;
            
            
            
        }

        public override void Update()
        {
            mouse = Mouse.GetState();
            base.Update();

           
            
        }

        
    }
}
