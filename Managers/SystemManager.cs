public class SystemManager
{
    private readonly List<BaseSystem> _systems = new();

    public SystemManager()
    {
        _systems.Add(new InputSystem());
        _systems.Add(new PhysicsSystem());
        _systems.Add(new CameraSystem());
        _systems.Add(new GraphicsSystem());
    }

    public void Update(World world, float dt)
    {
        foreach (BaseSystem system in _systems)
        {
            system.Update(world, dt);
        }
    }

    public void ClearSystems()
    {
        _systems.Clear();
    }
}