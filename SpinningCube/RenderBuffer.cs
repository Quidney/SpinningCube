class RenderBuffer
{
    public int ScreenWidth => screenWidth;
    private readonly int screenWidth;

    public int ScreenHeight => screenHeight;
    private readonly int screenHeight;

    private readonly char[] frameBuffer;
    private readonly float[] depthBuffer;
    private readonly char backgroundCharacter;

    public RenderBuffer(int width, int height, char background)
    {
        screenWidth = width;
        screenHeight = height;
        backgroundCharacter = background;
        frameBuffer = new char[screenWidth * screenHeight];
        depthBuffer = new float[screenWidth * screenHeight];
        Clear();
    }

    public void Clear()
    {
        Array.Fill(frameBuffer, backgroundCharacter);
        Array.Fill(depthBuffer, 0f);
    }

    public void UpdateBuffer(int x, int y, float depth, char displayChar)
    {
        int index = x + y * screenWidth;
        if (index >= 0 && index < screenWidth * screenHeight && depth > depthBuffer[index])
        {
            depthBuffer[index] = depth;
            frameBuffer[index] = displayChar;
        }
    }

    public void Display()
    {
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < frameBuffer.Length; i++)
        {
            if (i % screenWidth == 0) Console.Write('\n');
            Console.Write(frameBuffer[i]);
        }
    }
}