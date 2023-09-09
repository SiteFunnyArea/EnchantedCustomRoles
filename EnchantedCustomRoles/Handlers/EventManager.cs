// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Handlers.EventManager
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using EnchantedCustomRoles.CustomRolesManager;
using EnchantedCustomRoles.Events;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using System.Collections.Generic;

namespace EnchantedCustomRoles.Handlers
{
  internal class EventManager
  {
    private VerifiedPlayer PlayerVerified;
    private OnSpawned SpawnHandler;
    private EffectGiven PlayerReceivingEffect;
    private OnLeft PlayerLeft;

    public void EventLoader(bool IsEnabled)
    {
      if (IsEnabled)
      {
        Main.Instance = new Main();
        this.PlayerVerified = new VerifiedPlayer();
        this.SpawnHandler = new OnSpawned();
        this.PlayerReceivingEffect = new EffectGiven();
        this.PlayerLeft = new OnLeft();
        Exiled.Events.Handlers.Player.Verified += PlayerVerified.OnPlayerVerified;
        Exiled.Events.Handlers.Player.Spawned += SpawnHandler.OnSpawn;
        Exiled.Events.Handlers.Player.ReceivingEffect += PlayerReceivingEffect.GivenEffect;
        Exiled.Events.Handlers.Player.Left += PlayerLeft.OnPlayerLeft;
        CheckPlayers();
        Log.Info("Events loaded correctly!");
      }
      else
      {
        Exiled.Events.Handlers.Player.Left -= PlayerLeft.OnPlayerLeft;
        Exiled.Events.Handlers.Player.ReceivingEffect -= PlayerReceivingEffect.GivenEffect;
        Exiled.Events.Handlers.Player.Spawned -= SpawnHandler.OnSpawn;
        Exiled.Events.Handlers.Player.Verified -= PlayerVerified.OnPlayerVerified;
        this.PlayerLeft = (OnLeft) null;
        this.PlayerReceivingEffect = (EffectGiven) null;
        this.SpawnHandler = (OnSpawned) null;
        this.PlayerVerified = (VerifiedPlayer) null;
        Main.Instance = (Main) null;
        Log.Info("Events unloaded correctly!");
      }

      static void CheckPlayers()
      {
        foreach (Exiled.API.Features.Player key in Exiled.API.Features.Player.List)
        {
          if (!Main.Instance.PlayerCustomRoles.ContainsKey(key))
            Main.Instance.PlayerCustomRoles.Add(key, new List<CustomRolesClass>());
          if (!Main.Instance.PlayerCustomAbilities.ContainsKey(key))
            Main.Instance.PlayerCustomAbilities.Add(key, new List<CustomAbility>());
          if (!Main.Instance.IgnorePlayerRoleChange.ContainsKey(key))
            Main.Instance.IgnorePlayerRoleChange.Add(key, false);
          if (!Main.Instance.PlayerEffectsImmunity.ContainsKey(key))
            Main.Instance.PlayerEffectsImmunity.Add(key, new List<EffectType>());
        }
      }
    }
  }
}
