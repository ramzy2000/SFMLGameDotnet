using SFML.System;

public class RidgetBodyComponent : Component
{
    public RigidBody rigidBody;

    public CollisionState collisionState = CollisionState.RigidBody;

    public List<RidgetBodyComponent> overlapList = new List<RidgetBodyComponent>();

    public List<RidgetBodyComponent> collisionList = new List<RidgetBodyComponent>();

    public RidgetBodyComponent(RigidBody rigidBody)
    {
        this.rigidBody = rigidBody;
    }
}
