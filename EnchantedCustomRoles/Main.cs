// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Main
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using EnchantedCustomRoles.Configs;
using EnchantedCustomRoles.CustomRolesManager;
using EnchantedCustomRoles.Handlers;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using System;
using System.Collections.Generic;

namespace EnchantedCustomRoles
{
  public class Main : Plugin<PluginConfigs>
  {
    private EventManager? eventManager;
    private AbilitiesManager? abilitiesManager;
    private RoleManager? roleManager;
    public List<CustomRolesClass> CustomRoles = new List<CustomRolesClass>();
    public Dictionary<uint, int> CustomRolesAssignementCount = new Dictionary<uint, int>();
    public Dictionary<Player, List<CustomRolesClass>> PlayerCustomRoles = new Dictionary<Player, List<CustomRolesClass>>();
    public Dictionary<Player, List<CustomAbility>> PlayerCustomAbilities = new Dictionary<Player, List<CustomAbility>>();
    public Dictionary<Player, bool> IgnorePlayerRoleChange = new Dictionary<Player, bool>();
    public Dictionary<Player, List<EffectType>> PlayerEffectsImmunity = new Dictionary<Player, List<EffectType>>();
    public List<Player> PlayersWithRebirthNotUsed = new List<Player>();

    public static Main Instance { get; internal set; }

    public override string Name => "Enchanted Custom Roles";

    public override string Author => "ThemysteriousGuy#8953";

    public override string Prefix => "EnchantedCustomRoles";

    public override Version Version => new Version(1, 6, 0);

    public override Version RequiredExiledVersion => new Version(6, 2, 0);

    public override PluginPriority Priority => PluginPriority.Default;

    public override void OnEnabled()
    {
      this.eventManager = new EventManager();
      this.abilitiesManager = new AbilitiesManager();
      this.roleManager = new RoleManager();
      this.eventManager.EventLoader(true);
      this.abilitiesManager.RegisterAbilities(true);
      this.roleManager.ManageCustomRoles(true);
      base.OnEnabled();
    }

    public override void OnDisabled()
    {
      this.roleManager.ManageCustomRoles(false);
      this.abilitiesManager.RegisterAbilities(false);
      this.eventManager.EventLoader(false);
      this.roleManager = null;
      this.abilitiesManager = null;
      this.eventManager = null;
      base.OnDisabled();
    }
  }
}
