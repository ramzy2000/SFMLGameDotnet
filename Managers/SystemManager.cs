public class SystemManager
{
    public static InputSystem inputSystem = new InputSystem();
    public static TransformSystem transformSystem = new TransformSystem();
    public static GraphicsSystem graphicsSystem = new GraphicsSystem();
    public void Update(float dt)
    {
        Task.WaitAll(inputSystem.Update(dt), 
                     transformSystem.Update(dt),
                     graphicsSystem.Update(dt));
    }

    public void ClearSystems()
    {
       Task.WaitAll(inputSystem.ClearSystem(), 
                     transformSystem.ClearSystem(),
                     graphicsSystem.ClearSystem());
    }
}