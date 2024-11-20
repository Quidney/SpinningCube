interface IProjection
{
    (int, int, float) Project(float x, float y, float z, int screenWidth, int screenHeight, float scaleFactor, int cameraDistance);
}