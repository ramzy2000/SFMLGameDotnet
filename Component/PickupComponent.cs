public class PickUpComponent : Component
{
    public RidgetBodyComponent ridgetBodyComponent;

    public List<Entity> pickedUpEntities = new List<Entity>();
    public PickUpComponent(RidgetBodyComponent ridgetBodyComponent)
    {
        this.ridgetBodyComponent = ridgetBodyComponent;
        PickUpSystem.Register(this);
    }
    public override void Destroy()
    {
        PickUpSystem.Remove(this);
    }

    public override void Update(float dt)
    {
        if(ridgetBodyComponent.overlapList.Count() > 0)
        {
            pickedUpEntities.Add(entity);
        }
    }
}