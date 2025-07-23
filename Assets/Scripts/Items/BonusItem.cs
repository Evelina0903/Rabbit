using UnityEngine;
using UnityEngine.Events;

public class BonusItem : Item
{
    private UnityEvent[] EffectsEvents = new UnityEvent[]
    {
        EventController.OnHealEffectApplied,
        EventController.OnSpeedEffectApplied,
        EventController.OnSlowEffectApplied,
        EventController.OnReverseEffectApplied
    };

    public override void ApplyEffect()
    {
        EffectsEvents[Random.Range(0, EffectsEvents.Length)].Invoke();
    }
}
