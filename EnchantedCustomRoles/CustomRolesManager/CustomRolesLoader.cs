// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.CustomRolesManager.CustomRolesLoader
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using Exiled.API.Features;
using System;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;

namespace EnchantedCustomRoles.CustomRolesManager
{
  public class CustomRolesLoader
  {
    public void LoadCustomRoles()
    {
      foreach (string file in Directory.GetFiles(Paths.Configs + "\\" + Main.Instance.Config.CustomRolesFolderName, "*.Yaml"))
      {
        try
        {
          string str = File.ReadAllText(file);
          CustomRolesClass customRolesClass = new DeserializerBuilder().Build().Deserialize<CustomRolesClass>(str);
          CustomRolesClass CustomRoleToRegister = new CustomRolesClass()
          {
            Name = customRolesClass.Name,
            Description = customRolesClass.Description,
            Id = customRolesClass.Id,
            RoleBeforeAssignation = customRolesClass.RoleBeforeAssignation,
            RoleAfterAssignation = customRolesClass.RoleAfterAssignation,
            CustomInfo = customRolesClass.CustomInfo,
            SpawnChance = customRolesClass.SpawnChance / 100.0,
            SpawnLimit = customRolesClass.SpawnLimit,
            Scale = customRolesClass.Scale,
            Inventory = customRolesClass.Inventory,
            Ammo = customRolesClass.Ammo,
            MaxHealth = customRolesClass.MaxHealth,
            BroadCast = customRolesClass.BroadCast,
            Rank = customRolesClass.Rank,
            RoleSpecialProperties = customRolesClass.RoleSpecialProperties,
            Abilities = customRolesClass.Abilities
          };
          if (Main.Instance.CustomRoles.Any<CustomRolesClass>((Func<CustomRolesClass, bool>) (role => (int) role.Id == (int) CustomRoleToRegister.Id)))
          {
            Log.Error(string.Format("{0} has tried to registerd with the id {1} that is already used! The role will not be loaded!", (object) CustomRoleToRegister.Name, (object) CustomRoleToRegister.Id));
          }
          else
          {
            Main.Instance.CustomRoles.Add(CustomRoleToRegister);
            Main.Instance.CustomRolesAssignementCount.Add(customRolesClass.Id, 0);
            Log.Warn(string.Format("Custom Role dectected, Name: {0}, Id: {1}, Abilities count: {2}", (object) customRolesClass.Name, (object) customRolesClass.Id, (object) customRolesClass.Abilities.Count));
          }
        }
        catch (Exception ex)
        {
          Log.Error(string.Format("There is something wrong with the file {0}\n{1}", (object) file, (object) ex));
        }
      }
    }
  }
}
