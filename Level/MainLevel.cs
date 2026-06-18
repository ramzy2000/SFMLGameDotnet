using SFML.System;

public class MainLevel : Level
{
    public MainLevel()
    {
        AddEntity(new Player());
        Player player = new Player();
        TransformComponent? transformComponent = player.GetComponent<TransformComponent>();
        if(transformComponent != null)
        {
            transformComponent.position = new Vector2f(400.0f, 0);
        }
        AddEntity(player);
    }
}