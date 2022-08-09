# if DEBUG
using CharpGame.Framework.Graphics;
using CharpGame.Framework.Input;
using CharpGame.Framework.DxLib;
using System;

namespace CharpGame.Framework
{
    internal class Debugs
    {
        [STAThread]
        static void Main()
        {
            using (MainGame game = new MainGame())
                game.Run();
        }
    }

    internal class MainGame : Game
    {
        private Keyboard key = new Keyboard();
        private Mouse mouse = new Mouse();
        private JoyPad joyPad = new JoyPad();
        private Font t = new Font();
        private Texture2D s;
        private Sprite sp;
        private int g;
        private int count = 5;

        public MainGame()
        {
        }

        protected override void LoadContent()
        {
            s = new Texture2D("Obje.png", Texture2DLoadType.Normal);
            sp = new Sprite(s);
            sp.Position = new System.Drawing.PointF(0, 0);

            base.LoadContent();
        }

        protected override void Initialize()
        {
            t.FontSize = 20;
            t.CreateFontHandle();
            joyPad.joyPadType = JoyPadType.Key_Pad;

            base.Initialize();
        }

        protected override void RunLoop(GameTime gameTime)
        {
            key.Update();
            mouse.Update();
            joyPad.Update();

            if (joyPad.GetKeyUp(JoyPadKey.Down))
            {
                count++;
                Console.WriteLine($"Push:{count}");
            }

            DX.DrawGraphF(sp.Position.X, sp.Position.Y, sp.gHandle, DX.TRUE);

            base.RunLoop(gameTime);
        }

        protected override void UnloadContent()
        {
            sp.Dispose();

            base.UnloadContent();
        }
    }
}
#endif
