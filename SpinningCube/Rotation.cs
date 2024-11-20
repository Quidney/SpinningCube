class Rotation
{
    public float RotationX { get; set; } = 0;
    public float RotationY { get; set; } = 0;
    public float RotationZ { get; set; } = 0;

    public (float, float, float) ApplyRotation(float x, float y, float z)
    {
        float newX = y * MathF.Sin(RotationX) * MathF.Sin(RotationY) * MathF.Cos(RotationZ) -
                     z * MathF.Cos(RotationX) * MathF.Sin(RotationY) * MathF.Cos(RotationZ) +
                     y * MathF.Cos(RotationX) * MathF.Sin(RotationZ) +
                     z * MathF.Sin(RotationX) * MathF.Sin(RotationZ) +
                     x * MathF.Cos(RotationY) * MathF.Cos(RotationZ);

        float newY = y * MathF.Cos(RotationX) * MathF.Cos(RotationZ) +
                     z * MathF.Sin(RotationX) * MathF.Cos(RotationZ) -
                     y * MathF.Sin(RotationX) * MathF.Sin(RotationY) * MathF.Sin(RotationZ) +
                     z * MathF.Cos(RotationX) * MathF.Sin(RotationY) * MathF.Sin(RotationZ) -
                     x * MathF.Cos(RotationY) * MathF.Sin(RotationZ);

        float newZ = z * MathF.Cos(RotationX) * MathF.Cos(RotationY) -
                     y * MathF.Sin(RotationX) * MathF.Cos(RotationY) +
                     x * MathF.Sin(RotationY);

        return (newX, newY, newZ);
    }
}