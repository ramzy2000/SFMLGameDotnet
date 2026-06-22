using System.Numerics;
using SFML.System;

public class RigidBody
{
    public Vector2f Position;
    public Vector2f Velocity;
    public Vector2f Force;

    public float Radius;
    public float InvMass;

    public float Restitution;
    public float LinearDamping;

    public RigidBody(Vector2f position, float radius, float mass, float restitution = 0.6f, float linearDamping = 6.0f)
    {
        Position = position;
        Radius = radius;
        InvMass = mass > 0.0f ? 1.0f / mass : 0.0f;
        Restitution = restitution;
        LinearDamping = linearDamping;
        Velocity = new Vector2f(0.0f, 0.0f);
        Force = new Vector2f(0.0f, 0.0f);
    }

    public void ApplyForce(Vector2f force)
    {
        if(InvMass == 0)
        {
            return;
        }

        Force += force;
    }

    public void Update(float dt, Vector2f gravity)
    {
        if(InvMass == 0)
        {
            return;
        }

        Vector2f acceleration = gravity + (Force * InvMass);
        Velocity += acceleration * dt;

        float dampingFactor = MathF.Max(0.0f, 1.0f - (LinearDamping * dt));
        Velocity *= dampingFactor;

        if (MathF.Abs(Velocity.X) < 0.001f)
        {
            Velocity.X = 0.0f;
        }

        if (MathF.Abs(Velocity.Y) < 0.001f)
        {
            Velocity.Y = 0.0f;
        }

        Position += Velocity * dt;
        Force = new Vector2f(0.0f, 0.0f);
    }
}
