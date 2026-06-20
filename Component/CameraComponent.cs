using SFML.System;

public class CameraComponent : Component
{
    public TransformComponent transformComponent;
    
    public Vector2f transform;
    public CameraComponent(TransformComponent transformComponent)
    {
        this.transformComponent = transformComponent;
        transform = transformComponent.position + (Vector2f)GameState.window.Size / 2;
        CameraSystem.Register(this);
    }

    public override void Destroy()
    {
        CameraSystem.Remove(this);
    }

    public override void Update(float dt)
    {
        // get the distance between the current transform and the center of the screen
        Vector2f centerPos = (Vector2f)GameState.window.Size / 2;

        float distance = Utils.GetDistance(centerPos, transformComponent.position);

        Vector2f direction = transformComponent.position - centerPos;
        
        transform = direction * distance;
    }
}