// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Ability.Kamikaze
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups.Projectiles;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using System;

namespace EnchantedCustomRoles.Ability
{
  internal class Kamikaze : PassiveAbility
  {
    public virtual string Name { get; set; } = nameof (Kamikaze);

    public virtual string Description { get; set; } = "When You Die your corpse will explode";

    protected virtual void SubscribeEvents()
    {
      Exiled.Events.Handlers.Player.Dying += new Exiled.Events.Events.CustomEventHandler<DyingEventArgs>(this.OnDying);
      ((CustomAbility) this).SubscribeEvents();
    }

    protected virtual void UnsubscribeEvents()
    {
      Exiled.Events.Handlers.Player.Dying -= new Exiled.Events.Events.CustomEventHandler<DyingEventArgs>(this.OnDying);
      ((CustomAbility) this).UnsubscribeEvents();
    }

    private void OnDying(DyingEventArgs ev)
    {
      if (Main.Instance.PlayersWithRebirthNotUsed.Contains(ev.Player) || !((CustomAbility) this).Check(ev.Player))
        return;
      ExplosionGrenadeProjectile x = ((ExplosiveGrenade) Exiled.API.Features.Items.Item.Create((ItemType) 25)).SpawnActive(ev.Player.Position, ev.Player);
      Timing.CallDelayed(0.1f, (Action) (() => x.Explode()));
    }
  }
}
