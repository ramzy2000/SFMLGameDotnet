public class SystemManager
{
    public static InputSystem inputSystem = new InputSystem();
    public static TransformSystem transformSystem = new TransformSystem();
    public static PhysicsSystem physicsSystem = new PhysicsSystem();
    public static GraphicsSystem graphicsSystem = new GraphicsSystem();
    public void Update(float dt)
    {
        Task.WaitAll(inputSystem.Update(dt), 
                     transformSystem.Update(dt), 
                     physicsSystem.Update(dt), 
                     graphicsSystem.Update(dt));
    }

    public void ClearSystems()
    {
       Task.WaitAll(inputSystem.ClearSystem(), 
                     transformSystem.ClearSystem(), 
                     physicsSystem.ClearSystem(), 
                     graphicsSystem.ClearSystem());
    }
}