using CharpGame.Framework.DxLib;
using System;
using System.Drawing;

#if DEBUG
using System.Diagnostics;
#endif

namespace CharpGame.Framework.Graphics
{
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

        private bool _disposeStooper { get; set; }

        /// <summary>
        /// 初期化。
        /// </summary>
        /// <param name="texture">Texture2D</param>
        public Sprite(Texture2D texture) =>
            gHandle = texture.ConvertGraphHandle();

        /// <summary>
        /// Spriteを生成。
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        public Sprite(string filePath) => 
            gHandle = DX.LoadGraph(filePath);

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
}