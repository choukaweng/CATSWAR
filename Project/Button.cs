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
    class Button : Obj
    {
        protected Rectangle buttonBoundingbox;
        protected Rectangle mouseBoundingbox;
        public event EventHandler onClick;

        public Color color;
        private Color defaultColor = new Color(0, 0, 0, 0);
        private Color defaultHover = new Color(1, 0, 0, 1);
        private Boolean isActive;
        public Obj Boundingbox;

        public Boolean IsActive()
        {
            return isActive;
        }

        public Button(Vector2 pos, string spriteName) : base(pos)
        {
            position = pos;
            this.spriteName = spriteName;
            color = defaultColor;
            Boundingbox = new Tile(pos, 4, 4, 1);
            Boundingbox.alive = false;
            Items.objList.Add(Boundingbox);

            buttonBoundingbox = new Rectangle((int)position.X, (int)position.Y, 128, 128);
            mouseBoundingbox = new Rectangle(0, 0, 10, 10);
        }

        protected void UpdateBoundingbox(Rectangle buttonBoundingbox)
        {
            this.buttonBoundingbox = buttonBoundingbox;
        }

        public void Update()
        {
            mouseBoundingbox.X = mouse.X;
            mouseBoundingbox.Y = mouse.Y;

            //if(buttonBoundingbox.Contains(mouse.X, mouse.Y))
            if (buttonBoundingbox.Intersects(mouseBoundingbox))
            {
                color = defaultHover;
                isActive = true;
            }
            else
            {
                color = defaultColor;
                isActive = false;
            }

            if(isActive)
            {
                Boundingbox.alive = true;
            }
            else
            {
                Boundingbox.alive = false;
            }

            base.Update();
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 center = new Vector2(spriteIndex.Width / 2, spriteIndex.Height / 2);

            if (this.GetType() == typeof(Tile) || this.GetType() == typeof(Lane) || this.GetType() == typeof(Button))
            {
                scale = 1.5f;
            }

            spriteBatch.Draw(spriteIndex, position, null, Color.White, rotation, center, scale, SpriteEffects.None, depth);

        }

    }
}
