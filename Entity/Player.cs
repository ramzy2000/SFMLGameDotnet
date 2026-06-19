using SFML.Graphics;
using SFML.System;

public class Player : Entity
{
    public Player()
    {
        TransformComponent transformComponent = new TransformComponent();
        AddComponent(transformComponent);
        CircleShape circleShape = new CircleShape(50.0f);
        circleShape.Origin = new Vector2f(circleShape.Radius, circleShape.Radius);
        circleShape.FillColor = Color.Blue;
        GraphicsComponent graphicsComponent = new GraphicsComponent(circleShape, transformComponent);
        AddComponent(graphicsComponent);

        RidgetBodyComponent ridgetBodyComponent = new RidgetBodyComponent(new RigidBody(transformComponent.position, circleShape.Radius, 1), transformComponent);
        AddComponent(ridgetBodyComponent);

        InputComponent inputComponent = new InputComponent(ridgetBodyComponent);
        inputComponent.speed = 1000f;
        AddComponent(inputComponent);
    }
}