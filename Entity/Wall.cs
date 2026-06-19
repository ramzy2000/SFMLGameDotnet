using SFML.Graphics;
using SFML.System;

public class Wall : Entity
{
    public Wall()
    {
        TransformComponent transformComponent = new TransformComponent();
        transformComponent.position = new Vector2f(0, 500);
        AddComponent(transformComponent);

        RectangleShape rectangleShape = new RectangleShape(new Vector2f(300f, 50f));
        rectangleShape.FillColor = Color.Red;
        GraphicsComponent graphicsComponent = new GraphicsComponent(rectangleShape, transformComponent);
        AddComponent(graphicsComponent);

        RidgetBodyComponent ridgetBodyComponent = new RidgetBodyComponent(new RigidBody(rectangleShape.Position, 0.5f, 0), transformComponent);
        AddComponent(ridgetBodyComponent);
    }
}
