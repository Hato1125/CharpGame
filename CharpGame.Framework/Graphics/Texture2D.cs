using CharpGame.Framework.DxLib;
using System;
using System.Drawing;

#if DEBUG
using System.Diagnostics;
#endif

namespace CharpGame.Framework.Graphics
{
    /// <summary>
    /// PixelColorを格納する構造体。
    /// </summary>
    public struct PixelColor
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte A { get; set; }

        public PixelColor(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }

    public class Texture2D : IDisposable
    {
        /// <summary>
        /// ソフトイメージハンドル。
        /// </summary>
        public int SoftImageHandle { get; private set; }

        /// <summary>
        /// 透明度。
        /// </summary>
        public int Opacity { get; set; }

        /// <summary>
        /// Textureサイズ。
        /// </summary>
        public Size TextureSize
        {
            get
            {
                DX.GetSoftImageSize(SoftImageHandle, out int width, out int height);
                return new Size(width, height);
            }

        }

        /// <summary>
        /// 色。
        /// </summary>
        public Color TextureColor { get; set; }

        /// <summary>
        /// Textureのピクセル情報。
        /// </summary>
        public PixelColor[] TexturePixelColor { get; set; }

        private bool _disposeStooper { get; set; }

        /// <summary>
        /// 初期化。
        /// </summary>
        /// <param name="fileName">画像のパス</param>
        /// <param name="loadType">読み込み方法</param>
        public Texture2D(string fileName, Texture2DLoadType loadType)
        {
            switch (loadType)
            {
                case Texture2DLoadType.Normal:
                    SoftImageHandle = DX.LoadSoftImage(fileName);
                    break;

                case Texture2DLoadType.ARGB_8Color:
                    SoftImageHandle = DX.LoadARGB8ColorSoftImage(fileName);
                    break;

                case Texture2DLoadType.XRGB_8Color:
                    SoftImageHandle = DX.LoadXRGB8ColorSoftImage(fileName);
                    break;
            }

            if (SoftImageHandle == -1)
                throw new Exception("Textureの読み込みに失敗しました。");

            TexturePixelColor = GetPixels();
            TextureColor = Color.FromArgb(0, 0, 0);
        }

        ~Texture2D() => Dispose();

        /// <summary>
        /// テクスチャから１ピクセルの色を取得する。
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        /// <returns></returns>
        public PixelColor GetPixel(int x, int y)
        {
            DX.GetPixelSoftImage(SoftImageHandle, x, y, out int r, out int g, out int b, out int a);
            return new PixelColor((byte)r, (byte)g, (byte)b, (byte)a);
        }

        /// <summary>
        /// テクスチャからピクセルの色を取得する。
        /// </summary>
        /// <returns>PixelColor配列</returns>
        public PixelColor[] GetPixels()
        {
            int _counter = 0;
            PixelColor[] _colors = new PixelColor[TextureSize.Width * TextureSize.Height];

            for (int y = 0; y < TextureSize.Height; y++)
                for (int x = 0; x < TextureSize.Width; x++)
                {
                    DX.GetPixelSoftImage(SoftImageHandle, x, y, out int r, out int g, out int b, out int a);
                    _colors[_counter] = new PixelColor((byte)r, (byte)g, (byte)b, (byte)a);
                    _counter++;
                }

            return _colors;
        }

        /// <summary>
        /// テクスチャに１ピクセルを設定します。
        /// </summary>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        /// <param name="R">Red</param>
        /// <param name="G">Green</param>
        /// <param name="B">Blue</param>
        /// <param name="A">Alpha</param>
        public void SetPixel(int x, int y, byte R, byte G, byte B, byte A)
        {
            DX.DrawPixelSoftImage(SoftImageHandle, x, y, R, G, B, A);
        }

        /// <summary>
        /// Textureにピクセルを設定します。
        /// </summary>
        /// <param name="pixelColors">PixelColor配列</param>
        public void SetPixels(PixelColor[] pixelColors)
        {
            int _widthCount = 0;
            int _heightCount = 0;

            for (int i = 0; i < pixelColors.Length; i++)
            {
                DX.DrawPixelSoftImage(
                    SoftImageHandle,
                    _widthCount,
                    _heightCount,
                    pixelColors[i].R,
                    pixelColors[i].G,
                    pixelColors[i].B,
                    pixelColors[i].A);

                _widthCount++;
                if (_widthCount == TextureSize.Width)
                {
                    _widthCount = 0;
                    _heightCount++;
                }
            }
        }

        /// <summary>
        /// SoftImageHandleをGraphHandleに変換して取得する。
        /// </summary>
        public int ConvertGraphHandle()
        {
            return DX.CreateGraphFromSoftImage(SoftImageHandle);
        }

        /// <summary>
        /// Textuerを破棄する。
        /// </summary>
        public void Dispose()
        {
#if DEBUG
            Debug.WriteLine($"[Texture2D] DisposeStooper:{_disposeStooper}");
#endif

            if (SoftImageHandle != -1 && !_disposeStooper)
            {
                DX.DeleteSoftImage(SoftImageHandle);

#if DEBUG
                Debug.WriteLine("[Texture2D] SoftImageHandleを破棄。");
#endif
            }
        }
    }
}