# if DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharpGame.Framework.Input;
using CharpGame.Framework.Graphics;
using DxLibDLL;

namespace CharpGame.Framework
{
    internal class Debug
    {
        private static int count;
        private static int left;

        [STAThread]
        static void Main()
        {
            Keyboard key = new Keyboard();
            Mouse mouse = new Mouse();
            JoyPad joyPad = new JoyPad();

            DX.ChangeWindowMode(DX.TRUE);
            DX.SetBackgroundColor(255, 255, 255);
            DX.DxLib_Init();

            joyPad.joyPadType = JoyPadType.Key_Pad;

            while (true)
            {
                if (DX.ProcessMessage() == -1)
                    break;

                DX.ClearDrawScreen();

                key.Update();
                mouse.Update();
                joyPad.Update();

                if (joyPad.GetKeyUp(JoyPadKey.Down))
                {
                    count++;
                    Console.WriteLine($"Push:{count}");
                }

                DX.ScreenFlip();
            }

            DX.DxLib_End();
        }
    }
}
#endif
