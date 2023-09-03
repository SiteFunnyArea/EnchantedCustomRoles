// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Events.VerifiedPlayer
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using EnchantedCustomRoles.CustomRolesManager;
using Exiled.API.Enums;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using System.Collections.Generic;

namespace EnchantedCustomRoles.Events
{
  public class VerifiedPlayer
  {
    public void OnPlayerVerified(VerifiedEventArgs ev)
    {
      if (!Main.Instance.PlayerCustomRoles.ContainsKey(ev.Player))
        Main.Instance.PlayerCustomRoles.Add(ev.Player, new List<CustomRolesClass>());
      if (!Main.Instance.PlayerCustomAbilities.ContainsKey(ev.Player))
        Main.Instance.PlayerCustomAbilities.Add(ev.Player, new List<CustomAbility>());
      if (!Main.Instance.IgnorePlayerRoleChange.ContainsKey(ev.Player))
        Main.Instance.IgnorePlayerRoleChange.Add(ev.Player, false);
      if (Main.Instance.PlayerEffectsImmunity.ContainsKey(ev.Player))
        return;
      Main.Instance.PlayerEffectsImmunity.Add(ev.Player, new List<EffectType>());
    }
  }
}
