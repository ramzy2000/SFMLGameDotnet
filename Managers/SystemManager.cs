public class SystemManager
{
    public static InputSystem inputSystem = new InputSystem();
    public static TransformSystem transformSystem = new TransformSystem();
    public static GraphicsSystem graphicsSystem = new GraphicsSystem();

    public static PhysicsSystem physicsSystem = new PhysicsSystem();
    public async Task Update(float dt)
    {
        await inputSystem.Update(dt);
        await physicsSystem.Update(dt);
        await transformSystem.Update(dt);
        await graphicsSystem.Update(dt);
    }

    public void ClearSystems()
    {
       Task.WaitAll(inputSystem.ClearSystem(), 
                     transformSystem.ClearSystem(),
                     graphicsSystem.ClearSystem());
    }
}