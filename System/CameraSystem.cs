using SFML.System;

public class CameraSystem : BaseSystem
{
    public static Vector2f Offset { get; private set; }

    public override void Update(World world, float dt)
    {
        Vector2f centerPos = (Vector2f)GameState.window.Size / 2;
        Offset = new Vector2f(0f, 0f);

        foreach (ArchetypeChunk chunk in world.Query(typeof(CameraComponent), typeof(TransformComponent)))
        {
            CameraComponent[] cameras = chunk.GetComponentArray<CameraComponent>();
            TransformComponent[] transforms = chunk.GetComponentArray<TransformComponent>();

            for (int index = 0; index < chunk.Count; index++)
            {
                CameraComponent camera = cameras[index];
                if (!camera.isActive)
                {
                    continue;
                }

                Offset = centerPos - transforms[index].position;
                return;
            }
        }
    }
}