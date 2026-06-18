public class PhysicsComponent : Component
{
    public PhysicsComponent()
    {
        PhysicsSystem.Register(this);
    }
}