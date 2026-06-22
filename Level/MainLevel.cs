using SFML.System;

public class MainLevel : Level
{
    public override void Load(World world)
    {
        Player.Create(world, new Vector2f(400, 300));
        Wall.Create(world, new Vector2f(400, 500), 35f);
        PickUpEntity.Create(world, new Vector2f(500, 350));
    }
}