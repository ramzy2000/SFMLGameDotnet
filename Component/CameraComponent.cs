using SFML.System;

public class CameraComponent : Component
{
    public TransformComponent transformComponent;
    
    public static Vector2f transform;

    public static bool isActive = false;
    public CameraComponent(TransformComponent transformComponent)
    {
        this.transformComponent = transformComponent;
        // get the distance between the current transform and the center of the screen
        Vector2f centerPos = (Vector2f)GameState.window.Size / 2;

        transform = (centerPos - transformComponent.position);
        isActive = true;
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

        transform = (centerPos - transformComponent.position);
    }
}