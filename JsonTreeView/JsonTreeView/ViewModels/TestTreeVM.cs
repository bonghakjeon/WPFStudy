using CobimExplorer.Rest.Api.CobimBase.Explorer;
using CobimExplorerNet;
using JsonTreeView.Commands;
using Serilog;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JsonTreeView.ViewModels
{
    // TODO : TreeView Multi Level (프로젝트 - 팀 - 폴더 - 서브폴더 / 파일) 구현 (2023.09.11 jbh)
    // 참고 URL - https://stackoverflow.com/questions/50760316/wpf-treeview-with-three-levels-in
    public interface ITreeNode
    {
        string exp_TreeName { get; set; }
        
        List<ITreeNode> ChildNodes { get; set; }
    }

    public class ExplorerView : BindableBase
    {

        public Dictionary<string, object> DataInfo { get => _DataInfo; set { _DataInfo = value; Changed(); } }
        private Dictionary<string, object> _DataInfo = new Dictionary<string, object>();

        public Dictionary<string, object> ProjectDataInfo { get => _ProjectDataInfo; set { _ProjectDataInfo = value; Changed(); } }
        private Dictionary<string, object> _ProjectDataInfo = new Dictionary<string, object>();

        public Dictionary<string, object> TeamDataInfo { get => _TeamDataInfo; set { _TeamDataInfo = value; Changed(); } }
        private Dictionary<string, object> _TeamDataInfo = new Dictionary<string, object>();

        public Dictionary<string, object> FolderDataInfo { get => _FolderDataInfo; set { _FolderDataInfo = value; Changed(); } }
        private Dictionary<string, object> _FolderDataInfo = new Dictionary<string, object>();

        public Dictionary<string, object> SubFolderDataInfo { get => _SubFolderDataInfo; set { _SubFolderDataInfo = value; Changed(); } }
        private Dictionary<string, object> _SubFolderDataInfo = new Dictionary<string, object>();

        public Dictionary<string, object> FileDataInfo { get => _FileDataInfo; set { _FileDataInfo = value; Changed(); } }
        private Dictionary<string, object> _FileDataInfo = new Dictionary<string, object>();
    }

    public class ProjectView : ITreeNode
    {
        public string exp_TreeName { get; set; }
        public List<ITreeNode> ChildNodes { get; set; }

        /// <summary>
        /// 프로젝트 목록 리스트
        /// </summary>
        public List<ExplorerView> ProjectItems { get; } = new List<ExplorerView>();

        public Dictionary<string, object> ProjectDataInfo { get; } = new Dictionary<string, object>();
    }

    public class TeamView : ITreeNode
    {
        public string exp_TreeName { get; set; }
        public List<ITreeNode> ChildNodes { get; set; }

        /// <summary>
        /// 팀 목록 리스트
        /// </summary>
        public List<ExplorerView> TeamItems { get; } = new List<ExplorerView>();

        public Dictionary<string, object> TeamDataInfo { get; } = new Dictionary<string, object>();
    }

    public class FolderView : ITreeNode
    {
        public string exp_TreeName { get; set; }
        public List<ITreeNode> ChildNodes { get; set; }

        /// <summary>
        /// 폴더 목록 리스트
        /// </summary>
        public List<ExplorerView> FolderItems { get; } = new List<ExplorerView>();
    }

    public class SubFolderView : ITreeNode
    {
        public string exp_TreeName { get; set; }
        public List<ITreeNode> ChildNodes { get; set; }

        /// <summary>
        /// 서브 폴더 목록 리스트
        /// </summary>
        public List<ExplorerView> SubFolderItems { get; } = new List<ExplorerView>();
    }

    public class FileView : ITreeNode
    {
        public string exp_TreeName { get; set; }
        public List<ITreeNode> ChildNodes { get; set; }

        /// <summary>
        /// 파일 목록 리스트
        /// </summary>
        public List<ExplorerView> FileItems { get; } = new List<ExplorerView>();
    }

    public class TestTreeVM : Screen
    {
        #region 프로퍼티 
        /// <summary>
        /// 체크아웃 Command
        /// </summary>
        public ICommand TestCommand { get; set; }
        public List<ProjectView> ProjectNodes { get; } = new List<ProjectView>();

        public BindableCollection<ProjectView> LevelDatas { get; } = new BindableCollection<ProjectView>();

        /// <summary>
        /// 프로젝트 아이디 리스트 
        /// </summary>
        public List<string> ProjectIdList { get => _ProjectIdList; set { _ProjectIdList = value; NotifyOfPropertyChange(); } }
        private List<string> _ProjectIdList = new List<string>();

        /// <summary>
        /// 프로젝트 아이디,Dictionary
        /// Key = 프로젝트 아이디, Value = 팀 아이디
        /// </summary>
        public Dictionary<string, string> ProjectIdDic { get => _ProjectIdDic; set { _ProjectIdDic = value; NotifyOfPropertyChange(); } }
        private Dictionary<string, string> _ProjectIdDic = new Dictionary<string, string>();


        /// <summary>
        /// 프로젝트 아이디, 팀 아이디 Dictionary
        /// Key = 프로젝트 아이디, Value = 팀 아이디
        /// </summary>
        public Dictionary<string, string> ProjectTeamDic { get => _ProjectTeamDic; set { _ProjectTeamDic = value; NotifyOfPropertyChange(); } }
        private Dictionary<string, string> _ProjectTeamDic = new Dictionary<string, string>();

        /// <summary>
        /// 폴더 목록 리스트 
        /// </summary>
        public List<Dictionary<string, object>> FolderList { get => _FolderList; set { _FolderList = value; NotifyOfPropertyChange(); } }
        private List<Dictionary<string, object>> _FolderList = new List<Dictionary<string, object>>();

        /// <summary>
        /// HttpClient client (계속 호출하지 말고 싱글톤으로 사용해야함.)
        /// </summary>
        public HttpClient client { get; set; } = new HttpClient();

        /// <summary>
        /// 프로젝트(+팀) 정보
        /// </summary>
        public ProjectHelper.ProjectPack ProjectPack { get; set; }


        #endregion 프로퍼티 

        #region 생성자 

        public TestTreeVM()
        {
            TestCommand = new ButtonCommand(TestAsync, CanExecuteMethod);
            // CreateNode();
            // TreeView.ItemsSource = processes;
        }

        #endregion 생성자 

        #region TestAsync

        private async Task TestAsync(object arg)
        {
            try
            {
                await CreateNode();
            }
            catch (Exception e)
            {
                Log.Logger.Information(e.Message);
            }
            
        }

        #endregion TestAsync

        #region CanExecuteMethod

        private bool CanExecuteMethod(object arg)
        {
            return true;
        }

        #endregion CanExecuteMethod

        #region CreateNode

        private async Task CreateNode()
        {
            try
            {
                var FileNodes = new List<ITreeNode>
                {
                    new FileView { exp_TreeName = "File 1" },
                    new FileView { exp_TreeName = "File 2" },
                    new SubFolderView { exp_TreeName = "Sub Folder 1" },
                    new SubFolderView { exp_TreeName = "Sub Folder 2" }
                };
                var FolderNodes = new List<ITreeNode>
                {
                    new FolderView { exp_TreeName = "Folder 1", ChildNodes = FileNodes },
                    new FolderView { exp_TreeName = "Folder 2", ChildNodes = FileNodes },
                    new FolderView { exp_TreeName = "Folder 3", ChildNodes = FileNodes },
                    new FolderView { exp_TreeName = "Folder 4", ChildNodes = FileNodes }
                };
                var TeamNodes = new List<ITreeNode>
                { 
                    new TeamView { exp_TreeName = "Team 1", ChildNodes = FolderNodes },
                    new TeamView { exp_TreeName = "Team 2", ChildNodes = FolderNodes }
                };

                ProjectNodes.Add(new ProjectView { exp_TreeName = "Project 1", ChildNodes = TeamNodes });
                ProjectNodes.Add(new ProjectView { exp_TreeName = "Project 2", ChildNodes = TeamNodes });

                LevelDatas.Clear();
                LevelDatas.AddRange(ProjectNodes.ToArray());
            }
            catch (Exception e)
            {
                Log.Logger.Information(e.Message);
                throw;
            }
        }

        #endregion CreateNode

        #region TestCommand

        /// <summary>
        /// TestCommand
        /// </summary>
        //public ICommand TestCommand => _TestCommand = new RelayCommand(parameter =>
        //{
        //    try
        //    {

        //        //var FileNodes = new List<ITreeNode>
        //        //{
        //        //    new FileView { exp_TreeName = "File 1" },
        //        //    new FileView { exp_TreeName = "File 2" },
        //        //    new SubFolderView { exp_TreeName = "Sub Folder 1" },
        //        //    new SubFolderView { exp_TreeName = "Sub Folder 2" }
        //        //};
        //        //var FolderNodes = new List<ITreeNode>
        //        //{
        //        //    new FolderView { exp_TreeName = "Folder 1", ChildNodes = FileNodes },
        //        //    new FolderView { exp_TreeName = "Folder 2", ChildNodes = FileNodes },
        //        //    new FolderView { exp_TreeName = "Folder 3", ChildNodes = FileNodes },
        //        //    new FolderView { exp_TreeName = "Folder 4", ChildNodes = FileNodes }
        //        //};
        //        //ProjectNodes.Add(new ProjectView { exp_TreeName = "Project 1", ChildNodes = FolderNodes });
        //        //ProjectNodes.Add(new ProjectView { exp_TreeName = "Project 2", ChildNodes = FolderNodes });
        //    }


        //    catch (Exception e)
        //    {
        //        Log.Logger.Information(e.Message);
        //    }
        //});
        //private ICommand _TestCommand;

        #endregion TestCommand 
    }
}
