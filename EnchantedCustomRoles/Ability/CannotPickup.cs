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
    public virtual string Name { get; set; } = nameof (CannotPickup);

    public virtual string Description { get; set; } = "hmm... it seems that you can't pickup item, sorry for you";

    protected virtual void SubscribeEvents()
    {
      Exiled.Events.Handlers.Player.PickingUpItem += new Exiled.Events.Events.CustomEventHandler<PickingUpItemEventArgs>(this.OnPickingItem);
      ((CustomAbility) this).SubscribeEvents();
    }

    protected virtual void UnsubscribeEvents()
    {
      Exiled.Events.Handlers.Player.PickingUpItem -= new Exiled.Events.Events.CustomEventHandler<PickingUpItemEventArgs>(this.OnPickingItem);
      ((CustomAbility) this).UnsubscribeEvents();
    }

    private void OnPickingItem(PickingUpItemEventArgs ev)
    {
      if (!((CustomAbility) this).Check(ev.Player))
        return;
      ev.IsAllowed = false;
    }
  }
}
