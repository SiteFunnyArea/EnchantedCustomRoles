// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Commands.RA.GiveAbility
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Features.Pools;
using Exiled.CustomRoles.API.Features;
using System;
using System.Linq;
using System.Text;

namespace EnchantedCustomRoles.Commands.RA
{
  public class GiveAbility : ICommand
  {
    public string Command { get; } = nameof (GiveAbility);

    public string[] Aliases { get; } = new string[1]{ "ga" };

    public string Description { get; } = "gave to yourself the specified ability(if it exist)";

    public bool Execute(ArraySegment<string> args, ICommandSender sender, out string response)
    {
      Player key1 = Player.Get(sender);
      if (args.Count < 1)
      {
        response = "Please specify the ability to be given";
        return false;
      }
      if (CustomAbility.Registered.Count < 1)
      {
        response = "There are no customabilities registered in this server!";
        return false;
      }
      if (!CustomAbility.Registered.Any<CustomAbility>((Func<CustomAbility, bool>) (ability => ability.Name.ToLower() == args.Array[2].ToLower())))
      {
        response = "This ability does not exist!";
        return false;
      }
      CustomAbility customAbility1 = CustomAbility.Registered.ToList<CustomAbility>().Find((Predicate<CustomAbility>) (ability => ability.Name.ToLower() == args.Array[2].ToLower()));
      if (args.Count < 2)
      {
        if (key1 == null)
        {
          response = "Please specify the player you want to give this ability to";
          return false;
        }
        if (Main.Instance.PlayerCustomAbilities[key1].Contains(customAbility1))
        {
          response = "You already have this ability!";
          return false;
        }
        customAbility1.AddAbility(key1);
        Main.Instance.PlayerCustomAbilities[key1].Add(customAbility1);
        key1.ShowHint("An ability as been added to you!");
        int num = 0;
        StringBuilder stringBuilder = StringBuilderPool.Pool.Get();
        stringBuilder.AppendLine(string.Empty);
        stringBuilder.AppendLine(string.Format("You got {0} abilites:", (object) Main.Instance.PlayerCustomAbilities[key1].Count));
        foreach (CustomAbility customAbility2 in Main.Instance.PlayerCustomAbilities[key1])
          stringBuilder.AppendLine(string.Format("{0} - Name: {1} - Description: {2}", (object) ++num, (object) customAbility2.Name, (object) customAbility2.Description));
        key1.SendConsoleMessage(StringBuilderPool.Pool.ToStringReturn(stringBuilder), "green");
        response = "Done!";
        return true;
      }
      int result;
      if (int.TryParse(args.Array[3], out result))
      {
        Player key2 = Player.Get(result);
        if (key2 == null)
        {
          response = "Please specify a valid player!";
          return false;
        }
        if (Main.Instance.PlayerCustomAbilities[key2].Contains(customAbility1))
        {
          response = "This player already has this ability!";
          return false;
        }
        customAbility1.AddAbility(key2);
        Main.Instance.PlayerCustomAbilities[key2].Add(customAbility1);
        key2.ShowHint("An ability as been added to you, go to check the client console!");
        int num = 0;
        StringBuilder stringBuilder = StringBuilderPool.Pool.Get();
        stringBuilder.AppendLine(string.Empty);
        stringBuilder.AppendLine(string.Format("You currently {0} abilites:", (object) Main.Instance.PlayerCustomAbilities[key2].Count));
        foreach (CustomAbility customAbility3 in Main.Instance.PlayerCustomAbilities[key2])
          stringBuilder.AppendLine(string.Format("{0} - Name: {1} - Description: {2}", (object) ++num, (object) customAbility3.Name, (object) customAbility3.Description));
        key2.SendConsoleMessage(StringBuilderPool.Pool.ToStringReturn(stringBuilder), "green");
        response = "Done!";
        return true;
      }
      response = "Please specify a valid player!";
      return false;
    }
  }
}
