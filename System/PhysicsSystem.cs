using SFML.System;

public class PhysicsSystem : BaseSystem<RidgetBodyComponent>
{
    public static Vector2f Gravity = new Vector2f(0f, 981.0f);

    public override async Task Update(float dt)
    {
        // Transform is authoritative for placement. Sync body positions before collision checks.
        // Update the rigid body position to match the transform components position
        foreach(RidgetBodyComponent component in components)
        {
            component.rigidBody.Position = component.transformComponent.position;
        }

        // apply the forces of gravity to each Rigid body component
        foreach(RidgetBodyComponent component in components)
        {
            if(component.rigidBody.InvMass > 0)
            {
                component.rigidBody.Velocity += Gravity * dt;
            }
        }

        // apply collisions on each ridged body component
        for(int i = 0; i < components.Count(); i++)
        {
            for(int j = i + 1; j < components.Count(); j++)
            {
                RigidBody a = components[i].rigidBody;
                RigidBody b = components[j].rigidBody;

                if(a.InvMass == 0 && b.InvMass == 0)
                    continue;

                ResolveCollision(a, b);
            }
            components[i].Update(dt);
        }
    }

    private void ResolveCollision(RigidBody a, RigidBody b)
    {
        
        Vector2f direction = b.Position - a.Position;
        float distanceSq = direction.X * direction.X + direction.Y * direction.Y;
        float radiusSum = a.Radius + b.Radius;

        // check if circles overllap
        if(distanceSq >= radiusSum * radiusSum) return;

        float distance = (float)Math.Sqrt(distanceSq);
        if(distance == 0) return;

        // Calculate Normal and Penetration Depth
        Vector2f normal = direction / distance;
        float penetration = radiusSum - distance;

        // --- Positional Correction (Prevents Sinking) ---
        const float percent = 0.2f; // Penetration percentage to correct
        const float slop = 0.01f;    // Penetration allowance
        Vector2f correction = Math.Max(penetration - slop, 0.0f) / (a.InvMass + b.InvMass) * percent * normal;
        a.Position -= a.InvMass * correction;
        b.Position += b.InvMass * correction;

        // --- Impulse Resolution ---
        Vector2f relativeVelocity = b.Velocity - a.Velocity;
        float velAlongNormal = relativeVelocity.X * normal.X + relativeVelocity.Y * normal.Y;

        // Do not resolve if velocities are separating
        if (velAlongNormal > 0) return;

        // Calculate restitution (bounciness)
        float e = Math.Min(a.Restitution, b.Restitution);

        // Calculate impulse scalar
        float impulseScalar = -(1 + e) * velAlongNormal;
        impulseScalar /= (a.InvMass + b.InvMass);

        // Apply impulse to each body
        Vector2f impulse = impulseScalar * normal;
        a.Velocity -= a.InvMass * impulse;
        b.Velocity += b.InvMass * impulse;
    }
}