using SFML.Graphics;
using SFML.System;

public class Player : Entity
{
    public Player()
    {
        TransformComponent transformComponent = new TransformComponent();
        transformComponent.position = new Vector2f();
        AddComponent(transformComponent);
        RectangleShape circleShape = new RectangleShape(new Vector2f(50f, 50f));
        circleShape.FillColor = Color.Blue;
        GraphicsComponent graphicsComponent = new GraphicsComponent(circleShape, transformComponent);
        AddComponent(graphicsComponent);

        InputComponent inputComponent = new InputComponent(transformComponent);
        inputComponent.speed = 1000f;
        AddComponent(inputComponent);
    }
}