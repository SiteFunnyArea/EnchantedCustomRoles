// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Configs.PluginConfigs
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using Exiled.API.Interfaces;
using System.ComponentModel;

namespace EnchantedCustomRoles.Configs
{
  public class PluginConfigs : IConfig
  {
    [Description("Do you want to enable this plugin?")]
    public bool IsEnabled { get; set; } = true;

    [Description("Do you want to enable the debug logs?")]
    public bool Debug { get; set; } = false;

    [Description("What Name should the CustomRoles folder have?")]
    public string CustomRolesFolderName { get; set; } = "EnchantedCustomRoles";

    [Description("Should the plugin handle automatically the spawns of the players as customroles (true if you want the plugin to handle everything, or false if you want to enable your method to spawn the customroles)")]
    public bool ShouldThePluginSpawnCustomRolesAutomatically { get; set; } = true;

    [Description("Should the customroles show their rank?")]
    public bool ShouldCustomRolesShowTheirRank { get; set; } = false;
  }
}
