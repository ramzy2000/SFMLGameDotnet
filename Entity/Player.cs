using SFML.Graphics;
using SFML.System;

public class Player : Entity
{
    public Player()
    {
        TransformComponent transformComponent = new TransformComponent();
        transformComponent.position = new Vector2f(0.01f, 0.0f);
        AddComponent(transformComponent);
        CircleShape circleShape = new CircleShape(50.5f);
        circleShape.FillColor = Color.Blue;
        GraphicsComponent graphicsComponent = new GraphicsComponent(circleShape, transformComponent);
        AddComponent(graphicsComponent);

        RidgetBodyComponent ridgetBodyComponent = new RidgetBodyComponent(new RigidBody(circleShape.Position, circleShape.Radius, 1), transformComponent);
        AddComponent(ridgetBodyComponent);

        InputComponent inputComponent = new InputComponent(ridgetBodyComponent);
        inputComponent.speed = 100f;
        AddComponent(inputComponent);
    }
}