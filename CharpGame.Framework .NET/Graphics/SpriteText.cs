using CharpGame.Framework.DxLib;

namespace CharpGame.Framework.Graphics;

public class SpriteText : IDisposable
{
    private int _fontHandle { get; set; }

    /// <summary>
    /// フォント。
    /// </summary>
    public string Font { get; set; }

    /// <summary>
    /// フォントのサイズ。
    /// </summary>
    public int FontSize { get; set; }

    /// <summary>
    /// フォントの太さ。
    /// </summary>
    public int FontThick { get; set; }

    /// <summary>
    /// 透明度。
    /// </summary>
    public int Opacity { get; set; }

    /// <summary>
    /// テキストを表示するか否か。
    /// </summary>
    public bool IsVisible { get; set; }

    /// <summary>
    /// フォントのタイプ
    /// </summary>
    public FontType fontType { get; set; }

    /// <summary>
    /// フォントの横幅。
    /// </summary>
    public int FontWidth { get; private set; }

    /// <summary>
    /// フォントの高さ。
    /// </summary>
    public int FontHeight { get; private set; }

    /// <summary>
    /// 初期化。
    /// </summary>
    public SpriteText()
    {
        Font = "ＭＳ ゴシック";
        FontSize = 25;
        FontThick = 0;
        Opacity = 255;
        IsVisible = true;
        fontType = FontType.Antialiasing;
    }

    ~SpriteText()
    {
        Dispose();
    }

    /// <summary>
    /// FontHandleを作成する。
    /// </summary>
    public void CreateFontHandle()
    {
        DX.SetFontCacheCharNum(400);
        _fontHandle = DX.CreateFontToHandle(Font,
            FontSize,
            FontThick,
            (int)fontType);
        DX.SetFontCacheCharNum(0);
    }

    /// <summary>
    /// テキストを描画する。
    /// </summary>
    /// <param name="x">X座標</param>
    /// <param name="y">Y座標</param>
    /// <param name="text">テキスト</param>
    /// <param name="color">色</param>
    public void Draw(float x, float y, string text, uint color)
    {
        if (!IsVisible || _fontHandle == -1) return;

        // FontHandleのサイズを取得
        FontWidth = DX.GetDrawStringWidthToHandle(text, text.Length, _fontHandle);
        FontHeight = DX.GetFontSizeToHandle(_fontHandle);

        DX.SetDrawBlendMode(DX.DX_BLENDMODE_ALPHA, Opacity > 255 ? 255 : Opacity);
        DX.DrawStringFToHandle(
            x,
            y,
            text,
            color,
            _fontHandle);
        DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 0);
    }

    /// <summary>
    /// 開放。
    /// </summary>
    public void Dispose()
    {
        if (_fontHandle != -1)
            DX.DeleteFontToHandle(_fontHandle);
    }
}
