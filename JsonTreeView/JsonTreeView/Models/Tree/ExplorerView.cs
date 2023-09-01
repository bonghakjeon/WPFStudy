using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTreeView.Models.Tree
{
    public class ExplorerView : ValidatingModelBase
    {
        /// <summary>
        /// 루트 디렉토리 (프로젝트) 리스트 
        /// </summary>
        //public List<Dictionary<string, object>> Items { get => _Items; set { _Items = value; NotifyOfPropertyChange(); } }
        //private List<Dictionary<string, object>> _Items = new List<Dictionary<string, object>>();

        /// <summary>
        /// 루트 디렉토리 (프로젝트) 이름
        /// </summary>
        //public string exp_TreeName { get => _exp_TreeName; set { _exp_TreeName = value; NotifyOfPropertyChange(); } }
        //private string _exp_TreeName;

        // TODO : 하위 디렉토리 (폴더 - 파일) 이름을 따로 나눠야 할 경우 프로퍼티 "exp_TreeFolderNameDesc", "exp_TreeFileNameDesc" 구현 하기 (2023.09.01 jbh)
        /// <sumary>
        /// 하위 디렉토리 (폴더 - 파일) 이름
        /// </sumary>
        public string exp_TreeNameDesc { get => _exp_TreeNameDesc; set { _exp_TreeNameDesc = value; NotifyOfPropertyChange(); } }
        private string _exp_TreeNameDesc;


        /// <summary>
        /// 트리 레벨 (프로젝트 레벨 0  - 폴더 레벨 1 - 파일 레벨 2 순서)
        /// </summary>
        //public int exp_TreeLevel { get => _exp_TreeLevel; set { _exp_TreeLevel = value; NotifyOfPropertyChange(); } }
        //private int _exp_TreeLevel;

        /// <summary>
        /// 메타 데이터 리스트 
        /// </summary>
        /// 참고 URL - https://joyfuls.tistory.com/24
        //public List<Dictionary<string, object>> metaItems { get => _metaItems; set { _metaItems = value; NotifyOfPropertyChange(); } }
        //private List<Dictionary<string, object>> _metaItems = new List<Dictionary<string, object>>();
    }
}
