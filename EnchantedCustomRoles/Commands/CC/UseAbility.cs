// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Commands.CC.UseAbility
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using CommandSystem;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using System;

namespace EnchantedCustomRoles.Commands.CC
{
  public class UseAbility : ICommand
  {
    public string Command { get; } = nameof (UseAbility);

    public string[] Aliases { get; } = new string[1]{ "ue" };

    public string Description { get; } = "Activate an ability from his name";

    public bool Execute(ArraySegment<string> args, ICommandSender sender, out string response)
    {
      Player key = Player.Get(sender);
      bool flag1 = false;
      CustomAbility customAbility1 = (CustomAbility) null;
      bool flag2 = false;
      if (args.Count < 1)
      {
        response = "please specify a ability to activate";
        return false;
      }
      if (Main.Instance.PlayerCustomAbilities[key].Count < 1)
      {
        response = "You do not have any ability!";
        return false;
      }
      foreach (CustomAbility customAbility2 in Main.Instance.PlayerCustomAbilities[key])
      {
        if (!(customAbility2.Name.ToLower() != args.Array[2].ToLower()))
        {
          flag2 = true;
          break;
        }
      }
      if (!flag2)
      {
        response = "You do not have this ability between you abilities!";
        return false;
      }
      foreach (CustomAbility customAbility3 in CustomAbility.Registered)
      {
        if (!(customAbility3.Name.ToLower() != args.Array[2].ToLower()))
        {
          flag1 = true;
          customAbility1 = customAbility3;
          break;
        }
      }
      if (!flag1)
      {
        response = "Ability not found, retry";
        return false;
      }
      if (customAbility1 is ActiveAbility activeAbility)
      {
        string str;
        if (!activeAbility.CanUseAbility(key, ref str))
        {
          response = str;
          return false;
        }
        activeAbility.UseAbility(key);
        response = "Ability " + ((CustomAbility) activeAbility).Name + " used.";
        return true;
      }
      response = "This ability is passive or unvalid!";
      return false;
    }
  }
}
