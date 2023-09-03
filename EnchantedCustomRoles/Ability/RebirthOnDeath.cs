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
    public virtual string Name { get; set; } = "Rebirth";

    public virtual string Description { get; set; } = "In case you die you can resurrect (once per life) and you will get half of your max life";

    protected virtual void SubscribeEvents()
    {
      Exiled.Events.Handlers.Player.Dying += new Exiled.Events.Events.CustomEventHandler<DyingEventArgs>(this.OnDeath);
      ((CustomAbility) this).SubscribeEvents();
    }

    protected virtual void UnsubscribeEvents()
    {
      Exiled.Events.Handlers.Player.Dying -= new Exiled.Events.Events.CustomEventHandler<DyingEventArgs>(this.OnDeath);
      ((CustomAbility) this).UnsubscribeEvents();
    }

    protected virtual void AbilityAdded(Exiled.API.Features.Player player)
    {
      Main.Instance.PlayersWithRebirthNotUsed.Add(player);
      ((CustomAbility) this).AbilityAdded(player);
    }

    protected virtual void AbilityRemoved(Exiled.API.Features.Player player)
    {
      Main.Instance.PlayersWithRebirthNotUsed.Remove(player);
      ((CustomAbility) this).AbilityRemoved(player);
    }

    private void OnDeath(DyingEventArgs ev)
    {
      if (!((CustomAbility) this).Check(ev.Player))
        return;
      ev.IsAllowed = false;
      ev.Player.Health = ev.Player.MaxHealth / 2f;
      ev.Player.Broadcast((ushort) 5, "<size=60></color=yellow>you died and used your rebirth ability</color>, <color=red>however you won't get another extra life</color></size>", (Broadcast.BroadcastFlags) 0);
      ((CustomAbility) this).RemoveAbility(ev.Player);
    }
  }
}
