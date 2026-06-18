using SFML.System;

public class MainLevel : Level
{
    public MainLevel()
    {
        AddEntity(new Player());
    }
}