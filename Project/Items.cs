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
using Project.Hamsters;
using Project.Cats;

namespace Project
{
    class Items : Game1
    {
        protected MouseState mouse = new MouseState();
        protected KeyboardState keyboard = new KeyboardState();

        public static List<Obj> objList = new List<Obj>();
        public static Obj[,] tileArray = new Obj[4,6];
        public static List<Obj> hamsterList = new List<Obj>();
        public static List<Obj> catList = new List<Obj>();

       


        public static void Reset()
        {
            foreach(Obj o in objList)
            {
                o.alive = false; //setting all to NOT alive
            }

            foreach (Obj o in tileArray)
            {
                o.alive = false; //setting all to NOT alive
            }

            foreach (Obj o in hamsterList)
            {
                o.alive = false; //setting all to NOT alive
            }

            foreach (Obj o in catList)
            {
                o.alive = false; //setting all to NOT alive
            }
        }

        public static void Initialize()
        {
            //For Tiles & Lanes
            int posX = 300;
            int posY = 150;
            

            for(int i=0; i<4; i++)
            {
                for(int j=0; j<4; j++)
                {
                    Obj o = new Tile(new Vector2(posX, posY), i, j, 0);
                    tileArray[i,j] = o;

                    posX += 96;
 
                }

                for (int k = 0; k < 2; k++)
                {
                    Obj o = new Lane(new Vector2(posX, posY), i);
                    tileArray[i, k + 4] = o;
                    posX += 96;
                   
                }

                posX = 300;
                posY += 96;
                
            }

            //Timer Panel
            posX = 70;
            posY = 135;

            {
                for (int i = 0; i < 9; i++)
                {
                    if (i == 3 || i == 6)
                    {
                        posX = 70;
                        posY += 64;
                    }

                    if (i == 6)
                    {
                        posY += 30;

                    }

                    Obj p = new Obj(new Vector2(posX, posY));
                    p.spriteName = "panel";
                    objList.Add(p);

                    posX += 64;
                }

                Obj o = new Obj(new Vector2(70, posY));
                o.spriteName = "carrot";
                objList.Add(o);
            }


            //Add Hamster

            Obj o1 = new hamAttacker(tileArray[0, 0].position);
            hamsterList.Add(o1);
            Obj o2 = new hamDefender(tileArray[1, 1].position);
            hamsterList.Add(o2);
            Obj o3 = new hamTrap(tileArray[2, 2].position);
            hamsterList.Add(o3);

            //Obj c1 = new catSpecial(tileArray[0, 3].position + new Vector2((64*2), 0));
            //catList.Add(c1);
            
            //Obj c2 = new catSpecial(tileArray[1, 3].position + new Vector2((64 * 2), 0));
            //catList.Add(c2);

            //Obj c3 = new catSpecial(tileArray[2, 3].position + new Vector2((64 * 2), 0));
            //catList.Add(c3);

            //Obj c4 = new catSpecial(tileArray[3, 3].position + new Vector2((64 * 2), 0));
            ////catList.Add(c4);

            //for(int i = 0; i < 20; i++)
            //{
            //    obj o = new catspecial();
            //    o.alive = false;
            //    catlist.add(o);
            //}

        }

       

    }
}
