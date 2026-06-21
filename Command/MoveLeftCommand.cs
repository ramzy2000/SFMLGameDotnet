using System.ComponentModel;

public class MoveLeftCommand : ICommand
{
    public void Execute(Entity entity)
    {
        InputComponent? inputComponent = entity.GetComponent<InputComponent>();
        if(inputComponent != null)
        {
            inputComponent.MoveLeft();
        }
    }
}
