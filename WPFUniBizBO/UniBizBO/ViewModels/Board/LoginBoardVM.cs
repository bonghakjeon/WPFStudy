// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Board.LoginBoardVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UniBiz.Bo.Models;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.ProgOption;
using UniBizBO.Services;
using UniBizBO.Settings;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.Job;


#nullable enable
namespace UniBizBO.ViewModels.Board
{
  public class LoginBoardVM : UbScreen
  {
    private 
    #nullable disable
    string serverPath = "http://192.168.222.250:27026/api";
    private string _SiteViewCode = "1";
    private string _Id = "1";
    private string password = "1";
    private string _ProgVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
    private bool _IsLogin;

    public string ServerPath
    {
      get => this.serverPath;
      set
      {
        this.serverPath = value;
        this.NotifyOfPropertyChange(nameof (ServerPath));
      }
    }

    public string SiteViewCode
    {
      get => this._SiteViewCode;
      set => this.SetAndNotify<string>(ref this._SiteViewCode, value, nameof (SiteViewCode));
    }

    public string Id
    {
      get => this._Id;
      set => this.SetAndNotify<string>(ref this._Id, value, nameof (Id));
    }

    public string Password
    {
      get => this.password;
      set => this.SetAndNotify<string>(ref this.password, value, nameof (Password));
    }

    public string ProgVersion
    {
      get => this._ProgVersion;
      set
      {
        this._ProgVersion = value;
        this.NotifyOfPropertyChange(nameof (ProgVersion));
      }
    }

    public BindableCollection<string> ServerPaths { get; } = new BindableCollection<string>();

    public bool IsLogin
    {
      get => this._IsLogin;
      set
      {
        this._IsLogin = value;
        this.NotifyOfPropertyChange(nameof (IsLogin));
      }
    }

    public LoginBoardVM(IContainer container, IModelValidator<LoginBoardVM> validator)
      : base(container)
    {
      this.Validator = (IModelValidator) validator;
    }

    public LoginBoardVM ToShowData()
    {
      this.WindowManager.ShowDialog((object) this);
      return this;
    }

    private void LoadOption()
    {
      this.ServerPath = AppSetting.Default.Login.ServerPath;
      this.SiteViewCode = AppSetting.Default.Login.SiteViewCode;
      this.Id = AppSetting.Default.Login.Id;
      this.Password = AppSetting.Default.Login.Password;
      this.ServerPaths.Clear();
      if (AppSetting.Default.Login?.ServerPaths == null)
        return;
      this.ServerPaths.AddRange((IEnumerable<string>) AppSetting.Default.Login?.ServerPaths);
    }

    private void SaveOption()
    {
      if (!this.ServerPaths.Contains(this.ServerPath))
        this.ServerPaths.Add(this.ServerPath);
      AppSetting.Default.Login.ServerPath = this.ServerPath;
      AppSetting.Default.Login.SiteViewCode = this.SiteViewCode;
      AppSetting.Default.Login.Id = this.Id;
      AppSetting.Default.Login.Password = this.Password;
      AppSetting.Default.Login.ServerPaths = this.ServerPaths.ToList<string>();
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.LoadOption();
    }

