using static DxLibDLL.DX;

namespace CharpGame.Framework.Graphics
{
    /// <summary>
    /// FontType
    /// </summary>
    public enum FontType
    {
        Normal = DX_FONTTYPE_NORMAL,
        Edge = DX_FONTTYPE_EDGE,
        Antialiasing = DX_FONTTYPE_ANTIALIASING,
        Antialiasing_4x4 = DX_FONTTYPE_ANTIALIASING_4X4,
        Antialiasing_8x8 = DX_FONTTYPE_ANTIALIASING_8X8,
        Antialiasing_16x16 = DX_FONTTYPE_ANTIALIASING_16X16,
        Antialiasing_Edge_4x4 = DX_FONTTYPE_ANTIALIASING_4X4,
        Antialiasing_Edge_8x8 = DX_FONTTYPE_ANTIALIASING_8X8,
        Antialiasing_Edge_16x16 = DX_FONTTYPE_ANTIALIASING_16X16,
    }
}
