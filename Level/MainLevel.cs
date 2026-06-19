using SFML.System;

public class MainLevel : Level
{
    public MainLevel()
    {
        AddEntity(new Player());

        Wall wall = new Wall();
        TransformComponent? transformComponent = wall.GetComponent<TransformComponent>();
        if(transformComponent != null)
        {
            transformComponent.position = new Vector2f(0.0f, 400.0f);
        }
        AddEntity(wall);
    }
}