using SFML.Graphics;
using SFML.System;

public static class PickUpEntity
{
    public static Entity Create(World world, Vector2f position)
    {
        return world.CreateEntity(
            new TransformComponent
        {
            position = position,
            scale = new Vector2f(1f, 1f)
        },
            new GraphicsComponent(new CircleShape(10f)
        {
            Origin = new Vector2f(10f, 10f),
            FillColor = Color.Yellow
        }),
            new RidgetBodyComponent(new RigidBody(position, 10f, 0f, 0f))
        {
            collisionState = CollisionState.None
        });
    }
}