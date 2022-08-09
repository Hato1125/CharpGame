using System;
using CharpGame.Framework.DxLib;

#if DEBUG
using System.Diagnostics;
#endif

namespace CharpGame.Framework.Graphics
{
    /// <summary>
    /// Textを描画する機能を提供します。
    /// </summary>
    public class Font : IDisposable
    {
        /// <summary>
        /// フォントハンドル。
        /// </summary>
        public int FontHandle { get; private set; }

        /// <summary>
        /// フォント。
        /// </summary>
        public string TextFont { get; set; }

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

        private string _text;
        /// <summary>
        /// フォントの横幅。
        /// </summary>
        public int FontWidth
        {
            get
            {
                if (_text != null)
                    return DX.GetDrawStringWidthToHandle(_text, _text.Length, FontHandle);
                else
                    return 0;
            }
        }

        /// <summary>
        /// フォントの高さ。
        /// </summary>
        public int FontHeight
        {
            get
            {
                return DX.GetFontSizeToHandle(FontHandle);
            }
        }

        private bool _disposeStooper { get; set; }

        /// <summary>
        /// 初期化。
        /// </summary>
        public Font()
        {
            TextFont = "ＭＳ ゴシック";
            FontSize = 25;
            FontThick = 0;
            Opacity = 255;
            IsVisible = true;
            fontType = FontType.Antialiasing;
        }

        ~Font() => Dispose();

        /// <summary>
        /// FontHandleを作成する。
        /// </summary>
        public void CreateFontHandle()
        {
            DX.SetFontCacheCharNum(400);
            FontHandle = DX.CreateFontToHandle(
                TextFont,
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
            if (!IsVisible || FontHandle == -1) return;

            _text = text;
            DX.SetDrawBlendMode(DX.DX_BLENDMODE_ALPHA, Opacity > 255 ? 255 : Opacity);
            DX.DrawStringFToHandle(
                x,
                y,
                text,
                color,
                FontHandle);
            DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND, 0);
        }

        /// <summary>
        /// 開放。
        /// </summary>
        public void Dispose()
        {
#if DEBUG
            Console.WriteLine($"[FontHandle] DisposeStooper:{_disposeStooper}");
            Debug.WriteLine($"[FontHandle] DisposeStooper:{_disposeStooper}");
#endif

            if (FontHandle != -1) {
                DX.DeleteFontToHandle(FontHandle);

#if DEBUG
                Console.WriteLine("[FontHandle] FontHandleを破棄。");
                Debug.WriteLine("[FontHandle] FontHandleを破棄。");
#endif
            }
        }
    }
}
