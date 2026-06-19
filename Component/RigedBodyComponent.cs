using SFML.System;

public class RidgetBodyComponent : Component
{
    public RigidBody rigidBody;

    public TransformComponent transformComponent;

    public RidgetBodyComponent(RigidBody rigidBody, TransformComponent transformComponent)
    {
        this.transformComponent = transformComponent;
        this.rigidBody = rigidBody;
        PhysicsSystem.Register(this);
    }

    public override void Update(float dt)
    {
        rigidBody.Update(dt);
        transformComponent.position = rigidBody.Position;
    }
}
