// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Handlers.AbilitiesManager
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using EnchantedCustomRoles.Ability;
using Exiled.CustomRoles.API;
using Exiled.CustomRoles.API.Features;
using System.Collections.Generic;

namespace EnchantedCustomRoles.Handlers
{
  public class AbilitiesManager
  {
    public void RegisterAbilities(bool register)
    {
      List<CustomAbility> customAbilityList = new List<CustomAbility>()
      {
        (CustomAbility) new CannotPickup(),
        (CustomAbility) new HealOnKill(),
        (CustomAbility) new Immortal(),
        (CustomAbility) new Kamikaze(),
        (CustomAbility) new PryGate(),
        (CustomAbility) new RebirthOnDeath()
      };
      if (register)
      {
        foreach (CustomAbility customAbility in customAbilityList)
          Extensions.Register(customAbility);
      }
      else
      {
        foreach (CustomAbility customAbility in customAbilityList)
          Extensions.Unregister(customAbility);
      }
    }
  }
}
