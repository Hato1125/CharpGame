using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using DxLibDLL;

namespace CharpGame.Framework.Graphics;

public class SpriteText : IDisposable
{
    private int _fontHandle { get; set; }

    /// <summary>
    /// フォント。
    /// </summary>
    public string Font { get; set; } = "Meiryo";

    /// <summary>
    /// フォントのサイズ。
    /// </summary>
    public int FontSize { get; set; } = 20;

    /// <summary>
    /// フォントの太さ。
    /// </summary>
    public int FontThick { get; set; } = 0;

    /// <summary>
    /// 透明度。
    /// </summary>
    public int Opacity { get; set; } = 255;

    /// <summary>
    /// フォントのタイプ
    /// </summary>
    public FontType fontType { get; set; } = FontType.Antialiasing;

    /// <summary>
    /// フォントの横幅。
    /// </summary>
    public int FontWidth { get; private set; }

    /// <summary>
    /// フォントの高さ。
    /// </summary>
    public int FontHeight { get; private set; }

    /// <summary>
    /// Textを生成する。
    /// </summary>
    public SpriteText()
    {
        DX.SetFontCacheCharNum(400);
        _fontHandle = DX.CreateFontToHandle(Font,
            FontSize,
            FontThick,
            (int)fontType);
        DX.SetFontCacheCharNum(0);
    }

    ~SpriteText()
    {
        Dispose();
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
