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

    public void DestoryComponent(Component component)
    {
        component.Destroy();
        components.Remove(component);
    }

    public void DestoryAllComponents()
    {
        foreach(Component component in components)
        {
            component.Destroy();
        }
        components.Clear();
    }
}
