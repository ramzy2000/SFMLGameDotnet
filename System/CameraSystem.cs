using SFML.System;

public class CameraSystem : BaseSystem<CameraComponent>
{
    public override async Task Update(float dt)
    {
        // update every transform to keep the current transform in the center of the screen
        // get the center of the screen
        // get the get the vector to move transform to center of screen
        foreach(CameraComponent cameraComponent in components)
        {
            cameraComponent.Update(dt);
        }
    }
}