# if DEBUG
using CharpGame.Framework.Graphics;
using CharpGame.Framework.Input;
using DxLibDLL;
using System;

namespace CharpGame.Framework;

internal class Debug
{
    private static int count;
    private static GameWindow window = new GameWindow();

    [STAThread]
    static void Main()
    {
        Keyboard key = new Keyboard();
        Mouse mouse = new Mouse();
        JoyPad joyPad = new JoyPad();


        window.WindowSize = new Size(1280, 720);
        window.CreateWindow();

        SpriteText t = new SpriteText();
        t.FontSize = 20;
        t.CreateFontHandle();

        joyPad.joyPadType = JoyPadType.Key_Pad;

        while (true)
        {
            if (DX.ProcessMessage() == -1)
                break;

            DX.ClearDrawScreen();

            Console.WriteLine(
                string.Format("{0} : {1}   {2} : {3}",
                window.WindowRect.Width,
                window.WindowRect.Heigth,
                window.WindowRect.X,
                window.WindowRect.Y));

            key.Update();
            mouse.Update();
            joyPad.Update();

            if (joyPad.GetKeyUp(JoyPadKey.Down))
            {
                count++;
                Console.WriteLine($"Push:{count}");
            }

            for (int i = 0; i < count; i++)
            {
                t.Draw(0, i * t.FontHeight, $"Push{i}", 0x000000);
            }

            DX.ScreenFlip();
        }

        DX.DxLib_End();
    }
}
#endif
