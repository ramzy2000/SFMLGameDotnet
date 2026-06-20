using System.Xml.Serialization;

public class Component
{
    public Entity entity;
    public virtual void Update(float dt) { }

    public virtual void Destory() { }
}
