using Stylet;
using StyletIoC;
using System;
using System.Windows;
using System.Windows.Threading;
using System.Collections.Generic;
using DataTransfer.Pages;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using DataTransfer.ViewModels.MainControls;

namespace DataTransfer
{
    public class StyletBootstrapper : Bootstrapper<LoginVM>
    {
        /// <summary>
        /// 1. 시작 시
        /// </summary>
        protected override void OnStart()
        {
            // This is called just after the application is started, but before the IoC container is set up.
            // Set up things like logging, etc
            // Stylet.Logging.LogManager.LoggerFactory = name => new ExplorerLogger(name); // LogManager 구성   참고 URL - https://github.com/canton7/Stylet/wiki/Logging
            // Stylet.Logging.LogManager.Enabled = true;                                   // LogManager 활성화 참고 URL - https://github.com/canton7/Stylet/wiki/Logging

            // TODO : StyletBootstrapper.cs 이벤트 메서드 OnStart 추후 로직 보완 예정 (2023.07.03 jbh)
            base.OnStart();
#if DEBUG
            bool isDebug = true;
#else
            isDebug = false;
#endif
            if (!isDebug)
            {
                // Guid - 03587AE2-EA7C-43C0-9E10-38A7563C251B
                AppCenter.Start("03587AE2-EA7C-43C0-9E10-38A7563C251B", typeof(Analytics), typeof(Crashes));
            }
        }

        /// <summary>
        /// 2. 컨테이너 초기화
        /// </summary>
        /// <param name="builder"></param>
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            // Configure the IoC container in here
            builder.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();
            builder.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
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
                ["DataTransfer.ViewModels"] = "DataTransfer.Views"
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
