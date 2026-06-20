using SFML.System;

public class RidgetBodyComponent : Component
{
    public RigidBody rigidBody;

    public TransformComponent transformComponent;

    public CollisoinState collisoinState = CollisoinState.ridgedBody;

    public List<RidgetBodyComponent> overlapList = new List<RidgetBodyComponent>();

    public List<RidgetBodyComponent> collisionList = new List<RidgetBodyComponent>();

    public RidgetBodyComponent(RigidBody rigidBody, TransformComponent transformComponent)
    {
        this.transformComponent = transformComponent;
        this.rigidBody = rigidBody;
        PhysicsSystem.Register(this);
    }

    public override void Destroy()
    {
        PhysicsSystem.Remove(this);
    }

    public override void Update(float dt)
    {
        rigidBody.Update(dt);
        transformComponent.position = rigidBody.Position;
    }
}
