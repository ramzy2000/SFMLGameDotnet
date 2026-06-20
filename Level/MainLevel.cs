using SFML.System;

public class MainLevel : Level
{
    public Player? player;
    public MainLevel()
    {
        player = new Player();;
        if(player != null)
        {
            AddEntity(player);
        }
        

        Wall wall = new Wall();
        {
            TransformComponent? transformComponent = wall.GetComponent<TransformComponent>();
            if(transformComponent != null)
            {
                transformComponent.position = new Vector2f(300.0f, 400.0f);
            }
        }
        
        AddEntity(wall);
        
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