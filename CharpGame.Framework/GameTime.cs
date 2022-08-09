using CharpGame.Framework.DxLib;
using System;

namespace CharpGame.Framework
{
    public class GameTime
    {
        /// <summary>
        /// Runメソッドを呼び出した時からの時間。
        /// </summary>
        public TimeSpan TotalTime { get; private set; }

        /// <summary>
        /// OSが起動してからの時間。
        /// </summary>
        public TimeSpan OSTime { get; private set; }

        /// <summary>
        /// デルタタイム。
        /// </summary>
        public double DeltaTime { get; private set; }

        private double _nowTime { get; set; }
        private double _time { get; set; }

        /// <summary>
        /// 初期化。
        /// </summary>
        public GameTime()
        {
            TotalTime = TimeSpan.Zero;
            OSTime = TimeSpan.Zero;
            DeltaTime = 0;
            _nowTime = 0;
            _time = DX.GetNowHiPerformanceCount();
        }

        /// <summary>
        /// 計測をする。
        /// </summary>
        public void Measurement()
        {
            OSTime = TimeSpan.FromMilliseconds(DX.GetNowHiPerformanceCount());
            _nowTime = DX.GetNowHiPerformanceCount();
            DeltaTime = (_nowTime - _time) / 1000000;
            _time = _nowTime;
        }
    }
}
