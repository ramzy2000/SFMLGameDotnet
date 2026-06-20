using SFML.Graphics;
using SFML.System;

public class TransformComponent : Component
{
    public Vector2f position = new Vector2f();

    public Vector2f scale = new Vector2f();

    public float layerDepth = 0;

    public float rotation = 0;

    public TransformComponent()
    {
        TransformSystem.Register(this);
    }

    public override void Update(float dt)
    {
        if(CameraComponent.isActive)
        {
            position += CameraComponent.transform;
        }
    }

    public override void Destroy()
    {
        TransformSystem.Remove(this);
    }
}
