public class BaseSystem<T> where T : Component
{
    protected static List<T> components = new List<T>();

    public static void Register(T component)
    {
        components.Add(component);
    }
 
    public async static Task Update(float dt)
    {
        foreach(T component in components)
        {
            component.Update(dt);
        }
    }

    public async static Task ClearSystem()
    {
        components.Clear();
    }
}

public class TransformSystem : BaseSystem<TransformComponent> { }
public class ShapeSystem : BaseSystem<ShapeComponent> { }

public class MovementSystem : BaseSystem<MovementComponent> { }

public class ControllerSystem : BaseSystem<PlayerControllerComponent> { }