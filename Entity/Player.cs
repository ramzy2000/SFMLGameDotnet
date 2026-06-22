using SFML.Graphics;
using SFML.System;

public static class Player
{
    public static Entity Create(World world, Vector2f position)
    {
        return world.CreateEntity(
            new TransformComponent
        {
            position = position,
            scale = new Vector2f(1f, 1f),
            rotation = 0f
        },
            new GraphicsComponent(new CircleShape(20f)
        {
            Origin = new Vector2f(20f, 20f),
            FillColor = Color.Cyan
        }),
            new RidgetBodyComponent(new RigidBody(position, 20f, 1f, 0.25f, 5.0f))
        {
            collisionState = CollisionState.RigidBody
        },
            new InputComponent
        {
            speed = 2200f,
            walkAcceleration = 1
        },
            new CameraComponent(true));
    }
}