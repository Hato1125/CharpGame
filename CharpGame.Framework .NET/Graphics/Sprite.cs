using CharpGame.Framework.DxLib;
using System.Drawing;

#if DEBUG
using System.Diagnostics;
#endif

namespace CharpGame.Framework.Graphics;

public class Sprite : IDisposable
{
    /// <summary>
    /// グラフィックハンドル。
    /// </summary>
    public int gHandle { get; private set; }

    /// <summary>
    /// Spriteの位置。
    /// </summary>
    public PointF Position { get; set; }

    private int _opacity;
    /// <summary>
    /// 透明度、
    /// </summary>
    public int Opacity
    {
        get
        {
            return _opacity;
        }
        set
        {
            if (value > 255)
            {
                Opacity = 255;
                _opacity = 255;
            }
            else
            {
                _opacity = value;
            }
        }
    }

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
    /// 表示するか否か。
    /// </summary>
    public bool Visible { get; set; }

    /// <summary>
    /// Textureサイズ。
    /// </summary>
    public Size SpriteSize { get; private set; }

    private bool _disposeStooper { get; set; }

    /// <summary>
    /// 初期化。
    /// </summary>
    /// <param name="texture">Texture2D</param>
    public Sprite(Texture2D texture)
    {
        SpriteSize = texture.TextureSize;
        gHandle = texture.ConvertGraphHandle();

        Opacity = 255;
        Visible = true;
    }

    /// <summary>
    /// Spriteを生成。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    public Sprite(string filePath)
    {
        gHandle = DX.LoadGraph(filePath);
        DX.GetGraphSize(gHandle, out int width, out int height);
        SpriteSize = new Size(width, height);

        Opacity = 255;
        Visible = true;
    }

    ~Sprite() => Dispose();

    /// <summary>
    /// 開放。
    /// </summary>
    public void Dispose()
    {
#if DEBUG
        Debug.WriteLine($"[Sprite] DisposeStooper:{_disposeStooper}");
#endif

        if (gHandle != -1 && !_disposeStooper)
        {
            DX.DeleteGraph(gHandle);
            _disposeStooper = true;
#if DEBUG
            Debug.WriteLine("[Sprite] GraphHandleを破棄。");
#endif
        }
    }
}