using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;

namespace EnchantedCustomRoles.Ability
{
  internal class HealOnKill : PassiveAbility
  {
    public override string Name { get; set; } = "HealOnKill";

    public override string Description { get; set; } = "Every time you kill someone you will heal 10% of your max life(if you have already reached the max health it will convert in shield)";

    protected override void SubscribeEvents()
    {
      Exiled.Events.Handlers.Player.Dying += OnKill;
      base.SubscribeEvents();
    }

    protected override void UnsubscribeEvents()
    {
      Exiled.Events.Handlers.Player.Dying -= OnKill;
      base.UnsubscribeEvents();
    }

    private void OnKill(DyingEventArgs ev)
    {
      if (!Check(ev.Attacker))
        return;
      if ((double) ev.Player.Health >= (double) ev.Player.MaxHealth)
        ev.Player.HumeShield = ev.Player.MaxHealth / 20f;
      else
        ev.Player.Health += ev.Player.MaxHealth / 10f;
    }
  }
}
