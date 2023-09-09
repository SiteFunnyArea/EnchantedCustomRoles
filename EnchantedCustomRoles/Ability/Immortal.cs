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
    public override string Name { get; set; } = "Immortal";

    public override string Description { get; set; } = "You are immortal, so why not have fun?";

    protected override void SubscribeEvents()
    {
      Exiled.Events.Handlers.Player.Hurting += OnHurtingEvent;
      base.SubscribeEvents();
    }

    protected override void UnsubscribeEvents()
    {
      Exiled.Events.Handlers.Player.Hurting -= OnHurtingEvent;
      base.UnsubscribeEvents();
    }

    private void OnHurtingEvent(HurtingEventArgs ev)
    {
      if (!Check(ev.Player) || ev.DamageHandler.Type == DamageType.Unknown || ev.DamageHandler.Type == DamageType.Crushed || ev.DamageHandler.IsSuicide)
        return;
      ev.IsAllowed = false;
    }
  }
}
