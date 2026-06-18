using System.ComponentModel;

public class Entity
{
    private static int newId = 0;
    public int ID { get; set; }
    public List<Component> components = new List<Component>();

    public Entity()
    {
        ID = newId;
        newId++;
    }

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
}
