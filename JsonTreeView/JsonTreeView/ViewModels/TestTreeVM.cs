using CobimExplorer.Rest.Api.CobimBase.Explorer;
using CobimExplorerNet;
using JsonTreeView.Commands;
using Serilog;
using Stylet;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.Generic;
using System.Windows;

namespace JsonTreeView.ViewModels
{
    // TODO : TreeView Multi Level (프로젝트 - 팀 - 폴더 - 서브폴더 / 파일) 구현 (2023.09.11 jbh)
    // 참고 URL - https://stackoverflow.com/questions/50760316/wpf-treeview-with-three-levels-in
    public interface ITreeNode
    {
        string exp_TreeName { get; set; }
        
        List<ITreeNode> ChildNodes { get; set; }

        List<List<ITreeNode>> TestChildNodes { get; set; }
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

        //public List<ITreeNode> ChildNodes { get; set; }

        public List<ITreeNode> ChildNodes 
        { 
            get
            {
                // 싱글톤 패턴 
                if (_ChildNodes == null)
                {
                    _ChildNodes = new List<ITreeNode>();
                }
                return _ChildNodes;
            }
            set => _ChildNodes = value;
        }
        private List<ITreeNode> _ChildNodes;

        /// <summary>
        /// 프로젝트 아이디
        /// </summary>
        public string exp_TreeProjectId { get; set; }

        /// <summary>
        /// 프로젝트 목록 리스트
        /// </summary>
        // public List<ExplorerView> ProjectItems { get; set; } = new List<ExplorerView>();
        public List<Dictionary<string, object>> ProjectItems { get; set; } 
            // = new List<Dictionary<string, object>>();

        public Dictionary<string, object> ProjectDataInfo { get; set; } = new Dictionary<string, object>();

        public List<List<ITreeNode>> TestChildNodes { get; set; } = new List<List<ITreeNode>>();
    }

    public class TeamView : ITreeNode
    {
        public string exp_TreeName { get; set; }
        //public List<ITreeNode> ChildNodes { get; set; }

        public List<ITreeNode> ChildNodes
        {
            get
            {
                // 싱글톤 패턴 
                if (_ChildNodes == null)
                {
                    _ChildNodes = new List<ITreeNode>();
                }
                return _ChildNodes;
            }
            set => _ChildNodes = value;
        }
        private List<ITreeNode> _ChildNodes;


        public List<List<ITreeNode>> TestChildNodes
        {
            get
            {
                // 싱글톤 패턴 
                if (_TestChildNodes == null)
                {
                    _TestChildNodes = new List<List<ITreeNode>>();
                }
                return _TestChildNodes;
            }
            set => _TestChildNodes = value;
        }
        private List<List<ITreeNode>> _TestChildNodes;

        /// <summary>
        /// 팀 아이디
        /// </summary>
        public string exp_TreeTeamId { get; set; }

        /// <summary>
        /// 팀 목록 리스트
        /// </summary>
        // public List<ExplorerView> TeamItems { get; set; } = new List<ExplorerView>();
        public List<Dictionary<string, object>> TeamItems { get; set; }

        public Dictionary<string, object> TeamDataInfo { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 소속된 팀의 사용자 리스트 
        /// </summary>
        public List<Dictionary<string, object>> TeamUserList { get; set; }

        //public List<List<ITreeNode>> TestChildNodes { get; set; } = new List<List<ITreeNode>>();
    }

    public class FolderView : ITreeNode
    {
        public string exp_TreeName { get; set; }
        //public List<ITreeNode> ChildNodes { get; set; }

        public List<ITreeNode> ChildNodes
        {
            get
            {
                // 싱글톤 패턴 
                if (_ChildNodes == null)
                {
                    _ChildNodes = new List<ITreeNode>();
                }
                return _ChildNodes;
            }
            set => _ChildNodes = value;
        }
        private List<ITreeNode> _ChildNodes;

        /// <summary>
        /// 부모 폴더 아이디
        /// </summary>
        public string exp_TreeParentFolderId { get; set; }

        /// <summary>
        /// 폴더 그룹 아이디
        /// </summary>
        public string exp_TreeFolderGroupId { get; set; }

        /// <summary>
        /// 폴더 아이디
        /// </summary>
        public string exp_TreeFolderId { get; set; }

        /// <summary>
        /// 폴더 레벨
        /// </summary>
        public string exp_TreeFolderLevelNo { get; set; }

        /// <summary>
        /// 폴더 목록 리스트
        /// </summary>
        //public List<ExplorerView> FolderItems { get; set; }
        public List<Dictionary<string, object>> FolderItems { get; set; }

        public Dictionary<string, object> FolderDataInfo { get; set; }  = new Dictionary<string, object>();

        public List<List<ITreeNode>> TestChildNodes { get; set; } = new List<List<ITreeNode>>();
    }

    public class SubFolderView : ITreeNode
    {
        public string exp_TreeName { get; set; }
        //public List<ITreeNode> ChildNodes { get; set; }

        public List<ITreeNode> ChildNodes
        {
            get
            {
                // 싱글톤 패턴 
                if (_ChildNodes == null)
                {
                    _ChildNodes = new List<ITreeNode>();
                }
                return _ChildNodes;
            }
            set => _ChildNodes = value;
        }
        private List<ITreeNode> _ChildNodes;

        /// <summary>
        /// 부모 폴더 리스트 
        /// </summary>
        public List<ITreeNode> ParentNodes 
        {
            get 
            { 
                // 싱글톤 패턴 
                if (_ParentNodes == null)
                {
                    _ParentNodes = new List<ITreeNode>();
                }
                return _ParentNodes;
            } 
            set => _ParentNodes = value; 
        }
        private List<ITreeNode> _ParentNodes;

        /// <summary>
        /// 부모 폴더 아이디
        /// </summary>
        public string exp_TreeParentFolderId { get; set; }

        /// <summary>
        /// 폴더 그룹 아이디
        /// </summary>
        public string exp_TreeFolderGroupId { get; set; }

        /// <summary>
        /// 폴더 아이디
        /// </summary>
        public string exp_TreeFolderId { get; set; }

        /// <summary>
        /// 서브 폴더 목록 리스트
        /// </summary>
        public List<Dictionary<string, object>> SubFolderItems { get; set; } = new List<Dictionary<string, object>>();

        public Dictionary<string, object> SubFolderDataInfo { get; set; } = new Dictionary<string, object>();

        public List<List<ITreeNode>> TestChildNodes { get; set; } = new List<List<ITreeNode>>();
    }

    public class FileView : ITreeNode
    {
        public string exp_TreeName { get; set; }
        //public List<ITreeNode> ChildNodes { get; set; }

