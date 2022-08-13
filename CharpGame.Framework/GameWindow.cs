using System.Drawing;
using CharpGame.Framework.DxLib;

#if DEBUG
using System.Diagnostics;
#endif

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
            get
            {
                DX.GetBackgroundColor(out int R, out int G, out int B, out int _);
                return Color.FromArgb((byte)R, (byte)G, (byte)B);
            }
            set { DX.SetBackgroundColor(value.R, value.G, value.B); }
        }

        private Size _cliantSize { get; set; }
        /// <summary>
        /// クライアントサイズの取得、または設定をします。
        /// </summary>
        public Size CliantSize
        {
            get
            {
                return _cliantSize;
            }
            set
            {
                if (_cliantSize.Width != value.Width ||
                    _cliantSize.Height != value.Height)
                {
                    DX.SetGraphMode(value.Width, value.Height, 32);
                    _cliantSize = new Size(value.Width, value.Height);
                }
            }
        }

        private Size _windowSize { get; set; }
        /// <summary>
        /// Windowサイズの取得、または設定をします。
        /// </summary>
        public Size WindowSize
        {
            get
            {
                return _windowSize;
            }
            set
            {
                if (value.Width != _windowSize.Width ||
                    value.Height != _windowSize.Height)
                {
                    DX.SetWindowSize(value.Width, value.Height);
                    _windowSize = new Size(value.Width, value.Height);
                }
            }
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
        /// 初期化
        /// </summary>
        public GameWindow()
        {
            IsUserReSizeing = false;
            IsFullScreen = false;
            Title = "CharpGame";
        }

        /// <summary>
        /// Windowを生成する。
        /// </summary>
        public void CreateWindow()
        {
            DX.SetOutApplicationLogValidFlag(DX.FALSE);
#if DEBUG
            DX.SetOutApplicationLogValidFlag(DX.TRUE);
#endif

#if DEBUG
            Debug.WriteLine($"CliantSize Width:{CliantSize.Width} Height:{CliantSize.Height}");
            Debug.WriteLine($"WindowSize Width:{WindowSize.Width} Height:{WindowSize.Height}");
            Debug.WriteLine($"BackgroundColor R:{BackgroundColor.R} G:{BackgroundColor.G} B:{BackgroundColor.B}");
#endif
            DX.ChangeWindowMode(IsFullScreen ? DX.FALSE : DX.TRUE);
            DX.SetWindowSizeChangeEnableFlag(IsUserReSizeing ? DX.TRUE : DX.FALSE, DX.TRUE);
            DX.SetAlwaysRunFlag(DX.TRUE);
            DX.DxLib_Init();
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);
        }
    }
}