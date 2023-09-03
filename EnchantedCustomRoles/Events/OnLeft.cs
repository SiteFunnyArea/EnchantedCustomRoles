// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Events.OnLeft
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using EnchantedCustomRoles.CustomRolesManager;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using System.Collections.Generic;

namespace EnchantedCustomRoles.Events
{
  public class OnLeft
  {
    public void OnPlayerLeft(LeftEventArgs ev)
    {
      if (Main.Instance.PlayerCustomRoles.ContainsKey(ev.Player))
      {
        List<CustomRolesClass> customRolesClassList = new List<CustomRolesClass>();
        foreach (CustomRolesClass customRolesClass in Main.Instance.PlayerCustomRoles[ev.Player])
          customRolesClassList.Add(customRolesClass);
        foreach (CustomRolesClass customRolesClass in customRolesClassList)
          customRolesClass.RemoveCustomRole(ev.Player);
        Main.Instance.PlayerCustomRoles.Remove(ev.Player);
      }
      if (Main.Instance.PlayerCustomAbilities.ContainsKey(ev.Player))
      {
        List<CustomAbility> customAbilityList = new List<CustomAbility>();
        foreach (CustomAbility customAbility in Main.Instance.PlayerCustomAbilities[ev.Player])
          customAbilityList.Add(customAbility);
        foreach (CustomAbility customAbility in customAbilityList)
          customAbility.RemoveAbility(ev.Player);
        Main.Instance.PlayerCustomAbilities.Remove(ev.Player);
      }
      if (Main.Instance.IgnorePlayerRoleChange.ContainsKey(ev.Player))
        Main.Instance.IgnorePlayerRoleChange.Remove(ev.Player);
      if (!Main.Instance.PlayerEffectsImmunity.ContainsKey(ev.Player))
        return;
      Main.Instance.PlayerEffectsImmunity.Remove(ev.Player);
    }
  }
}
