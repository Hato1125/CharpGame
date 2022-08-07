using DxLibDLL;

namespace CharpGame.Framework.Input;

public class JoyPad
{
    private readonly int[] _value = new int[32];

    /// <summary>
    /// 入力状態を取得するパッドの識別子。
    /// </summary>
    /// <value></value>
    public JoyPadType joyPadType { get; set; }

    /// <summary>
    /// 初期化。
    /// </summary>
    public JoyPad() => joyPadType = JoyPadType.Key_Pad;

    /// <summary>
    /// 更新処理。
    /// </summary>
    public void Update()
    {
        for (int i = 0; i < 32; i++)
        {
            if (DX.GetJoypadInputState((int)joyPadType) == (int)GetJoyPadKey(i))
            {
                if (!GetKeyDown(GetJoyPadKey(i)))
                    _value[i] = 1;
                else
                    _value[i] = 2;
            }
            else
            {
                if (GetKeyDown(GetJoyPadKey(i)))
                    _value[i] = -1;
                else
                    _value[i] = 0;
            }
        }
    }

    /// <summary>
    /// JoyPadを取得する。
    /// </summary>
    /// <param name="index">インデックス</param>
    public JoyPadKey GetJoyPadKey(int index)
    {
        switch (index)
        {
            case 0: return JoyPadKey.Down;
            case 1: return JoyPadKey.Left;
            case 2: return JoyPadKey.Right;
            case 3: return JoyPadKey.Up;
            case 4: return JoyPadKey.Pad_1;
            case 5: return JoyPadKey.Pad_2;
            case 6: return JoyPadKey.Pad_3;
            case 7: return JoyPadKey.Pad_4;
            case 8: return JoyPadKey.Pad_5;
            case 9: return JoyPadKey.Pad_6;
            case 10: return JoyPadKey.Pad_7;
            case 11: return JoyPadKey.Pad_8;
            case 12: return JoyPadKey.Pad_9;
            case 13: return JoyPadKey.Pad_10;
            case 14: return JoyPadKey.Pad_11;
            case 15: return JoyPadKey.Pad_12;
            case 16: return JoyPadKey.Pad_13;
            case 17: return JoyPadKey.Pad_14;
            case 18: return JoyPadKey.Pad_15;
            case 19: return JoyPadKey.Pad_16;
            case 20: return JoyPadKey.Pad_17;
            case 21: return JoyPadKey.Pad_18;
            case 22: return JoyPadKey.Pad_19;
            case 23: return JoyPadKey.Pad_20;
            case 24: return JoyPadKey.Pad_21;
            case 25: return JoyPadKey.Pad_22;
            case 26: return JoyPadKey.Pad_23;
            case 27: return JoyPadKey.Pad_24;
            case 28: return JoyPadKey.Pad_25;
            case 29: return JoyPadKey.Pad_26;
            case 30: return JoyPadKey.Pad_27;
            case 31: return JoyPadKey.Pad_28;
            default: return JoyPadKey.Left;
        }
    }

    /// <summary>
    /// ジョイパッドのインデックスを取得する。
    /// </summary>
    /// <param name="joyPadKey">JoyPad</param>
    public int GetJoyPadKeyIndex(JoyPadKey joyPadKey)
    {
        switch (joyPadKey)
        {
            case JoyPadKey.Down: return 0;
            case JoyPadKey.Left: return 1;
            case JoyPadKey.Right: return 2;
            case JoyPadKey.Up: return 3;
            case JoyPadKey.Pad_1: return 4;
            case JoyPadKey.Pad_2: return 5;
            case JoyPadKey.Pad_3: return 6;
            case JoyPadKey.Pad_4: return 7;
            case JoyPadKey.Pad_5: return 8;
            case JoyPadKey.Pad_6: return 9;
            case JoyPadKey.Pad_7: return 10;
            case JoyPadKey.Pad_8: return 11;
            case JoyPadKey.Pad_9: return 12;
            case JoyPadKey.Pad_10: return 13;
            case JoyPadKey.Pad_11: return 14;
            case JoyPadKey.Pad_12: return 15;
            case JoyPadKey.Pad_13: return 16;
            case JoyPadKey.Pad_14: return 17;
            case JoyPadKey.Pad_15: return 18;
            case JoyPadKey.Pad_16: return 19;
            case JoyPadKey.Pad_17: return 20;
            case JoyPadKey.Pad_18: return 21;
            case JoyPadKey.Pad_19: return 22;
            case JoyPadKey.Pad_20: return 23;
            case JoyPadKey.Pad_21: return 24;
            case JoyPadKey.Pad_22: return 25;
            case JoyPadKey.Pad_23: return 26;
            case JoyPadKey.Pad_24: return 27;
            case JoyPadKey.Pad_25: return 28;
            case JoyPadKey.Pad_26: return 29;
            case JoyPadKey.Pad_27: return 30;
            case JoyPadKey.Pad_28: return 31;
            default: return 1;
        }
    }

    /// <summary>
    /// キーを押した瞬間を取得します。
    /// </summary>
    /// <param name="joyPadKey">JoyPadKey</param>
    public bool GetKey(JoyPadKey joyPadKey) => _value[GetJoyPadKeyIndex(joyPadKey)] == 1;

    /// <summary>
    /// キーを押している間を取得する。
    /// </summary>
    /// <param name="joyPadKey">JoyPadKey</param>
    public bool GetKeyDown(JoyPadKey joyPadKey) => _value[GetJoyPadKeyIndex(joyPadKey)] > 0;

    /// <summary>
    /// キーを離した瞬間を取得する。
    /// </summary>
    /// <param name="joyPadKey">JoyPadKey</param>
    public bool GetKeyUp(JoyPadKey joyPadKey) => _value[GetJoyPadKeyIndex(joyPadKey)] == -1;
}