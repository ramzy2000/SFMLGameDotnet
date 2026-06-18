public class SystemManager
{
    public void Update(float dt)
    {
        Task.WaitAll(TransformSystem.Update(dt), 
                     ControllerSystem.Update(dt), 
                     MovementSystem.Update(dt), 
                     ShapeSystem.Update(dt));
    }

    public void ClearSystems()
    {
       Task.WaitAll(TransformSystem.ClearSystem(), 
                     ControllerSystem.ClearSystem(), 
                     MovementSystem.ClearSystem(), 
                     ShapeSystem.ClearSystem());
    }
}