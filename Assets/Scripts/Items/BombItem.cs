public class BombItem : Item
{
    public override void ApplyEffect()
    {
        EventController.OnBombItemPicUp.Invoke();
    }
}
