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
    [DefaultValue("Meiryo")]
    public string Font { get; set; }

    /// <summary>
    /// フォントのサイズ。
    /// </summary>
    [DefaultValue("20")]
    public int FontSize { get; set; }

    /// <summary>
    /// フォントの太さ。
    /// </summary>
    [DefaultValue(0)]
    public int FontThick { get; set; }

    /// <summary>
    /// 透明度。
    /// </summary>
    [DefaultValue(255)]
    public int Opacity { get; set; }

    /// <summary>
    /// フォントのタイプ
    /// </summary>
    [DefaultValue(FontType.Antialiasing)]
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
