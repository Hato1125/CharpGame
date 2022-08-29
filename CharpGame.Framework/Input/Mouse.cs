using CharpGame.Framework.DxLib;

namespace CharpGame.Framework.Input
{
    public class Mouse
    {
        private readonly int[] _value = new int[10];

        /// <summary>
        /// マウスのX座標。
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// マウスのY座標。
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// 更新処理。
        /// </summary>
        public void Update()
        {
            DX.GetMousePoint(out int mx, out int my);
            X = mx;
            Y = my;

            for (int i = 0; i < 8; i++)
            {
                if (DX.GetMouseInput() == (int)GetMouseKey(i))
                {
                    if (!GetKeyDown(GetMouseKey(i)))
                        _value[i] = 1;
                    else
                        _value[i] = 2;
                }
                else
                {
                    if (GetKey(GetMouseKey(i)))
                        _value[i] = -1;
                    else
                        _value[i] = 0;
                }
            }
        }

        /// <summary>
        /// MouseKeyを取得する。
        /// </summary>
        /// <param name="index">インデックス</param>
        public MouseKey GetMouseKey(int index)
        {
            switch (index)
            {
                case 0: return MouseKey.Left;
                case 1: return MouseKey.Right;
                case 2: return MouseKey.Middle;
                case 3: return MouseKey.Input_4;
                case 4: return MouseKey.Input_5;
                case 5: return MouseKey.Input_6;
                case 6: return MouseKey.Input_7;
                case 7: return MouseKey.Input_8;
                default: return MouseKey.Left;
            }
        }

        /// <summary>
        /// マウスキーのインデックスを取得する。
        /// </summary>
        /// <param name="mouseKey">Mousekey</param>
        public int GetMouseKeyIndex(MouseKey mouseKey)
        {
            switch (mouseKey)
            {
                case MouseKey.Left: return 0;
                case MouseKey.Right: return 1;
                case MouseKey.Middle: return 2;
                case MouseKey.Input_4: return 3;
                case MouseKey.Input_5: return 4;
                case MouseKey.Input_6: return 5;
                case MouseKey.Input_7: return 6;
                case MouseKey.Input_8: return 7;
                default: return 0;
            }
        }

        /// <summary>
        /// キーを押した瞬間を取得します。
        /// </summary>
        /// <param name="mouseKey">MouseKey</param>
        public bool GetKey(MouseKey mouseKey) => _value[GetMouseKeyIndex(mouseKey)] == 1;

        /// <summary>
        /// キーを押している間を取得する。
        /// </summary>
        /// <param name="mouseKey">MouseKey</param>
        public bool GetKeyDown(MouseKey mouseKey) => _value[GetMouseKeyIndex(mouseKey)] > 0;

        /// <summary>
        /// キーを離した瞬間を取得する。
        /// </summary>
        /// <param name="mouseKey">MouseKey</param>
        public bool GetKeyUp(MouseKey mouseKey) => _value[GetMouseKeyIndex(mouseKey)] == -1;
    }
}
