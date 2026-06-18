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
            transformComponent.position.X = 400;
            transformComponent.position.Y = 400;
        }
        AddEntity(wall);
    }
}