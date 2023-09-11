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
    }

    public class TeamView : ITreeNode
    {
        public string exp_TreeName { get; set; }
        public List<ITreeNode> ChildNodes { get; set; }

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
    }

    public class FolderView : ITreeNode
    {
        public string exp_TreeName { get; set; }
        public List<ITreeNode> ChildNodes { get; set; }

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
        /// 폴더 목록 리스트
        /// </summary>
        //public List<ExplorerView> FolderItems { get; set; }
        public List<Dictionary<string, object>> FolderItems { get; set; }

        public Dictionary<string, object> FolderDataInfo { get; set; }  = new Dictionary<string, object>();
    }

    public class SubFolderView : ITreeNode
    {
        public string exp_TreeName { get; set; }
        public List<ITreeNode> ChildNodes { get; set; }

        /// <summary>
        /// 서브 폴더 목록 리스트
        /// </summary>
        public List<ExplorerView> SubFolderItems { get; set; } = new List<ExplorerView>();

        public Dictionary<string, object> SubFolderDataInfo { get; set; } = new Dictionary<string, object>();
    }

    public class FileView : ITreeNode
    {
        public string exp_TreeName { get; set; }
        public List<ITreeNode> ChildNodes { get; set; }

        /// <summary>
        /// 파일 목록 리스트
        /// </summary>
        public List<ExplorerView> FileItems { get; set; } = new List<ExplorerView>();

        public Dictionary<string, object> FileDataInfo { get; set; } = new Dictionary<string, object>();
    }

    public class TestTreeVM : Screen
    {
        #region 프로퍼티 
        /// <summary>
        /// TestCommand
        /// </summary>
        public ICommand TestCommand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ProjectView> ProjectList { get; set; } = new List<ProjectView>();

        /// <summary>
        /// 
        /// </summary>
        public List<ITreeNode> TeamList { get; set; } = new List<ITreeNode>();

        /// <summary>
        /// 
        /// </summary>
        public List<ITreeNode> FolderList { get; set; } = new List<ITreeNode>();

        /// <summary>
        /// 
        /// </summary>
        public List<ITreeNode> FileAndFolderList { get; set; } = new List<ITreeNode>();

        /// <summary>
        /// 
        /// </summary>
        public List<ITreeNode> FileList { get; set; } = new List<ITreeNode>();

        /// <summary>
        /// 
        /// </summary>
        public BindableCollection<ProjectView> LevelDatas { get; set; } = new BindableCollection<ProjectView>();

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
                await CreateList();
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

        private async Task CreateList()
        {
            try
            {
                FileList.Add(new FileView { exp_TreeName = "Sub File 1" });
                FileList.Add(new FileView { exp_TreeName = "Sub File 2" });

                //var TestList = new List<ITreeNode> 
                //{  
                //    new FileView { exp_TreeName = "Sub File 1" },
                //    new FileView { exp_TreeName = "Sub File 2" }
                //};

                FileAndFolderList.Add(new FileView { exp_TreeName = "File 1" });
                FileAndFolderList.Add(new FileView { exp_TreeName = "File 2" });
                FileAndFolderList.Add(new SubFolderView { exp_TreeName = "Sub Folder 1", ChildNodes = FileList });
                FileAndFolderList.Add(new SubFolderView { exp_TreeName = "Sub Folder 2", ChildNodes = FileList });

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
                await AddProjectTeamList(ProjectList, TeamList, FolderList, FileAndFolderList);

                //ProjectList.Add(new ProjectView { exp_TreeName = "Project 1", ChildNodes = TeamList });
                //ProjectList.Add(new ProjectView { exp_TreeName = "Project 2", ChildNodes = TeamList });

                LevelDatas.Clear();
                LevelDatas.AddRange(ProjectList.ToArray());
            }
            catch (Exception e)
            {
                Log.Logger.Information(e.Message);
                throw;
            }
        }

        #endregion CreateNode

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

        #region AddProjectList

        // TODO : 리스트 
        private async Task AddProjectTeamList(List<ProjectView> pProjectList, List<ITreeNode> pTeamList, List<ITreeNode> pFolderList, List<ITreeNode> pFileAndFolderList)
        {
            string projectId = string.Empty;                // JSON 프로젝트 아이디
            string jsonProjectTeamPath = string.Empty;      // JSON 프로젝트 + 팀 테스트 데이터 경로
            string jsonFolderPath = string.Empty;           // JSON 폴더 테스트 데이터 경로 
            string teamProjectId = string.Empty;            // JSON 팀의 상위 프로젝트 아이디
            string teamId = string.Empty;                   // JSON 팀 아이디
            string teamName = string.Empty;                 // JSON 팀 이름 
            string folderName = string.Empty;               // JSON 폴더 이름 
            string parentFolderId = string.Empty;           // JSON 부모 폴더 아이디
            string folderGroupId = string.Empty;            // JSON 폴더 그룹 아이디 
            string folderId = string.Empty;                 // JSON 폴더 아이디
            string fileJson = string.Empty;                 // JSON 파일 리스트 문자열 

            try
            {
                // TODO : JSON 파일 "example.json" 파일 경로 설정 및 File.ReadAllBytes 메서드 호출문 구현 (2023.08.31 jbh)
                // 참고 URL - https://blog.naver.com/heennavi1004/222100360201
                // 테스트 json 파일 "example.json" 파일 경로 설정 "jsonProjectTeamPath" (2023.08.31 jbh)
                // string jsonProjectTeamPath = @"D:\bhjeon\WPFStudy\JsonTreeView\JsonTreeView\example.json";

                // 테스트 json 파일 "example2.json" 파일 경로 설정 "jsonProjectTeamPath" (2023.09.07 jbh)
                jsonProjectTeamPath = @"D:\bhjeon\WPFStudy\JsonTreeView\JsonTreeView\example2.json";

                // TODO : JSON 데이터 -> byte[] 배열 SerializeToUtf8Bytes() 변환 구현 (2023.08.31 jbh)
                // 참고 URL - https://developer-talk.tistory.com/213
                var json = File.ReadAllText(jsonProjectTeamPath);

                var jtmp = (JsonObject.Parse(json)["resultData"] as JsonArray).Select(x => x);

                var datas = jtmp.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();

                foreach (var data in datas)
                {
                    // var projectArray = jtmp.Select(x => x["projectEntity"]).Select(x => x);  // (data["projectEntity"] as JsonArray);
                    var projectDic = ToDictionary(data["projectEntity"]);
                    // Dictionary 객체 projectDic 특정 키(Key) "projectId"에 속하는 값(Value) 문자열로 변환 (2023.09.11 jbh)
                    // 참고 URL - https://developer-talk.tistory.com/694
                    projectId = projectDic["projectId"].ToString();

                    // var jsonList = jtmp.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();
                    // var teamList = jtmp.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x["teamEntity"])).ToList(); // (data["teamEntity"] as JsonArray);
                    var teamDic = ToDictionary(data["teamEntity"]);
                    teamProjectId = teamDic["projectId"].ToString();
                    teamId = teamDic["teamId"].ToString();
                    teamName = teamDic["teamName"].ToString();


                    // 팀 하위 디렉토리 (폴더) 존재하지 않을 경우 새로 생성 
                    if (projectId.Equals("jc-constrct") && teamId.Equals("inc-001-jc-constrct-t001"))
                        // 테스트 json 파일 "example2.json" 파일 경로 설정 "jsonProjectTeamPath" (2023.09.07 jbh)
                        jsonFolderPath = @"D:\bhjeon\WPFStudy\JsonTreeView\JsonTreeView\Subexample.json";
                    else if (projectId.Equals("project-09-01-aa") && teamId.Equals("inc-001-project-09-01-aa-t002"))
                        // 테스트 json 파일 "example2.json" 파일 경로 설정 "jsonProjectTeamPath" (2023.09.07 jbh)
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
                    var folderList = jtmpFolder.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();



                    // 폴더 데이터 리스트 "folderList" (파일 리스트 포함) -> Dictionary 객체 "FolderDataInfo"로 변환
                    // folderList Value 값 타입을 object로 변환하기 위해 as 연산자 사용 
                    // 참고 URL - https://inasie.tistory.com/14
                    // var folderDic = folderList.ToDictionary(key => key.Keys.ToString(), value => value.Values as object);

                    // TODO : folderList -> Dictionary로 형 변환 처리 예정(2023.09.08 jbh) 
                    // 참고 URL - https://yeko90.tistory.com/entry/difference-between-select-selectmany
                    var folderDic = folderList.SelectMany(value => value).ToDictionary(key => key.Key, value => value.Value);

                    // TODO : NULL 예외처리 연산자 ?. 구현 (2023.09.11 jbh)
                    // (folderDic["parentFolderId"].ToString() 문자열이 Null일 경우 parentFolderId에 null로 저장) (2023.09.11 jbh)
                    // 참고 URL - https://skuld2000.tistory.com/17
                    // 참고 2 URL - https://afsdzvcx123.tistory.com/entry/C-%EB%AC%B8%EB%B2%95-C-Null-%EA%B4%80%EB%A0%A8-%EC%97%B0%EC%82%B0%EC%9E%90-%EA%B8%B0%ED%98%B8
                    //if (string.IsNullOrWhiteSpace(folderDic["parentFolderId"].ToString()))
                    //{
                    //    parentFolderId = "    ";
                    //    // parentFolderId = folderDic["parentFolderId"].ToString()?.ToString();
                    //}

                    // TODO : NULL 예외처리 연산자 ?. 사용시 오류 발생으로 인하여 NULL 예외처리 삼항 연산자 사용하는 로직으로 수정 (2023.09.11 jbh)
                    // 참고 URL - https://jellyho.com/blog/54/
                    parentFolderId = (folderDic["parentFolderId"] == null) ? (string.Empty) : (folderDic["parentFolderId"].ToString());
                    
                    folderGroupId = folderDic["folderGroupId"].ToString();
                    folderId = folderDic["folderId"].ToString();
                    folderName = folderDic["folderName"].ToString();

                    // TODO : JSON 문자열 객체 fileJson에 데이터가 존재하지 않을 경우 NULL 예외처리 삼항 연산자 구현 (2023.09.11 jbh)
                    // 참고 URL - https://jellyho.com/blog/54/
                    // 참고 2 URL - https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=traeumen927&logNo=220968723242
                    fileJson = folderDic["fileList"].ToString();
                    
                    
                    var fileList = (fileJson.Length <= 2) ? new List<Dictionary<string, object>>() : fileJson.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();

                    // 폴더 하위 서브 폴더(또는 파일) 존재하지 않을 경우 새로 생성 추후 구현 예정 (2023.09.11 jbh)
                    //if ()
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
                    //else
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
                    if (string.IsNullOrWhiteSpace(parentFolderId) 
                        && !string.IsNullOrWhiteSpace(folderGroupId)
                        && !string.IsNullOrWhiteSpace(folderId) 
                        && !string.IsNullOrWhiteSpace(folderName))
                    {
                        FolderInfo = new FolderView()
                        {
                            FolderDataInfo = ToDictionary(folderDic),
                            FolderItems = new List<Dictionary<string, object>> { folderDic },
                            exp_TreeParentFolderId = parentFolderId,
                            exp_TreeFolderGroupId = folderGroupId,
                            exp_TreeFolderId = folderId,
                            exp_TreeName = folderName,
                            ChildNodes = pFileAndFolderList
                        };

                        pFolderList.Add(FolderInfo);
                    }
                    


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
                                exp_TreeTeamId = teamId.ToString(),
                                exp_TreeName = teamName.ToString(),
                                ChildNodes = pFolderList.Where(key => key.exp_TreeName.Equals(folderName)).ToList()
                            };

                            pTeamList.Add(TeamInfo);
                        }
                        
                    }

                    // 루트 디렉토리 (프로젝트) 존재하지 않을 경우 새로 생성
                    if (!string.IsNullOrWhiteSpace(projectId)
                        && projectId.Equals(teamProjectId)
                        && projectDic.TryGetValue("projectName", out object projectNameValue))
                    {
                        ProjectInfo = new ProjectView()
                        {
                            ProjectDataInfo = projectDic,
                            // TODO : ProjectItems값이 NULL인 원인 파악 후 해결하기(2023.09.11 jbh)
                            ProjectItems = new List<Dictionary<string, object>> { projectDic },
                            exp_TreeProjectId = projectId.ToString(),
                            exp_TreeName = projectNameValue.ToString(),
                            ChildNodes = pTeamList.Where(key => key.exp_TreeName.Equals(teamName)).ToList()
                        };

                        pProjectList.Add(ProjectInfo);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        #endregion AddProjectList

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
