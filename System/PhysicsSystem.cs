using SFML.System;

public class PhysicsSystem : BaseSystem
{
    public static Vector2f Gravity = new Vector2f(0f, 0f);

    public override void Update(World world, float dt)
    {
        foreach (ArchetypeChunk chunk in world.Query(typeof(InputComponent), typeof(RidgetBodyComponent)))
        {
            InputComponent[] inputs = chunk.GetComponentArray<InputComponent>();
            RidgetBodyComponent[] bodiesWithInput = chunk.GetComponentArray<RidgetBodyComponent>();

            for (int index = 0; index < chunk.Count; index++)
            {
                InputComponent input = inputs[index];
                RidgetBodyComponent body = bodiesWithInput[index];

                if (input.direction.X != 0f || input.direction.Y != 0f)
                {
                    body.rigidBody.ApplyForce(input.direction * input.speed);
                }
            }
        }

        List<(TransformComponent transform, RidgetBodyComponent body)> bodies = new();
        foreach (ArchetypeChunk chunk in world.Query(typeof(TransformComponent), typeof(RidgetBodyComponent)))
        {
            TransformComponent[] transforms = chunk.GetComponentArray<TransformComponent>();
            RidgetBodyComponent[] rigidBodies = chunk.GetComponentArray<RidgetBodyComponent>();

            for (int index = 0; index < chunk.Count; index++)
            {
                bodies.Add((transforms[index], rigidBodies[index]));
            }
        }

        foreach ((TransformComponent transform, RidgetBodyComponent body) in bodies)
        {
            body.rigidBody.Position = transform.position;
            body.overlapList.Clear();
            body.collisionList.Clear();
        }

        for (int i = 0; i < bodies.Count; i++)
        {
            for (int j = i + 1; j < bodies.Count; j++)
            {
                RidgetBodyComponent a = bodies[i].body;
                RidgetBodyComponent b = bodies[j].body;

                if (a.rigidBody.InvMass == 0 && b.rigidBody.InvMass == 0)
                {
                    continue;
                }

                ResolveCollision(a, b);
            }
        }

        foreach ((TransformComponent transform, RidgetBodyComponent body) in bodies)
        {
            body.rigidBody.Update(dt, Gravity);
            transform.position = body.rigidBody.Position;
        }
    }

    private void ResolveCollision(RidgetBodyComponent a, RidgetBodyComponent b)
    {
        Vector2f direction = b.rigidBody.Position - a.rigidBody.Position;
        float distanceSq = direction.X * direction.X + direction.Y * direction.Y;
        float radiusSum = a.rigidBody.Radius + b.rigidBody.Radius;

        if (distanceSq > radiusSum * radiusSum)
        {
            return;
        }

        a.overlapList.Add(b);
        b.overlapList.Add(a);

        if (a.collisionState == CollisionState.None || b.collisionState == CollisionState.None)
        {
            return;
        }

        float distance = (float)Math.Sqrt(distanceSq);
        if(distance == 0)
        {
            return;
        }

        Vector2f normal = direction / distance;
        float penetration = radiusSum - distance;

        const float percent = 0.2f;
        const float slop = 0.01f;
        Vector2f correction = Math.Max(penetration - slop, 0.0f) / (a.rigidBody.InvMass + b.rigidBody.InvMass) * percent * normal;
        a.rigidBody.Position -= a.rigidBody.InvMass * correction;
        b.rigidBody.Position += b.rigidBody.InvMass * correction;

        Vector2f relativeVelocity = b.rigidBody.Velocity - a.rigidBody.Velocity;
        float velAlongNormal = relativeVelocity.X * normal.X + relativeVelocity.Y * normal.Y;

        if (velAlongNormal > 0) return;

        float e = Math.Min(a.rigidBody.Restitution, b.rigidBody.Restitution);

        float impulseScalar = -(1 + e) * velAlongNormal;
        impulseScalar /= (a.rigidBody.InvMass + b.rigidBody.InvMass);

        Vector2f impulse = impulseScalar * normal;
        a.rigidBody.Velocity -= a.rigidBody.InvMass * impulse;
        b.rigidBody.Velocity += b.rigidBody.InvMass * impulse;

        a.collisionList.Add(b);
        b.collisionList.Add(a);
    }
}