class PerspectiveProjection : IProjection
{
    public (int, int, float) Project(float x, float y, float z, int screenWidth, int screenHeight, float scaleFactor, int cameraDistance)
    {
        float rotatedZ = z + cameraDistance;
        float inverseZ = 1 / rotatedZ;

        int projectedX = (int)(screenWidth / 2 + scaleFactor * inverseZ * x * 2);
        int projectedY = (int)(screenHeight / 2 + scaleFactor * inverseZ * y);

        return (projectedX, projectedY, inverseZ);
    }
}