// Decompiled with JetBrains decompiler
// Type: UniBizBO.Composition.Resource.Icons
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using UniinfoNet;


#nullable enable
namespace UniBizBO.Composition.Resource
{
  public class Icons : BindableBase, IEnumerable<
  #nullable disable
  IconInfo>, IEnumerable
  {
    public static string DefaultMappingFileName = "_iconMapping.json";
    private string basePath;
    private string mappingFilePath;

    public static string DefaultAppBasePath => Path.GetDirectoryName(typeof (Icons).Assembly.Location);

    public static string DefaultIconBasePath => Path.Combine(Icons.DefaultAppBasePath, "Resource", "Icon");

    public static IEnumerable<PropertyInfo> IconInfoProps => ((IEnumerable<PropertyInfo>) typeof (Icons).GetProperties(BindingFlags.Instance | BindingFlags.Public)).Where<PropertyInfo>((Func<PropertyInfo, bool>) (it => it.PropertyType.Equals(typeof (IconInfo))));

    public static Icons Origin { get; protected set; } = new Icons();

    public static Icons Default { get; protected set; } = new Icons(true);

    [JsonIgnore]
    public string BasePath
    {
      get => this.basePath;
      private set
      {
        this.basePath = value;
        this.Changed(nameof (BasePath));
      }
    }

    private Icons()
    {
    }

    private Icons(bool isDesign)
    {
      if (isDesign)
        this.InitInDesigner("C:\\UniApp\\UniBizSM\\UniBizBO\\Composition\\Resource\\Icons.cs");
      else
        this.Init();
    }

    public Icons(string basePath) => this.Init(basePath);

    private void InitInDesigner([CallerFilePath] string path = "")
    {
      path = this.GetSolutionFolderPath(Path.GetDirectoryName(path));
      if (path == null)
        return;
      this.Init(Path.Combine(path, "AfterBuildCopy", "Resource", "Icon"), Path.Combine(path, Icons.DefaultMappingFileName));
    }

    public void Init(string basePath = null, string mappingFilePath = null)
    {
      if (basePath == null)
        basePath = Icons.DefaultIconBasePath;
      this.BasePath = basePath;
      this.mappingFilePath = mappingFilePath ?? Path.Combine(Icons.DefaultAppBasePath, Icons.DefaultMappingFileName);
      this.Clear();
      this.Load();
      this.Fill();
      this.Refresh();
      this.Save();
      this.Changed("");
    }

    private string GetSolutionFolderPath(string path)
    {
      path = Path.GetDirectoryName(path);
      if (path == null)
        return (string) null;
      DirectoryInfo directoryInfo = new DirectoryInfo(path);
      if (!directoryInfo.Exists)
        return (string) null;
      return ((IEnumerable<FileInfo>) directoryInfo.GetFiles()).Any<FileInfo>((Func<FileInfo, bool>) (it => string.Equals(it.Extension, ".sln", StringComparison.OrdinalIgnoreCase))) ? path : this.GetSolutionFolderPath(directoryInfo.Parent.FullName);
    }

    private void Clear()
    {
      foreach (PropertyInfo propertyInfo in Icons.IconInfoProps.Where<PropertyInfo>((Func<PropertyInfo, bool>) (it => it.CanWrite)))
        propertyInfo.SetValue((object) this, (object) null);
    }

    private void Load()
    {
      FileInfo fileInfo = new FileInfo(this.mappingFilePath);
      if (!fileInfo.Exists)
        return;
      string json = string.Empty;
      using (StreamReader streamReader = fileInfo.OpenText())
        json = streamReader.ReadToEnd();
      try
      {
        Dictionary<string, string> dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        foreach (PropertyInfo propertyInfo in Icons.IconInfoProps.Where<PropertyInfo>((Func<PropertyInfo, bool>) (it => it.CanWrite)))
        {
          string str;
          if (dictionary.TryGetValue(propertyInfo.Name, out str) && !string.IsNullOrWhiteSpace(str))
            propertyInfo.SetValue((object) this, (object) new IconInfo(this, str.Split('|')[0]));
        }
      }
      catch
      {
      }
    }

    private void Fill()
    {
      foreach (PropertyInfo propertyInfo in Icons.IconInfoProps.Where<PropertyInfo>((Func<PropertyInfo, bool>) (it => it.CanWrite)))
      {
        if (!(propertyInfo.GetValue((object) this) is IconInfo iconInfo) || string.IsNullOrWhiteSpace(iconInfo.Path))
          propertyInfo.SetValue((object) this, propertyInfo.GetValue((object) Icons.Origin));
      }
    }

    private void Save()
    {
      string a = JsonSerializer.Serialize<Dictionary<string, string>>(Icons.IconInfoProps.Where<PropertyInfo>((Func<PropertyInfo, bool>) (it => it.CanWrite)).ToDictionary<PropertyInfo, string, string>((Func<PropertyInfo, string>) (it => it.Name), (Func<PropertyInfo, string>) (it =>
      {
        string str = (it.GetValue((object) this) is IconInfo iconInfo2 ? iconInfo2.Path : (string) null) ?? "";
        if ((iconInfo2 != null ? (iconInfo2.IsExist ? 1 : 0) : 0) == 0)
          str += "|NotExist";
        return str;
      })), new JsonSerializerOptions()
      {
        WriteIndented = true
      });
      string mappingFilePath = this.mappingFilePath;
      string b = string.Empty;
      FileInfo fileInfo = new FileInfo(mappingFilePath);
      if (fileInfo.Exists)
      {
        using (StreamReader streamReader = fileInfo.OpenText())
          b = streamReader.ReadToEnd();
      }
      if (string.Equals(a, b))
        return;
      using (StreamWriter streamWriter = new StreamWriter(mappingFilePath, false, Encoding.UTF8))
        streamWriter.Write(a);
    }

    public void Refresh(string[] extensions = null)
    {
      if (extensions == null)
        extensions = IconInfo.DefaultExtensions;
      foreach (IconInfo immutable in this.ToImmutableArray<IconInfo>())
      {
        immutable.BaseGroup = this;
        immutable.Refresh(extensions);
      }
    }

    public async Task RefreshAsync(string[] extensions = null, CancellationToken? token = null)
    {
      Icons items = this;
      if (extensions == null)
        extensions = IconInfo.DefaultExtensions;
      ImmutableArray<IconInfo> iconInfos = items.ToImmutableArray<IconInfo>();
      await Task.Factory.StartNew((Action) (() =>
      {
        foreach (IconInfo iconInfo in iconInfos)
        {
          iconInfo.BaseGroup = this;
          iconInfo.Refresh(extensions);
        }
      }), token ?? CancellationToken.None);
    }

    public string ConvertToLocalFilePath(string path)
    {
      string pathext = Path.GetExtension(path);
      if (!((IEnumerable<string>) IconInfo.DefaultExtensions).Any<string>((Func<string, bool>) (it => string.Equals(pathext, it, StringComparison.OrdinalIgnoreCase))))
        path += ((IEnumerable<string>) IconInfo.DefaultExtensions).FirstOrDefault<string>();
      return Path.Combine(this.BasePath, path);
    }

    public string ConvertToLocalFilePathWithExist(string path)
    {
      path = this.ConvertToLocalFilePath(path);
      return !File.Exists(path) ? (string) null : path;
    }

    public IEnumerator<IconInfo> GetEnumerator() => Icons.IconInfoProps.Where<PropertyInfo>((Func<PropertyInfo, bool>) (it => it.CanRead)).Select<PropertyInfo, object>((Func<PropertyInfo, object>) (it => it.GetValue((object) this))).OfType<IconInfo>().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    public IconInfo App { get; set; }

    public IconInfo _None { get; set; } = (IconInfo) "";

    public IconInfo _NotFound { get; set; } = (IconInfo) "unused";

    public IconInfo QuickTool_Button_Menu { get; set; } = (IconInfo) "menu_btn";

    public IconInfo QuickTool_Button_Menu_Activated { get; set; } = (IconInfo) "menu_btn_active";

    public IconInfo QuickTool_Button_Whether { get; set; } = (IconInfo) "weather_btn";

    public IconInfo QuickTool_Button_Whether_Activated { get; set; } = (IconInfo) "weather_btn_active";

    public IconInfo QuickTool_Button_Notification { get; set; } = (IconInfo) "notice_btn";

    public IconInfo QuickTool_Button_Notification_Activated { get; set; } = (IconInfo) "notice_btn_active";

    public IconInfo QuickTool_Button_ScreenSetting { get; set; } = (IconInfo) "setting_btn";

    public IconInfo QuickTool_Button_ScreenSetting_Activated { get; set; } = (IconInfo) "setting_btn_active";

    public IconInfo QuickTool_Button_Lock { get; set; } = (IconInfo) "lock_btn";

    public IconInfo QuickTool_Button_Lock_Activated { get; set; } = (IconInfo) "lock_btn_active";

    public IconInfo BookMarkTool_Button_Setting { get; set; } = (IconInfo) "bookmark_setting";

    public IconInfo BookMarkTool_Button_Folder { get; set; } = (IconInfo) "folder";

    public IconInfo PageContainer_TabHeader_Button_Close { get; set; } = (IconInfo) "close_small";

    public IconInfo PageContainer_Tab_Button_Home { get; set; } = (IconInfo) "home";

    public IconInfo PageContainer_Tab_Button_Previous { get; set; } = (IconInfo) "bring_forward";

    public IconInfo PageContainer_Tab_Button_Next { get; set; } = (IconInfo) "send_backward";

    public IconInfo Page_TitleMenu_Button_Bookmark { get; set; } = (IconInfo) "bookmark";

    public IconInfo Page_TitleMenu_Button_New { get; set; } = (IconInfo) "new";

    public IconInfo Page_TitleMenu_Button_Search { get; set; } = (IconInfo) "search";

    public IconInfo Page_TitleMenu_Button_Save { get; set; } = (IconInfo) "save";

    public IconInfo Page_TitleMenu_Button_Delete { get; set; } = (IconInfo) "delete";

    public IconInfo Page_TitleMenu_Button_Clear { get; set; } = (IconInfo) "reset";

    public IconInfo Page_TitleMenu_Button_Print { get; set; } = (IconInfo) "print";

    public IconInfo Page_TitleMenu_Button_ExportPdf { get; set; } = (IconInfo) "pdf";

    public IconInfo Page_TitleMenu_Button_ExportExcel { get; set; } = (IconInfo) "excel";

    public IconInfo Page_TitleMenu_Button_Help { get; set; } = (IconInfo) "help";

    public IconInfo Page_TitleMenu_Button_Close { get; set; } = (IconInfo) "close";

    public IconInfo Page_SearchParam_Button_Folding { get; set; } = (IconInfo) "search_minus";

    public IconInfo Page_SearchParam_Button_UnFolding { get; set; } = (IconInfo) "search_plus";

    public IconInfo Common_Logout { get; set; } = (IconInfo) "logout";

    public IconInfo Common_Button_AddFixed { get; set; } = (IconInfo) "add_fixed";

    public IconInfo Common_Button_Zip { get; set; } = (IconInfo) "zip";

    public IconInfo Common_Button_DownLoad { get; set; } = (IconInfo) "download";

    public IconInfo Common_Button_UpLoad { get; set; } = (IconInfo) "upload";

    public IconInfo Common_Help { get; set; } = (IconInfo) "help";

    public IconInfo Common_Device { get; set; } = (IconInfo) "device";

    public IconInfo Common_Fixed { get; set; } = (IconInfo) "fixed";

    public IconInfo Common_EventSale { get; set; } = (IconInfo) "event_sale";

    public IconInfo Common_Tax { get; set; } = (IconInfo) "taxDiv_tax_word";

    public IconInfo Common_TaxFree { get; set; } = (IconInfo) "taxDiv_free_tax_word";

    public IconInfo Common_NotFound { get; set; } = (IconInfo) "unused";

    public IconInfo Common_BringToFront { get; set; } = (IconInfo) "bring_to_front";

    public IconInfo Common_BringForward { get; set; } = (IconInfo) "bring_forward";

    public IconInfo Common_Prev { get; set; } = (IconInfo) "prev";

    public IconInfo Common_Next { get; set; } = (IconInfo) "next";

    public IconInfo Common_SendBackward { get; set; } = (IconInfo) "send_backward";

    public IconInfo Common_SendToBack { get; set; } = (IconInfo) "send_to_back";

    public IconInfo Common_Bookmark { get; set; } = (IconInfo) "bookmark";

    public IconInfo Common_Print { get; set; } = (IconInfo) "print";

    public IconInfo Common_Excel { get; set; } = (IconInfo) "excel";

    public IconInfo Common_ExcelUpload { get; set; } = (IconInfo) "excel_upload";

    public IconInfo Common_Mail { get; set; } = (IconInfo) "mail";

    public IconInfo Common_Search { get; set; } = (IconInfo) "search";

    public IconInfo Common_Save { get; set; } = (IconInfo) "save";

    public IconInfo Common_New { get; set; } = (IconInfo) "new";

    public IconInfo Common_Clear { get; set; } = (IconInfo) "reset";

    public IconInfo Common_Delete { get; set; } = (IconInfo) "delete";

    public IconInfo Common_Close { get; set; } = (IconInfo) "close";

    public IconInfo Common_Folder { get; set; } = (IconInfo) "folder";

    public IconInfo Common_Category { get; set; } = (IconInfo) "category";

    public IconInfo Common_CategoryTop { get; set; } = (IconInfo) "category_main_category";

    public IconInfo Common_CategoryMid { get; set; } = (IconInfo) "category_middle_category";

    public IconInfo Common_CategoryBot { get; set; } = (IconInfo) "category_subclass";

    public IconInfo Common_Setting { get; set; } = (IconInfo) "setting";

    public IconInfo Common_Campaign { get; set; } = (IconInfo) "campaign";

    public IconInfo Common_Promotion { get; set; } = (IconInfo) "campaign";

    public IconInfo Common_Coupon { get; set; } = (IconInfo) "campaign";

    public IconInfo Common_Ok { get; set; } = (IconInfo) "ok";

    public IconInfo Common_Store { get; set; } = (IconInfo) "site";

    public IconInfo Common_Supplier { get; set; } = (IconInfo) "company";

    public IconInfo Common_Member { get; set; } = (IconInfo) "member";

    public IconInfo Common_MemberType { get; set; } = (IconInfo) "member_type";

    public IconInfo Common_SupDirect { get; set; } = (IconInfo) "company_direct";

    public IconInfo Common_SupSpecific { get; set; } = (IconInfo) "company_specific";

    public IconInfo Common_SupRent { get; set; } = (IconInfo) "company_rent";

    public IconInfo Common_Reset { get; set; } = (IconInfo) "reset";

    public IconInfo Common_LockFixed { get; set; } = (IconInfo) "lock_fixed";

    public IconInfo Common_Employee { get; set; } = (IconInfo) "employee";

    public IconInfo Common_Level { get; set; } = (IconInfo) "benchmark";

    public IconInfo Common_Level_Plus { get; set; } = (IconInfo) "benchmark_registration";

    public IconInfo Common_Cycle { get; set; } = (IconInfo) "calculation_cycle";

    public IconInfo Common_SalesUnit_Ea { get; set; } = (IconInfo) "salesUnit_ea_word";

    public IconInfo Common_SalesUnit_Box { get; set; } = (IconInfo) "salesUnit_box_word";

    public IconInfo Common_SalesUnit_Weight { get; set; } = (IconInfo) "salesUnit_Weight_word";

    public IconInfo Common_SalesUnit_Amount { get; set; } = (IconInfo) "salesUnit_amount_word";

    public IconInfo Common_StockUnit_Qty { get; set; } = (IconInfo) "stockunit_qty_word";

    public IconInfo Common_StockUnit_Weight { get; set; } = (IconInfo) "stockunit_weight_word";

    public IconInfo Common_StockUnit_Amount { get; set; } = (IconInfo) "stockunit_amount_word";

    public IconInfo Common_PackUnit_Ea { get; set; } = (IconInfo) "packunit_ea_word";

    public IconInfo Common_PackUnit_Box { get; set; } = (IconInfo) "packunit_box_word";

    public IconInfo Common_PackUnit_Bom { get; set; } = (IconInfo) "packunit_bom_word";
  }
}
