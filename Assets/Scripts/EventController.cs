using UnityEngine.Events;

public class EventController
{
    public static UnityEvent OnPointsItemPicUp = new UnityEvent();
    public static UnityEvent OnBombItemPicUp = new UnityEvent();

    public static UnityEvent OnPlayerDie = new UnityEvent();
    public static UnityEvent<int> OnPlayerHealthChange = new UnityEvent<int>();

    public static UnityEvent OnHealEffectApplied = new UnityEvent();
    public static UnityEvent OnSpeedEffectApplied = new UnityEvent();
    public static UnityEvent OnSlowEffectApplied = new UnityEvent();
    public static UnityEvent OnReverseEffectApplied = new UnityEvent();

    public static UnityEvent OnGameModeChanged = new UnityEvent();
    public static UnityEvent OnGameRestart = new UnityEvent();
}
