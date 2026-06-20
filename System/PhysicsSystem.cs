using SFML.System;

public class PhysicsSystem : BaseSystem<RidgetBodyComponent>
{
    public static Vector2f Gravity = new Vector2f(0f, 0.100f);

    public override async Task Update(float dt)
    {
        // Transform is authoritative for placement. Sync body positions before collision checks.
        // Update the rigid body position to match the transform components position
        foreach(RidgetBodyComponent component in components)
        {
            component.rigidBody.Position = component.transformComponent.position;
            component.overlapList.Clear(); // clear the overlap list from the previous frame
            component.collisionList.Clear(); // clear all collision list from previous frame
        }

        // apply the forces of gravity to each Rigid body component
        foreach(RidgetBodyComponent component in components)
        {
            if(component.rigidBody.InvMass > 0)
            {
                if(component.rigidBody.Velocity.X < 0)
                {
                    component.rigidBody.Velocity.X += Gravity.Y;
                }
                if(component.rigidBody.Velocity.X > 0)
                {
                    component.rigidBody.Velocity.X -= Gravity.Y;
                }
                if(component.rigidBody.Velocity.Y < 0)
                {
                    component.rigidBody.Velocity.Y += Gravity.Y;
                }
                if(component.rigidBody.Velocity.Y > 0)
                {
                    component.rigidBody.Velocity.Y -= Gravity.Y;
                }
            }
        }

        // apply collisions on each ridged body component
        for(int i = 0; i < components.Count(); i++)
        {
            for(int j = i + 1; j < components.Count(); j++)
            {
                RidgetBodyComponent a = components[i];
                RidgetBodyComponent b = components[j];

                if(a.rigidBody.InvMass == 0 && b.rigidBody.InvMass == 0)
                    continue;

                ResolveCollision(a, b);
            }
            components[i].Update(dt);
        }
    }

    private void ResolveCollision(RidgetBodyComponent a, RidgetBodyComponent b)
    {
        Vector2f direction = b.rigidBody.Position - a.rigidBody.Position;
        float distanceSq = direction.X * direction.X + direction.Y * direction.Y;
        float radiusSum = a.rigidBody.Radius + b.rigidBody.Radius;

        // check if circles overllap
        if(distanceSq >= radiusSum * radiusSum)
        {
            
            a.overlapList.Add(b);
            b.overlapList.Add(a);
            return;
        }

        // return if no collision
        if(a.collisoinState == CollisoinState.none || b.collisoinState == CollisoinState.none)
        {
            return;
        }
        

        float distance = (float)Math.Sqrt(distanceSq);
        if(distance == 0) return;

        // Calculate Normal and Penetration Depth
        Vector2f normal = direction / distance;
        float penetration = radiusSum - distance;

        // --- Positional Correction (Prevents Sinking) ---
        const float percent = 0.2f; // Penetration percentage to correct
        const float slop = 0.01f;    // Penetration allowance
        Vector2f correction = Math.Max(penetration - slop, 0.0f) / (a.rigidBody.InvMass + b.rigidBody.InvMass) * percent * normal;
        a.rigidBody.Position -= a.rigidBody.InvMass * correction;
        b.rigidBody.Position += b.rigidBody.InvMass * correction;

        // --- Impulse Resolution ---
        Vector2f relativeVelocity = b.rigidBody.Velocity - a.rigidBody.Velocity;
        float velAlongNormal = relativeVelocity.X * normal.X + relativeVelocity.Y * normal.Y;

        // Do not resolve if velocities are separating
        if (velAlongNormal > 0) return;

        // Calculate restitution (bounciness)
        float e = Math.Min(a.rigidBody.Restitution, b.rigidBody.Restitution);

        // Calculate impulse scalar
        float impulseScalar = -(1 + e) * velAlongNormal;
        impulseScalar /= (a.rigidBody.InvMass + b.rigidBody.InvMass);

        // Apply impulse to each body
        Vector2f impulse = impulseScalar * normal;
        a.rigidBody.Velocity -= a.rigidBody.InvMass * impulse;
        b.rigidBody.Velocity += b.rigidBody.InvMass * impulse;

        a.collisionList.Add(b);
        b.collisionList.Add(a);
    }
}