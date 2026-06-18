public class SystemManager
{
    public void Update(float dt)
    {
        TransformSystem.Update(dt);
        ControllerSystem.Update(dt);
        MovementSystem.Update(dt);
        ShapeSystem.Update(dt);
    }
}