    public WpfCommand CmdLogin => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() => new WpfCommand().AutoRefreshOn<WpfCommand>().ApplyCanExecute(new Func<bool>(this.CanLogin)).ApplyExecute(new Func<Task>(this.LoginAsync))), nameof (CmdLogin));

    public bool CanLogin() => !string.IsNullOrWhiteSpace(this.Id) && !string.IsNullOrWhiteSpace(this.Password);

    public async Task LoginAsync()
    {
      LoginBoardVM loginBoardVm = this;
      try
      {
        if (string.IsNullOrWhiteSpace(loginBoardVm.ServerPath))
          throw new Exception("서버 주소가 비어 있습니다.");
        if (loginBoardVm.ServerPath.Last<char>() != '/')
          loginBoardVm.ServerPath += "/";
        LogInPack backUpPack;
        UbRes<LogInPack> res;
        List<UniBizBO.Composition.TableColumnInfo> colInfos;
        // ISSUE: explicit non-virtual call
        using (JobProgressState j = __nonvirtual (loginBoardVm.Job).CreateJob("로그인", (string) null))
        {
          // ISSUE: explicit non-virtual call
          __nonvirtual (loginBoardVm.App).Api.RecreateBaseClient(loginBoardVm.ServerPath);
          backUpPack = new LogInPack();
          backUpPack.PutData(loginBoardVm.LogInPackInfo);
          loginBoardVm.LogInPackInfo.UserMenuInfo.Clear();
          loginBoardVm.LogInPackInfo.UserMenuPropInfo.Clear();
          loginBoardVm.LogInPackInfo.Lt_BookMark.Clear();
          loginBoardVm.LogInPackInfo.siteID = Convert.ToInt64(loginBoardVm.SiteViewCode);
          loginBoardVm.LogInPackInfo.userID = loginBoardVm.Id;
          loginBoardVm.LogInPackInfo.userPwd = loginBoardVm.Password;
          loginBoardVm.LogInPackInfo.appID = 26.ToString();
          Log.Logger.Information("로그인 시도");
          // ISSUE: explicit non-virtual call
          res = await EmployeeRestServer.PostEmployeeLogIn("UniBizBO", 1L, loginBoardVm.LogInPackInfo).ExecuteToReturnAsync<UbRes<LogInPack>>((UniBizHttpClient) __nonvirtual (loginBoardVm.App).Api);
          if (!res.isSuccess)
          {
            loginBoardVm.LogInPackInfo.UserMenuInfo.PutData(backUpPack.UserMenuInfo);
            loginBoardVm.LogInPackInfo.UserMenuPropInfo.PutData(backUpPack.UserMenuPropInfo);
            throw new Exception("사용자를 확인할 수 없습니다.");
          }
          Log.Logger.Information("로그인 성공");
          JobProgressState jobProgressState1 = await j.Progress().Async();
          loginBoardVm.LogInPackInfo.PutData(res.response);
          // ISSUE: explicit non-virtual call
          __nonvirtual (loginBoardVm.App).User.SetUser(loginBoardVm.LogInPackInfo.employee);
          Log.Logger.Information("웹소켓 연결 시도");
          Log.Logger.Information("웹소켓 연결 성공");
          loginBoardVm.IsLogin = true;
          List<Type> list = ((IEnumerable<Assembly>) AppDomain.CurrentDomain.GetAssemblies()).SelectMany<Assembly, Type>((Func<Assembly, IEnumerable<Type>>) (t => (IEnumerable<Type>) t.GetTypes())).Where<Type>((Func<Type, bool>) (it => it.IsClass && !it.IsAbstract && it.GetTypeInfo().IsSubclassOf(typeof (UbModelBase)))).ToList<Type>();
          colInfos = new List<UniBizBO.Composition.TableColumnInfo>();
          ConcurrentBag<UniBizBO.Composition.TableColumnInfo> collection = new ConcurrentBag<UniBizBO.Composition.TableColumnInfo>();
          foreach (Type clazzType in list)
          {
            if (!clazzType.FullName.Contains("`1") && Assembly.GetAssembly(typeof (UbModelBase)).CreateInstance(clazzType.FullName) is IUbModelBase instance && instance.ToColumnInfo().Count > 0)
            {
              foreach (UniBizBO.Composition.TableColumnInfo tableColumnInfo in UniBizBO.Composition.TableColumnInfo.CreateList(clazzType, (IEnumerable<TTableColumn>) instance.ToColumnInfo().Values))
                collection.Add(tableColumnInfo);
            }
          }
          colInfos.AddRange((IEnumerable<UniBizBO.Composition.TableColumnInfo>) collection);
          AppSetting.Default.Login.DtLastLogIn = new DateTime?(DateTime.Now);
          if (colInfos.Count > 0)
          {
            JobProgressState jobProgressState2 = await j.Progress().Async();
            // ISSUE: explicit non-virtual call
            __nonvirtual (loginBoardVm.App).Sys.TableColumns.Clear();
            // ISSUE: explicit non-virtual call
            __nonvirtual (loginBoardVm.App).Sys.TableColumns.AddRange((IEnumerable<UniBizBO.Composition.TableColumnInfo>) colInfos);
            // ISSUE: explicit non-virtual call
            __nonvirtual (loginBoardVm.App).Sys.CommonCodes.Clear();
            if (Enum2StrConverter.Dic_SiteCommonCodes == null)
              Enum2StrConverter.Dic_SiteCommonCodes = new SiteCommonCodeGroupDic();
            else
              Enum2StrConverter.Dic_SiteCommonCodes.Clear();
            foreach (CommonCodeView commonCodeView in loginBoardVm.LogInPackInfo.hm_CommonCode.Select<KeyValuePair<int, CommonCodeView>, CommonCodeView>((Func<KeyValuePair<int, CommonCodeView>, CommonCodeView>) (c => c.Value)))
            {
              // ISSUE: explicit non-virtual call
              __nonvirtual (loginBoardVm.App).Sys.CommonCodes.AddRange((IEnumerable<CommonCodeView>) commonCodeView.Lt_Detail);
              Enum2StrConverter.Dic_SiteCommonCodes.AddRange((IEnumerable<CommonCodeView>) commonCodeView.Lt_Detail);
            }
            // ISSUE: explicit non-virtual call
            __nonvirtual (loginBoardVm.App).Sys.UpdateTableColumns();
            // ISSUE: explicit non-virtual call
            __nonvirtual (loginBoardVm.App).Sys.Changed("");
          }
          JobProgressState jobProgressState3 = await j.Progress().Async();
          Log.Logger.Information("환경설정 조회");
          // ISSUE: explicit non-virtual call
          IList<ProgOptionView> data = (await ProgOptionRestServer.GetProgOptionList(loginBoardVm.LogInPackInfo.sendType, loginBoardVm.LogInPackInfo.siteID, 0, 0, is_opt_Code_ZeroCode: true).ExecuteToReturnAsync<UbRes<IList<ProgOptionView>>>((UniBizHttpClient) __nonvirtual (loginBoardVm.App).Api)).GetData<IList<ProgOptionView>>();
          if (data != null)
          {
            // ISSUE: reference to a compiler-generated method
            data.Action<IList<ProgOptionView>>(new Action<IList<ProgOptionView>>(loginBoardVm.\u003CLoginAsync\u003Eb__35_3));
          }
          Log.Logger.Information("환경설정 조회 성공");
          JobProgressState jobProgressState4 = await j.Progress().Async();
          // ISSUE: explicit non-virtual call
          __nonvirtual (loginBoardVm.App).Sys.Changed("");
          loginBoardVm.SaveOption();
          // ISSUE: explicit non-virtual call
          AppMainVM viewModel = __nonvirtual (loginBoardVm.Container).Get<AppMainVM>();
          // ISSUE: explicit non-virtual call
          __nonvirtual (loginBoardVm.WindowManager).ShowWindow((object) viewModel);
          loginBoardVm.RequestClose(new bool?());
        }
        backUpPack = (LogInPack) null;
        res = (UbRes<LogInPack>) null;
        colInfos = (List<UniBizBO.Composition.TableColumnInfo>) null;
      }
      catch (Exception ex)
      {
        Log.Logger.Information("로그인 실패 = " + ex.Message);
        throw;
      }
    }

    public WpfCommand CmdClose => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() => new WpfCommand().AutoRefreshOn<WpfCommand>().ApplyExecute(new Action(this.WindowClose))), nameof (CmdClose));

    public void WindowClose() => this.RequestClose(new bool?());
  }
}
