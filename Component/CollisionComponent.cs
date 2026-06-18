using SFML.Graphics;
using SFML.System;

public class CollisionComponent : Component
{
    public CollisoinState collisoinState = CollisoinState.none;

    public RectangleShape collisionBody;

    public TransformComponent transformComponent;
    public CollisionComponent(TransformComponent transformComponent, Vector2f size)
    {
        collisionBody = new RectangleShape();
        this.transformComponent = transformComponent;
        this.collisionBody.Size = size;
        this.collisionBody.FillColor = Color.Transparent;
        this.collisionBody.Position = transformComponent.position;
        CollisionSystem.Register(this);
    }
}