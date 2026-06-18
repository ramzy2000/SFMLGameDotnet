using SFML.Graphics;
using SFML.System;

public class GraphicsComponent : Component
{
    public Shape shape;
    public TransformComponent transformComponent;

    public GraphicsComponent(Shape shape, TransformComponent transformComponent)
    {
        this.shape = shape;
        this.transformComponent = transformComponent;
        GraphicsSystem.Register(this);
    }

    public override void Update(float dt)
    {
        if(transformComponent != null && shape != null)
        {
            shape.Position = transformComponent.position;
            shape.Rotation = transformComponent.rotation;
        }
        GameState.window.Draw(shape);
    }
}