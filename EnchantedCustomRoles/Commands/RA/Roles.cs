// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Commands.RA.Roles
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using CommandSystem;
using EnchantedCustomRoles.CustomRolesManager;
using Exiled.API.Features.Pools;
using System;
using System.Text;

namespace EnchantedCustomRoles.Commands.RA
{
  public class Roles : ICommand
  {
    public string Command { get; } = "roles";

    public string[] Aliases { get; } = new string[1]{ "r" };

    public string Description { get; } = "Obtain a list of all the custom roles registered by " + Main.Instance.Name + " plugin";

    public bool Execute(ArraySegment<string> args, ICommandSender sender, out string response)
    {
      if (Main.Instance.CustomRoles.Count < 1)
      {
        response = "There are no custom roles registered!";
        return false;
      }
      StringBuilder stringBuilder = StringBuilderPool.Pool.Get();
      stringBuilder.AppendLine(string.Format("[Custom Roles registered number ({0})]", (object) Main.Instance.CustomRoles.Count));
      foreach (CustomRolesClass customRole in Main.Instance.CustomRoles)
        stringBuilder.AppendLine(string.Format("[{0}. {1}, {2}%]", (object) customRole.Id, (object) customRole.Name, (object) (customRole.SpawnChance * 100.0)));
      response = stringBuilder.ToString();
      return true;
    }
  }
}
