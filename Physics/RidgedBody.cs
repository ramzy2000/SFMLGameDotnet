using System.Numerics;
using SFML.System;

public class RigidBody
{
    public Vector2f Position;
    public Vector2f Velocity;

    public float Radius;
    public float InvMass;

    public float Restitution;

    public RigidBody(Vector2f position, float radius, float mass, float restitution = 0.6f)
    {
        Position = position;
        Radius = radius;
        InvMass = mass > 0.0f ? 1.0f / mass : 0.0f;
        Restitution = restitution;
        Velocity = new Vector2f(0.0f, 0.0f);
    }

    public void ApplyForce(Vector2f  force, float deltaTime)
    {
        if(InvMass == 0)
            return;

        Velocity += force * InvMass * deltaTime;
    }

    public void Update(float dt)
    {
        if(InvMass == 0) return;
            Position += Velocity * dt;
    }
}
