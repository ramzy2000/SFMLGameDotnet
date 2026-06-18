using SFML.Graphics;
using SFML.System;

public class Player : Entity
{
    public Player()
    {

        TransformComponent transformComponent = new TransformComponent();
        transformComponent.position = new Vector2f();
        AddComponent(transformComponent);

        ShapeComponent shapeComponent = new ShapeComponent();
        shapeComponent.shape = new CircleShape(50.0f);
        shapeComponent.shape.FillColor = Color.Blue;
        shapeComponent.transformComponent = transformComponent;
        AddComponent(shapeComponent);

        MovementComponent movementComponent = new MovementComponent();
        movementComponent.transformComponent = transformComponent;
        movementComponent.speed = 1000.0f;
        AddComponent(movementComponent);

        PlayerControllerComponent playerControllerComponent = new PlayerControllerComponent();
        playerControllerComponent.movementComponent = movementComponent;
        AddComponent(playerControllerComponent);
    }
}