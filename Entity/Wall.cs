using SFML.Graphics;
using SFML.System;

public class Wall : Entity
{
    public Wall()
    {
        TransformComponent transformComponent = new TransformComponent();
        AddComponent(transformComponent);

        RectangleShape rectangleShape = new RectangleShape(new Vector2f(300f, 50f));
        rectangleShape.FillColor = Color.Red;
        GraphicsComponent graphicsComponent = new GraphicsComponent(rectangleShape, transformComponent);
        AddComponent(graphicsComponent);

        CollisionComponent collisionComponent = new CollisionComponent(transformComponent, new Vector2f(300f, 50f));
        AddComponent(collisionComponent);
    }
}