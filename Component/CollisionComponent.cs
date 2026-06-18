using SFML.Graphics;

public class CollisionComponent : Component
{
    public CollisionComponent()
    {
        CollisionSystem.Register(this);
    }

    public override void Update(float dt)
    {
         
    }
}