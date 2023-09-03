// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Ability.HealOnKill
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;

namespace EnchantedCustomRoles.Ability
{
  internal class HealOnKill : PassiveAbility
  {
    public virtual string Name { get; set; } = nameof (HealOnKill);

    public virtual string Description { get; set; } = "Every time you kill someone you will heal 10% of your max life(if you have already reached the max health it will convert in shield)";

    protected virtual void SubscribeEvents()
    {
      Exiled.Events.Handlers.Player.Dying += new Exiled.Events.Events.CustomEventHandler<DyingEventArgs>(this.OnKill);
      ((CustomAbility) this).SubscribeEvents();
    }

    protected virtual void UnsubscribeEvents()
    {
      Exiled.Events.Handlers.Player.Dying -= new Exiled.Events.Events.CustomEventHandler<DyingEventArgs>(this.OnKill);
      ((CustomAbility) this).UnsubscribeEvents();
    }

    private void OnKill(DyingEventArgs ev)
    {
      if (!((CustomAbility) this).Check(ev.Attacker))
        return;
      if ((double) ev.Player.Health >= (double) ev.Player.MaxHealth)
        ev.Player.HumeShield = ev.Player.MaxHealth / 20f;
      else
        ev.Player.Health += ev.Player.MaxHealth / 10f;
    }
  }
}
