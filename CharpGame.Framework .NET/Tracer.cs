namespace CharpGame.Framework;

/// <summary>
/// トレーサー。
/// </summary>
public class Tracer
{
    public static void Comment(string message)
    {
        // 表示がバグるので色を変える前にリセット
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"[COMMENT] {message}");
        Console.ResetColor();
    }

    public static void Info(string message)
    {
        // 表示がバグるので色を変える前にリセット
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"[INFO] {message}");
        Console.ResetColor();
    }

    public static void Warning(string message)
    {
        // 表示がバグるので色を変える前にリセット
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[WARNING] {message}");
        Console.ResetColor();
    }
}