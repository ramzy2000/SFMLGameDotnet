using System.Collections.Generic;

public class World
{
    private readonly Dictionary<string, ArchetypeChunk> archetypes = new();
    private readonly Dictionary<int, EntityLocation> entityLocations = new();
    private int nextEntityId;
    private readonly SystemManager systemManager = new();

    public Entity CreateEntity(params Component[] components)
    {
        int entityId = nextEntityId++;
        string archetypeKey = BuildArchetypeKey(components);

        if (!archetypes.TryGetValue(archetypeKey, out ArchetypeChunk? archetype))
        {
            archetype = new ArchetypeChunk(components.Select(component => component.GetType()).ToArray(), 128);
            archetypes[archetypeKey] = archetype;
        }

        int indexInChunk = archetype.AddEntity(entityId, components);
        entityLocations[entityId] = new EntityLocation(archetype, indexInChunk, entityId);

        return new Entity(entityId);
    }

    public bool RemoveEntity(Entity entity)
    {
        if (!entityLocations.TryGetValue(entity.ID, out EntityLocation location))
        {
            return false;
        }

        EntityLocation? moved = location.Chunk.RemoveEntity(location.IndexInChunk);
        if (moved.HasValue)
        {
            entityLocations[moved.Value.EntityId] = moved.Value;
        }

        entityLocations.Remove(entity.ID);
        return true;
    }

    public IEnumerable<ArchetypeChunk> Query(params Type[] componentTypes)
    {
        foreach (ArchetypeChunk archetype in archetypes.Values)
        {
            if (archetype.HasComponents(componentTypes))
            {
                yield return archetype;
            }
        }
    }

    public void Update(float dt)
    {
        systemManager.Update(this, dt);
    }

    public void Shutdown()
    {
        systemManager.ClearSystems();
        Reset();
    }

    public void Reset()
    {
        archetypes.Clear();
        entityLocations.Clear();
        nextEntityId = 0;
    }

    private static string BuildArchetypeKey(IEnumerable<Component> components)
    {
        return string.Join(",", components.Select(component => component.GetType().FullName).OrderBy(name => name));
    }
}