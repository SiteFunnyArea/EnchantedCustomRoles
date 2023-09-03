// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Classes.Rank
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using System.ComponentModel;

namespace EnchantedCustomRoles.Classes
{
  public class Rank
  {
    [Description("The name of the rank")]
    public string Name { get; set; }

    [Description("The color of the rank")]
    public string Color { get; set; }

    [Description("set if the rank should be showed")]
    public bool ShowRank { get; set; }

    public Rank()
      : this(string.Empty, string.Empty, false)
    {
    }

    public Rank(string name, string color, bool show)
    {
      this.Name = name;
      this.Color = color;
      this.ShowRank = show;
    }

    public Rank(string name, bool show)
    {
      this.Name = name;
      this.Color = (string) null;
      this.ShowRank = show;
    }

    public Rank(string name)
    {
      this.Name = name;
      this.Color = (string) null;
      this.ShowRank = true;
    }

    public override string ToString() => string.Format("({0}) {1} {2}", (object) this.Name, (object) this.Color, (object) this.ShowRank);
  }
}
