public class TriangularNumber
{
    public float Left { get; private set; } = default;
    public float Middle { get; private set; } = default;
    public float Right { get; private set; } = default;

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

}
