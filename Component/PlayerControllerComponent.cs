using SFML.System;
using SFML.Window;

public class PlayerControllerComponent : Component
{

    public MovementComponent? movementComponent;
    public PlayerControllerComponent()
    {
        ControllerSystem.Register(this);
    }

    public override void Update(float dt)
    {
        if(movementComponent != null)
        {
            if(Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                movementComponent.moveState.isMoveingForward = true;
            }
            else
            {
                movementComponent.moveState.isMoveingForward = false;
            }

            if(Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                movementComponent.moveState.isMovingBackward = true;
            }
            else
            {
                movementComponent.moveState.isMovingBackward = false;
            }

            if(Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                movementComponent.moveState.isMoveingLeft = true;
            }
            else
            {
                movementComponent.moveState.isMoveingLeft = false;
            }

            if(Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                movementComponent.moveState.isMoveingRight = true;
            }
            else
            {
                movementComponent.moveState.isMoveingRight = false;
            }
        }
    }
}