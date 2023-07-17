using System;
using Stylet;
using StyletIoC;
using LazyTreeView.ViewModels;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

namespace LazyTreeView
{
    public class StyletBootstrapper : Bootstrapper<MainVM>
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
                // <Guid("F59107C0-A6DE-4132-BAF9-129CCE40B69C")>
                AppCenter.Start("F59107C0-A6DE-4132-BAF9-129CCE40B69C", typeof(Analytics), typeof(Crashes));
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
            // builder.Assemblies.Add(typeof(MainVM).Assembly);    // Autobind 및 ToAllImplementatinos에서 검색한 어셈블리 목록을 가져오거나 설정

            // TODO: 새로 추가할 싱글톤 객체가 존재할시 아래처럼 싱글톤 객체로 설정하기 (2023.07.10 jbh)
            // 싱글톤 참고 URL - https://morit.tistory.com/5
            // 싱글톤 참고 2 URL - https://github.com/canton7/Stylet/wiki/StyletIoC-Configuration
            // 싱글톤 객체 설정 또 다른 예시 - builder.Bind<IConfigurationManager>().ToFactory(container => new ConfigurationManager()).InSingletonScope();
            builder.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();
            builder.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            // builder.Bind<MainVM>().ToSelf().InSingletonScope();

            // TODO : ShellViewModel, TestViewModel 말고도 "셀프 바인딩"할 뷰모델 찾아서 아래처럼 구현하기 (2023.07.10 jbh)
            // 셀프 바인딩 - StyletIoC에게 TestExplorer.sln 솔루션이 MainVM, ShellViewModel, TestViewModel을 요청할 때마다 모든 종속 항목이 이미 채워진 ShellViewModel, TestViewModel을 제공 해주는 기능.
            // 참고 URL - https://github.com/canton7/Stylet/wiki/StyletIoC-Configuration
            // 셀프 바인딩 예시 1 - builder.Bind<ShellViewModel>().ToSelf();
            // 셀프 바인딩 예시 2 - builder.Bind<ShellViewModel>().To<ShellViewModel>();
            // 필요 없는 코드 - builder.Bind<MainVM>().ToSelf(); 
            builder.Bind<MainVM>().ToSelf();

            // TODO: 추후 필요시 입력 받은 키 값을 전달 (Clear, Back space, 숫자 키 등등.... ) 받는 인터페이스 IPageBase 멤버  메서드 "OnReceivePosKeyUp" 구현 예정 (2023.07.03 jbh)
            // builder.Bind<IPageBase>().ToAllImplementations();
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
                ["LazyTreeView.ViewModels"] = "LazyTreeView.Views"
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
