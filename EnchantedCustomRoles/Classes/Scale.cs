// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Classes.Scale
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

namespace EnchantedCustomRoles.Classes
{
  public class Scale
  {
    public float X { get; set; }

    public float Y { get; set; }

    public float Z { get; set; }

    public Scale()
      : this(1f, 1f, 1f)
    {
    }

    public Scale(float x, float y, float z)
    {
      this.X = x;
      this.Y = y;
      this.Z = z;
    }
  }
}
