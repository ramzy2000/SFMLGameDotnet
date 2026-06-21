public class MoveForwardCommand : ICommand
{
    public void Execute(Entity entity)
    {
        InputComponent? inputComponent = entity.GetComponent<InputComponent>();
        if(inputComponent != null)
        {
            inputComponent.MoveForward();
        }
    }
}