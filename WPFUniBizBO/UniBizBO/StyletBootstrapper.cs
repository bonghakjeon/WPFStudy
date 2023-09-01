// Decompiled with JetBrains decompiler
// Type: UniBizBO.StyletBootstrapper
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using FluentValidation;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Stylet;
using Stylet.Logging;
using StyletIoC;
using StyletIoC.Creation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Threading;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Employee;
using UniBizBO.Common;
using UniBizBO.Composition;
using UniBizBO.Composition.Resource;
using UniBizBO.Config;
using UniBizBO.Services;
using UniBizBO.Services.Page;
using UniBizBO.Services.Part;
using UniBizBO.Store;
using UniBizBO.ViewModels;
using UniBizUtil.Util;
using UniinfoNet;
using UniinfoNet.Clazz;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Providers;
using UniinfoNet.Windows.Wpf;


#nullable enable
namespace UniBizBO
{
  public class StyletBootstrapper : Bootstrapper<
  #nullable disable
  AppInitVM>
  {
    private string BOConfigPath = ".\\BOConfig.json";

    public bool IsDebug => false;

    protected override void OnStart()
    {
      base.OnStart();
      Log.Logger.Information(nameof (OnStart));
      LoggerSinkConfiguration writeTo = new LoggerConfiguration().MinimumLevel.Verbose().WriteTo.Debug().WriteTo;
      string path = "Logs\\" + Assembly.GetEntryAssembly().GetName().Name + "_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
      Encoding utF8 = Encoding.UTF8;
      long? fileSizeLimitBytes = new long?(1073741824L);
      TimeSpan? flushToDiskInterval = new TimeSpan?();
      int? retainedFileCountLimit = new int?(31);
      Encoding encoding = utF8;
      TimeSpan? retainedFileTimeLimit = new TimeSpan?();
      Logger logger = writeTo.File(path, fileSizeLimitBytes: fileSizeLimitBytes, flushToDiskInterval: flushToDiskInterval, retainedFileCountLimit: retainedFileCountLimit, encoding: encoding, retainedFileTimeLimit: retainedFileTimeLimit).CreateLogger();
      LogManager.Enabled = false;
      Log.Logger = (Serilog.ILogger) logger;
      Log.Logger.Information("AppCenter Start");
      if (!this.IsDebug)
        Microsoft.AppCenter.AppCenter.Start("b8c79438-28d6-4e15-8504-156702c0e937", typeof (Microsoft.AppCenter.Analytics.Analytics), typeof (Microsoft.AppCenter.Crashes.Crashes));
      WpfSystemInfo wpfSystemInfo = SystemInfo<WpfSystemInfo>.Default;
      wpfSystemInfo.Init();
      Dictionary<string, string> dic = new Dictionary<string, string>();
      dic["AppVersion"] = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
      dic["OSVersion"] = wpfSystemInfo.OSVersionName;
      dic["Processor"] = wpfSystemInfo.ProcessorName;
      int num = wpfSystemInfo.ProcessorCoreCount;
      dic["Processor Core"] = num.ToString();
      num = wpfSystemInfo.ProcessorThreadCount;
      dic["Processor Thread"] = num.ToString();
      dic["Memory(GB)"] = Math.Round(wpfSystemInfo.MemorySizeGB, 0).ToString();
      Size primaryResolution = wpfSystemInfo.ScreenPrimaryResolution;
      // ISSUE: variable of a boxed type
      __Boxed<int> width = (ValueType) primaryResolution.Width;
      primaryResolution = wpfSystemInfo.ScreenPrimaryResolution;
      // ISSUE: variable of a boxed type
      __Boxed<int> height = (ValueType) primaryResolution.Height;
      dic["Monitor Main Resolution"] = string.Format("{0}, {1}", (object) width, (object) height);
      num = wpfSystemInfo.ScreenCount;
      dic["Monitor Count"] = num.ToString();
      AppEventLog.AppStart(dic);
    }

    private T ReadWithCreate<T>(string path) where T : new()
    {
      if (!File.Exists(path))
        File.WriteAllText(path, JsonSerializer.Serialize<T>(new T(), new JsonSerializerOptions()
        {
          WriteIndented = true
        }));
      return JsonSerializer.Deserialize<T>(File.ReadAllText(path));
    }

    protected override void ConfigureIoC(IStyletIoCBuilder builder)
    {
      base.ConfigureIoC(builder);
      Log.Logger.Information(nameof (ConfigureIoC));
      Icons.Default.Init();
      builder.Bind<Serilog.ILogger>().ToInstance((object) Log.Logger);
      builder.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();
      builder.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
      builder.Bind<ManifestResourceProvider>().ToInstance((object) new ManifestResourceProvider((IEnumerable<Assembly>) builder.Assemblies));
      builder.Bind<AppInitVM>().ToSelf().InSingletonScope();
      builder.Bind<AppMainVM>().ToSelf();
      builder.Bind<LogInPack>().ToSelf().InSingletonScope();
      builder.Bind<ThemeSetting>().ToSelf().InSingletonScope();
      builder.Bind<UbAppStatus>().To<UbAppStatus>().InSingletonScope();
      builder.Bind<LocalStatusDb>().To<LocalStatusDb>();
      builder.Bind<LocalStatusStore>().To<LocalStatusStore>().InSingletonScope();
      builder.Bind(typeof (IModelValidator<>)).To(typeof (FluentModelValidator<>));
      builder.Bind(typeof (IValidator<>)).ToAllImplementations(false);
      this.BindServiceClass(builder, typeof (ISystemPage), typeof (IParentPage), typeof (IParentPart), typeof (IUbVM), typeof (IPageContainer), typeof (IPage), typeof (IPartContainer), typeof (IPart), typeof (IMPart));
      builder.Bind<UbHttpClient>().ToFactory<UbHttpClient>((Func<IRegistrationContext, UbHttpClient>) (it =>
      {
        it.Get<IEventAggregator>();
        UbHttpClient ubHttpClient = new UbHttpClient();
        ubHttpClient.Requesting += (Action<UniBizApiClientRequestingArgs>) (e => Log.Information<HttpMethod, Uri>("{Method} {RequestUri} ", e.Req.Method, e.Req.RequestUri));
        ubHttpClient.Responsed += (Action<UniBizApiClientResponedArgs>) (e => Log.Information<int, Uri, long?>("{StatusCode} {RequestUri} {DataSize:#,##0} Byte", (int) e.Res.StatusCode, e.Res.RequestMessage.RequestUri, e.Res.Content.Headers.ContentLength));
        ubHttpClient.BaseClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("UniBizBO", Assembly.GetEntryAssembly().GetName().Version.ToString()));
        ubHttpClient.WebSocketTextReceiving += (Action<UniBizWebSocketReceivingArg>) (arg => this.Container.Get<UbAppStatus>().ApiWebSocket?.RecvMessageAsync(arg.Text));
        return ubHttpClient;
      }));
      builder.Bind<UserManager>().To<UserManager>().InSingletonScope();
      builder.Bind<UserInfo>().To<UserInfo>().InSingletonScope();
      builder.Bind<BOConfig>().ToFactory<BOConfig>((Func<IRegistrationContext, BOConfig>) (it => this.ReadWithCreate<BOConfig>(this.BOConfigPath))).InSingletonScope();
    }

