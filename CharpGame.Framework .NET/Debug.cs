# if DEBUG
using CharpGame.Framework.Graphics;
using CharpGame.Framework.Input;
using CharpGame.Framework.DxLib;

namespace CharpGame.Framework;

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

    public MainGame()
    {
        Window.IsUserReSizeing = true;
    }

    protected override void LoadContent()
    {

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

        base.RunLoop(gameTime);
    }

    protected override void UnloadContent()
    {
        base.UnloadContent();
    }
}
#endif