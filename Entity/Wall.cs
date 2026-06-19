using SFML.Graphics;
using SFML.System;

public class Wall : Entity
{
    public Wall()
    {
        TransformComponent transformComponent = new TransformComponent();
        AddComponent(transformComponent);
        CircleShape circleShape = new CircleShape(100.0f);
        circleShape.Origin = new Vector2f(circleShape.Radius, circleShape.Radius);
        circleShape.FillColor = Color.Red;
        GraphicsComponent graphicsComponent = new GraphicsComponent(circleShape, transformComponent);
        AddComponent(graphicsComponent);

        RidgetBodyComponent ridgetBodyComponent = new RidgetBodyComponent(new RigidBody(transformComponent.position, circleShape.Radius, 0), transformComponent);
        AddComponent(ridgetBodyComponent);
    }
}
