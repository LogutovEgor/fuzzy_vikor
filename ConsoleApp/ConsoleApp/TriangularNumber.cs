public class TriangularNumber
{
    public float Left { get; set; } = default;
    public float Middle { get; set; } = default;
    public float Right { get; set; } = default;

    public TriangularNumber() { }

    public TriangularNumber(float left, float middle, float right)
    {
        Left = left;
        Middle = middle;
        Right = right;
    }

    public override string ToString() => $"<{Left} {Middle} {Right}>";

    public static TriangularNumber operator +(TriangularNumber operand1, TriangularNumber operand2) =>
        new TriangularNumber(operand1.Left + operand2.Left, operand1.Middle + operand2.Middle, operand1.Right + operand2.Right);

    public static TriangularNumber operator -(TriangularNumber operand1, TriangularNumber operand2) =>
        new TriangularNumber(operand1.Left - operand2.Right, operand1.Middle - operand2.Middle, operand1.Right - operand2.Left);

    public static TriangularNumber operator *(TriangularNumber operand1, TriangularNumber operand2) =>
        new TriangularNumber(operand1.Left * operand2.Left, operand1.Middle * operand2.Middle, operand1.Right * operand2.Right);

    public static TriangularNumber operator *(TriangularNumber operand1, float operand2) =>
        new TriangularNumber(operand1.Left * operand2, operand1.Middle * operand2, operand1.Right * operand2);

    public static TriangularNumber operator *(float operand1, TriangularNumber operand2) =>
     new TriangularNumber(operand1 * operand2.Left, operand1 * operand2.Middle, operand1 * operand2.Right);

    public static TriangularNumber operator /(TriangularNumber operand1, float operand2) =>
    new TriangularNumber(operand1.Left / operand2, operand1.Middle / operand2, operand1.Right / operand2);
}
