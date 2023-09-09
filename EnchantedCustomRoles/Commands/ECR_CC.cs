// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Commands.ECR_CC
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using CommandSystem;
using EnchantedCustomRoles.Commands.CC;
using System;

namespace EnchantedCustomRoles.Commands
{
  [CommandHandler(typeof (ClientCommandHandler))]
  public class ECR_CC : ParentCommand
  {
    public override string Command { get; } = "EnchantedAbility";

    public override string[] Aliases { get; } = new string[1]
    {
      "ea"
    };

    public override string Description { get; } = "all the commands of the Enchanted Custom Roles plugin";

    public ECR_CC() => ((CommandHandler) this).LoadGeneratedCommands();

    public override void LoadGeneratedCommands() => ((CommandHandler) this).RegisterCommand((ICommand) new UseAbility());

    protected override bool ExecuteParent(
      ArraySegment<string> arguments,
      ICommandSender sender,
      out string response)
    {
      response = "Invalid SubCommand! Available subcommands: UseAbility (ea) [ability name]";
      return false;
    }
  }
}
