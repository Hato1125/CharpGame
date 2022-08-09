﻿using CharpGame.Framework.DxLib;

namespace CharpGame.Framework;

internal abstract class Game : IDisposable
{
    public GameWindow Window { get; set; }
    private GameTime _gameTime { get; set; }
    private bool _initializer = false;
    private bool _isExit = false;

    /// <summary>
    /// 初期化。
    /// </summary>
    public Game()
    {
        Window = new GameWindow();
        _gameTime = new GameTime();
    }

    ~Game()
    {
        Window = null;
        _gameTime = null;
        Dispose();
    }

    /// <summary>
    /// <see cref="Initialize()"/>の後に<see cref="RunLoop(GameTime)"/>の前に呼び出されます。
    /// </summary>
    protected virtual void BeginRun()
    {
    }

    /// <summary>
    /// ゲームループが終了される前に呼び出されます。
    /// </summary>
    protected virtual void EndRun()
    {
    }

    /// <summary>
    /// ゲームに必要なグラフィックリソースを読み込みます。
    /// </summary>
    protected virtual void LoadContent()
    {
    }

    /// <summary>
    /// ゲームに必要な非グラフィックリソースを読み込みます。
    /// このメソッド内で<see cref="LoadContent()"/>が読みだされます。
    /// </summary>
    protected virtual void Initialize()
    {
        LoadContent();
    }

    /// <summary>
    /// 読み込んだグラフィックリソースを破棄します。
    /// </summary>
    protected virtual void UnloadContent()
    {
    }

    /// <summary>
    /// ゲームループ。
    /// </summary>
    /// <param name="gameTime">ゲームタイマー</param>
    protected virtual void RunLoop(GameTime gameTime)
    {
    }

    /// <summary>
    /// 終了イベントを発生させます。
    /// </summary>
    protected virtual void OnExiting()
    {
        _isExit = true;
    }

    /// <summary>
    /// 開放。
    /// </summary>
    public void Dispose()
    {
        DX.InitGraph();
        DX.InitSoundMem();
        DX.InitFontToHandle();
        DX.InitMusicMem();
        GC.Collect();
    }

    /// <summary>
    /// ゲームのエントリーポイント。
    /// </summary>
    public void Run()
    {
        Window.CreateWindow();

        if (!_initializer)
            Initialize();

        BeginRun();

        while (true)
        {
            if (DX.ProcessMessage() == -1 || _isExit)
            {
                EndRun();
                break;
            }

            DX.ClearDrawScreen();
            RunLoop(_gameTime);
            DX.ScreenFlip();
            _gameTime.Measurement();
        }

        UnloadContent();
        DX.DxLib_End();
        Environment.Exit(0);
    }
}