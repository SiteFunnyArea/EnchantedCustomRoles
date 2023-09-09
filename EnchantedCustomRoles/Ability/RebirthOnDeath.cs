// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Ability.RebirthOnDeath
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;

namespace EnchantedCustomRoles.Ability
{
  internal class RebirthOnDeath : PassiveAbility
  {
    public override string Name { get; set; } = "Rebirth";

    public override string Description { get; set; } = "In case you die you can resurrect (once per life) and you will get half of your max life";

    protected override void SubscribeEvents()
    {
            Exiled.Events.Handlers.Player.Dying += OnDeath;
      base.SubscribeEvents();
    }

    protected override void UnsubscribeEvents()
    {
      Exiled.Events.Handlers.Player.Dying -= OnDeath;
            base.UnsubscribeEvents();
    }

    protected override void AbilityAdded(Exiled.API.Features.Player player)
    {
      Main.Instance.PlayersWithRebirthNotUsed.Add(player);
      base.AbilityAdded(player);
    }

    protected override void AbilityRemoved(Exiled.API.Features.Player player)
    {
      Main.Instance.PlayersWithRebirthNotUsed.Remove(player);
      base.AbilityRemoved(player);
    }

    private void OnDeath(DyingEventArgs ev)
    {
      if (Check(ev.Player))
        return;
      ev.IsAllowed = false;
      ev.Player.Health = ev.Player.MaxHealth / 2f;
      ev.Player.Broadcast((ushort) 5, "<size=60></color=yellow>you died and used your rebirth ability</color>, <color=red>however you won't get another extra life</color></size>", (Broadcast.BroadcastFlags) 0);
      ((CustomAbility) this).RemoveAbility(ev.Player);
    }
  }
}
