public class Level
{
    public List<Entity> entities = new List<Entity>();

    public void AddEntity(Entity entity)
    {
        entities.Add(entity);
    }

    public virtual void Load()
    {
        
    }

    public virtual void Unload()
    {
        GameState.systemManager.ClearSystems();
    }
}