        public List<ITreeNode> ChildNodes
        {
            get
            {
                // 싱글톤 패턴 
                if (_ChildNodes == null)
                {
                    _ChildNodes = new List<ITreeNode>();
                }
                return _ChildNodes;
            }
            set => _ChildNodes = value;
        }
        private List<ITreeNode> _ChildNodes;

        /// <summary>
        /// 파일 목록 리스트
        /// </summary>
        public List<ExplorerView> FileItems { get; set; } = new List<ExplorerView>();

        public Dictionary<string, object> FileDataInfo { get; set; } = new Dictionary<string, object>();

        public List<List<ITreeNode>> TestChildNodes { get; set; } = new List<List<ITreeNode>>();
    }

    public class TestTreeVM : Screen
    {
        #region 프로퍼티 
        /// <summary>
        /// TestCommand
        /// </summary>
        public ICommand TestCommand { get; set; }

        /// <summary>
        /// 프로젝트 리스트 
        /// </summary>
        //public List<ProjectView> ProjectList { get; set; } = new List<ProjectView>();
        public List<ProjectView> ProjectList 
        { 
            get
            {
                // 싱글톤 패턴 
                if (_ProjectList == null)
                {
                    _ProjectList = new List<ProjectView>();
                }
                return _ProjectList;
            }
            set => _ProjectList = value;
        } 
        private List<ProjectView> _ProjectList;

        /// <summary>
        /// 팀 리스트 
        /// </summary>
        public List<ITreeNode> TeamList 
        { 
            get
            {
                // 싱글톤 패턴 
                if (_TeamList == null)
                {
                    _TeamList = new List<ITreeNode>();
                }
                return _TeamList;
            }
            set => _TeamList = value;
        } 
        private List<ITreeNode> _TeamList;

        /// <summary>
        /// 폴더 리스트 
        /// </summary>
        //public List<ITreeNode> FolderList { get; set; } = new List<ITreeNode>();

        /// <summary>
        /// 서브 폴더 리스트 
        /// </summary>
        //public List<ITreeNode> SubFolderList 
        //{ 
        //    get
        //    {
        //        // 싱글톤 패턴 
        //        if (_SubFolderList == null)
        //        {
        //            _SubFolderList = new List<ITreeNode>();
        //        }
        //        return _SubFolderList;
        //    }
        //    set => _SubFolderList = value;
        //} 
        //private List<ITreeNode> _SubFolderList;

        public List<ITreeNode> SubFolderList { get; set; }

        /// <summary>
        /// 테스트용 폴더(+서브 폴더) 2차원 리스트 
        /// </summary>
        public List<List<ITreeNode>> FolderList 
        { 
            get
            {
                // 싱글톤 패턴
                if (_FolderList == null)
                {
                    _FolderList = new List<List<ITreeNode>>();
                }
                return _FolderList;
            }
            set => _FolderList = value;
        } 
        private List<List<ITreeNode>> _FolderList;


        public List<List<ITreeNode>> TestFolderNodes
        {
            get
            {
                // 싱글톤 패턴 
                if (_TestFolderNodes == null)
                {
                    _TestFolderNodes = new List<List<ITreeNode>>();
                }
                return _TestFolderNodes;
            }
            set => _TestFolderNodes = value;
        }
        private List<List<ITreeNode>> _TestFolderNodes;

        // TODO : FileAndFolderList 필요 없을 시 삭제 예정 (2023.09.14 jbh)
        /// <summary>
        /// 
        /// </summary>
        public List<ITreeNode> FileAndFolderList { get; set; } = new List<ITreeNode>();

        /// <summary>
        /// 파일 리스트 
        /// </summary>
        //public List<ITreeNode> FileList { get; set; } = new List<ITreeNode>();
        public List<List<ITreeNode>> FileList 
        { 
            get
            {
                // 싱글톤 패턴
                if (_FileList == null)
                {
                    _FileList = new List<List<ITreeNode>>();
                }
                return _FileList;
            }
            set => _FileList = value;
        } 
        private List<List<ITreeNode>> _FileList;

        /// <summary>
        /// 전체 (프로젝트 + 팀 + 폴더 + 서브폴더 + 파일) 데이터 Collection
        /// </summary>
        //public BindableCollection<ProjectView> LevelDatas { get; set; } = new BindableCollection<ProjectView>();
        public BindableCollection<ProjectView> LevelDatas 
        { 
            get
            {
                // 싱글톤 패턴
                if (_LevelDatas == null)
                {
                    _LevelDatas = new BindableCollection<ProjectView>();
                }
                return _LevelDatas;
            }
            set => _LevelDatas = value;
        } 
        private BindableCollection<ProjectView> _LevelDatas;

        /// <summary>
        /// 프로젝트 정보
        /// </summary>
        public ProjectView ProjectInfo { get; set; }

        /// <summary>
        /// 팀 정보
        /// </summary>
        public TeamView TeamInfo { get; set; }

        /// <summary>
        /// 폴더 정보
        /// </summary>
        public FolderView FolderInfo { get; set; }

        /// <summary>
        /// 테스트 서브 폴더 정보
        /// </summary>
        public FolderView TestSubFolderInfo { get; set; }

        /// <summary>
        /// 폴더 하위 서브 폴더 정보
        /// </summary>
        public SubFolderView SubFolderInfo { get; set; }

        /// <summary>
        /// 파일 정보
        /// </summary>
        public FileView FileInfo { get; set; }

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
        public List<Dictionary<string, object>> JsonFolderList { get => _JsonFolderList; set { _JsonFolderList = value; NotifyOfPropertyChange(); } }
        private List<Dictionary<string, object>> _JsonFolderList = new List<Dictionary<string, object>>();

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
                // await CreateList();
                // FileList.Add(new FileView { exp_TreeName = "테스트 파일 3" });
                // FileList.Add(new FileView { exp_TreeName = "테스트 파일 4" });

                //var TestList = new List<ITreeNode> 
                //{  
                //    new FileView { exp_TreeName = "Sub File 1" },
                //    new FileView { exp_TreeName = "Sub File 2" }
                //};

                // FileAndFolderList.Add(new FileView { exp_TreeName = "테스트 파일 1" });
                // FileAndFolderList.Add(new FileView { exp_TreeName = "테스트 파일 2" });
                // FileAndFolderList.Add(new SubFolderView { exp_TreeName = "테스트 서브폴더 1", ChildNodes = FileList });
                // FileAndFolderList.Add(new SubFolderView { exp_TreeName = "테스트 서브폴더 2", ChildNodes = FileList });

