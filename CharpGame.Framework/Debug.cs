# if DEBUG
using CharpGame.Framework.DxLib;
using CharpGame.Framework.Graphics;
using CharpGame.Framework.Input;
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
        private int count = 5;
        private Sprite s;
        private VirtualScreen vvv = new VirtualScreen(120, 120);

        public MainGame()
        {
            Window.IsUserReSizeing = true;
        }

        protected override void LoadContent()
        {
            s = new Sprite(@"C:\Users\hatof\Desktop\CharpGame\CharpGame.Framework\bin\Debug\a.png");
            base.LoadContent();
        }

        protected override void Initialize()
        {
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

            vvv.SetSprite(s);
            //Console.WriteLine(s.gHandle);
            DX.DrawExtendGraph(0, 0, 100, 480, vvv.Screen.gHandle, DX.FALSE);

            base.RunLoop(gameTime);
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
    }
}
#endif
