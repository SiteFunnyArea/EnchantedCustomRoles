// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Ability.Immortal
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using Exiled.API.Enums;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;

namespace EnchantedCustomRoles.Ability
{
  internal class Immortal : PassiveAbility
  {
    public virtual string Name { get; set; } = nameof (Immortal);

    public virtual string Description { get; set; } = "You are immortal, so why not have fun?";

    protected virtual void SubscribeEvents()
    {
      Exiled.Events.Handlers.Player.Hurting += new Exiled.Events.Events.CustomEventHandler<HurtingEventArgs>(this.OnHurtingEvent);
      ((CustomAbility) this).SubscribeEvents();
    }

    protected virtual void UnsubscribeEvents()
    {
      Exiled.Events.Handlers.Player.Hurting -= new Exiled.Events.Events.CustomEventHandler<HurtingEventArgs>(this.OnHurtingEvent);
      ((CustomAbility) this).UnsubscribeEvents();
    }

    private void OnHurtingEvent(HurtingEventArgs ev)
    {
      if (!((CustomAbility) this).Check(ev.Player) || ev.DamageHandler.Type == DamageType.Unknown || ev.DamageHandler.Type == DamageType.Crushed || ev.DamageHandler.IsSuicide)
        return;
      ev.IsAllowed = false;
    }
  }
}
