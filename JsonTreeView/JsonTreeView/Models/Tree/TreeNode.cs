using Stylet;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JsonTreeView.ViewModels;

namespace JsonTreeView.Models.Tree
{
    // TODO: JSON 데이터 파싱 -> TreeView 데이터 바인딩 테스트 코드 구현 (2023.09.01 jbh) 
    // TODO : propertyName "projectName"  말고 "projectEntity" 영역 관련 기타 데이터 추가해서 리스트에 넣는 방법 생각하고 구현하기 (2023.08.31 jbh)
    // 참고 URL - https://stackoverflow.com/questions/63656768/displaying-treeview-from-custom-json-with-wpf
    #region TreeNode

    // TODO : NotifyPropertyChanged 클래스 필요시 구현 예정 (2023.08.31 jbh)
    public class TreeNode : ValidatingModelBase // : NotifyPropertyChanged 
    {
        public static MainVM mainVM { get; set; }

        /// <summary>
        /// IsSelected
        /// </summary>
        public bool IsSelected 
        {
            get => _IsSelected;
            set
            {
                _IsSelected = value;
                if (_IsSelected) mainVM.SelectedItem = this;
            }
        }
        private bool _IsSelected;

        /// <summary>
        /// Name
        /// </summary>
        public string ParentName
        {
            get => _ParentName;
            set
            {
                _ParentName = value;
                NotifyOfPropertyChange();
            }
        }
        private string _ParentName;

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                NotifyOfPropertyChange();
            }
        }
        private string _Name;
    }

    #endregion TreeNode

    #region TreeObject 

    public class TreeObject : TreeNode
    {
        public ObservableCollection<TreeNode> Children
        {
            get => _Children;
            set
            {
                _Children = value;
                NotifyOfPropertyChange();
            }
        }
        private ObservableCollection<TreeNode> _Children;

        /// <summary>
        /// EtcValue
        /// </summary>
        public string EtcValue
        {
            get => _EtcValue;
            set
            {
                _EtcValue = value;
                NotifyOfPropertyChange();
            }
        }
        private string _EtcValue;
    }

    #endregion TreeObject

    #region TestTreeObject

    public class TestTreeObject : TreeNode
    {
        public List<TreeNode> Children
        {
            get => _Children;
            set
            {
                _Children = value;
                NotifyOfPropertyChange();
            }
        }
        private List<TreeNode> _Children;

        public List<TreeNode> Etc
        {
            get => _Etc;
            set
            {
                _Etc = value;
                NotifyOfPropertyChange();
            }
        }
        private List<TreeNode> _Etc;
    }

    #endregion TestTreeObject

    #region TreeValue

    public class TreeValue : TreeNode
    {
        public string Value
        {
            get => _Value;
            set
            {
                _Value = value;
                NotifyOfPropertyChange();
            }
        }
        private string _Value;

        /// <summary>
        /// Name
        /// </summary>
        public string NameValue
        {
            get => _NameValue;
            set
            {
                _NameValue = value;
                NotifyOfPropertyChange();
            }
        }
        private string _NameValue;
    }

    #endregion TreeValue

    #region TestTreeValue

    public class TestTreeValue : TreeNode
    {
        public string Value
        {
            get => _Value;
            set
            {
                _Value = value;
                NotifyOfPropertyChange();
            }
        }
        private string _Value;
    }

    #endregion TestTreeValue
}
