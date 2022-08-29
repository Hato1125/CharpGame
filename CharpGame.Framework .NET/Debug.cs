#if DEBUG
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
    public Font f = new Font();
    private int j;

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
        f.CreateFontHandle();
        joyPad.joyPadType = JoyPadType.Key_Pad;

        base.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        key.Update();
        mouse.Update();
        joyPad.Update();

        if (joyPad.GetKeyUp(JoyPadKey.Down))
        {
            count++;
            Console.WriteLine($"Push:{count}");
        }

        f.Draw(0, 0, string.Format("DeltaTime:{0}", gameTime.DeltaTime), 0xffffff);

        base.Update(gameTime);
    }

    protected override void UnloadContent()
    {
        base.UnloadContent();
    }
}
#endif