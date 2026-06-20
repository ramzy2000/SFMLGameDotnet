public class Level
{
    public List<Entity> entities = new List<Entity>();

    public void AddEntity(Entity entity)
    {
        entities.Add(entity);
    }

    public virtual void RemoveEntity(Entity entity)
    {
        if(!entities.Contains(entity)) return;
        entity.DestoryAllComponents();
        entities.Remove(entity);
    }
}
