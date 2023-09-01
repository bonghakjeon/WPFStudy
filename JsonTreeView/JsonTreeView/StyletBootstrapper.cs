using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using JsonTreeView.ViewModels;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace JsonTreeView
{
    public class StyletBootstrapper : Bootstrapper<MainVM>
    {
        /// <summary>
        /// 1. 시작 시
        /// </summary>
        protected override void OnStart()
        {
            // TODO : StyletBootstrapper.cs 이벤트 메서드 OnStart 추후 로직 보완 예정 (2023.07.03 jbh)
            base.OnStart();
#if DEBUG
            bool isDebug = true;
#else
            isDebug = false;
#endif
            if (!isDebug)
            {
                // <Guid("1FDFD875-A485-425E-89BE-7C480B57AA36")>
                AppCenter.Start("59824C9A-A636-4BC3-8886-E3F941F63AC2", typeof(Analytics), typeof(Crashes));
            }
        }

        /// <summary>
        /// 2. 컨테이너 초기화
        /// </summary>
        /// <param name="builder"></param>
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            // Configure the IoC container in here
            // Bind your own types. Concrete types are automatically self-bound.
            //builder.Bind<IMyInterface>().To<MyType>();
            base.ConfigureIoC(builder);

            builder.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();
            builder.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            builder.Bind<MainVM>().ToSelf();
        }

        /// <summary>
        /// 3. 컨테이너 초기화 후 설정
        /// <see cref="ConfigureIoC(IStyletIoCBuilder)"/> 이후
        /// </summary>
        protected override void Configure()
        {
            // Perform any other configuration before the application starts
            // This is called after Stylet has created the IoC container, so this.Container exists, but before the
            // Root ViewModel is launched.
            // Configure your services, etc, in here
            // 참고 URL - https://github.com/canton7/Stylet/wiki/The-ViewManager
            base.Configure();
            var vm = this.Container.Get<ViewManager>();
            vm.ViewNameSuffix = "V";
            vm.ViewModelNameSuffix = "VM";
            vm.NamespaceTransformations = new Dictionary<string, string>()
            {
                ["JsonTreeView.ViewModels"] = "JsonTreeView.Views"
            };
        }

        /// <summary>
        /// 4. 실행 후
        /// </summary>
        protected override void OnLaunch()
        {
            // This is called just after the root ViewModel has been launched
            // Something like a version check that displays a dialog might be launched from here
            base.OnLaunch();
        }

        /// <summary>
        /// 5. 종료 시
        /// </summary>
        /// <param name="e"></param>
        protected override void OnExit(ExitEventArgs e)
        {
            // Called on Application.Exit
            //SystemCurrentInfo.Instance.Dispose();
            base.OnExit(e);
        }

        /// <summary>
        /// 6. 예외
        /// </summary>
        /// <param name="e"></param>
        protected override void OnUnhandledException(DispatcherUnhandledExceptionEventArgs e)
        {
            // Called on Application.DispatcherUnhandledException
            base.OnUnhandledException(e);

            // 인터넷 연결 되어있을 때에 Exception 수집 
            Crashes.TrackError(e.Exception);
#if DEBUG
            var isRelease = false;
#else
            isRelease = true;
#endif
            if (isRelease)
            {
                e.Handled = true;   //  프로그램이 죽지 않고 진행 가능 하도록 
            }
        }
    }
}