                //var FileList = new List<ITreeNode>
                //{
                //    new FileView { exp_TreeName = "File 1" },
                //    new FileView { exp_TreeName = "File 2" },
                //    new SubFolderView { exp_TreeName = "Sub Folder 1" },
                //    new SubFolderView { exp_TreeName = "Sub Folder 2" }
                //};

                //FolderList.Add(new FolderView { exp_TreeName = "Folder 1", ChildNodes = FileAndFolderList });
                //FolderList.Add(new FolderView { exp_TreeName = "Folder 2", ChildNodes = FileAndFolderList });
                //FolderList.Add(new FolderView { exp_TreeName = "Folder 3", ChildNodes = FileAndFolderList });
                //FolderList.Add(new FolderView { exp_TreeName = "Folder 4", ChildNodes = FileAndFolderList });



                // await AddFolderAndFileList(FolderList, FileAndFolderList);

                //var FolderList = new List<ITreeNode>
                //{
                //    new FolderView { exp_TreeName = "Folder 1", ChildNodes = FileList },
                //    new FolderView { exp_TreeName = "Folder 2", ChildNodes = FileList },
                //    new FolderView { exp_TreeName = "Folder 3", ChildNodes = FileList },
                //    new FolderView { exp_TreeName = "Folder 4", ChildNodes = FileList }
                //};
                // TeamList.Clear();

                // TeamList.Add(new TeamView { exp_TreeName = "Team 1", ChildNodes = FolderList });
                // TeamList.Add(new TeamView { exp_TreeName = "Team 2", ChildNodes = FolderList });

                //var TeamList = new List<ITreeNode>
                //{ 
                //    new TeamView { exp_TreeName = "Team 1", ChildNodes = FolderList },
                //    new TeamView { exp_TreeName = "Team 2", ChildNodes = FolderList }
                //};

                // FileAndFolderList.Clear();
                FolderList.Clear();
                TeamList.Clear();
                ProjectList.Clear();
                await CreateListAsync(ProjectList, TeamList, FolderList, FileAndFolderList);

                //ProjectList.Add(new ProjectView { exp_TreeName = "Project 1", ChildNodes = TeamList });
                //ProjectList.Add(new ProjectView { exp_TreeName = "Project 2", ChildNodes = TeamList });

                LevelDatas.Clear();
                LevelDatas.AddRange(ProjectList.ToArray());
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

        #region CreateList

        //private async Task CreateList()
        //{
        //    try
        //    {
        //        FileList.Add(new FileView { exp_TreeName = "테스트 파일 3" });
        //        FileList.Add(new FileView { exp_TreeName = "테스트 파일 4" });

        //        //var TestList = new List<ITreeNode> 
        //        //{  
        //        //    new FileView { exp_TreeName = "Sub File 1" },
        //        //    new FileView { exp_TreeName = "Sub File 2" }
        //        //};

        //        FileAndFolderList.Add(new FileView { exp_TreeName = "테스트 파일 1" });
        //        FileAndFolderList.Add(new FileView { exp_TreeName = "테스트 파일 2" });
        //        FileAndFolderList.Add(new SubFolderView { exp_TreeName = "테스트 서브폴더 1", ChildNodes = FileList });
        //        FileAndFolderList.Add(new SubFolderView { exp_TreeName = "테스트 서브폴더 2", ChildNodes = FileList });

        //        //var FileList = new List<ITreeNode>
        //        //{
        //        //    new FileView { exp_TreeName = "File 1" },
        //        //    new FileView { exp_TreeName = "File 2" },
        //        //    new SubFolderView { exp_TreeName = "Sub Folder 1" },
        //        //    new SubFolderView { exp_TreeName = "Sub Folder 2" }
        //        //};

        //        //FolderList.Add(new FolderView { exp_TreeName = "Folder 1", ChildNodes = FileAndFolderList });
        //        //FolderList.Add(new FolderView { exp_TreeName = "Folder 2", ChildNodes = FileAndFolderList });
        //        //FolderList.Add(new FolderView { exp_TreeName = "Folder 3", ChildNodes = FileAndFolderList });
        //        //FolderList.Add(new FolderView { exp_TreeName = "Folder 4", ChildNodes = FileAndFolderList });



        //        // await AddFolderAndFileList(FolderList, FileAndFolderList);

        //        //var FolderList = new List<ITreeNode>
        //        //{
        //        //    new FolderView { exp_TreeName = "Folder 1", ChildNodes = FileList },
        //        //    new FolderView { exp_TreeName = "Folder 2", ChildNodes = FileList },
        //        //    new FolderView { exp_TreeName = "Folder 3", ChildNodes = FileList },
        //        //    new FolderView { exp_TreeName = "Folder 4", ChildNodes = FileList }
        //        //};
        //        // TeamList.Clear();

        //        // TeamList.Add(new TeamView { exp_TreeName = "Team 1", ChildNodes = FolderList });
        //        // TeamList.Add(new TeamView { exp_TreeName = "Team 2", ChildNodes = FolderList });

        //        //var TeamList = new List<ITreeNode>
        //        //{ 
        //        //    new TeamView { exp_TreeName = "Team 1", ChildNodes = FolderList },
        //        //    new TeamView { exp_TreeName = "Team 2", ChildNodes = FolderList }
        //        //};

        //        // FileAndFolderList.Clear();
        //        FolderList.Clear();
        //        TeamList.Clear();
        //        ProjectList.Clear();
        //        await CreateListAsync(ProjectList, TeamList, FolderList, FileAndFolderList);

        //        //ProjectList.Add(new ProjectView { exp_TreeName = "Project 1", ChildNodes = TeamList });
        //        //ProjectList.Add(new ProjectView { exp_TreeName = "Project 2", ChildNodes = TeamList });

        //        LevelDatas.Clear();
        //        LevelDatas.AddRange(ProjectList.ToArray());
        //    }
        //    catch (Exception e)
        //    {
        //        Log.Logger.Information(e.Message);
        //        throw;
        //    }
        //}

        #endregion CreateList

        #region ToDictionary

        private Dictionary<string, object> ToDictionary(object obj)
        {
            var json = JsonSerializer.Serialize(obj);
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            return dictionary;
        }

        #endregion ToDictionary

        //#region AddFolderAndFileList

        //private Task AddFolderAndFileList(List<ITreeNode> folderList, List<ITreeNode> fileAndFolderList)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}

        //#endregion AddFolderAndFileList

        #region CreateListAsync

