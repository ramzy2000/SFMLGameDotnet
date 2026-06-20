using System.ComponentModel;

public class Entity
{
    public List<Component> components = new List<Component>();

    public void AddComponent(Component component)
    {
        components.Add(component);
        component.entity = this;
    }

    public T? GetComponent<T>() where T : Component
    {
        foreach(Component component in components)
        {
            if(component.GetType().Equals(typeof(T)))
            {
                return (T)component;
            }
        }
        return null;
    }

    ~Entity()
    {
        // remove all of this entitys components from the systems.
        // maybe come up with a way to manage the entities in the systems better.
    }
}
