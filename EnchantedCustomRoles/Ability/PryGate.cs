// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Ability.PryGate
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;

namespace EnchantedCustomRoles.Ability
{
  internal class PryGate : PassiveAbility
  {
    public virtual string Name { get; set; } = nameof (PryGate);

    public virtual string Description { get; set; } = "bruh, you so strong that opening a gate is nothing but a joke";

    protected virtual void SubscribeEvents()
    {
      Exiled.Events.Handlers.Player.InteractingDoor += new Exiled.Events.Events.CustomEventHandler<InteractingDoorEventArgs>(this.OninteractingDoors);
      ((CustomAbility) this).SubscribeEvents();
    }

    protected virtual void UnsubscribeEvents()
    {
      Exiled.Events.Handlers.Player.InteractingDoor -= new Exiled.Events.Events.CustomEventHandler<InteractingDoorEventArgs>(this.OninteractingDoors);
      ((CustomAbility) this).UnsubscribeEvents();
    }

    private void OninteractingDoors(InteractingDoorEventArgs ev)
    {
      if (!((CustomAbility) this).Check(ev.Player) || !ev.Door.IsGate)
        return;
      ev.Door.TryPryOpen();
    }
  }
}