        // TODO : 프로젝트 - 팀 - 폴더 - 서브폴더/파일 리스트 생성 해주는 메서드 "CreateListAsync" 구현 (2023.09.12 jbh)
        /// <summary>
        /// 프로젝트 - 팀 - 폴더 - 서브폴더/파일 리스트 생성
        /// 메서드 파라미터 List<ITreeNode> pSubFolderFileList 추가 여부 확인 
        /// </summary>
        private async Task CreateListAsync(List<ProjectView> pProjectList, List<ITreeNode> pTeamList, List<List<ITreeNode>> pFolderList, List<ITreeNode> pFileAndFolderList)
        {
            string projectId = string.Empty;                // JSON 프로젝트 아이디
            string projectName = string.Empty;              // JSON 프로젝트 이름 
            string jsonProjectTeamPath = string.Empty;      // JSON 프로젝트 + 팀 테스트 데이터 경로
            string jsonFolderPath = string.Empty;           // JSON 폴더 테스트 데이터 경로 

            string jsonteam = string.Empty;                 // JSON 팀 전체 데이터
            string teamProjectId = string.Empty;            // JSON 팀의 상위 프로젝트 아이디
            string teamId = string.Empty;                   // JSON 팀 아이디
            string teamName = string.Empty;                 // JSON 팀 이름 

            string folderName = string.Empty;               // JSON 폴더 이름 
            string parentFolderId = string.Empty;           // JSON 부모 폴더 아이디
            string folderGroupId = string.Empty;            // JSON 폴더 그룹 아이디 
            string folderId = string.Empty;                 // JSON 폴더 아이디
            string folderLevelNo = string.Empty;            // JSON 폴더 레벨 (상위 폴더 또는 하위 폴더 분류 기준) 

            string fileJson = string.Empty;                 // JSON 파일 리스트 문자열 
            int folderIndex = 0;                            // JSON 파일 폴더 인덱스

            try
            {
                // TODO : JSON 파일 "example.json" 파일 경로 설정 및 File.ReadAllBytes 메서드 호출문 구현 (2023.08.31 jbh)
                // 참고 URL - https://blog.naver.com/heennavi1004/222100360201
                // 테스트 json 파일 "example.json" 파일 경로 설정 "jsonProjectTeamPath" (2023.08.31 jbh)
                // string jsonProjectTeamPath = @"D:\bhjeon\WPFStudy\JsonTreeView\JsonTreeView\example.json";

                // 테스트 json 파일 "example2.json" 파일 경로 설정 "jsonProjectTeamPath" (2023.09.07 jbh)
                // jsonProjectTeamPath = @"D:\bhjeon\WPFStudy\JsonTreeView\JsonTreeView\example2.json";

                // JSON 데이터 구조 변경 -> 테스트 json 파일 "example.json" 파일 경로 설정 "jsonProjectTeamPath" (2023.09.07 jbh)
                jsonProjectTeamPath = @"D:\bhjeon\WPFStudy\JsonTreeView\JsonTreeView\example.json";

                // TODO : JSON 데이터 -> byte[] 배열 SerializeToUtf8Bytes() 변환 구현 (2023.08.31 jbh)
                // 참고 URL - https://developer-talk.tistory.com/213
                var json = File.ReadAllText(jsonProjectTeamPath);

                var jtmp = (JsonObject.Parse(json)[ProjectHelper.projectWithTeamInfos] as JsonArray).Select(x => x);

                var datas = jtmp.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();

                foreach (var data in datas)
                {
                    // var projectArray = jtmp.Select(x => x["projectEntity"]).Select(x => x);  // (data["projectEntity"] as JsonArray);
                    var projectDic = ToDictionary(data[ProjectHelper.projectEntity]);
                    // Dictionary 객체 projectDic 특정 키(Key) "projectId"에 속하는 값(Value) 문자열로 변환 (2023.09.11 jbh)
                    // 참고 URL - https://developer-talk.tistory.com/694
                    projectId = projectDic[ProjectHelper.projectId].ToString();
                    projectName = projectDic[ProjectHelper.projectName].ToString();

                    // var jsonList = jtmp.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();
                    // var teamList = jtmp.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x["teamEntity"])).ToList(); // (data["teamEntity"] as JsonArray);



                    // jsonteam = data["teamEntity"].ToString();
                    // TODO : 팀에 소속된 사용자 리스트 JSON 데이터 인재 INC 로부터 REST API 공유 받으면 구현 진행 예정 (2023.09.12 jbh)
                    // jsonteam = ""; 

                    // TODO : 특정 팀에 소속된 사용자 리스트 데이터 "teamUserList" 추출 (2023.09.12 jbh)
                    // var teamUsersJson = (JsonObject.Parse(jsonteam)[TeamHelper.teamUserList] as JsonArray).Select(x => x);

                    // var teamUserList = teamUsersJson.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();

                    // TODO : teamUserList -> Dictionary로 형 변환 처리 예정(2023.09.12 jbh) 
                    // 참고 URL - https://yeko90.tistory.com/entry/difference-between-select-selectmany
                    // var teamUserDic = teamUserList.SelectMany(value => value).ToDictionary(key => key.Key, value => value.Value);

                    var teamDic = ToDictionary(data[TeamHelper.teamEntity]);
                    teamProjectId = teamDic[ProjectHelper.projectId].ToString();
                    teamId = teamDic[TeamHelper.teamId].ToString();
                    teamName = teamDic[TeamHelper.teamName].ToString();

                    // TODO : 파일 리스트 JSON 데이터 인재 INC 로부터 REST API 공유 받으면 구현 진행 예정 (2023.09.12 jbh)
                    // TODO : JSON 문자열 객체 fileJson에 데이터가 존재하지 않을 경우 NULL 예외처리 삼항 연산자 구현 (2023.09.11 jbh)
                    // 참고 URL - https://jellyho.com/blog/54/
                    // 참고 2 URL - https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=traeumen927&logNo=220968723242
                    //fileJson = folder[FileHelper.fileList].ToString();

                    // TODO : 파일 리스트(fileList) 구할 때에 부모 폴더(루트 폴더) 아이디만 존재하는 파일 목록만 추출하도록 Linq로 구현하기(2023.09.13 jbh)
                    //var fileList = (fileJson.Length <= 2) ? new List<Dictionary<string, object>>() : fileJson.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();

                    // TODO : 서브폴더 하위 파일 리스트 데이터 추가 구현 예정 (2023.09.13 jbh)
                    // 1 단계 : 서브폴더 하위 파일 리스트 데이터 추가 
                    //for (var file in fileList)
                    //{
                    //    if ()
                    //    {
                    //        FileInfo = new FileView()
                    //        {

                    //        }
                    //        pFileList
                    //    }
                    //}

                    // 2 단계 : 서브 폴더 하위 파일 데이터(FileList) 추가 + 폴더 없이 파일 데이터 추가 
                    if (projectId.Equals(ProjectHelper.testProjectId) && teamId.Equals(ProjectHelper.testTeamId))
                        // TODO : 테스트 폴더 목록 json 파일 "Subexample3.json" 파일 경로 설정 "jsonProjectTeamPath" (2023.09.12 jbh)
                        jsonFolderPath = @"D:\bhjeon\WPFStudy\JsonTreeView\JsonTreeView\Subexample3.json";

                    else if (projectId.Equals("jc-constrct") && teamId.Equals("inc-001-jc-constrct-t001"))
                        // TODO : 테스트 폴더 목록  json 파일 "Subexample.json" 파일 경로 설정 "jsonProjectTeamPath" (2023.09.07 jbh)
                        jsonFolderPath = @"D:\bhjeon\WPFStudy\JsonTreeView\JsonTreeView\Subexample.json";
                    else if (projectId.Equals("project-09-01-aa") && teamId.Equals("inc-001-project-09-01-aa-t002"))
                        // TODO : 테스트 폴더 목록  json 파일 "Subexample2.json" 파일 경로 설정 "jsonProjectTeamPath" (2023.09.07 jbh)
                        jsonFolderPath = @"D:\bhjeon\WPFStudy\JsonTreeView\JsonTreeView\Subexample2.json";

                    else
                    {
                        MessageBox.Show("프로젝트 아이디 오류");
                        return;
                    }

                    // TODO : 테스트 JSON 데이터 -> byte[] 배열 SerializeToUtf8Bytes() 변환 구현 추후 필요 없을시 삭제 예정 (2023.08.31 jbh)
                    // 참고 URL - https://developer-talk.tistory.com/213
                    var jsonFolder = File.ReadAllText(jsonFolderPath);


                    // TODO : 테스트 JSON 데이터(jtmpFolder) -> Dictionary<string, object> 변환(Convert) 구현 및 var jtmp에 데이터 할당 (2023.08.30 jbh)
                    //        할당 받은 데이터 var jtmpFolder는 조사식 -> 키워드 "jtmpFolder" 입력 및 엔터(또는 해당 var jtmpFolder 클릭 및 조사식으로 드래그) -> Results View 에서 확인 가능 - var 자료형 이여서 IEnumerable<JsonNode> 형태이기 때문 (2023.09.04 jbh)
                    // TODO : JSON 데이터(jtmpFolder) 를 JsonObject.Parse(jsonFolder) 사용해서 "resultData" 항목만 파싱(Json Object(객체) 변환) -> 파싱한 Json Object(객체)안에 존재하는 데이터들을 JsonArray (JSON 배열) 변환
                    var jtmpFolder = (JsonObject.Parse(jsonFolder)[ProjectHelper.resultData] as JsonArray).Select(x => x);

                    // TODO : jtmpFolder -> Select 메서드 사용 -> Dictionary<string, object>>(x) 형태로 Deserialize -> Deserialize해서 나온 Dictionary 객체를 List로 변환 및 해당 List에 속한 데이터를 var jsonList에 할당 (2023.08.31 jbh) 
                    //        할당 받은 데이터 var jsonList 조사식 -> 키워드 "jsonList" 입력 및 엔터(또는 해당 var jsonList 클릭 및 조사식으로 드래그) 확인 가능
                    //var folderList = jtmpFolder.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();

                    // TODO : 폴더 리스트에 속한 폴더 데이터 Dictionary 객체의 Key "levelNo"의 값(Value)을 기준으로 내림차순(OrderByDescending) 정렬하여 리스트 구현 (2023.09.12 jbh)
                    // 참고 URL - https://codechacha.com/ko/csharp-sort-list/
                    // 참고 2 URL - https://developer-talk.tistory.com/694
                    // 참고 3 URL - https://developer-talk.tistory.com/210
                    var folderList = jtmpFolder.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).OrderByDescending(x => Int32.Parse(x[FolderHelper.levelNo].ToString())).ToList();

                    // TODO : 폴더 리스트에 속한 폴더 데이터 Dictionary 객체의 Key "levelNo"의 값(Value)을 기준으로 오름차순(OrderBy) 정렬하여 리스트 구현 (2023.09.12 jbh)
                    // Int32.Parse 메서드 사용 방법 
                    // 참고 URL - https://2-nan.tistory.com/43
                    // var folderList = jtmpFolder.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).OrderBy(x => Int32.Parse(x[FolderHelper.levelNo].ToString())).ToList();

                    foreach (var folder in folderList)
                    {
                        // TODO : NULL 예외처리 연산자 ?. 사용시 오류 발생으로 인하여 NULL 예외처리 삼항 연산자 사용하는 로직으로 수정 (2023.09.11 jbh)
                        // 참고 URL - https://jellyho.com/blog/54/
                        parentFolderId = (folder[FolderHelper.parentFolderId] == null) ? (string.Empty) : (folder[FolderHelper.parentFolderId].ToString());

                        folderGroupId = folder[FolderHelper.folderGroupId].ToString();
                        folderId = folder[FolderHelper.folderId].ToString();
                        folderName = folder[FolderHelper.folderName].ToString();
                        folderLevelNo = folder[FolderHelper.levelNo].ToString();
                        

                        // 3 단계 : 팀 밑에 루트 디렉토리(폴더) 하위 서브폴더(또는 하위 폴더) 데이터 추가	

                        // TODO : 파일 리스트 JSON 데이터 인재 INC 로부터 REST API 공유 받으면 구현 진행 예정 (2023.09.12 jbh)
                        // TODO : JSON 문자열 객체 fileJson에 데이터가 존재하지 않을 경우 NULL 예외처리 삼항 연산자 구현 (2023.09.11 jbh)
                        // 참고 URL - https://jellyho.com/blog/54/
                        // 참고 2 URL - https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=traeumen927&logNo=220968723242
                        //fileJson = folder[FileHelper.fileList].ToString();

                        // TODO : 파일 리스트(fileList) 구할 때에 부모 폴더(루트 폴더 또는 서브폴더) 아이디가 존재하는 파일 목록만 추출하도록 Linq로 구현하기(2023.09.13 jbh)
                        //var fileList = (fileJson.Length <= 2) ? new List<Dictionary<string, object>>() : fileJson.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();


                        // TODO : 팀 밑에 루트 디렉토리(폴더) 하위 파일 존재하지 않을 경우 새로 생성 구현 예정 (2023.09.13 jbh)
                        //if (1. 부모 폴더 id 값이 null이 아니고 
                        //    && 2. 파일 id 값이 null이 아니고 
                        //    && 3.부모 폴더 존재
                        //    && 4. 부모폴더가 루트 디렉토리("levelNo": 0) 조건 만족)
                        //{
                        //    // 하위 파일 
                        //    FileInfo = new FileView()
                        //    {

                        //    };

                        //    pFileAndFolderList.Add(FileInfo);
                        //}

                        // 폴더(+ 서브 폴더) 생성 
                        // !string.IsNullOrWhiteSpace(parentFolderId)
                        if (!string.IsNullOrWhiteSpace(folderGroupId)
                            && !string.IsNullOrWhiteSpace(folderId)
                            && !string.IsNullOrWhiteSpace(folderName)
                            && !string.IsNullOrWhiteSpace(folderLevelNo))
                        {
                            if (TestSubFolderInfo != null)
                            {
                                SubFolderList = new List<ITreeNode>();

                                SubFolderList.Add(TestSubFolderInfo);
                            }
                            

                            FolderInfo = new FolderView()
                            {
                                FolderDataInfo = ToDictionary(folder),
                                FolderItems = new List<Dictionary<string, object>> { folder },
                                exp_TreeParentFolderId = parentFolderId,
                                exp_TreeFolderGroupId = folderGroupId,
                                exp_TreeFolderId = folderId,
                                exp_TreeName = folderName,
                                exp_TreeFolderLevelNo = folderLevelNo,
                                // TODO : 파일 리스트 추가 작업시 ChildNodes 사용 예정 (2023.09.14 jbh)
                                //ChildNodes = pFileAndFolderList
                                ChildNodes = SubFolderList
                            };

                            TestSubFolderInfo = FolderInfo;

                            // FolderView 클래스 객체 FolderInfo 가 들어갈 자리(껍데기) 만들어 줌.
                            pFolderList.Add(new List<ITreeNode>());

                            pFolderList[folderIndex].Add(FolderInfo);

                            folderIndex += 1;

                            // await CreateFolderAsync(FolderInfo);
                        }

                      


                        // 서브 폴더 밑에 서브 폴더 (Level2 이상) 존재하지 않을 경우 새로 생성 
                        // 서브 폴더 존재하지 않을 경우 새로 생성  
                        //if (!string.IsNullOrWhiteSpace(parentFolderId)
                        //    && !string.IsNullOrWhiteSpace(folderGroupId)
                        //    && !string.IsNullOrWhiteSpace(folderId)
                        //    && !string.IsNullOrWhiteSpace(folderName)
                        //    && !folderLevelNo.Equals(FolderHelper.level1SubFolder))
                        //{


                        //    // 서브 폴더
                        //    SubFolderInfo = new SubFolderView()
                        //    {
                        //        SubFolderDataInfo = ToDictionary(folder),
                        //        SubFolderItems = new List<Dictionary<string, object>> { folder },
                        //        exp_TreeParentFolderId = parentFolderId,
                        //        exp_TreeFolderGroupId = folderGroupId,
                        //        exp_TreeFolderId = folderId,
                        //        exp_TreeName = folderName,
                        //        // TODO : 서브 폴더 밑의 하위 파일 리스트 "FileList" 구현 및 ChildNodes에 추가 예정 (2023.09.14 jbh)
                        //        //ChildNodes = , // pSubFolderFileList
                        //    };

                        //    // 테스트용 루트 폴더 
                        //    FolderInfo = new FolderView()
                        //    {
                        //        FolderDataInfo = ToDictionary(folder),
                        //        FolderItems = new List<Dictionary<string, object>> { folder },
                        //        exp_TreeParentFolderId = parentFolderId,
                        //        exp_TreeFolderGroupId = folderGroupId,
                        //        exp_TreeFolderId = folderId,
                        //        exp_TreeFolderLevelNo = folderLevelNo,
                        //        exp_TreeName = folderName,

                        //        // ChildNodes = pFileAndFolderList
                        //    };

                        //    // var folderNodes = new List<ITreeNode>();

                        //    // folderNodes.Add(FolderInfo);
                        //    // folderNodes.Add(SubFolderInfo);

                        //    await CreateFolderAsync(FolderInfo);

                        //    // SubFolderList.Add(SubFolderInfo);

                        //    // SubFolderInfo.ChildNodes.Add(SubFolderInfo);

                        //    // pFileAndFolderList.Add(SubFolderInfo);
                        //}


                        // 루트 디렉토리(Level 0) 바로 밑 서브 폴더(Level 1) 존재하지 않을 경우 새로 생성  
                        //if (!string.IsNullOrWhiteSpace(parentFolderId)
                        //    && !string.IsNullOrWhiteSpace(folderGroupId)
                        //    && !string.IsNullOrWhiteSpace(folderId)
                        //    && !string.IsNullOrWhiteSpace(folderName)
                        //    && folderLevelNo.Equals(FolderHelper.level1SubFolder)
                        //    && folderGroupId.Equals(parentFolderId))
                        //{
                        //    // 서브 폴더
                        //    SubFolderInfo = new SubFolderView()
                        //    {
                        //        SubFolderDataInfo = ToDictionary(folder),
                        //        SubFolderItems = new List<Dictionary<string, object>> { folder },
                        //        exp_TreeParentFolderId = parentFolderId,
                        //        exp_TreeFolderGroupId = folderGroupId,
                        //        exp_TreeFolderId = folderId,
                        //        exp_TreeName = folderName,
                        //        // ChildNodes = pSubFolderFileList
                        //        ChildNodes = SubFolderList,   // SubFolderInfo.ChildNodes
                        //        TestChildNodes = testSubFolderList
                        //    };

                        //    pFileAndFolderList.Add(SubFolderInfo);

                        //    // TODO : 파일 타입일 경우 구현 예정 (2023.09.13) 
                        //    FileInfo = new FileView()
                        //    {
                        //        exp_TreeName = "파일 테스트"
                        //    };

                        //    pFileAndFolderList.Add(FileInfo);
                        //}

                        //// 루트 디렉토리(Level 0) 바로 밑 서브 폴더(Level 1) 존재하지 않을 경우 새로 생성  
                        //if (!string.IsNullOrWhiteSpace(parentFolderId)
                        //    && !string.IsNullOrWhiteSpace(folderGroupId)
                        //    && !string.IsNullOrWhiteSpace(folderId)
                        //    && !string.IsNullOrWhiteSpace(folderName)
                        //    && folderLevelNo.Equals(FolderHelper.level1SubFolder)
                        //    && folderGroupId.Equals(parentFolderId))
                        //{
                        //    // 서브 폴더
                        //    SubFolderInfo = new SubFolderView()
                        //    {
                        //        SubFolderDataInfo = ToDictionary(folder),
                        //        SubFolderItems = new List<Dictionary<string, object>> { folder },
                        //        exp_TreeParentFolderId = parentFolderId,
                        //        exp_TreeFolderGroupId = folderGroupId,
                        //        exp_TreeFolderId = folderId,
                        //        exp_TreeName = folderName,
                        //        // ChildNodes = pSubFolderFileList
                        //        ChildNodes = SubFolderNode
                        //    };

                        //    pFileAndFolderList.Add(SubFolderInfo);
                        //}


                        // 팀 밑에 루트 디렉토리 (폴더) 존재하지 않을 경우 새로 생성 및 하위 서브폴더(또는 하위 파일) 데이터(pFileAndFolderList) 추가	
                        //if (string.IsNullOrWhiteSpace(parentFolderId)
                        //    && !string.IsNullOrWhiteSpace(folderGroupId)
                        //    && !string.IsNullOrWhiteSpace(folderId)
                        //    && !string.IsNullOrWhiteSpace(folderName)
                        //    && !string.IsNullOrWhiteSpace(folderLevelNo)
                        //    && folderLevelNo.Equals(FolderHelper.rootFolder)
                        //    && folderGroupId.Equals(folderId))
                        //{
                        //    FolderInfo = new FolderView()
                        //    {
                        //        FolderDataInfo = ToDictionary(folder),
                        //        FolderItems = new List<Dictionary<string, object>> { folder },
                        //        exp_TreeParentFolderId = parentFolderId,
                        //        exp_TreeFolderGroupId = folderGroupId,
                        //        exp_TreeFolderId = folderId,
                        //        exp_TreeName = folderName,
                        //        ChildNodes = pFileAndFolderList
                        //    };

                        //    pFolderList.Add(FolderInfo);
                        //}



                        // 폴더 데이터 리스트 "folderList" (파일 리스트 포함) -> Dictionary 객체 "FolderDataInfo"로 변환
                        // folderList Value 값 타입을 object로 변환하기 위해 as 연산자 사용 
                        // 참고 URL - https://inasie.tistory.com/14
                        // var folderDic = folderList.ToDictionary(key => key.Keys.ToString(), value => value.Values as object);

                        // TODO : folderList -> Dictionary로 형 변환 처리 예정(2023.09.08 jbh) 
                        // 참고 URL - https://yeko90.tistory.com/entry/difference-between-select-selectmany
                        // var folderDic = folderList.SelectMany(value => value).ToDictionary(key => key.Key, value => value.Value);

                        // TODO : NULL 예외처리 연산자 ?. 구현 (2023.09.11 jbh)
                        // (folderDic["parentFolderId"].ToString() 문자열이 Null일 경우 parentFolderId에 null로 저장) (2023.09.11 jbh)
                        // 참고 URL - https://skuld2000.tistory.com/17
                        // 참고 2 URL - https://afsdzvcx123.tistory.com/entry/C-%EB%AC%B8%EB%B2%95-C-Null-%EA%B4%80%EB%A0%A8-%EC%97%B0%EC%82%B0%EC%9E%90-%EA%B8%B0%ED%98%B8
                        //if (string.IsNullOrWhiteSpace(folderDic["parentFolderId"].ToString()))
                        //{
                        //    parentFolderId = "    ";
                        //    // parentFolderId = folderDic["parentFolderId"].ToString()?.ToString();
                        //}



                        // TODO : 파일 리스트 JSON 데이터 인재 INC 로부터 REST API 공유 받으면 구현 진행 예정 (2023.09.12 jbh)
                        // TODO : JSON 문자열 객체 fileJson에 데이터가 존재하지 않을 경우 NULL 예외처리 삼항 연산자 구현 (2023.09.11 jbh)
                        // 참고 URL - https://jellyho.com/blog/54/
                        // 참고 2 URL - https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=traeumen927&logNo=220968723242
                        //fileJson = folder[FileHelper.fileList].ToString();


                        //var fileList = (fileJson.Length <= 2) ? new List<Dictionary<string, object>>() : fileJson.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();


                        // TODO : 폴더 하위 서브 폴더(또는 파일) 존재하지 않을 경우 새로 생성 추후 구현 예정 (2023.09.11 jbh)
                        // 구현 방식 1
                        //if (levelNo != 0 && SubFolder.parentFolderId == Folder.folderId)
                        //{
                        //    var FileList = new List<ITreeNode>
                        //    {
                        //        new FileView { exp_TreeName = "File 1" },
                        //        new FileView { exp_TreeName = "File 2" },
                        //        new SubFolderView { exp_TreeName = "Sub Folder 1" },
                        //        new SubFolderView { exp_TreeName = "Sub Folder 2" }
                        //    };
                        //}

                        // TODO : 폴더 하위 디렉토리 (서브 폴더) 존재하지 않을 경우 새로 생성 추후 구현 예정 (2023.09.11 jbh)
                        // 구현 방식 2
                        //else if ()
                        //{
                        //    var FileList = new List<ITreeNode> 
                        //    {
                        //        new SubFolderView() { }
                        //        new SubFolderView { exp_TreeName = "Sub Folder 2" }
                        //    };

                        //    pFileAndFolderList
                        //}

                        // 서브 폴더 하위 파일 존재하지 않을 경우 새로 생성 


                        // 팀 하위 디렉토리 (폴더) 존재하지 않을 경우 새로 생성 
                        //if (string.IsNullOrWhiteSpace(parentFolderId)
                        //    && !string.IsNullOrWhiteSpace(folderGroupId)
                        //    && !string.IsNullOrWhiteSpace(folderId)
                        //    && !string.IsNullOrWhiteSpace(folderName)
                        //    && !string.IsNullOrWhiteSpace(folderLevelNo)
                        //    && folderLevelNo.Equals(FolderHelper.topLevelFolder))
                        //{
                        //    FolderInfo = new FolderView()
                        //    {
                        //        FolderDataInfo = ToDictionary(folder),
                        //        FolderItems = new List<Dictionary<string, object>> { folder },
                        //        exp_TreeParentFolderId = parentFolderId,
                        //        exp_TreeFolderGroupId = folderGroupId,
                        //        exp_TreeFolderId = folderId,
                        //        exp_TreeName = folderName,
                        //        ChildNodes = pFileAndFolderList
                        //    };

                        //    pFolderList.Add(FolderInfo);
                        //}


                    }


                    // 폴더 (+ 서브 폴더) 리스트 역순 정렬 
                    // 참고 URL - https://shoney.tistory.com/entry/C-%EB%94%95%EC%85%94%EB%84%88%EB%A6%AC-%EB%B0%8F-2%EC%B0%A8%EC%9B%90-List-%EC%A0%95%EB%A0%AC-%EB%B0%A9%EB%B2%95
                    TestFolderNodes = pFolderList.OrderByDescending(x => x[0]);


                    // 프로젝트 하위 디렉토리 (팀) 존재하지 않을 경우 새로 생성 
                    if (!string.IsNullOrWhiteSpace(teamProjectId)
                        && !string.IsNullOrWhiteSpace(teamId)
                        && !string.IsNullOrWhiteSpace(teamName))
                    {
                        if (!string.IsNullOrWhiteSpace(projectId) 
                            && projectId.Equals(teamProjectId))
                        {
                            TeamInfo = new TeamView()
                            {
                                TeamDataInfo = teamDic ,
                                // TODO : TeamItems값이 NULL인 원인 파악 후 해결하기(2023.09.11 jbh) 
                                // TeamItems = teamArray.Where(key => key["teamId"].Equals(teamIdValue)).Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList(),
                                TeamItems = new List<Dictionary<string, object>> { teamDic },
                                // TODO : 팀에 소속된 사용자 리스트 JSON 데이터 인재 INC 로부터 REST API 공유 받으면 구현 진행 예정 (2023.09.12 jbh)
                                // TeamUserList = new List<Dictionary<string, object>> { teamUserDic },
                                exp_TreeTeamId = teamId,
                                exp_TreeName = teamName,
                                // TestChildNodes = pFolderList

                                TestChildNodes = TestFolderNodes
                                // ChildNodes = pFolderList
                            };

                            pTeamList.Add(TeamInfo);
                        }
                        
                    }

                    // 루트 디렉토리 (프로젝트) 존재하지 않을 경우 새로 생성
                    if (!string.IsNullOrWhiteSpace(projectId)
                        && !string.IsNullOrWhiteSpace(projectName)
                        && projectId.Equals(teamProjectId))
                    {
                        ProjectInfo = new ProjectView()
                        {
                            ProjectDataInfo = projectDic,
                            // TODO : ProjectItems값이 NULL인 원인 파악 후 해결하기(2023.09.11 jbh)
                            ProjectItems = new List<Dictionary<string, object>> { projectDic },
                            exp_TreeProjectId = projectId,
                            exp_TreeName = projectName,
                            ChildNodes = pTeamList.Where(key => key.exp_TreeName.Equals(teamName)).ToList()
                        };

                        pProjectList.Add(ProjectInfo);
                    }
                }
            }
            catch (Exception e)
            {
                Log.Logger.Information(e.Message);
                throw;
            }
        }

