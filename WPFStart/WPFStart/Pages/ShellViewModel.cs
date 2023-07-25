using System;
using Stylet;

namespace WPFStart.Pages
{
    public class ShellViewModel : Screen, IHandle<OpenSubredditEvent>
    {
        // private set; 의 역할 - 해당 필드 값을 읽기전용으로 쓰겠다는 것을 의미
        // 참고 URL - https://yeko90.tistory.com/entry/c-private-set-%EC%82%AC%EC%9A%A9-%EC%9D%B4%EC%9C%A0%ED%94%84%EB%9F%AC%ED%8D%BC%ED%8B%B0
        public TaskbarViewModel Taskbar { get; private set; }

        public ShellViewModel(IEventAggregator events, TaskbarViewModel taskbarViewModel)
        {
            this.DisplayName = "Reddit Browser";

            this.Taskbar = taskbarViewModel;

            events.Subscribe(this);
        }

        public void Handle(OpenSubredditEvent message)
        {
            // throw new NotImplementedException();
        }
    }
}
