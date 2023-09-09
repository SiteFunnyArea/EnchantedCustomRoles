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
    public override string Name { get; set; } = nameof (PryGate);

    public override string Description { get; set; } = "bruh, you so strong that opening a gate is nothing but a joke";

    protected override void SubscribeEvents()
    {
      Exiled.Events.Handlers.Player.InteractingDoor += OninteractingDoors;
      base.SubscribeEvents();
    }

    protected override void UnsubscribeEvents()
    {
      Exiled.Events.Handlers.Player.InteractingDoor -= OninteractingDoors;
      base.UnsubscribeEvents();
    }

    private void OninteractingDoors(InteractingDoorEventArgs ev)
    {
      if (!Check(ev.Player) || !ev.Door.IsGate)
        return;
    }
  }
}