        #endregion CreateListAsync

        #region CreateSubFolderAsync

        /// <summary>
        /// 폴더(+서브 폴더) 생성
        /// </summary>
        /// <param name="subFolderView"></param>
        /// <returns></returns>
        private async Task CreateFolderAsync (FolderView folderNodes)
        {
            // string folderLevelNo = string.Empty; // 생성할 폴더 레벨 

            // Int32.Parse 메서드 사용 방법 
            // 참고 URL - https://2-nan.tistory.com/43
            int levelNo = Int32.Parse(folderNodes.exp_TreeFolderLevelNo);   // 생성할 폴더 레벨 
            int rootLevelNo = Int32.Parse(FolderHelper.rootFolder);         // 루트 폴더 레벨 
            int index = 0;

            try
            {
                // C# 2차원 리스트 참고 자료 
                // 참고 URL - https://codechacha.com/ko/csharp-init-2d-list/

                // C# 2차원 리스트 데이터(요소) 추가 
                // 참고 URL - https://gamedevst.tistory.com/11

                if (FolderList.ElementAtOrDefault(levelNo) == null)
                {
                    SubFolderList = new List<ITreeNode>();
                    // SubFolderList.Add(folderNodes);
                    // FolderList.Add(SubFolderList);
                }
                else
                {
                    folderNodes.ChildNodes = SubFolderList;

                }

                // FolderList[index].Add(folderNodes);

                index++;

                // SubFolderList.Add(folderNodes);



                    // 루트 폴더 아닐 경우 
                //else
                //{
                //    folderNodes.ChildNodes = SubFolderList;
                //}

                //FolderList[LevelNo].Add(folderNodes);


                // folderNodes.ChildNodes = 

                // folderNodes.ChildNodes = ;






                //if (FolderList.ElementAtOrDefault(LevelNo) == null)
                //{
                //    SubFolderList = new List<ITreeNode>();

                //    FolderList.Add(SubFolderList);
                //}

                //SubFolderList = new List<ITreeNode>();

                //SubFolderList.Add(folderNodes);

                //folderNodes.ChildNodes = SubFolderList;

                //FolderList[LevelNo].Add(folderNodes);




                // 생성할 폴더가 루트 폴더인 경우 
                //if (LevelNo.Equals(rootLevelNo))
                //{
                //    SubFolderList.Add(folderNodes);
                //}

                // 생성할 폴더가 루트 폴더가 아닌 경우 SubFolderList에 데이터 folderNodes 추가 
                // if (!LevelNo.Equals(rootLevelNo))
                // {
                //     SubFolderList.Add(folderNodes);
                // }

                // FolderList[0].Add(folderNodes);
                //FolderList.Add(SubFolderList);

                // FolderList[0].Add(folderNodes);


                // TODO : (루트 폴더 + 서브 폴더)를 포함하는 리스트를 2차원 리스트 객체 "testSubFolderList"로 구현 예정 (2023.09.14 jbh)
                // 1. FolderList에 루트 폴더(exp_TreeFolderLevelNo = "0") 데이터 추가 
                //if (folderLevelNo.Equals(FolderHelper.rootFolder))
                //{
                //    FolderList[].Add(folderNodes);
                //}

                // 2. FolderList에 서브 폴더 데이터 추가 및 부모폴더(또는 루트폴더)와 연결  
                //else
                //{
                //    FolderList.Add(folderNodes);
                //}

                // C# 2차원 리스트 참고 자료 
                // 참고 URL - https://codechacha.com/ko/csharp-init-2d-list/

                //if (1. 해당 부모 폴더 아이디 
                //    && 2. 폴더 그룹 아이디 ) 
                //{
                //    SubFolderList.Add(subFolderView);
                //}
                //testSubFolderList.Where().Select().ToList().Add(subFolderView);

                //FolderList.Add(folderNodes);





            }
            catch (Exception e)
            {
                Log.Logger.Information(e.Message);
                throw;
            }
        }

        #endregion CreateSubFolderAsync

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
