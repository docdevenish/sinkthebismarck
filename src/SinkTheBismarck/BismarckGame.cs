using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;

namespace Game2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class BismarckGame : Game
    {
        // These are the Class variable members  (some are moved to later in file!!)
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        private Song mySong;
        public Song nearMiss;
        public Song explosion;
        public SoundEffect gunFire;
        public enum Game_mode { start, normal, battle, shutdown };
        public Game_mode myMode;
        public Ship[] myShips = new Ship[9];
        public int currentShip;
        public MyInputState inputstate = new MyInputState();
        public bool D, S, R, T = false;
        const float Pi = 3.1416f;
        public float courseTime=0;
        public string EnteredString = "";


        //  The constructor for our game class
        public BismarckGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromMilliseconds(20); // 20 milliseconds, or 50 FPS.
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
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            base.Initialize();
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            myMode = Game_mode.start;
            myShips[0] = Ship.getBismarck();
            myShips[1] = Ship.getEugen();
            myShips[2] = Ship.getHood();
            myShips[3] = Ship.getPOW();
            myShips[4] = Ship.getKJV();
            myShips[5] = Ship.getRepulse();
            myShips[6] = Ship.getRodney();
            myShips[7] = Ship.getNorfolk();
            myShips[8] = Ship.getSuffolk();
            currentShip = 2;

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.  (moved to later in file!)

            // TODO: use this.Content to load your game content here
            MyDraw.LoadGraphics(this);
            mySong = Content.Load<Song>("Sounds/Everybody Backing");
            gunFire = Content.Load<SoundEffect>("Sounds/Gun Fire");
            //MediaPlayer.Play(mySong);
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
            // Get the user input and handle it - I can't pass the enum type to the handle input class !!!
            if ( Keyboard.GetState().IsKeyDown(Keys.Enter))
                myMode = Game_mode.normal;
            inputstate.Update();
            HandleInput.HandleKeyInput(this, inputstate);

            // Get number input from keyboard
            HandleInput.GetNumber(this, inputstate);



            // Update Bismarck and Eugen Course
            courseTime += gameTime.ElapsedGameTime.Milliseconds;
            if (courseTime > 15000)
            {
                Random randomCourse = new Random();
                float newCourse = Pi * 0.75f + Pi * randomCourse.Next(0, 4) / 10;
                myShips[0].Course.Direction = newCourse;
                myShips[1].Course.Direction = newCourse;
                courseTime = 0;
            }



            // TODO: Add your update logic here
            if (myMode == Game_mode.normal)
            {
                for (int i = 0; i < 9; i++)
                {
                    myShips[i].Move(gameTime);
                }
            }
            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>

        protected override void Draw(GameTime gameTime)
        {
            //      GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //base.Draw(gameTime);  not sure what this base class method does!

            if (myMode == Game_mode.start)
            {
                MyDraw.DrawStartScreen(this);
            }

            if (myMode == Game_mode.normal)
            {
                // draw_Status_Panel.Draw_Panel;
                MyDraw.DrawNormalScreen(this, myShips);
            }
        }

        public void PlayGunFire()
        {
            gunFire.Play();
        }


    }
}

