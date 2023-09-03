// Decompiled with JetBrains decompiler
// Type: EnchantedCustomRoles.Handlers.RoleManager
// Assembly: EnchantedCustomRoles, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E9E43DB-320C-49E5-9A2C-3AE9959E9255
// Assembly location: C:\Users\Danie\Desktop\ecr\EnchantedCustomRoles.dll

using EnchantedCustomRoles.CustomRolesManager;
using Exiled.API.Features;

namespace EnchantedCustomRoles.Handlers
{
  internal class RoleManager
  {
    private CustomRolesChecker checker;
    private CustomRolesLoader loader;

    public void ManageCustomRoles(bool register)
    {
      if (register)
      {
        this.checker = new CustomRolesChecker();
        this.loader = new CustomRolesLoader();
        this.checker.CheckFolder();
        this.checker.CheckFiles();
        this.loader.LoadCustomRoles();
        Log.Info(string.Format("{0} custom roles loaded correctly!", (object) Main.Instance.CustomRoles.Count));
      }
      else
      {
        this.checker = (CustomRolesChecker) null;
        this.loader = (CustomRolesLoader) null;
        Log.Info("Custom roles loader disabled!");
      }
    }
  }
}
