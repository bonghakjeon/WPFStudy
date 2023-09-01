using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JsonTreeView.Commands
{
    // TODO: RelayCommand 추후 로직 변경 예정 (2023.07.03 jbh)
    // 참고 URL - https://www.codeproject.com/Tips/813345/Basic-MVVM-and-ICommand-Usage-Example
    // 참고 2 URL - https://youtu.be/s7pt3EkDyq4
    // 참고 3 URL - https://blog.naver.com/PostView.naver?blogId=goldrushing&logNo=221243250136 
    // Command 참고 URL - https://blog.naver.com/goldrushing/221243250136
    public class ButtonCommand : ICommand
    {
        // Action은 반환 타입이 void인 메소드를 위해 특별히 설계된 제네릭 델리게이트 의미
        // 참고 URL - https://blog.joe-brothers.com/csharp-delegate-func-action/
        Func<object, Task> _executeMethod;
        //Func<object, Task> _executeMethod;
        Func<object, bool> _canexecuteMethod;

        public ButtonCommand(Func<object, Task> executeMethod, Func<object, bool> canexecuteMethod)
        {
            this._executeMethod = executeMethod;
            this._canexecuteMethod = canexecuteMethod;
        }

        // TODO : 추후 필요 시 이벤트 핸들러 "CanExecuteChanged" 사용 예정(2023.08.24 jbh)
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _executeMethod(parameter);
        }

        // TODO : 아래 소스코드 필요시 사용 예정 (2023.08.24 jbh)
        //private Action<object> execute;
        //private Func<object, bool> canExecute;

        //public event EventHandler CanExecuteChanged
        //{
        //    add { CommandManager.RequerySuggested += value;  }
        //    remove { CommandManager.RequerySuggested -= value; }
        //}

        //public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        //{
        //    this.execute = execute;
        //    this.canExecute = canExecute;
        //}

        /// <summary>
        /// RelayCommand 활성화 여부 제어 (활성화 - true / 비활성화 - false)
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        //public bool CanExecute(object parameter)
        //{
        //    return canExecute == null || canExecute(parameter);
        //}

        //public void Execute(object parameter)
        //{
        //    execute(parameter);
        //}
    }
}
