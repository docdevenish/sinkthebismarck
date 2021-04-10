using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    public class MyInputState
    {
        public KeyboardState CurrentKeyboardState = new KeyboardState();
        public KeyboardState LastKeyboardState = new KeyboardState();

        public MyInputState()
        {
        }
       
        /// <summary>
        ///    Reads the latest state of the keyboard.
        /// </summary>
        public void Update()
        {
                LastKeyboardState = CurrentKeyboardState;
                CurrentKeyboardState = Keyboard.GetState();
        }

        

        /// <summary>
        ///    Helper for checking if a key was newly pressed during this update.
        /// </summary>
        public bool IsNewKeyPress(Keys key)
        {
                return (CurrentKeyboardState.IsKeyDown(key) && LastKeyboardState.IsKeyUp(key));
        }


        /// <summary>
        /// Allows numbers to be input for processing numerical user input.
        /// </summary>

        public string GetNewKey()
        {
            if ((CurrentKeyboardState.IsKeyDown(Keys.D1) && LastKeyboardState.IsKeyUp(Keys.D1)) || (CurrentKeyboardState.IsKeyDown(Keys.NumPad1) && LastKeyboardState.IsKeyUp(Keys.NumPad1)))
                return "1";
            else
            if ((CurrentKeyboardState.IsKeyDown(Keys.D2) && LastKeyboardState.IsKeyUp(Keys.D2))|| (CurrentKeyboardState.IsKeyDown(Keys.NumPad2) && LastKeyboardState.IsKeyUp(Keys.NumPad2)))
                return "2";
            else
            if ((CurrentKeyboardState.IsKeyDown(Keys.D3) && LastKeyboardState.IsKeyUp(Keys.D3)) || (CurrentKeyboardState.IsKeyDown(Keys.NumPad3) && LastKeyboardState.IsKeyUp(Keys.NumPad3)))
                return "3";
            else
            if ((CurrentKeyboardState.IsKeyDown(Keys.D4) && LastKeyboardState.IsKeyUp(Keys.D4)) || (CurrentKeyboardState.IsKeyDown(Keys.NumPad4) && LastKeyboardState.IsKeyUp(Keys.NumPad4)))
                return "4";
            else
            if ((CurrentKeyboardState.IsKeyDown(Keys.D5) && LastKeyboardState.IsKeyUp(Keys.D5)) || (CurrentKeyboardState.IsKeyDown(Keys.NumPad5) && LastKeyboardState.IsKeyUp(Keys.NumPad5)))
                return "5";
            else
            if ((CurrentKeyboardState.IsKeyDown(Keys.D6) && LastKeyboardState.IsKeyUp(Keys.D6)) || (CurrentKeyboardState.IsKeyDown(Keys.NumPad6) && LastKeyboardState.IsKeyUp(Keys.NumPad6)))
                return "6";
            else
            if ((CurrentKeyboardState.IsKeyDown(Keys.D7) && LastKeyboardState.IsKeyUp(Keys.D7)) || (CurrentKeyboardState.IsKeyDown(Keys.NumPad7) && LastKeyboardState.IsKeyUp(Keys.NumPad7)))
                return "7";
            else
            if ((CurrentKeyboardState.IsKeyDown(Keys.D8) && LastKeyboardState.IsKeyUp(Keys.D8)) || (CurrentKeyboardState.IsKeyDown(Keys.NumPad8) && LastKeyboardState.IsKeyUp(Keys.NumPad8)))
                return "8";
            else
             if ((CurrentKeyboardState.IsKeyDown(Keys.D9) && LastKeyboardState.IsKeyUp(Keys.D9)) || (CurrentKeyboardState.IsKeyDown(Keys.NumPad9) && LastKeyboardState.IsKeyUp(Keys.NumPad9)))
                return "9";
            else
            if ((CurrentKeyboardState.IsKeyDown(Keys.D0) && LastKeyboardState.IsKeyUp(Keys.D0)) || (CurrentKeyboardState.IsKeyDown(Keys.NumPad0) && LastKeyboardState.IsKeyUp(Keys.NumPad0)))
                return "0";
            else
            if ((CurrentKeyboardState.IsKeyDown(Keys.OemPeriod) && LastKeyboardState.IsKeyUp(Keys.OemPeriod)) || (CurrentKeyboardState.IsKeyDown(Keys.Decimal) && LastKeyboardState.IsKeyUp(Keys.Decimal)))
                return ".";
            else
            if (CurrentKeyboardState.IsKeyDown(Keys.Back) && LastKeyboardState.IsKeyUp(Keys.Back))
                return "b";
            else
                return "";
        }



        public bool IsExitGame()
        {
            return IsNewKeyPress(Keys.Escape);
        }

        public bool IsUp()
        {
             return IsNewKeyPress(Keys.Up);
        }

        public bool IsDown()
        {
            return IsNewKeyPress(Keys.Down);
        }

        public bool IsFire()
        {
             return IsNewKeyPress(Keys.F);
        }

        public bool IsDirection()
        {
            return IsNewKeyPress(Keys.D);
        }

        public bool IsSpeed()
        {
            return IsNewKeyPress(Keys.S);
        }

        public bool Radar()
        {
            return IsNewKeyPress(Keys.R);
        }

        public bool IsBattle()
        {
            return IsNewKeyPress(Keys.B);
        }

        public bool IsScope()
        {
            return IsNewKeyPress(Keys.X);
        }

        public bool IsNormal()
        {
            return IsNewKeyPress(Keys.N);
        }

        public bool IsEnter()
        {
            return IsNewKeyPress(Keys.Enter);
        }



    }
}