    private void BindServiceClass(IStyletIoCBuilder builder, params Type[] types)
    {
      InheritClazzFinder clazzFinder = new InheritClazzFinder((IEnumerable<Assembly>) builder.Assemblies);
      builder.Bind<InheritClazzFinder>().ToInstance((object) clazzFinder);
      ((IEnumerable<Type>) types).AsParallel<Type>().Select<Type, (Type, List<Type>)>((Func<Type, (Type, List<Type>)>) (type =>
      {
        List<Type> list = clazzFinder.GetList(type);
        List<Type> typeList1;
        if (list == null)
        {
          typeList1 = (List<Type>) null;
        }
        else
        {
          IEnumerable<Type> source1 = list.Where<Type>((Func<Type, bool>) (it => it.IsClass));
          if (source1 == null)
          {
            typeList1 = (List<Type>) null;
          }
          else
          {
            IEnumerable<Type> source2 = source1.Where<Type>((Func<Type, bool>) (it => !it.IsAbstract));
            typeList1 = source2 != null ? source2.Where<Type>((Func<Type, bool>) (it => it.GetCustomAttribute<HiddenVmAttribute>(false) == null)).ToList<Type>() : (List<Type>) null;
          }
        }
        List<Type> typeList2 = typeList1;
        return (type, typeList2);
      })).ToList<(Type, List<Type>)>().ForEach((Action<(Type, List<Type>)>) (mapping => mapping.founds.ForEach((Action<Type>) (imp =>
      {
        builder.Bind(mapping.type).To(imp).WithKey(imp.FullName);
        Log.Debug<string, string>("서비스 {Service}, 구현 {Implement} 등록", mapping.type.Name, imp.FullName);
      }))));
    }

    protected override void Configure()
    {
      base.Configure();
      ViewManager viewManager = this.Container.Get<ViewManager>();
      viewManager.ViewNameSuffix = "V";
      viewManager.ViewModelNameSuffix = "VM";
      viewManager.NamespaceTransformations = new Dictionary<string, string>()
      {
        ["UniBizBO.ViewModels"] = "UniBizBO.Views.V0"
      };
    }

    protected override void OnLaunch() => base.OnLaunch();

    protected override void OnUnhandledException(DispatcherUnhandledExceptionEventArgs e)
    {
      base.OnUnhandledException(e);
      Log.Logger.ErrorColor("e.Exception.Message = " + e.Exception.Message);
      this.Container.Get<Serilog.ILogger>().Error(e.Exception, e.Exception.Message);
      Microsoft.AppCenter.Crashes.Crashes.TrackError(e.Exception, (IDictionary<string, string>) null);
      e.Handled = true;
      int num = (int) MessageBox.Show(e?.Exception?.Message ?? "예외 정보 없음", "오류");
    }

    protected override async void OnExit(ExitEventArgs e)
    {
      StyletBootstrapper styletBootstrapper = this;
      if (styletBootstrapper.Container.Get<UbAppStatus>().Api != null)
      {
        await styletBootstrapper.Container.Get<UbAppStatus>().ApiWebSocket.AppStoppingAsync();
        styletBootstrapper.Container.Get<UbAppStatus>().Api.Dispose();
        styletBootstrapper.Container.Get<UbAppStatus>().Api = (UbHttpClient) null;
      }
      SystemCurrentInfo.Instance.Dispose();
      // ISSUE: reference to a compiler-generated method
      styletBootstrapper.\u003C\u003En__0(e);
    }
  }
}
