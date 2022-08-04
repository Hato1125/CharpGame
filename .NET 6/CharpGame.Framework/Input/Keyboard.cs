using DxLibDLL;

namespace CharpGame.Framework.Input;

public class Keyboard
{
    private readonly byte[] _buffer = new byte[256];
    private readonly int[] _value = new int[256];

    /// <summary>
    /// 更新処理。
    /// </summary>
    public void Update()
    {
        _ = DX.GetHitKeyStateAll(_buffer);

        for (int i = 0; i < 256; i++)
        {
            if (_buffer[i] == 1)
            {
                if (!GetKeyDown(i))
                    _value[i] = 1;
                else
                    _value[i] = 2;
            }
            else
            {
                if (GetKeyDown(i))
                    _value[i] = -1;
                else
                    _value[i] = 0;
            }
        }
    }

    /// <summary>
    /// 押しているキーのインデックスを取得する。
    /// </summary>
    public int? GetPushKey()
    {
        for (int i = 0; i < 256; i++)
        {
            if (GetKeyDown(i))
                return i;
        }

        return null;
    }

    /// <summary>
    /// キーを押した瞬間を取得する。
    /// </summary>
    /// <param name="keyCode">KeyCode</param>
    public bool GetKey(KeyCode keyCode) => _value[(int)keyCode] == 1;

    /// <summary>
    /// キーを押した瞬間を取得する。
    /// </summary>
    /// <param name="keyCode">KeyCode</param>
    public bool GetKey(int keyCode) => _value[keyCode] == 1;

    /// <summary>
    /// キーを押している間を取得する。
    /// </summary>
    /// <param name="keyCode">KeyCode</param>
    public bool GetKeyDown(KeyCode keyCode) => _value[(int)keyCode] > 0;

    /// <summary>
    /// キーを押している間を取得する。
    /// </summary>
    /// <param name="keyCode">KeyCode</param>
    public bool GetKeyDown(int keyCode) => _value[keyCode] > 0;

    /// <summary>
    /// キーを離した瞬間を取得する。
    /// </summary>
    /// <param name="keyCode">KeyCode</param>
    public bool GetKeyUp(KeyCode keyCode) => _value[(int)keyCode] == -1;

    /// <summary>
    /// キーを離した瞬間を取得する。
    /// </summary>
    /// <param name="keyCode">KeyCode</param>
    public bool GetKeyUp(int keyCode) => _value[keyCode] == -1;
}
