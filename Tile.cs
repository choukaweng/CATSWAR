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
    class Tile : Obj
    {
        int row, column;
     

        public Tile(Vector2 pos, int row, int column, float depth) : base(pos)
        {
            position = pos;
            spriteName = "tile";
            this.row = row;
            this.column = column;
            
            
        }

       
       

        

    }
}
