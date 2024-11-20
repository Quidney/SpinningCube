class Scene
{
    private readonly List<IRenderable> renderables;

    public Scene()
    {
        renderables = new List<IRenderable>();
    }

    public void AddObject(IRenderable obj)
    {
        renderables.Add(obj);
    }

    public void RenderScene(RenderBuffer buffer)
    {
        foreach (var obj in renderables)
        {
            obj.Render();
        }
    }
}