// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Classes.RoleSpecialProperties
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using Exiled.API.Enums;
using System.Collections.Generic;

namespace EnchantedCustomRoles.Classes
{
  public class RoleSpecialProperties
  {
    public List<EffectType> EffectImmunity { get; set; }

    public int Speed { get; set; }

    public RoleSpecialProperties()
      : this(new List<EffectType>(), (byte) 0)
    {
    }

    public RoleSpecialProperties(List<EffectType> effectImmunity, byte speed)
    {
      this.EffectImmunity = effectImmunity;
      this.Speed = (int) (sbyte) speed;
    }
  }
}
