// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Events.OnSpawned
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using EnchantedCustomRoles.CustomRolesManager;
using Exiled.API.Enums;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;

namespace EnchantedCustomRoles.Events
{
  public class OnSpawned
  {
    public void OnSpawn(SpawnedEventArgs ev)
    {
      Random random = new Random();
      List<SpawnReason> spawnReasonList1 = new List<SpawnReason>()
      {
        SpawnReason.RoundStart,
        SpawnReason.LateJoin,
        SpawnReason.Respawn,
        SpawnReason.Revived,
        SpawnReason.Escaped
      };
      List<SpawnReason> spawnReasonList2 = new List<SpawnReason>()
      {
        SpawnReason.Died,
        SpawnReason.Destroyed,
        SpawnReason.None,
        SpawnReason.ForceClass
      };
      if (!Main.Instance.PlayerCustomRoles.ContainsKey(ev.Player) || !Main.Instance.PlayerCustomAbilities.ContainsKey(ev.Player) || !Main.Instance.IgnorePlayerRoleChange.ContainsKey(ev.Player) || !Main.Instance.PlayerEffectsImmunity.ContainsKey(ev.Player))
        return;
      if (spawnReasonList1.Contains(ev.Reason))
      {
        List<CustomRolesClass> customRolesClassList = new List<CustomRolesClass>();
        if (Main.Instance.PlayerCustomRoles[ev.Player].Count > 0)
          return;
        foreach (CustomRolesClass customRole in Main.Instance.CustomRoles)
        {
          if (customRole.RoleBeforeAssignation == ev.Player.Role.Type && Main.Instance.CustomRolesAssignementCount[customRole.Id] < customRole.SpawnLimit && customRole.SpawnChance != 0.0 && customRole.SpawnLimit != 0)
            customRolesClassList.Add(customRole);
        }
        if (customRolesClassList.Count < 1)
          return;
        double num1 = 0.0;
        foreach (CustomRolesClass customRolesClass in customRolesClassList)
          num1 += customRolesClass.SpawnChance;
        double num2 = random.NextDouble() * num1;
        foreach (CustomRolesClass customRolesClass in customRolesClassList)
        {
          if (num2 <= customRolesClass.SpawnChance / num1)
          {
            customRolesClass.AddCustomRole(ev.Player);
            break;
          }
          num2 -= customRolesClass.SpawnChance / num1;
        }
      }
      if (!spawnReasonList2.Contains(ev.Reason))
        return;
      List<CustomRolesClass> customRolesClassList1 = new List<CustomRolesClass>();
      List<CustomAbility> customAbilityList = new List<CustomAbility>();
      if (Main.Instance.IgnorePlayerRoleChange[ev.Player])
      {
        Main.Instance.IgnorePlayerRoleChange[ev.Player] = false;
      }
      else
      {
        foreach (CustomRolesClass customRolesClass in Main.Instance.PlayerCustomRoles[ev.Player])
          customRolesClassList1.Add(customRolesClass);
        foreach (CustomRolesClass customRolesClass in customRolesClassList1)
          customRolesClass.RemoveCustomRole(ev.Player);
        foreach (CustomAbility customAbility in Main.Instance.PlayerCustomAbilities[ev.Player])
          customAbilityList.Add(customAbility);
        foreach (CustomAbility customAbility in customAbilityList)
        {
          customAbility.RemoveAbility(ev.Player);
          Main.Instance.PlayerCustomAbilities[ev.Player].Remove(customAbility);
        }
      }
    }
  }
}
