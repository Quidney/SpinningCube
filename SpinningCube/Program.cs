class Program
{
    static void Main(string[] args)
    {
        Console.SetWindowSize(160, 45);

        RenderBuffer renderBuffer = new(160, 44, '.');
        Rotation rotation = new(); //Euler angles, and not Quaternion, meaning it is prone to gimbal lock
        PerspectiveProjection projection = new();
        Scene scene = new();

        Cube cube = new(20, 0.6f, ['@', '$', '~', '#', ';', '+'], rotation, 100, -40, renderBuffer, 40, projection);
        scene.AddObject(cube);

        while (true)
        {
            renderBuffer.Clear();

            scene.RenderScene(renderBuffer);

            renderBuffer.Display();

            rotation.RotationX += 0.05f;
            rotation.RotationY += 0.05f;
            rotation.RotationZ += 0.01f;

            Thread.Sleep(32);
        }
    }
}