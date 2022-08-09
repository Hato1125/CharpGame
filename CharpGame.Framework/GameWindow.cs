using CharpGame.Framework.DxLib;
using System.Drawing;

namespace CharpGame.Framework
{
    /// <summary>
    /// Windowのサイズ・位置を格納する構造体。
    /// </summary>
    public struct WindowRect
    {
        public int X;
        public int Y;
        public int Width;
        public int Heigth;
    }

    public class GameWindow
    {
        /// <summary>
        /// ユーザーがWindowのサイズを変更できるかどうか。
        /// </summary>
        public bool IsUserReSizeing { get; set; }

        /// <summary>
        /// フルスクリーンか否か。
        /// </summary>
        public bool IsFullScreen { get; set; }

        private string _title;
        /// <summary>
        /// windowのタイトルの取得、または設定をします。
        /// </summary>
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    DX.SetWindowText(value);
                }
            }
        }

        /// <summary>
        /// 背景の色。
        /// </summary>
        public Color BackgroundColor
        {
            get { return BackgroundColor; }
            set { DX.SetBackgroundColor(value.R, value.G, value.B); }
        }

        /// <summary>
        /// クライアントサイズの取得、または設定をします。
        /// </summary>
        public Size CliantSize
        {
            get { return CliantSize; }
            set { DX.SetGraphMode(value.Width, value.Height, 32); }
        }

        /// <summary>
        /// Windowサイズの設定をします。
        /// </summary>
        public Size WindowSize
        {
            set { DX.SetWindowSize(value.Width, value.Height); }
        }

        /// <summary>
        /// Windowのサイズ・位置を取得します。
        /// </summary>
        public WindowRect WindowRect
        {
            get
            {
                DX.GetWindowSize(out int width, out int heigth);
                DX.GetWindowPosition(out int x, out int y);
                var rect = new WindowRect();
                rect.X = x;
                rect.Y = y;
                rect.Width = width;
                rect.Heigth = heigth;
                return rect;
            }
        }

        /// <summary>
        /// 初期化。
        /// </summary>
        public GameWindow()
        {
            IsUserReSizeing = false;
            IsFullScreen = false;
            BackgroundColor = Color.FromArgb(255, 255, 255);
            CliantSize = new Size(640, 480);
            WindowSize = new Size(640, 480);
            Title = "CharpGame";
        }

        /// <summary>
        /// Windowを生成する。
        /// </summary>
        public void CreateWindow()
        {
            DX.SetOutApplicationLogValidFlag(DX.FALSE);
            DX.ChangeWindowMode(IsFullScreen ? DX.FALSE : DX.TRUE);
            DX.SetAlwaysRunFlag(DX.TRUE);
            DX.DxLib_Init();
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);
        }
    }
}
