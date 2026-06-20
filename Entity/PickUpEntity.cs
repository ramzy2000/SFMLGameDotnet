using SFML.Graphics;
using SFML.System;

public class PickUpEntity : Entity
{
    public PickUpEntity()
    {
        TransformComponent transformComponent = new TransformComponent();
        AddComponent(transformComponent);
        CircleShape circleShape = new CircleShape(50.0f);
        circleShape.Origin = new Vector2f(circleShape.Radius, circleShape.Radius);
        circleShape.FillColor = Color.White;
        GraphicsComponent graphicsComponent = new GraphicsComponent(circleShape, transformComponent);
        AddComponent(graphicsComponent);

        RidgetBodyComponent ridgetBodyComponent = new RidgetBodyComponent(new RigidBody(transformComponent.position, circleShape.Radius, 0), transformComponent);
        ridgetBodyComponent.collisoinState = CollisoinState.none;
        AddComponent(ridgetBodyComponent);

        PickUpComponent pickUpComponent = new PickUpComponent(ridgetBodyComponent);
        AddComponent(pickUpComponent);
    }
}