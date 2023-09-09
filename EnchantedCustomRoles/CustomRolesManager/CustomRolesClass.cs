// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.CustomRolesManager.CustomRolesClass
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using EnchantedCustomRoles.Classes;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Pools;
using Exiled.CustomItems.API.Features;
using Exiled.CustomRoles.API.Features;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EnchantedCustomRoles.CustomRolesManager
{
  public class CustomRolesClass
  {
    [System.ComponentModel.Description("Name of the custom role")]
    public string Name { get; set; }

    [System.ComponentModel.Description("Description of the customrole")]
    public string Description { get; set; }

    [System.ComponentModel.Description("Id of the custom role")]
    public uint Id { get; set; }

    [System.ComponentModel.Description("Role of the player you want to assign the customrole")]
    public RoleTypeId RoleBeforeAssignation { get; set; }

    [System.ComponentModel.Description("Role of the player when the customrole is assigned")]
    public RoleTypeId RoleAfterAssignation { get; set; }

    [System.ComponentModel.Description("What the other player will see")]
    public string CustomInfo { get; set; }

    [System.ComponentModel.Description("The chance of spawn")]
    public double SpawnChance { get; set; }

    [System.ComponentModel.Description("How many people can have this role at the same time")]
    public int SpawnLimit { get; set; }

    [System.ComponentModel.Description("The scale of the customrole")]
    public Scale Scale { get; set; }

    [System.ComponentModel.Description("The inventory of the customrole")]
    public List<string> Inventory { get; set; } = new List<string>();

    [System.ComponentModel.Description("The ammo that the player will receive")]
    public Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort>();

    [System.ComponentModel.Description("The health with this customrole will be spawned")]
    public int MaxHealth { get; set; }

    [System.ComponentModel.Description("The broadcast shown to the player if he has this customrole")]
    public Exiled.API.Features.Broadcast BroadCast { get; set; }

    [System.ComponentModel.Description("The rank that the player will receive, the color and if it will be showed")]
    public Rank Rank { get; set; }

    [System.ComponentModel.Description("Custom role properties")]
    public RoleSpecialProperties RoleSpecialProperties { get; set; }

    [System.ComponentModel.Description("The abilities that this customrole will have")]
    public List<string> Abilities { get; set; } = new List<string>();

    private string PreviousBadge { get; set; } = (string) null;

    private string PreviousBadgeColor { get; set; } = (string) null;

    private bool WasPlayerInHideTag { get; set; } = false;

    public void AddCustomRole(Player player)
    {
      Main.Instance.CustomRolesAssignementCount[this.Id]++;
      Main.Instance.PlayerCustomRoles[player].Add(this);
      Main.Instance.IgnorePlayerRoleChange[player] = true;
      player.Role.Set(this.RoleAfterAssignation, (RoleSpawnFlags) 0);
      this.AddInventory(player);
      this.AddAbilities(player);
      this.AddOtherThings(player);
      this.CheckPlayerProperties(player);
      this.ConsoleMessage(player);
      Log.Info(string.Format("{0} customrole is: [{1}, {2}]", (object) player.Nickname, (object) this.Name, (object) this.Id));
    }

    protected void AddInventory(Player player)
    {
      player.ClearInventory();
      player.Ammo.Clear();
      foreach (string str in this.Inventory)
      {
        ItemType result;
        if (Enum.TryParse<ItemType>(str, out result))
        {
          player.AddItem(result);
        }
        else
        {
          CustomItem customItem;
          if (!CustomItem.TryGet(str,out customItem))
            Log.Warn("The item " + str + " in the " + this.Name + " custom role inventory is not valid");
          else
                        customItem.Give(player, true);
        }
      }
      foreach (KeyValuePair<AmmoType, ushort> keyValuePair in this.Ammo)
        player.AddAmmo(keyValuePair.Key, keyValuePair.Value);
    }

    protected void AddAbilities(Player player)
    {
      if (this.Abilities.Count == 0)
        return;
      foreach (string ability1 in this.Abilities)
      {
        string ability = ability1;
        if (!CustomAbility.Registered.Any<CustomAbility>((Func<CustomAbility, bool>) (customability => customability.Name.ToLower() == ability.ToLower())))
        {
          Log.Error(ability + " ability does not exist!");
        }
        else
        {
          CustomAbility customAbility = CustomAbility.Registered.ToList<CustomAbility>().Find((Predicate<CustomAbility>) (customability => customability.Name.ToLower() == ability.ToLower()));
          customAbility.AddAbility(player);
          Main.Instance.PlayerCustomAbilities[player].Add(customAbility);
        }
      }
    }

    protected void AddOtherThings(Player player)
    {
      player.CustomInfo = this.CustomInfo;
      player.MaxHealth = (float) this.MaxHealth;
      player.Scale = new Vector3(this.Scale.X, this.Scale.Y, this.Scale.Z);
      player.Broadcast(this.BroadCast, true);
      player.ShowHint(this.Description, 5f);
      if (!Main.Instance.Config.ShouldCustomRolesShowTheirRank || !this.Rank.ShowRank)
        return;
      this.PreviousBadge = player.RankName;
      this.PreviousBadgeColor = player.RankColor;
      this.WasPlayerInHideTag = player.BadgeHidden;
      player.RankColor = this.Rank.Color;
      player.RankName = this.Rank.Name;
    }

    protected void CheckPlayerProperties(Player player)
    {
      foreach (EffectType effectType in this.RoleSpecialProperties.EffectImmunity)
        Main.Instance.PlayerEffectsImmunity[player].Add(effectType);
      if (this.RoleSpecialProperties.Speed > 0)
        player.GetEffect(EffectType.MovementBoost).Intensity = (byte) this.RoleSpecialProperties.Speed;
      else
        player.GetEffect(EffectType.Disabled).Intensity = (byte) -this.RoleSpecialProperties.Speed;
    }

    protected void ConsoleMessage(Player player)
    {
      int num = 0;
      StringBuilder stringBuilder = StringBuilderPool.Pool.Get();
      stringBuilder.AppendLine(string.Empty);
      stringBuilder.AppendLine(string.Format("CustomRole found - Name: {0}, Id: {1}, Abilities: {2}", (object) this.Name, (object) this.Id, (object) this.Abilities.Count));
      if (this.Abilities.Count < 1)
      {
        stringBuilder.AppendLine("You don't have any customability");
        player.SendConsoleMessage(StringBuilderPool.Pool.ToStringReturn(stringBuilder), "green");
      }
      else
      {
        stringBuilder.AppendLine("Your actual abilties that you can use are:");
        foreach (string ability1 in this.Abilities)
        {
          string ability = ability1;
          if (CustomAbility.Registered.Any<CustomAbility>((Func<CustomAbility, bool>) (ca => ca.Name.ToLower() == ability.ToLower())))
          {
            CustomAbility customAbility = CustomAbility.Registered.ToList<CustomAbility>().Find((Predicate<CustomAbility>) (customability => customability.Name.ToLower() == ability.ToLower()));
            stringBuilder.AppendLine(string.Format("{0} - {1} - {2}", (object) ++num, (object) customAbility.Name, (object) customAbility.Description));
          }
        }
        stringBuilder.AppendLine("you can use the abilities (if the ability is not passive type) by .ea [ability name]");
        player.SendConsoleMessage(StringBuilderPool.Pool.ToStringReturn(stringBuilder), "green");
      }
    }

    public void RemoveCustomRole(Player player)
    {
      Main.Instance.CustomRolesAssignementCount[this.Id]--;
      Main.Instance.PlayerCustomRoles[player].Remove(this);
      this.RemoveOtherThings(player);
      this.RemoveAbilities(player);
      Log.Info(this.Name + " custom role has been removed from " + player.Nickname);
    }

    protected void RemoveOtherThings(Player player)
    {
      player.CustomInfo = string.Empty;
      player.Scale = Vector3.one;
      player.BadgeHidden = false;
      if (!Main.Instance.Config.ShouldCustomRolesShowTheirRank || !this.Rank.ShowRank)
        return;
      player.RankColor = this.PreviousBadgeColor;
      player.RankName = this.PreviousBadge;
      player.BadgeHidden = this.WasPlayerInHideTag;
    }

    protected void RemoveAbilities(Player player)
    {
      if (this.Abilities.Count == 0)
        return;
      foreach (string ability1 in this.Abilities)
      {
        string ability = ability1;
        if (!CustomAbility.Registered.Any<CustomAbility>((Func<CustomAbility, bool>) (customability => customability.Name.ToLower() == ability.ToLower())))
        {
          Log.Error(ability + " ability does not exist!");
        }
        else
        {
          CustomAbility customAbility = CustomAbility.Registered.ToList<CustomAbility>().Find((Predicate<CustomAbility>) (customability => customability.Name.ToLower() == ability.ToLower()));
          customAbility.AddAbility(player);
          Main.Instance.PlayerCustomAbilities[player].Add(customAbility);
        }
      }
    }
  }
}
