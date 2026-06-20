using SFML.System;
using SFML.Graphics;

public class MyEntity : Entity
{
    public MyEntity()
    {
        TransformComponent transformComponent = new TransformComponent();
        AddComponent(transformComponent);
        CircleShape circleShape = new CircleShape(50.0f);
        circleShape.Origin = new Vector2f(circleShape.Radius, circleShape.Radius);
        circleShape.FillColor = Color.Cyan;
        GraphicsComponent graphicsComponent = new GraphicsComponent(circleShape, transformComponent);
        AddComponent(graphicsComponent);

        RidgetBodyComponent ridgetBodyComponent = new RidgetBodyComponent(new RigidBody(transformComponent.position, circleShape.Radius, 0), transformComponent);
        AddComponent(ridgetBodyComponent);
    }
}