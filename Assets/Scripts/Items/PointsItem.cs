public class PointsItem : Item
{
    public override void ApplyEffect()
    {
        EventController.OnPointsItemPicUp.Invoke();
    }
}
