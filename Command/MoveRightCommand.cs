using System.ComponentModel;

public class MoveRightCommand : ICommand
{
    public void Execute(Entity entity)
    {
        InputComponent? inputComponent = entity.GetComponent<InputComponent>();
        if(inputComponent != null)
        {
            inputComponent.MoveRight();
        }
    }
}
