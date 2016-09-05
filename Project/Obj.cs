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
    class Obj
    {
        //create variables
        public Vector2 position;
        public float rotation = 0.0f;
        public Texture2D spriteIndex;
        public string spriteName;
        public float speed = 0.0f;
        public float scale = 1.0f;
        public float depth;
        public Vector2 size;

        

        protected bool hover = false;
        Rectangle rect;

        public Boolean alive = true;  //check if object is active

        protected MouseState mouse = new MouseState();
        protected KeyboardState keyboard = new KeyboardState();



        public Obj(Vector2 pos)
        {
            position = pos;
            rect = new Rectangle((int)pos.X, (int)pos.Y, 64, 64);
          
        }

        public Obj() { }

        public virtual void LoadContent(ContentManager Content)
        {
            spriteIndex = Content.Load<Texture2D>(this.spriteName);
        }

        public Texture2D getSprite()
        {
            return spriteIndex;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!alive) return;

            Vector2 center = new Vector2(spriteIndex.Width / 2, spriteIndex.Height / 2);

            if(this.GetType() == typeof(Tile) || this.GetType() == typeof(Lane) || this.GetType() == typeof(Button))
            {
                scale = 1.5f;
            }
           
            spriteBatch.Draw(spriteIndex, position, null, Color.White, rotation, center, scale, SpriteEffects.None, 0);
            
            
        }

        public virtual void Update()
        {
            if (!alive) return;
            pushTo(speed, rotation);
        }

        public void pushTo(float pix, float dir)
        {
            float newX = -(float)Math.Cos(dir);
            float newY = -(float)Math.Sin(dir);
            position.X += pix * (float)newX;
            position.Y += pix * (float)newY;
        }

        public bool checkHover()
        {
            if(rect.Contains(mouse.X, mouse.Y))
            {
                hover = true;
            }
            else
            {
                hover = false;
            }

            return hover;
        }

        //public Vector2 returnSize()
        //{
            //return new Vector2(spriteIndex.Width, spriteIndex.Height);
        //}

        public Vector2 returnPos()
        {
            return position;
        }
    }
}
