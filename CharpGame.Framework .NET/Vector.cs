namespace CharpGame.Framework;

/// <summary>
/// Vector構造体
/// </summary>
public struct Vector2
{
    public float X { get; set; }
    public float Y { get; set; }

    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }
}

/// <summary>
/// Vector構造体
/// </summary>
public struct Vector3
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}

/// <summary>
/// Vector構造体
/// </summary>
public struct VectorD2
{
    public double X { get; set; }
    public double Y { get; set; }

    public VectorD2(double x, double y)
    {
        X = x;
        Y = y;
    }
}

/// <summary>
/// Vector構造体
/// </summary>
public struct VectorD3
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public VectorD3(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}