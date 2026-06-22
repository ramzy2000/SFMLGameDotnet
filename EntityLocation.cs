public readonly struct EntityLocation
{
    public ArchetypeChunk Chunk { get; }
    public int IndexInChunk { get; }
    public int EntityId { get; }

    public EntityLocation(ArchetypeChunk chunk, int indexInChunk, int entityId)
    {
        Chunk = chunk;
        IndexInChunk = indexInChunk;
        EntityId = entityId;
    }
}