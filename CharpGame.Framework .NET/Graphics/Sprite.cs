using CharpGame.Framework.DxLib;
using System.Drawing;

namespace CharpGame.Framework.Graphics;

internal class Sprite : Texture2D, IDisposable
{
    /// <summary>
    /// グラフィックハンドル。
    /// </summary>
    public int gHandle { get; private set; }

    /// <summary>
    /// Spriteの位置。
    /// </summary>
    public PointF Position { get; set; }

    /// <summary>
    /// 横方向の拡大率。
    /// </summary>
    public float ScaleX { get; set; }

    /// <summary>
    /// 縦方向の拡大率。
    /// </summary>
    public float ScaleY { get; set; }

    /// <summary>
    /// 回転率。
    /// </summary>
    public float Rotation { get; set; }

    /// <summary>
    /// Textureサイズ。
    /// </summary>
    public Size SpriteSize { get; private set; }

    /// <summary>
    /// 初期化。
    /// </summary>
    /// <param name="fileName">画像のパス</param>
    public Sprite(string fileName) : base(fileName, Texture2DLoadType.Normal)
    {
        SpriteSize = new Size(TextureSize.Width, TextureSize.Height);
        gHandle = ConvertGraphHandle();

        if (gHandle == -1)
            throw new Exception("Spriteの読み込みに失敗しました。");
    }

    ~Sprite() => Dispose();

    /// <summary>
    /// グラフィックハンドルを破棄する。
    /// </summary>
    public new void Dispose()
    {
        Dispose();
        if (gHandle != -1)
            DX.DeleteGraph(gHandle);
    }
}
