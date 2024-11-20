class Scene
{
    private readonly List<IRenderable> renderables;

    public Scene()
    {
        renderables = [];
    }

    public void AddObject(IRenderable obj)
    {
        renderables.Add(obj);
    }

    public void RenderScene(RenderBuffer buffer)
    {
        foreach (IRenderable obj in renderables)
        {
            obj.Render();
        }
    }
}