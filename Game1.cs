using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using Nez;
namespace Project
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Nez.Core
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Variables
        public static Rectangle room;
        public static SpriteFont timerFont;
        public static SpriteFont catFont;

        public float maxTimerLength = 120;
        public float timer = 120;
        public int timerInt;
        public bool timeIsUp = false;
        private static int carrot = 100;

        public float catTimer = 2;
        

        private int catNo = 19;

        private MouseState mouse;
        private KeyboardState keyboard;
        Cursor cursor = new Cursor(new Vector2(0, 0), true);
        Cursor cursorClicked = new Cursor(new Vector2(0, 0), false);

        private bool[] deployed = new bool[4];
        private bool[] canDeploy = new bool[4];
        

        

        Vector2 deploy1;
        Vector2 deploy2;
        Vector2 deploy3;
        Vector2 deploy4;

        //var table = this.addElement(new Table());



        public Game1() : base(width: 1000, height: 600, isFullScreen: false, enableEntitySystems: false)
        {
            //graphics = new GraphicsDeviceManager(this);
            //graphics.PreferredBackBufferWidth = 1000;
            // graphics.PreferredBackBufferHeight = 600;

            Content.RootDirectory = "Content";
        }

        public GraphicsDeviceManager ReturnGraphics()
        {
            return graphics;
        }


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //room = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            IsMouseVisible = false;
            cursor.alive = true;
            cursorClicked.alive = false;


            Items.Initialize();

            Items.objList.Add(cursor);
            Items.objList.Add(cursorClicked);

            Vector2 deploy1 = Items.tileArray[0, 3].position + new Vector2(64 * 3, 0);
            Vector2 deploy2 = Items.tileArray[1, 3].position + new Vector2(64 * 3, 0);
            Vector2 deploy3 = Items.tileArray[2, 3].position + new Vector2(64 * 3, 0);
            Vector2 deploy4 = Items.tileArray[3, 3].position + new Vector2(64 * 3, 0);

            for(int i=0; i<4; i++)
            {
                deployed[i] = false;
                canDeploy[i] = true;
            }

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load Font
            timerFont = Content.Load<SpriteFont>("timerFont");

           catFont = Content.Load<SpriteFont>("catFont");

            // TODO: use this.Content to load your game content here
            foreach (Obj o in Items.objList)
            {
                o.LoadContent(Content);
            }

            foreach (Obj o in Items.tileArray)
            {
                o.LoadContent(Content);

            }

            foreach (Obj o in Items.hamsterList)
            {
                o.LoadContent(Content);
            }

            foreach (Obj o in Items.catList)
            {
                o.LoadContent(Content);
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            mouse = Mouse.GetState();
            keyboard = Keyboard.GetState();

            if (mouse.LeftButton == ButtonState.Pressed)
            {
                cursor.alive = false;
                cursorClicked.alive = true;
            }
            else
            {
                cursor.alive = true;
                cursorClicked.alive = false;
            }

            Vector2 mousePos = new Vector2(mouse.X, mouse.Y);
            
                //if (mousePos.X > deploy1.X - 64 && mousePos.X < deploy1.X + 64 && mousePos.Y > deploy1.Y - 64 && mousePos.Y < deploy1.Y + 64)
            if(Items.tileArray[0,5].spriteIndex.Bounds.Contains(mouse.X, mouse.Y) && mouse.LeftButton == ButtonState.Pressed)
            {
                Obj o = new Cats.catSpecial(Items.tileArray[0, 5].position);
                o.LoadContent(Content);
                Items.catList.Add(o);
            }
            

            //Deploy cat if Number of cat != 0

            if (catNo >= 0)
            {   //check Key Down
                int catRow = 4;
                if (keyboard.IsKeyDown(Keys.NumPad1) && !deployed[0] && canDeploy[0])
                {
                    catRow = 0;

                }
                if (keyboard.IsKeyDown(Keys.NumPad2) && !deployed[1] && canDeploy[1])
                {
                    catRow = 1;

                }
                if (keyboard.IsKeyDown(Keys.NumPad3) && !deployed[2] && canDeploy[2])
                {
                    catRow = 2;

                }
                if (keyboard.IsKeyDown(Keys.NumPad4) && !deployed[3] && canDeploy[3])
                {
                    catRow = 3;
                }

                if(catRow < 4)
                {
                    Obj o = new Cats.catSpecial(Items.tileArray[catRow, 5].position);
                    o.LoadContent(Content);
                    Items.catList.Add(o);
                    deployed[catRow] = true;
                    canDeploy[catRow] = false;
                    catNo--;
                }
            }


            //Check Key Up, if yes then can deploy again
            if (keyboard.IsKeyUp(Keys.NumPad1) && deployed[0])
            {
                deployed[0] = false;
            }
            if (keyboard.IsKeyUp(Keys.NumPad2) && deployed[1])
            {
                deployed[1] = false;
            }
            if (keyboard.IsKeyUp(Keys.NumPad3) && deployed[2])
            {
                deployed[2] = false;
            }
            if (keyboard.IsKeyUp(Keys.NumPad4) && deployed[3])
            {
                deployed[3] = false;
            }
            

            //Timer of each lane
            if(!canDeploy[0])
            {
                catTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (catTimer <= 0)
                {
                    catTimer = 2;
                    canDeploy[0] = true;
                }
            }
            if (!canDeploy[1])
            {
                catTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (catTimer <= 0)
                {
                    catTimer = 2;
                    canDeploy[1] = true;
                }
            }
            if (!canDeploy[2])
            {
                catTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (catTimer <= 0)
                {
                    catTimer = 2;
                    canDeploy[2] = true;
                }
            }
            if (!canDeploy[3])
            {
                catTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (catTimer <= 0)
                {
                    catTimer = 2;
                    canDeploy[3] = true;
                }
            }


            //Update Timer
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(timer <= 0)
            {
                timeIsUp = true;
            }

            foreach (Obj o in Items.objList)
            {
                //if(o.GetType() == typeof(Button) && o.spriteIndex.Bounds.Contains(mouse.X, mouse.Y))
                //{
                    //spriteBatch.Draw();
               // }
                o.Update();
            }

            foreach (Obj o in Items.tileArray)
            {
                o.Update();
                if(o.checkHover())
                {
                    Texture2D hoverRect = new Texture2D(graphics.GraphicsDevice, o.getSprite().Width, o.getSprite().Height);
                    spriteBatch.Begin();
                    spriteBatch.Draw(hoverRect, o.position, Color.Red);
                    spriteBatch.End();
                }

            }

            foreach (Obj o in Items.hamsterList)
            {
                o.Update();
            }

            foreach (Obj o in Items.catList)
            {
                o.Update();
            }

           



            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //To Draw UI Components
            spriteBatch.Begin();

            foreach (Obj o in Items.objList)
            {
                if(!(o.GetType() == typeof(Cursor)) && !(o.GetType() == typeof(Tile)))
                {
                    o.Draw(spriteBatch);
                }
                
            }

            foreach (Obj o in Items.tileArray)
            {
                o.Draw(spriteBatch);

            }

            foreach (Obj o in Items.objList)
            {
                if (o.GetType() == typeof(Tile))
                {
                    o.Draw(spriteBatch);
                }
            }

            if (!timeIsUp)
            {
                timerInt = (int)timer;


                //Draw "S"
                spriteBatch.DrawString(timerFont, "s", new Vector2(185, 140), Color.Black, 0, new Vector2(0, 0), 3, SpriteEffects.None, 1);
                spriteBatch.DrawString(timerFont, "s", new Vector2(185, 138), Color.Red, 0, new Vector2(0, 0), 3, SpriteEffects.None, 1);

                //Draw "Time"
                if (timerInt >= 100)
                {
                    spriteBatch.DrawString(timerFont, timerInt.ToString(), new Vector2(76, 140), Color.Black, 0, new Vector2(0, 0), 3, SpriteEffects.None, 1);
                    spriteBatch.DrawString(timerFont, timerInt.ToString(), new Vector2(74, 138), Color.Red, 0, new Vector2(0, 0), 3, SpriteEffects.None, 1);
                }
                else
                {
                    spriteBatch.DrawString(timerFont, timerInt.ToString(), new Vector2(106, 140), Color.Black, 0, new Vector2(0, 0), 3, SpriteEffects.None, 1);
                    spriteBatch.DrawString(timerFont, timerInt.ToString(), new Vector2(104, 138), Color.Red, 0, new Vector2(0, 0), 3, SpriteEffects.None, 1);
                }
            }
            else
            {
                spriteBatch.DrawString(timerFont, "TIME'S UP", new Vector2(20, 140), Color.Black, 0, new Vector2(0, 0), 3, SpriteEffects.None, 1);
                spriteBatch.DrawString(timerFont, "TIME'S UP", new Vector2(18, 138), Color.Red, 0, new Vector2(0, 0), 3, SpriteEffects.None, 1);
            }

            spriteBatch.DrawString(timerFont, " =  " + carrot , new Vector2(120, 275), Color.Black, 0, new Vector2(0, 0), 2, SpriteEffects.None, 1);

            spriteBatch.DrawString(catFont, " Cat x   " + (catNo+1), new Vector2(850, 275), Color.Black, 0, new Vector2(0, 0), 2, SpriteEffects.None, 1);



            spriteBatch.End();

            
            spriteBatch.Begin();


            foreach (Obj o in Items.hamsterList)
            {
                o.Draw(spriteBatch);

            }

            foreach (Obj o in Items.catList)
            {
                o.Draw(spriteBatch);
            }

            foreach (Obj o in Items.objList)
            {
                if (o.GetType() == typeof(Cursor))
                {
                    o.Draw(spriteBatch);
                }
            }
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
