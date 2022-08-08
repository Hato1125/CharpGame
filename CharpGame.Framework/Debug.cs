# if DEBUG
using CharpGame.Framework.Graphics;
using CharpGame.Framework.Input;
using System;

namespace CharpGame.Framework
{
    internal class Debug
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
        private SpriteText t = new SpriteText();
        private int count = 5;

        public MainGame()
        {
        }

        protected override void LoadContent()
        {
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

            base.RunLoop(gameTime);
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
    }
}
#endif
