using SFML.Graphics;
using SFML.System;

public static class Wall
{
    public static Entity Create(World world, Vector2f position, float radius = 30f)
    {
        return world.CreateEntity(
            new TransformComponent
        {
            position = position,
            scale = new Vector2f(1f, 1f),
            rotation = 0f
        },
            new GraphicsComponent(new CircleShape(radius)
        {
            Origin = new Vector2f(radius, radius),
            FillColor = Color.White
        }),
            new RidgetBodyComponent(new RigidBody(position, radius, 0f, 0.2f))
        {
            collisionState = CollisionState.StaticBody
        });
    }
}
