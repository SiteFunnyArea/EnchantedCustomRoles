// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Commands.RA.GiveRole
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using CommandSystem;
using EnchantedCustomRoles.CustomRolesManager;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnchantedCustomRoles.Commands.RA
{
  public class GiveRole : ICommand
  {
    public string Command { get; } = nameof (GiveRole);

    public string[] Aliases { get; } = new string[1]{ "gr" };

    public string Description { get; } = "gave to yourself the specified role(if it exist)";

    public bool Execute(ArraySegment<string> args, ICommandSender sender, out string response)
    {
      Player player1 = Player.Get(sender);
      if (Main.Instance.CustomRoles.Count < 1)
      {
        response = "There are no custom roles registered!";
        return false;
      }
      if (args.Count < 1)
      {
        response = "please specify the role you want to assign to yourself";
        return false;
      }
      try
      {
        if (!Main.Instance.CustomRoles.Any<CustomRolesClass>((Func<CustomRolesClass, bool>) (role => (int) role.Id == (int) uint.Parse(args.Array[2]))))
        {
          response = "The customrole requested is non existent";
          return false;
        }
      }
      catch
      {
        response = "please specify the Id of the role you want to request!";
        return false;
      }
      if (args.Count < 2)
      {
        if (player1 == null)
        {
          response = "Please specify the player you want to give this ability to";
          return false;
        }
        List<CustomRolesClass> customRolesClassList = new List<CustomRolesClass>();
        foreach (CustomRolesClass customRolesClass in Main.Instance.PlayerCustomRoles[player1])
          customRolesClassList.Add(customRolesClass);
        foreach (CustomRolesClass customRolesClass in customRolesClassList)
          customRolesClass.RemoveCustomRole(player1);
        Main.Instance.CustomRoles.Find((Predicate<CustomRolesClass>) (role => (int) role.Id == (int) uint.Parse(args.Array[2]))).AddCustomRole(player1);
        response = "Done!";
        return true;
      }
      int result;
      if (int.TryParse(args.Array[3], out result))
      {
        if (Player.TryGet(result, out Player _))
        {
          Player player2 = Player.Get(result);
          List<CustomRolesClass> customRolesClassList = new List<CustomRolesClass>();
          foreach (CustomRolesClass customRolesClass in Main.Instance.PlayerCustomRoles[player2])
            customRolesClassList.Add(customRolesClass);
          foreach (CustomRolesClass customRolesClass in customRolesClassList)
            customRolesClass.RemoveCustomRole(player2);
          CustomRolesClass customRolesClass1 = Main.Instance.CustomRoles.Find((Predicate<CustomRolesClass>) (role => (int) role.Id == (int) uint.Parse(args.Array[2])));
          customRolesClass1.AddCustomRole(player2);
          response = "The " + customRolesClass1.Name + " role has been given to " + player2.Nickname + "!";
          return true;
        }
        response = "Please specify a valid player";
        return false;
      }
      response = "Please specify a valid player!";
      return false;
    }
  }
}
