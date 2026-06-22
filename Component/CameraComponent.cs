using SFML.System;

public class CameraComponent : Component
{
    public bool isActive;

    public CameraComponent(bool isActive = true)
    {
        this.isActive = isActive;
    }
}