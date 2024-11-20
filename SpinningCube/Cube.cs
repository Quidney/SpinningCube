class Cube : IRenderable
{
    private readonly float size;
    private readonly float surfaceStep;
    private readonly char[] faces;
    private readonly Rotation rotation;
    private readonly int cameraDistance;
    private readonly float horizontalOffset;
    private readonly RenderBuffer buffer;
    private readonly float scaleFactor;
    private readonly IProjection projection;

    public Cube(float size, float surfaceStep, char[] faces, Rotation rotation, int cameraDistance, float horizontalOffset, RenderBuffer buffer, float scaleFactor, IProjection projection)
    {
        this.size = size;
        this.surfaceStep = surfaceStep;
        this.faces = faces;
        this.rotation = rotation;
        this.cameraDistance = cameraDistance;
        this.horizontalOffset = horizontalOffset;
        this.buffer = buffer;
        this.scaleFactor = scaleFactor;
        this.projection = projection;
    }

    public void Render()
    {
        for (float cubeX = -size; cubeX < size; cubeX += surfaceStep)
        {
            for (float cubeY = -size; cubeY < size; cubeY += surfaceStep)
            {
                RenderFace(cubeX, cubeY, -size, faces[0]); // Front face
                RenderFace(size, cubeY, cubeX, faces[1]);  // Right face
                RenderFace(-size, cubeY, -cubeX, faces[2]); // Left face
                RenderFace(-cubeX, cubeY, size, faces[3]);  // Back face
                RenderFace(cubeX, -size, -cubeY, faces[4]); // Bottom face
                RenderFace(cubeX, size, cubeY, faces[5]);   // Top face
            }
        }
    }

    private void RenderFace(float x, float y, float z, char displayChar)
    {
        (float rotatedX, float rotatedY, float rotatedZ) = rotation.ApplyRotation(x, y, z);
        (int projectedX, int projectedY, float depth) = projection.Project(rotatedX, rotatedY, rotatedZ, buffer.ScreenWidth, buffer.ScreenHeight, scaleFactor, cameraDistance);
        buffer.UpdateBuffer(projectedX, projectedY, depth, displayChar);
    }
}