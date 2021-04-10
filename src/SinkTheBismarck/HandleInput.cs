using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    public static class HandleInput
    {
        public static void HandleKeyInput(BismarckGame gameRoot, MyInputState inState)
        {
            //           if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            //      gameRoot.myMode = <Game_mode> 2; // Game_mode.normal;

            if (inState.IsFire())
            {
                gameRoot.PlayGunFire();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                gameRoot.Exit();


            if (inState.IsUp())
            {
                var index = gameRoot.PlayerShips.IndexOf(gameRoot.ActiveShip) + 1;
                if (index >= gameRoot.PlayerShips.Count) index = 0;
                gameRoot.ActiveShip = gameRoot.PlayerShips.ElementAt(index);
            }

            if (gameRoot.inputstate.IsDown())
            {
                var index = gameRoot.PlayerShips.IndexOf(gameRoot.ActiveShip) - 1;
                gameRoot.ActiveShip = index < 0 ? gameRoot.PlayerShips.Last() : gameRoot.PlayerShips.ElementAt(index);
            }

            if (gameRoot.inputstate.IsDirection())
            {
                gameRoot.D = true;
                //ReadNewDirection();
            }

            if (gameRoot.inputstate.IsSpeed())
            {
                gameRoot.S = true;
                //ReadNewDirection();
            }

        }

        /// <summary>
        /// Processes numerical user input and handles it.
        /// </summary>
        public static void GetNumber(BismarckGame gameRoot, MyInputState inState)
        {
            string newKey = inState.GetNewKey();
            if ((newKey == "b") && (gameRoot.EnteredString != ""))
                gameRoot.EnteredString = gameRoot.EnteredString.Remove(gameRoot.EnteredString.Length-1, 1);
            else
            if (newKey != "b")
                gameRoot.EnteredString += newKey;

            if (gameRoot.inputstate.IsEnter())
            {
                // process string then reset - there are four different dialogues to handle
                if (gameRoot.D) //Direction dialogue
                {
                    float newDirn;
                    float.TryParse(gameRoot.EnteredString, out newDirn);
                    // convert to radians
                    newDirn = newDirn * 2 * 3.14156f / 360;
                    gameRoot.ActiveShip.Course.Direction = newDirn;
                    gameRoot.D = false;
                }

                if (gameRoot.S) //Speed dialogue
                {
                    float newSpeed;
                    float.TryParse(gameRoot.EnteredString, out newSpeed);
                    gameRoot.ActiveShip.Course.Speed = newSpeed;
                    gameRoot.S = false;
                }

                if (gameRoot.R) //Range dialogue
                {
                    float newDirn;
                    float.TryParse(gameRoot.EnteredString, out newDirn);
                    // convert to radians
                    newDirn = newDirn * 2 * 3.14156f / 360;
                    gameRoot.ActiveShip.Course.Direction = newDirn;
                    gameRoot.R = false;
                }

                if (gameRoot.T) //Traverse dialogue
                {
                    float newDirn;
                    float.TryParse(gameRoot.EnteredString, out newDirn);
                    // convert to radians
                    newDirn = newDirn * 2 * 3.14156f / 360;
                    gameRoot.ActiveShip.Course.Direction = newDirn;
                    gameRoot.T = false;
                }

                gameRoot.EnteredString = "";
            }

        }

    }
}
