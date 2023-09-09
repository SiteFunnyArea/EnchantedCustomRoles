// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Ability.CannotPickup
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;

namespace EnchantedCustomRoles.Ability
{
    internal class CannotPickup : PassiveAbility
  {
    public override string Name { get; set; } = "CannotPickup";

    public override string Description { get; set; } = "hmm... it seems that you can't pickup item, sorry for you";

    protected override void SubscribeEvents()
    {
      Exiled.Events.Handlers.Player.PickingUpItem += OnPickingItem;
      base.SubscribeEvents();
    }

    protected override void UnsubscribeEvents()
    {
      Exiled.Events.Handlers.Player.PickingUpItem -= OnPickingItem;
      base.UnsubscribeEvents();
    }

    private void OnPickingItem(PickingUpItemEventArgs ev)
    {
      if (!Check(ev.Player))
        return;
      ev.IsAllowed = false;
    }
  }
}
