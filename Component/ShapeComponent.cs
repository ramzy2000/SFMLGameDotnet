using SFML.Graphics;
using SFML.System;

public class ShapeComponent : Component
{
    public Shape? shape;

    public TransformComponent? transformComponent;

    public ShapeComponent()
    {
        ShapeSystem.Register(this);
    }

    public override void Update(float dt)
    {
        if(transformComponent != null && shape != null)
        {
            shape.Position = transformComponent.position;
            shape.Rotation = transformComponent.rotation;
        }
        Game.window.Draw(shape);
    }
}