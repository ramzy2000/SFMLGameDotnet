using SFML.System;

public class MovementComponent : Component
{
    public TransformComponent? transformComponent;

    public MoveState moveState = new MoveState();

    Vector2f velocity = new Vector2f(0f, 0f);

    public float speed = 10.0f;
    public MovementComponent()
    {
        MovementSystem.Register(this);
    }
    public override void Update(float dt)
    {
        velocity = new Vector2f(0f, 0f);
        if(transformComponent != null)
        {
            if(moveState.isMoveingForward)
            {
                velocity.Y -= speed;
            }
            if(moveState.isMovingBackward)
            {
                velocity.Y += speed;
            }
            if(moveState.isMoveingLeft)
            {
                velocity.X -= speed;
            }
            if(moveState.isMoveingRight)
            {
                velocity.X += speed;
            }
            transformComponent.position += velocity * dt;
        }
    }
}