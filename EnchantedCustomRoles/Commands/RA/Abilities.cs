// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Commands.RA.Abilities
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using CommandSystem;
using Exiled.API.Features.Pools;
using Exiled.CustomRoles.API.Features;
using System;
using System.Text;

namespace EnchantedCustomRoles.Commands.RA
{
  public class Abilities : ICommand
  {
    public string Command { get; } = "abilities";

    public string[] Aliases { get; } = new string[1]{ "a" };

    public string Description { get; } = "Obtain a list of all the abilities";

    public bool Execute(ArraySegment<string> args, ICommandSender sender, out string response)
    {
      if (CustomAbility.Registered.Count < 1)
      {
        response = "There are no custom abilities registered!";
        return false;
      }
      int num = 0;
      StringBuilder stringBuilder = StringBuilderPool.Pool.Get();
      stringBuilder.AppendLine(string.Format("Custom abilities registered number: {0}", (object) CustomAbility.Registered.Count));
      stringBuilder.AppendLine("abilities:");
      foreach (CustomAbility customAbility in CustomAbility.Registered)
        stringBuilder.AppendLine(string.Format("{0} - name: {1} - Description: {2}", (object) ++num, (object) customAbility.Name, (object) customAbility.Description));
      response = stringBuilder.ToString();
      return true;
    }
  }
}
