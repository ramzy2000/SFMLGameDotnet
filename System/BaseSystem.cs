using SFML.Graphics;

public class BaseSystem<T> where T : Component
{
    protected static List<T> components = new List<T>();

    public static void Register(T component)
    {
        components.Add(component);
    }
 
    public virtual async Task Update(float dt)
    {
        foreach(T component in components)
        {
            component.Update(dt);
        }
    }

    public async Task ClearSystem()
    {
        components.Clear();
    }
}

public class TransformSystem : BaseSystem<TransformComponent> { }
public class GraphicsSystem : BaseSystem<GraphicsComponent> { }

public class PhysicsSystem : BaseSystem<PhysicsComponent> { }

public class InputSystem : BaseSystem<InputComponent> { }

public class CollisionSystem : BaseSystem<CollisionComponent> { }
