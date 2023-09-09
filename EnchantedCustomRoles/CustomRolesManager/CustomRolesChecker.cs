// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.CustomRolesManager.CustomRolesChecker
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using EnchantedCustomRoles.Classes;
using Exiled.API.Enums;
using Exiled.API.Features;
using PlayerRoles;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;

namespace EnchantedCustomRoles.CustomRolesManager
{
  public class CustomRolesChecker
  {
    public void CheckFolder()
    {
      string path = Paths.Configs + "/" + Main.Instance.Config.CustomRolesFolderName;
      if (Directory.Exists(path))
        return;
      Log.Warn("There is no folder called " + Main.Instance.Config.CustomRolesFolderName + " in " + Paths.Configs + ", I will create it . . .");
      Directory.CreateDirectory(path);
    }

    public void CheckFiles()
    {
      string str = Paths.Configs + "/" + Main.Instance.Config.CustomRolesFolderName;
      if (((IEnumerable<string>) Directory.GetFiles(str, "*.yml")).ToList<string>().Count > 0)
        return;
      Log.Warn("There are no Custom Roles at " + str + ", i will create one . . .");
      CustomRolesClass customRolesClass = new CustomRolesClass()
      {
        Name = "Janitor",
        Description = "Janitor, a simple janitor",
        Id = 200,
        RoleBeforeAssignation = (RoleTypeId) 1,
        RoleAfterAssignation = (RoleTypeId) 1,
        CustomInfo = "Janitor",
        SpawnChance = 100.0,
        SpawnLimit = 2,
        Scale = new Scale(1f, 1f, 1f),
        Inventory = {
          ((ItemType) 0).ToString(),
          ((ItemType) 15).ToString()
        },
        Ammo = {
          {
            AmmoType.Nato9,
            (ushort) 0
          },
          {
            AmmoType.Nato556,
            (ushort) 0
          },
          {
            AmmoType.Nato762,
            (ushort) 0
          },
          {
            AmmoType.Ammo12Gauge,
            (ushort) 0
          },
          {
            AmmoType.Ammo44Cal,
            (ushort) 0
          }
        },
        MaxHealth = 100,

        BroadCast = new Exiled.API.Features.Broadcast("<size=60><color=yellow>You are a Janitor</color></size>", 3, type: 0),
        Rank = new Rank("Null", "Null", false),
        RoleSpecialProperties = new RoleSpecialProperties(new List<EffectType>(), (byte) 1),
        Abilities = new List<string>()
      };
      string path2 = "ExampleCustomRole.yml";
      File.WriteAllText(Path.Combine(str, path2), new SerializerBuilder().Build().Serialize((object) customRolesClass));
    }
  }
}
