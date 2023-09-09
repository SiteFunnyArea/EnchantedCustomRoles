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
    public override string Name { get; set; } = "Kamikaze";

    public override string Description { get; set; } = "When you die, your corpse will explode";

    protected override void SubscribeEvents()
    {
      Exiled.Events.Handlers.Player.Dying += OnDying;
      base.SubscribeEvents();
    }

    protected override void UnsubscribeEvents()
    {
      Exiled.Events.Handlers.Player.Dying -= OnDying;
      base.UnsubscribeEvents();
    }

    private void OnDying(DyingEventArgs ev)
    {
      if (Main.Instance.PlayersWithRebirthNotUsed.Contains(ev.Player) || !Check(ev.Player))
        return;
      ExplosionGrenadeProjectile x = ((ExplosiveGrenade) Exiled.API.Features.Items.Item.Create((ItemType) 25)).SpawnActive(ev.Player.Position, ev.Player);
      Timing.CallDelayed(0.1f, () => x.Explode());
    }
  }
}
