using SFML.Graphics;
using SFML.System;

public class GraphicsComponent : Component
{
    public Shape shape;

    public GraphicsComponent(Shape shape)
    {
        this.shape = shape;
    }
}
