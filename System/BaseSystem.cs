using SFML.Graphics;
using SFML.System;

public abstract class BaseSystem
{
    public abstract void Update(World world, float dt);
}

public class GraphicsSystem : BaseSystem
{
    public override void Update(World world, float dt)
    {
        foreach (ArchetypeChunk chunk in world.Query(typeof(TransformComponent), typeof(GraphicsComponent)))
        {
            TransformComponent[] transforms = chunk.GetComponentArray<TransformComponent>();
            GraphicsComponent[] graphicsComponents = chunk.GetComponentArray<GraphicsComponent>();

            for (int index = 0; index < chunk.Count; index++)
            {
                GraphicsComponent graphics = graphicsComponents[index];
                TransformComponent transform = transforms[index];

                graphics.shape.Position = transform.position + CameraSystem.Offset;
                graphics.shape.Rotation = transform.rotation;
                GameState.window.Draw(graphics.shape);
            }
        }
    }
}

public class InputSystem : BaseSystem
{
    public override void Update(World world, float dt)
    {
        foreach (ArchetypeChunk chunk in world.Query(typeof(InputComponent)))
        {
            InputComponent[] inputs = chunk.GetComponentArray<InputComponent>();

            for (int index = 0; index < chunk.Count; index++)
            {
                InputComponent input = inputs[index];
                input.CaptureInput();
            }
        }
    }
}

