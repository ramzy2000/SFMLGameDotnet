public class ComponentManager
{
    public static Dictionary<Entity, Dictionary<Type, Component>> entityComponentDict = new Dictionary<Entity, Dictionary<Type, Component>>();

    // register a entity with a component
    public static void RegisterComponent(Entity entity, List<Component> component)
    {
        entityComponentDict.Add(entity, component);
    }

    // unregister a entity with a component
    public static void UnregisterComponents(Entity entity, Component component)
    {
        entityComponentDict.Remove();
    }
}