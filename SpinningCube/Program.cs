class Program
{
    static void Main(string[] args)
    {
        Console.SetWindowSize(160, 45);

        var renderBuffer = new RenderBuffer(160, 44, '.');
        var rotation = new Rotation();
        var projection = new PerspectiveProjection();
        var scene = new Scene();

        // Create and add cubes to the scene
        Cube cube1 = new(20, 0.6f, ['@', '$', '~', '#', ';', '+'], rotation, 100, -40, renderBuffer, 40, projection);
        //Cube cube2 = new(10, 0.6f, ['@', '$', '~', '#', ';', '+'], rotation, 100, 10, renderBuffer, 40, projection);
        //Cube cube3 = new(5, 0.6f, ['@', '$', '~', '#', ';', '+'], rotation, 100, 40, renderBuffer, 40, projection);

        scene.AddObject(cube1);
        //scene.AddObject(cube2);
        //scene.AddObject(cube3);

        while (true)
        {
            // Clear buffers for each frame
            renderBuffer.Clear();

            // Render the scene
            scene.RenderScene(renderBuffer);

            // Display buffer
            renderBuffer.Display();

            rotation.RotationX += 0.05f;
            rotation.RotationY += 0.05f;
            rotation.RotationZ += 0.01f;

            Thread.Sleep(16);
        }
    }
}