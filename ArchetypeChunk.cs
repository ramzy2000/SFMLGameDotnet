using System.Collections.Generic;

public class ArchetypeChunk
{
    private readonly Dictionary<Type, Array> componentArrays = new();
    private readonly int[] entityIds;

    public Type[] ComponentTypes { get; }
    public int Capacity { get; }
    public int Count { get; private set; }

    public ArchetypeChunk(Type[] componentTypes, int capacity)
    {
        ComponentTypes = componentTypes;
        Capacity = capacity;
        entityIds = new int[capacity];

        foreach (Type type in componentTypes)
        {
            componentArrays[type] = Array.CreateInstance(type, capacity);
        }
    }

    public bool HasComponents(params Type[] requiredComponentTypes)
    {
        foreach (Type type in requiredComponentTypes)
        {
            if (!componentArrays.ContainsKey(type))
            {
                return false;
            }
        }

        return true;
    }

    public int AddEntity(int entityId, params Component[] components)
    {
        EnsureCapacity();

        int index = Count++;
        entityIds[index] = entityId;

        foreach (Component component in components)
        {
            component.EntityId = entityId;
            componentArrays[component.GetType()].SetValue(component, index);
        }

        return index;
    }

    public EntityLocation? RemoveEntity(int index)
    {
        if (Count == 0)
        {
            return null;
        }

        int lastIndex = Count - 1;
        int removedEntityId = entityIds[index];

        if (index != lastIndex)
        {
            int movedEntityId = entityIds[lastIndex];
            foreach (Type type in ComponentTypes)
            {
                Array array = componentArrays[type];
                object? movedComponent = array.GetValue(lastIndex);
                array.SetValue(movedComponent, index);
            }

            entityIds[index] = movedEntityId;
            Count--;
            return new EntityLocation(this, index, movedEntityId);
        }

        entityIds[lastIndex] = default;
        foreach (Type type in ComponentTypes)
        {
            componentArrays[type].SetValue(null, lastIndex);
        }

        Count--;
        return null;
    }

    public T[] GetComponentArray<T>()
    {
        return (T[])componentArrays[typeof(T)];
    }

    private void EnsureCapacity()
    {
        if (Count < Capacity)
        {
            return;
        }

        throw new InvalidOperationException("Archetype chunk capacity exceeded.");
    }
}