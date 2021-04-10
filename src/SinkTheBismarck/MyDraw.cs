using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game2
{
    public static class MyDraw
    {
        public static Texture2D ShipGraphic;
        public static Texture2D ShipSmall;
        public static Texture2D ShipSmallHighlighted;
        public static Texture2D ShipLarge;
        public static Texture2D ShipLargeHighlighted;
        public static SpriteFont font12;
        public static SpriteFont font16;
        public static SpriteFont font32;
        public static SpriteFont font64;
        public static SpriteFont font24;
        public static Texture2D NorthAtlantic;
        public static Texture2D FrontScreen;
        public static Texture2D Panel;

        public static void LoadGraphics(BismarckGame gameRoot)
        {
            gameRoot.Content.RootDirectory = "Content";
            // TODO: use this.Content to load your game content here
            ShipGraphic = gameRoot.Content.Load<Texture2D>("Sprites/Ship3");
            ShipSmall = gameRoot.Content.Load<Texture2D>("Sprites/Ship Small");
            ShipSmallHighlighted = gameRoot.Content.Load<Texture2D>("Sprites/Ship Small Highlighted");
            ShipLarge = gameRoot.Content.Load<Texture2D>("Sprites/Ship Large");
            ShipLargeHighlighted = gameRoot.Content.Load<Texture2D>("Sprites/Ship Large Highlighted");
            font12 = gameRoot.Content.Load<SpriteFont>("Fonts/VSmallFont");
            font16 = gameRoot.Content.Load<SpriteFont>("Fonts/SmallFont");
            font24 = gameRoot.Content.Load<SpriteFont>("Fonts/MediumFont");
            font32 = gameRoot.Content.Load<SpriteFont>("Fonts/File");
            font64 = gameRoot.Content.Load<SpriteFont>("Fonts/LargeFont");
            FrontScreen = gameRoot.Content.Load<Texture2D>("Sprites/Front Screen");
            NorthAtlantic = gameRoot.Content.Load<Texture2D>("Sprites/NorthAtlantic");
            Panel = gameRoot.Content.Load<Texture2D>("Sprites/Panel 4");
        }



        public static void DrawStartScreen(BismarckGame gameRoot)
        {

            gameRoot.spriteBatch.Begin();
            gameRoot.spriteBatch.Draw(FrontScreen, new Rectangle(10, 10, 1900, 1105), Color.LightCyan);
            gameRoot.spriteBatch.DrawString(font32, "The time is May 23rd 1941 and operation Rheinubung is underway.  The", new Vector2(280, 70), Color.Black);
            gameRoot.spriteBatch.DrawString(font32, "battleship Bismarck and cruiser Prinz Eugen have passed through the", new Vector2(280, 120), Color.Black);
            gameRoot.spriteBatch.DrawString(font32, "Denmark Straight and entered the Atlantic.  The cruisers Suffolk and", new Vector2(280, 170), Color.Black);
            gameRoot.spriteBatch.DrawString(font32, "Norfolk are tracking the Bismarck on their radar.  If the Germans are", new Vector2(280, 220), Color.Black);
            gameRoot.spriteBatch.DrawString(font32, "successful in their operation, the Bismarck could wreak havoc amongst", new Vector2(280, 270), Color.Black);
            gameRoot.spriteBatch.DrawString(font32, "the convoys and bring Britain to her knees.  If the British can destroy", new Vector2(280, 320), Color.Black);
            gameRoot.spriteBatch.DrawString(font32, "the Bismarck then the Germans will have lost their only operational", new Vector2(280, 370), Color.Black);
            gameRoot.spriteBatch.DrawString(font32, "battleship.", new Vector2(280, 420), Color.Black);
            gameRoot.spriteBatch.DrawString(font32, "You command the might of the British navy.  You must", new Vector2(280, 680), Color.Black);
            gameRoot.spriteBatch.DrawString(font64, "SINK  THE  BISMARCK !", new Vector2(450, 780), Color.Black);
            gameRoot.spriteBatch.DrawString(font32, "Press 'Enter' to continue", new Vector2(450, 950), Color.Black);
            gameRoot.spriteBatch.DrawString(font24, "Powered by Devenish", new Vector2(1400, 1000), Color.Black);
            gameRoot.spriteBatch.End();
        }

        public static void DrawNormalScreen(BismarckGame gameRoot)
        {
            gameRoot.spriteBatch.Begin();
            gameRoot.spriteBatch.Draw(NorthAtlantic, new Rectangle(10, 10, 1900, 1105), Color.LightCyan);

            // Draw the Status Panel
            gameRoot.spriteBatch.Draw(Panel, new Rectangle(1550, 550, 300, 500), Color.LightCyan);
            gameRoot.spriteBatch.DrawString(font24, gameRoot.ActiveShip.Title, new Vector2(1590, 600), Color.White);
            gameRoot.spriteBatch.DrawString(font12, "Type:  "+ gameRoot.ActiveShip.Type, new Vector2(1600, 930), Color.White);
            gameRoot.spriteBatch.DrawString(font12, "Displacement:  " + gameRoot.ActiveShip.Displacement + " tonnes", new Vector2(1600, 955), Color.White);
            gameRoot.spriteBatch.DrawString(font12, "Max. Speed:  " + gameRoot.ActiveShip.MaxSpeed + " knots", new Vector2(1600, 980), Color.White);
            gameRoot.spriteBatch.DrawString(font12, "Armament:  " + gameRoot.ActiveShip.Size + " inch guns", new Vector2(1600, 1005), Color.White);

            // Draw the Ships
            gameRoot.Ships.ForEach(s =>
            {
                var texture = s.MaxHits > 5 ? ShipLarge : ShipSmall;
                if (s == gameRoot.ActiveShip) texture = s.MaxHits > 5 ? ShipLargeHighlighted : ShipSmallHighlighted;
                gameRoot.spriteBatch.Draw(texture, s.Course.Position, null, Color.Red, s.Course.Direction, Vector2.Zero, 0.07f, SpriteEffects.None, 0);
                gameRoot.spriteBatch.DrawString(font16, s.Symbol, s.Course.Position, Color.Black);
            });

            // gameRoot.spriteBatch.DrawString(font24, "entered number is " + ship[gameRoot.currentShip].Course.Direction, new Vector2(700, 1000), Color.Black);

            // Draw any other dialogues
            if (gameRoot.D == true) DrawDirectionDialogue(gameRoot);
            if (gameRoot.S == true) DrawDirectionDialogue(gameRoot);
            if (gameRoot.R == true) DrawDirectionDialogue(gameRoot);
            if (gameRoot.T == true) DrawDirectionDialogue(gameRoot);

            gameRoot.spriteBatch.End();
        }

        public static void DrawDirectionDialogue(BismarckGame gameRoot)
        {
            gameRoot.spriteBatch.DrawString(font24, "Enter the new Direction", new Vector2(350, 950), Color.Black);
            gameRoot.spriteBatch.DrawString(font24, gameRoot.EnteredString, new Vector2(700, 950), Color.Black);
        }

        public static void DrawSpeedDialogue(BismarckGame gameRoot)
        {
            gameRoot.spriteBatch.DrawString(font24, "Enter the new Speed", new Vector2(350, 950), Color.Black);
            gameRoot.spriteBatch.DrawString(font24, gameRoot.EnteredString, new Vector2(700, 950), Color.Black);
        }

        public static void DrawRangeDialogue(BismarckGame gameRoot)
        {
            gameRoot.spriteBatch.DrawString(font24, "Enter the target Range", new Vector2(350, 950), Color.Black);
            gameRoot.spriteBatch.DrawString(font24, gameRoot.EnteredString, new Vector2(700, 950), Color.Black);
        }

        public static void DrawTraverseDialogue(BismarckGame gameRoot)
        {
            gameRoot.spriteBatch.DrawString(font24, "Enter the target Direction", new Vector2(350, 950), Color.Black);
            gameRoot.spriteBatch.DrawString(font24, gameRoot.EnteredString, new Vector2(700, 950), Color.Black);
        }
/*
        public static void MyDrawLine(BismarckGame gameRoot, Vector2 point1, Vector2 point2, Color color, float thickness = 1f)
        {
                var distance = Vector2.Distance(point1, point2);
                var angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            gameRoot.spriteBatch.Draw()
                    //point1, distance, angle, color, thickness);
        }
*/

    }
}
