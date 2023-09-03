// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Events.EffectGiven
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using Exiled.API.Enums;
using Exiled.Events.EventArgs.Player;
using System;
using System.Linq;

namespace EnchantedCustomRoles.Events
{
  public class EffectGiven
  {
    public void GivenEffect(ReceivingEffectEventArgs ev)
    {
      if (!Main.Instance.PlayerCustomRoles.ContainsKey(ev.Player) || !Main.Instance.PlayerCustomAbilities.ContainsKey(ev.Player) || !Main.Instance.IgnorePlayerRoleChange.ContainsKey(ev.Player) || !Main.Instance.PlayerEffectsImmunity.ContainsKey(ev.Player) || !Main.Instance.PlayerEffectsImmunity[ev.Player].Any<EffectType>((Func<EffectType, bool>) (effect => (UnityEngine.Object) ev.Player.GetEffect(effect) == (UnityEngine.Object) ev.Effect)))
        return;
      ev.IsAllowed = false;
    }
  }
}
