using CharpGame.Framework.DxLib;

#if DEBUG
using System.Diagnostics;
#endif

namespace CharpGame.Framework.Graphics;

public class MultipleSprite : IDisposable
{
    public Sprite[] Sprites;

    private bool _disposeStooper { get; set; }

    /// <summary>
    /// Spriteを生成。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    public MultipleSprite(string filePath, int SplitNum, int XNum, int YNum, int XSize, int YSize)
    {
        Sprites = new Sprite[SplitNum];
        int[] tempGHandle = new int[SplitNum];
        DX.LoadDivGraph(filePath, SplitNum, XNum, YNum, XSize, YSize, tempGHandle);
        for (int i = 0; i < SplitNum; i++)
            Sprites[i] = new Sprite(tempGHandle[i]);
        tempGHandle = null;
    }

    ~MultipleSprite() => Dispose();

    /// <summary>
    /// 開放。
    /// </summary>
    public void Dispose()
    {
#if DEBUG
        Debug.WriteLine($"[MultipleSprite] DisposeStooper:{_disposeStooper}");
#endif
        for (int i = 0; i < Sprites.Length; i++)
        {
            if (Sprites[i].gHandle != -1 && !_disposeStooper)
            {
                DX.DeleteGraph(Sprites[i].gHandle);
                _disposeStooper = true;
#if DEBUG
                Debug.WriteLine("[MultipleSprite] GraphHandleを破棄。");
#endif
            }
        }
    }
}