using SFML.System;

public class TestCollisionLevel : Level
{
    public Player? player;

    public Random random = new Random();
    public TestCollisionLevel()
    {
        player = new Player();;
        if(player != null)
        {
            AddEntity(player);
        }
        
        for(int i = 0; i < 1000; i++)
        {
            Wall wall = new Wall();
            {
                TransformComponent? transformComponent = wall.GetComponent<TransformComponent>();
                if(transformComponent != null)
                {
                    transformComponent.position = new Vector2f(random.Next(-10000, 10000), random.Next(-10000, 10000));
                }
            }
            AddEntity(wall);
        }
        
        
        PickUpEntity pickUpEntity = new PickUpEntity();
        {
            TransformComponent? transformComponent = pickUpEntity.GetComponent<TransformComponent>();
            if(transformComponent != null)
            {
                transformComponent.position = new Vector2f(600.0f, 400.0f);
            }
        }
        
        AddEntity(pickUpEntity);
    }
}