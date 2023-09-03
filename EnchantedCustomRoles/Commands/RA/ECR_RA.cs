// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Commands.RA.ECR_RA
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using CommandSystem;
using System;

namespace EnchantedCustomRoles.Commands.RA
{
  [CommandHandler(typeof (RemoteAdminCommandHandler))]
  [CommandHandler(typeof (GameConsoleCommandHandler))]
  public class ECR_RA : ParentCommand
  {
    public virtual string Command { get; } = "EnchantedCustomRoles";

    public virtual string[] Aliases { get; } = new string[1]
    {
      "ecr"
    };

    public virtual string Description { get; } = "all the commands of the Enchanted Custom Roles plugin, use: ecr [subcommand]";

    public ECR_RA() => ((CommandHandler) this).LoadGeneratedCommands();

    public virtual void LoadGeneratedCommands()
    {
      ((CommandHandler) this).RegisterCommand((ICommand) new Roles());
      ((CommandHandler) this).RegisterCommand((ICommand) new Abilities());
      ((CommandHandler) this).RegisterCommand((ICommand) new GiveRole());
      ((CommandHandler) this).RegisterCommand((ICommand) new GiveAbility());
    }

    protected virtual bool ExecuteParent(
      ArraySegment<string> arguments,
      ICommandSender sender,
      out string response)
    {
      response = "Invalid SubCommand! available SubCommands: roles (r), abilities (a), giveRole (gr) [roleId] (player), GiveAbility (ga) [ability name] (player)";
      return false;
    }
  }
}
