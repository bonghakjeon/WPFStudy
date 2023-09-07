﻿using Stylet;
using Serilog;
using System;
using System.IO;
using System.Linq;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using JsonTreeView.Commands;
using CobimExplorerNet;
// using JsonTreeView.Models.Tree;
// using JsonTreeView.Models.Explorer;

namespace JsonTreeView.ViewModels
{
    public enum ExplorerTreeLevel : int
    {
        Project = 0,
        Team = 1,
        Folder = 2,
        File = 3
    }

    public class ExplorerFolderView : BindableBase // ExplorerLevelView<ExplorerLevelView>
    {
        public IDictionary<string, object> FolderDataInfo { get => _FolderDataInfo; set { _FolderDataInfo = value; Changed(); } }
        private IDictionary<string, object> _FolderDataInfo = new Dictionary<string, object>();

        public string exp_TreeFolderName { get => _exp_TreeFolderName; set { _exp_TreeFolderName = value; Changed(); } }
        private string _exp_TreeFolderName;
    }

    public class ExplorerView : ExplorerFolderView
    {
        public IDictionary<string, object> DataInfo { get => _DataInfo; set { _DataInfo = value; Changed(); } }
        private IDictionary<string, object> _DataInfo = new Dictionary<string, object>();

        public IDictionary<string, object> ProjectDataInfo { get => _ProjectDataInfo; set { _ProjectDataInfo = value; Changed(); } }
        private IDictionary<string, object> _ProjectDataInfo = new Dictionary<string, object>();

        public IDictionary<string, object> TeamDataInfo { get => _TeamDataInfo; set { _TeamDataInfo = value; Changed(); } }
        private IDictionary<string, object> _TeamDataInfo = new Dictionary<string, object>();

        public string exp_TreeTeamName { get => _exp_TreeTeamName; set { _exp_TreeTeamName = value; Changed(); } }
        private string _exp_TreeTeamName;
    }

    public class ExplorerLevel : ExplorerView
    {
        //public IList<ExplorerLevelView> Items { get => _Items; set { _Items = value; Changed(); } }
        //private IList<ExplorerLevelView> _Items = new List<ExplorerLevelView>();

        //public IList<Dictionary<string, object>> Items { get => _Items; set { _Items = value; Changed(); } }
        //private IList<Dictionary<string, object>> _Items = new List<Dictionary<string, object>>();

        /// <summary>
        /// 프로젝트 목록 리스트
        /// </summary>
        public IList<ExplorerView> ProjectItems { get => _ProjectItems; set { _ProjectItems = value; Changed(); } }
        private IList<ExplorerView> _ProjectItems = new List<ExplorerView>();

        /// <summary>
        /// 팀 목록 리스트
        /// </summary>
        public IList<ExplorerView> TeamItems { get => _TeamItems; set { _TeamItems = value; Changed(); } }
        private IList<ExplorerView> _TeamItems = new List<ExplorerView>();

        /// <summary>
        /// 폴더 목록 리스트
        /// </summary>
        public IList<ExplorerView> FolderItems { get => _FolderItems; set { _FolderItems = value; Changed(); } }
        private IList<ExplorerView> _FolderItems = new List<ExplorerView>();

        //public int exp_TreeLevel { get => _exp_TreeLevel; set { _exp_TreeLevel = value; Changed(); } }
        //private int _exp_TreeLevel;

        public string exp_TreeProjectIdLevel { get => _exp_TreeProjectIdLevel; set { _exp_TreeProjectIdLevel = value; Changed(); } }
        private string _exp_TreeProjectIdLevel;

        /// <summary>
        /// 루트 디렉토리 (프로젝트) 이름
        /// </summary>
        public string exp_TreeName { get => _exp_TreeName; set { _exp_TreeName = value; Changed(); } }
        private string _exp_TreeName;
    }

    //public class ExplorerLevel : ExplorerView // ValidatingModelBase
    //{
    //    /// <summary>
    //    /// 루트 디렉토리 (프로젝트) 리스트 
    //    /// </summary>
    //    //public List<Dictionary<string, object>> Items { get => _Items; set { _Items = value; NotifyOfPropertyChange(); } }
    //    //private List<Dictionary<string, object>> _Items = new List<Dictionary<string, object>>();

    //    public List<ExplorerView> Items { get => _Items; set { _Items = value; NotifyOfPropertyChange(); } }
    //    private List<ExplorerView> _Items = new List<ExplorerView>();

    //    /// <summary>
    //    /// 루트 디렉토리 (프로젝트) 이름
    //    /// </summary>
    //    public string exp_TreeName { get => _exp_TreeName; set { _exp_TreeName = value; NotifyOfPropertyChange(); } }
    //    private string _exp_TreeName;

    //    /// <summary>
    //    /// 루트 디렉토리 (프로젝트) 메타 데이터 리스트 
    //    /// </summary>
    //    /// 참고 URL - https://joyfuls.tistory.com/24
    //    public List<Dictionary<string, object>> MetaItems { get => _MetaItems; set { _MetaItems = value; NotifyOfPropertyChange(); } }
    //    private List<Dictionary<string, object>> _MetaItems = new List<Dictionary<string, object>>();


    //    /// <summary>
    //    /// 팀 리스트 
    //    /// </summary>
    //    public List<Dictionary<string, object>> TeamItems { get => _TeamItems; set { _TeamItems = value; NotifyOfPropertyChange(); } }
    //    private List<Dictionary<string, object>> _TeamItems = new List<Dictionary<string, object>>();

    //    /// <summary>
    //    /// 팀 이름
    //    /// </summary>
    //    public string exp_TreeTeamName { get => _exp_TreeTeamName; set { _exp_TreeTeamName = value; NotifyOfPropertyChange(); } }
    //    private string _exp_TreeTeamName;

    //    /// <summary>
    //    /// 팀 메타 데이터 리스트 
    //    /// </summary>
    //    /// 참고 URL - https://joyfuls.tistory.com/24
    //    public List<Dictionary<string, object>> MetaTeamItems { get => _MetaTeamItems; set { _MetaTeamItems = value; NotifyOfPropertyChange(); } }
    //    private List<Dictionary<string, object>> _MetaTeamItems = new List<Dictionary<string, object>>();




    //    // TODO : 서버로 부터 리턴받은 기타 데이터 및 메타 데이터 ("resultData" 영역 -> "projectEntity"와 "teamEntity" 말고)
    //    // 그외 기타 데이터 및 메타데이터("resultCount", "resultMessage", "tenantId", "jwt", "refreshToken", "param", "payload", "actionUserInfo")
    //    // 필요시 기타 데이터 리스트 "EtcItems" 사용 예정 (2023.09.01 jbh)
    //    /// <summary>
    //    /// 기타 데이터 리스트 
    //    /// </summary>
    //    public List<Dictionary<string, object>> EtcItems { get => _EtcItems; set { _EtcItems = value; NotifyOfPropertyChange(); } }
    //    private List<Dictionary<string, object>> _EtcItems = new List<Dictionary<string, object>>();

    //    // TODO : 서버로 부터 리턴받은 기타 데이터 및 메타 데이터 ("resultData" 영역 -> "projectEntity"와 "teamEntity" 말고)
    //    // 그외 기타 데이터 및 메타데이터("resultCount", "resultMessage", "tenantId", "jwt", "refreshToken", "param", "payload", "actionUserInfo")
    //    // 필요시 기타 기타 이름 "EtcItems" 사용 예정 (2023.09.01 jbh)
    //    /// <summary>
    //    /// 기타 이름
    //    /// </summary>
    //    public string exp_TreeEtcName { get => _exp_TreeEtcName; set { _exp_TreeEtcName = value; NotifyOfPropertyChange(); } }
    //    private string _exp_TreeEtcName;


    //    // TODO : 서버로 부터 리턴받은 기타 데이터 및 메타 데이터 ("resultData" 영역 -> "projectEntity"와 "teamEntity" 말고)
    //    // 그외 기타 데이터 및 메타데이터("resultCount", "resultMessage", "tenantId", "jwt", "refreshToken", "param", "payload", "actionUserInfo")
    //    // 필요시 기타 메타 데이터 리스트 "EtcmetaItems" 사용 예정 (2023.09.01 jbh)
    //    /// <summary>
    //    /// 기타 메타 데이터 리스트 
    //    /// </summary>
    //    /// 참고 URL - https://joyfuls.tistory.com/24
    //    public List<Dictionary<string, object>> EtcMetaItems { get => _EtcMetaItems; set { _EtcMetaItems = value; NotifyOfPropertyChange(); } }
    //    private List<Dictionary<string, object>> _EtcMetaItems = new List<Dictionary<string, object>>();


    //    // TODO : 하위 디렉토리 (폴더 - 파일) 이름을 따로 나눠야 할 경우 프로퍼티 "exp_TreeFolderNameDesc", "exp_TreeFileNameDesc" 구현 하기 (2023.09.01 jbh)
    //    /// <sumary>
    //    /// 하위 디렉토리 (폴더 - 파일) 이름
    //    /// </sumary>
    //    public string exp_TreeNameDesc { get => _exp_TreeNameDesc; set { _exp_TreeNameDesc = value; NotifyOfPropertyChange(); } }
    //    private string _exp_TreeNameDesc;


    //    /// <summary>
    //    /// 트리 레벨 (프로젝트 레벨 0  - 팀 레벨 1 - 폴더 레벨 2 - 파일 레벨 3 순서)
    //    /// </summary>
    //    public int exp_TreeLevel { get => _exp_TreeLevel; set { _exp_TreeLevel = value; NotifyOfPropertyChange(); } }
    //    private int _exp_TreeLevel;


    //    // private RelayCommand folderListCommand;

    //    /// <summary>
    //    /// 폴더 목록 조회 Command
    //    /// </summary>
    //    public ICommand FolderListCommand { get; set; } = new ButtonCommand(FolderListAsync, CanExecuteMethod);

    //    #region 기본 메소드

    //    private static bool CanExecuteMethod(object obj)
    //    {
    //        return true;
    //    }

    //    #endregion 기본 메소드

    //    #region FolderListAsync

    //    // TODO : 프로젝트 클릭시 폴더 리스트 출력되도록 메서드 "FolderListAsync" 구현하기 (2023.09.01 jbh) 
    //    public static async Task FolderListAsync(object obj)
    //    {
    //        try
    //        {
    //            MessageBox.Show("폴더 리스트 테스트 출력");



    //            return;
    //        }
    //        catch (Exception e)
    //        {
    //            Log.Logger.Information(e.Message);
    //            return;
    //        }
    //    }

    //    #endregion FolderListAsync


    //}

    public class ExplorerVM : Screen
    {
        #region 프로퍼티 

        public BindableCollection<ExplorerLevel> LevelDatas { get; } = new BindableCollection<ExplorerLevel>();

        public BindableCollection<ExplorerLevel> DepthDatas { get; } = new BindableCollection<ExplorerLevel>();

        public List<Dictionary<string, object>> FolderList { get => _FolderList; set { _FolderList = value; NotifyOfPropertyChange(); } }
        private List<Dictionary<string, object>> _FolderList = new List<Dictionary<string, object>>();

        #endregion 프로퍼티 

        #region 생성자 

        public ExplorerVM()
        {

        }

        #endregion 생성자 

        #region FolderListCommand

        /// <summary>
        /// FolderListCommand
        /// </summary>
        //public ICommand FolderListCommand => _FolderListCommand = new RelayCommand(parameter =>
        //{
        //    MessageBox.Show("폴더 리스트 테스트 출력");
        //});
        //private ICommand _FolderListCommand;

        #endregion FolderListCommand

        #region TestCommand

        /// <summary>
        /// LoadCommand
        /// </summary>
        public ICommand TestCommand => _TestCommand = new RelayCommand(parameter =>
        {
            try
            {
                // TODO : JSON 파일 "example.json" 파일 경로 설정 및 File.ReadAllBytes 메서드 호출문 구현 (2023.08.31 jbh)
                // 참고 URL - https://blog.naver.com/heennavi1004/222100360201
                // 테스트 json 파일 "example.json" 파일 경로 설정 "jsonProjectTeamPath" (2023.08.31 jbh)
                // string jsonProjectTeamPath = @"D:\bhjeon\WPFStudy\JsonTreeView\JsonTreeView\example.json";

                // 테스트 json 파일 "example2.json" 파일 경로 설정 "jsonProjectTeamPath" (2023.09.07 jbh)
                string jsonProjectTeamPath = @"D:\bhjeon\WPFStudy\JsonTreeView\JsonTreeView\example2.json";

                // TODO : JSON 데이터 -> byte[] 배열 SerializeToUtf8Bytes() 변환 구현 (2023.08.31 jbh)
                // 참고 URL - https://developer-talk.tistory.com/213
                var json = File.ReadAllText(jsonProjectTeamPath);

                var jtmp = (JsonObject.Parse(json)["resultData"] as JsonArray).Select(x => x);

                var datas = jtmp.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();

                




                //var jsonDatas = jproject.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();

                // var jsonDatas = jtmp.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();


                // 트리 뷰 영역 (DepthDatas)
                // TODO: 추후 트리뷰 영역(DepthDatas) 클래스 "OuterConnAuthLevel" 대신 클래스 "OuterConnAuthByProgKindDic" 사용해서 개발 진행 하기(2023.04.12 jbh)
                // 트리뷰 영역(DepthDatas)에 추가될 데이터(List 객체 depthDatas) 생성
                List<ExplorerLevel> levelDatas = new List<ExplorerLevel>();

                // Dictionary<string, object> levelDictionary = ToDictionary(datas);

                foreach (var data in datas)
                {
                    // object projectIdValue;
                    // object projectNameValue;
                    // object teamprojectIdValue;
                    // object teamNameValue;
                    bool bContains = false;

                    // 루트 디렉토리 (프로젝트)
                    if (!bContains)
                    {
                        var lv = new ExplorerLevel();

                        ExplorerView projectDic = new ExplorerView();

                        projectDic.DataInfo = ToDictionary(data);
                        projectDic.ProjectDataInfo = ToDictionary(data["projectEntity"]);
                        projectDic.TeamDataInfo = ToDictionary(data["teamEntity"]);

                        // TODO : 추후 아래 3줄 코드 "lv.DataInfo". "lv.ProjectDataInfo", "lv.TeamDataInfo" 필요 없을시 수정 예정 (2023.09.05 jbh)
                        lv.DataInfo = projectDic.DataInfo;
                        lv.ProjectDataInfo = projectDic.ProjectDataInfo;
                        lv.TeamDataInfo = projectDic.TeamDataInfo;


                        if (projectDic.ProjectDataInfo.TryGetValue("projectId", out object projectIdValue) && projectDic.ProjectDataInfo.TryGetValue("projectName", out object projectNameValue))
                        {
                            // projectDic.exp_TreeFolderName = "테스트";

                            lv.exp_TreeProjectIdLevel = projectIdValue.ToString();

                            lv.exp_TreeName = projectNameValue.ToString();

                            lv.ProjectItems.Add(projectDic);

                            levelDatas.Add(lv);
                        }
                    }

                    // 프로젝트 하위 디렉토리 (팀)
                    // var teamDic = ToDictionary(data["teamEntity"]);

                    ExplorerView teamDic = new ExplorerView();

                    teamDic.DataInfo = ToDictionary(data);
                    teamDic.ProjectDataInfo = ToDictionary(data["projectEntity"]);
                    teamDic.TeamDataInfo = ToDictionary(data["teamEntity"]);

                    foreach (var level in levelDatas)
                    {

                        if (teamDic.TeamDataInfo.TryGetValue("projectId", out object teamprojectIdValue) && teamDic.TeamDataInfo.TryGetValue("teamName", out object teamNameValue))
                        {
                            if (level.exp_TreeProjectIdLevel.Equals(teamprojectIdValue.ToString()))
                            {
                                // teamDic.exp_TreeFolderName = teamNameValue.ToString();
                                teamDic.exp_TreeTeamName = teamNameValue.ToString();
                                level.TeamItems.Add(teamDic);

                                bContains = true;
                                break; // foreach문 종료
                            }
                        }
                    }

                    // 팀 하위 디렉토리 (폴더)
                    ExplorerFolderView folderDic = new ExplorerFolderView();


                }

                // var testDatas = levelDatas.

                //LevelDatas.Clear();
                //LevelDatas.AddRange(depthDatas.ToArray());

                // levelDatas.Where(x => x.Items)

                LevelDatas.Clear();
                LevelDatas.AddRange(levelDatas.ToArray());

                // 폴더 리스트 목록 가져오기 (재귀함수 식으로 호출)
                GetFolderList(LevelDatas);

                // var testDatas = levelDatas.Where(x => x.Items[0].).ToList();

                //DepthDatas.Clear();
                //DepthDatas.AddRange(.ToArray());

            }


            catch (Exception e)
            {

            }
        });
        private ICommand _TestCommand;
        #endregion TestCommand 

        #region GetFolderList

        // TODO : 메서드 "GetFolderList" 구현 진행하기 (2023.09.06 jbh)
        private void GetFolderList(BindableCollection<ExplorerLevel> pLevelDatas)
        {
            // 1. pLevelDatas에서 프로젝트 리스트 가져오기
            // pLevelDatas -> 인덱스 [0], [1] 번지에 속하는 프로퍼티 "ProjectDataInfo" 접근 -> 프로젝트 리스트 객체 "ProjectList"에 값 할당 
            var projectList = pLevelDatas.Select(x => x.ProjectDataInfo["projectId"].ToString()).ToList();

            // 2. pLevelDatas에서 팀 Dictionary 가져오기 (Key = projectId / Value = teamId)
            // pLevelDatas -> 인덱스 [0], [1] 번지에 속하는 프로퍼티 "TeamDataInfo" 접근 -> 팀 리스트 객체 "teamList"에 값 할당 
            //Dictionary<string, string> teamDictionary = pLevelDatas.Select(x => x.TeamDataInfo)
            //                                .ToList()
            //                                .ToDictionary(key => key.Keys, value => value.Values.ToString());

            // TODO : 팀 리스트 "teamList"에서 프로젝트 아이디 "projectId"를 key 값으로 가져오고,
            //        팀 아이디 "teamId" 정보를 value 값으로 가져와서 Dictionary로 구현 (2023.09.07 jbh)
            // 참고 URL - https://qawithexperts.com/article/c-sharp/convert-list-to-dictionary-in-c-various-ways/439

            // TryGetValue 사용 방법 
            // 참고 URL - https://codingcoding.tistory.com/812
            //if (teamDictionary.TryGetValue("projectId", out object projectId) && teamDictionary.TryGetValue("testId", out string testId))
            //{
                
            //}

            // Dictionary<string, object> jDic = jsonDic.Where(x => x.Key.Equals("projectName")).ToDictionary(x => x.Key, x => x.Value);

            //var teamDictionary = teamList.Where(x => x.Keys.Contains("projectId") && x.Keys.Contains(""));

            // 3. 반복문 사용 -> 프로젝트 리스트에 속한 프로젝트 아이디 접근
            //foreach (var project in projectList)
            //{
            //    // 4. 반복문 사용 -> 프로젝트 하위에 속하는 팀 리스트에 속한 팀 아이디 접근 
            //    foreach ()
            //    {
            // 5. projectList에 속하는 "projectId"와 teamDictionary에 속하는 Key 값("projectId")이 일치하는 경우 6번 진행 
            // if ()
            //        {
            //              // 6. 해당 프로젝트 및 팀에 속하는 폴더 리스트 정보를 Http 통신(Get) 방식으로 폴더 리스트 데이터 가져와서 pLevelDatas에 추가 
            //              // 6-1. 프로젝트 아이디, 팀 아이디 데이터를 ProjectHelper 클래스 객체에 담기
            //              // ProjectHelper.

            //              // 6-2. Http 통신(Get) 방식으로 폴더 리스트 데이터 가져오기
            //        } 

            //        // 7. 메서드 "GetFolderList" 재귀 호출
            //    }
            //}



            // 1. 폴더 리스트 가져오기 
            // pLevelDatas.Where(x => x.ProjectItems[]).ToList();

            // TODO : JSON 파일 "subexample.json" 파일 경로 설정 및 File.ReadAllBytes 메서드 호출문 구현 (2023.09.06 jbh)
            // 참고 URL - https://blog.naver.com/heennavi1004/222100360201
            string jsonFolderPath = @"D:\bhjeon\WPFStudy\JsonTreeView\JsonTreeView\subexample.json";

            //var jsonFolder = File.ReadAllText(jsonFolderPath);

            //var jtmpFolder = (JsonObject.Parse(jsonFolder)["resultData"] as JsonArray).Select(x => x);

            //var folderdatas = jtmpFolder.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();


            var jsonFolder = File.ReadAllText(jsonFolderPath);

            var jtmpFolder = (JsonObject.Parse(jsonFolder)["resultData"] as JsonArray).Select(x => x);

            FolderList = jtmpFolder.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();

            // 2. 해당 폴더 데이터가 상위 부모 폴더가 없는 경우 (상위 디렉토리로 추가)
            // 2-2. 해당 폴더 데이터 하위 파일 데이터가 없는 경우 (continue)
            // 2-3. 해당 폴더 데이터 하위 파일 데이터가 있는 경우 (해당 폴더 하위로 파일 데이터 추가)

            // 3. 해당 폴더 데이터가 상위 부모 폴더가 있는 경우 (부모 폴더 밑에 하위 디렉토리로 추가)
            // 3-2. 해당 폴더 데이터 하위 파일 데이터가 없는 경우 (continue)
            // 3-3. 해당 폴더 데이터 하위 파일 데이터가 있는 경우 (해당 폴더 하위로 파일 데이터 추가)


            // 폴더 + 파일 데이터 목록이 다 추가 될 때까지 재귀함수 호출 (재귀함수 - DFS 알고리즘 참고)
            // 프로젝트 - 팀 목록 밑에 폴더 - 파일 순서대로 데이터 추가
            // (Tree에 바인딩할 수 있도록 List 또는 Collection으로 팀 밑에 폴더 + 파일 데이터 추가 필요)
            //GetFolderList();
        }

        #endregion GetFolderList

        #region 

        public Dictionary<string, object> ToDictionary(object obj)
        {
            var json = JsonSerializer.Serialize(obj);
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            return dictionary;
        }

        #endregion 


        #region LoadCommand

        /// <summary>
        /// LoadCommand
        /// </summary>
        //public ICommand LoadCommand => _LoadCommand = new RelayCommand(parameter =>
        //{
        //    //TreeItems = new ObservableCollection<TreeNode>();
        //    //// TestTreeItems = new List<TreeNode>();
        //    //JsonReaderOptions options = new JsonReaderOptions
        //    //{
        //    //    AllowTrailingCommas = true,
        //    //    CommentHandling = JsonCommentHandling.Skip
        //    //};

        //    try
        //    {
        //        // TODO : JSON 파일 "example.json" 파일 경로 설정 및 File.ReadAllBytes 메서드 호출문 구현 (2023.08.31 jbh)
        //        // 참고 URL - https://blog.naver.com/heennavi1004/222100360201
        //        string jsonFilePath = @"D:\bhjeon\WPFStudy\JsonTreeView\JsonTreeView\example.json";

        //        // TODO : JSON 데이터 -> byte[] 배열 SerializeToUtf8Bytes() 변환 구현 (2023.08.31 jbh)
        //        // 참고 URL - https://developer-talk.tistory.com/213
        //        var json = File.ReadAllText(jsonFilePath);

        //        var jtmp = (JsonObject.Parse(json)["resultData"] as JsonArray).Select(x => x["projectEntity"]);

        //        var jsonDatas = jtmp.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();


        //        // TODO : "resultData" 영역 안에 속하는 데이터 중 "projectEntity" 영역 말고 그외 나머지 JSON 데이터(jtmpTeam)는
        //        //        "인재INC"와 소통 후 필요시 해당 데이터 추출 하도록 구현 (2023.09.01 jbh)
        //        var jtmpTeam = (JsonObject.Parse(json)["resultData"] as JsonArray).Select(x => x["teamEntity"]);

        //        var jsonTeamDatas = jtmpTeam.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();



        //        // TODO : "resultData" 영역 안에 속하는 데이터 중 "projectEntity", "teamEntity" 영역 말고 그 외 나머지 JSON 데이터(jtmpEtc)는
        //        //        "인재INC"와 소통 후 필요시 해당 데이터 추출 하도록 구현 (2023.09.04 jbh)
        //        //var jtmpEtc = (JsonObject.Parse(json)["resultData"] as JsonArray).Select(x => x);
        //        //var jsonEtc = jtmpEtc.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();
        //        // 참고 URL - https://forum.dotnetdev.kr/t/jsonobject/6728
        //        // 참고 2 URL - https://learn.microsoft.com/ko-kr/dotnet/api/system.text.json.nodes.jsonarray.remove?view=net-7.0
        //        // 참고 3 URL - https://shlee0882.tistory.com/260
        //        // var jtmpEtc = (JsonObject.Parse(json) as JsonArray);

        //        var jsonObjEtcDatas = (JsonObject.Parse(json) as JsonObject);

        //        if (jsonObjEtcDatas.ContainsKey("resultData")) jsonObjEtcDatas.Remove("resultData");

        //        JsonArray jarray = new JsonArray();

        //        foreach (var jsonObjEtc in jsonObjEtcDatas)
        //        {
        //            jarray.Add(jsonObjEtc);
        //        }

        //        //jarray.Add(jsonObjEtc);

        //        var jtmpEtc = jarray.Select(x => x);

        //        var jsonEtcDatas = jtmpEtc.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();



        //        // TODO : 폴더 목록 JSON 파일 "example2.json" 파일 경로 설정 및 File.ReadAllBytes 메서드 호출문 구현 (2023.08.31 jbh)
        //        // 참고 URL - https://blog.naver.com/heennavi1004/222100360201
        //        string jsonFolderFilePath = @"D:\bhjeon\WPFStudy\JsonTreeView\JsonTreeView\subexample.json";

        //        // TODO : JSON 데이터 -> byte[] 배열 SerializeToUtf8Bytes() 변환 구현 (2023.08.31 jbh)
        //        // 참고 URL - https://developer-talk.tistory.com/213
        //        var jsonFolder = File.ReadAllText(jsonFolderFilePath);

        //        var jtmpFolder = (JsonObject.Parse(jsonFolder)["resultData"] as JsonArray).Select(x => x);

        //        var jsonFolderDatas = jtmpFolder.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();




        //        // var t = JsonNode.Parse(json);

        //        //foreach (var jObj in jtmpEtc)
        //        //{
        //        //    var items = jObj.AsObject();

        //        //    if (items.ContainsKey("resultData")) jtmpEtc.Remove(jObj);
        //        //}

        //        // var jsonEtcDatas = jtmpEtc.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();

        //        // 트리 뷰 영역 (LevelDatas)
        //        // 트리뷰 영역(LevelDatas)에 추가될 데이터(List 객체 levelDatas) 생성
        //        List<ExplorerLevel> levelDatas = new List<ExplorerLevel>();

        //        int Index = 0; // jsonDatas 인덱스 카운팅 변수

        //        // 서버로 부터 리턴받은 데이터 값을 갖는 변수(var jsonDatas)를 사용해서 foreach문 실행
        //        // 변수(var jsonDatas)에는 루트 디렉토리 밑에 들어가는 하위 디렉토리 데이터 값을 가지고 있다.
        //        // ExplorerLevel 클래스 하위 프로퍼티 List 객체 Items에 json 추가
        //        foreach (var jsonDic in jsonDatas)
        //        {
        //            bool bContains = false; // bContains - 루트 디렉토리가 존재하고 그 루트 디렉토리 밑에 하위 디렉토리 데이터 추가 여부
        //            bool bMetaContains = false; // 메타 데이터 추가 여부 
        //            object Value;               // Dictionary<string, object> 객체 jDic에 속하는 Value(object 자료형) 할당받는 변수 선언
        //            object teamValue;           // Dictionary<string, object> 객체 jDic에 속하는 Value(object 자료형) 할당받는 변수 선언
        //            bool bPResult = false;      // 프로젝트 리스트 및 메타 데이터 존재 여부 확인
        //            bool bTResult = false;      // 팀 리스트 및 메타 데이터 존재 여부 확인
        //            string folderName = string.Empty;   // 폴더 이름 문자열

        //            // TODO : 루트 디렉토리(프로젝트 리스트) 밑에 존재하는 하위 폴더 및 파일 리스트 서버로 부터 JSON 데이터 가져오면 아래 "foreach (var level in levelDatas)" 구현하기 (2023.09.01 jbh)
        //            // 트리뷰 영역(LevelDatas)에 추가할 데이터(List 객체 levelDatas)를 가지고 foreach문 실행 
        //            // foreach문을 실행하는 이유는 List 객체 levelDatas에 루트 디렉토리가 없다면 루트 디렉토리 데이터(ExplorerLevel 클래스 객체 lv)를 
        //            // 새로 생성해주고 만약 루트 디렉토리 데이터(ExplorerLevel 클래스 객체)가 있다면 
        //            // 해당 루트 디렉토리 밑에 하위 디렉토리(ExplorerLevel 클래스에 속하는 프로퍼티 리스트 객체 Items) 데이터를 추가해 주기 위해서 이다.
        //            foreach (var level in levelDatas)
        //            {

        //                foreach (var jsonFolderData in jsonFolderDatas)
        //                {
        //                    folderName = jsonFolderData["folderName"].ToString();
        //                    if (level.exp_TreeTeamName.Equals(folderName))
        //                    {
        //                        //level.Items.Add(jsonFolderData);
        //                        level.Items.Add(jsonFolderData);
        //                        level.exp_SubTreeNameDesc = folderName;
        //                        bContains = true;
        //                    }

        //                }











        //                // TODO : Dictionary 관련 메서드 "TryGetValue" 호출문 구현 (2023.09.01 jbh)
        //                // 참고 URL - https://ckhyeok.tistory.com/37
        //                //if (jDic.ContainsKey("projectName"))
        //                //{
        //                //    // List 객체 (ExplorerLevel 클래스에 속하는 프로퍼티 리스트 객체 Items)에 
        //                //    // 서버로 부터 리턴받은 데이터(jDic)를 추가(Add)한다.
        //                //    var test = jDic;
        //                //    level.Items.Add(jDic);
        //                //    bContains = true;
        //                //    break; // foreach문 종료
        //                //}
        //                //else
        //                //{
        //                //    // List 객체 (ExplorerLevel 클래스에 속하는 프로퍼티 리스트 객체 metaItems)에 
        //                //    // 서버로 부터 리턴받은 데이터(jDic)를 추가(Add)한다.
        //                //    var test = jDic;
        //                //    level.metaItems.Add(jDic);
        //                //    // 루트 디렉토리가 존재하고 그 루트 디렉토리 밑에 하위 디렉토리 데이터를 추가하였으므로 
        //                //    // bool 변수 bContains 값을 true로 변경 
        //                //    bMetaContains = true;
        //                //    break; // foreach문 종료
        //                //}
        //            }

        //            // bool 변수 bContains, bMetaContains 값이 false일 경우 루트 디렉토리 데이터(ExplorerLevel 클래스 객체 lv)가 
        //            // 존재하지 않으므로 해당 if절을 실행해서 루트 디렉토리 데이터를 새로 생성해 준다.
        //            if (!bContains || !bMetaContains)
        //            {

        //                // 루트 디렉토리 데이터(ExplorerLevel 클래스 객체 lv) 객체(lv) 생성 
        //                var lv = new ExplorerLevel();

        //                // TODO : Dictionary<string, object> 클래스 객체 "jsonDic" Linq 구현 및 Dictionary<string, object> jDic에 값 할당 (2023.09.01 jbh)
        //                // 참고 URL - https://stackoverflow.com/questions/24662408/linq-dictionary-of-dictionaries
        //                Dictionary<string, object> jDic = jsonDic.Where(x => x.Key.Equals("projectName")).ToDictionary(x => x.Key, x => x.Value);

        //                // TODO : Dictionary<string, object> 클래스 객체 "jsonDic" Linq 구현 및 Dictionary<string, object> 메타데이터 jMetaDic에 값 할당 (2023.09.01 jbh)
        //                // 참고 URL - https://stackoverflow.com/questions/24662408/linq-dictionary-of-dictionaries
        //                Dictionary<string, object> jMetaDic = jsonDic.Where(x => !x.Key.Equals("projectName")).ToDictionary(x => x.Key, x => x.Value);

        //                // "projectEntity"와 같은 레벨의 "teamEntity" 영역 JSON 데이터 "teamName" 추출 및 jTeamDic 할당 (2023.09.01 jbh)
        //                Dictionary<string, object> jTeamDic = jsonTeamDatas[Index].Where(x => x.Key.Equals("teamName")).ToDictionary(x => x.Key, x => x.Value);

        //                // "projectEntity"와 같은 레벨의 "teamEntity" 영역 JSON 메타 데이터 추출 및 jTeamMetaDic 할당 (2023.09.01 jbh)
        //                Dictionary<string, object> jTeamMetaDic = jsonTeamDatas[Index].Where(x => !x.Key.Equals("teamName")).ToDictionary(x => x.Key, x => x.Value);

        //                // "projectEntity", "teamEntity" 영역에 속해있지 않은 JSON 데이터 추출 및 jEtcDic 할당 (2023.09.04 jbh)
        //                // Dictionary<string, object> jEtcDic = jsonEtcDatas.ToDictionary(x => x.);


        //                // TODO :"resultData" 영역 -> "projectEntity"와 "teamEntity" 말고
        //                // 그외 기타 데이터 및 메타데이터("resultCount", "resultMessage", "tenantId", "jwt", "refreshToken", "param", "payload", "actionUserInfo") 추출 및 할당 필요시 구현 예정(2023.09.01 jbh) 
        //                // "projectEntity"와 같은 레벨의 기타 데이터 추출 및 jEtcDic 할당 (2023.09.01 jbh)
        //                // Dictionary<string, object> jEtcDic = jsonEtcDatas[Index].Where(x => x.Key.Equals("teamName")).ToDictionary(x => x.Key, x => x.Value);
        //                // "projectEntity"와 같은 레벨의 기타 메타 데이터 추출 및 jEtcMetaDic 할당 (2023.09.01 jbh)
        //                // Dictionary<string, object> jEtcMetaDic = jsonEtcDatas[Index].Where(x => !x.Key.Equals("teamName")).ToDictionary(x => x.Key, x => x.Value);


        //                // TODO : Dictionary<string, object> 객체 jDic, jTeamDic 메서드 "TryGetValue" 호출문 구현(2023.09.01 jbh)
        //                // 참고 URL - https://developer-talk.tistory.com/694
        //                bPResult = jDic != null && jMetaDic != null;
        //                bTResult = jTeamDic != null && jTeamMetaDic != null;

        //                if (bPResult && bTResult && jDic.TryGetValue("projectName", out Value) && jTeamDic.TryGetValue("teamName", out teamValue))
        //                {
        //                    lv.exp_TreeLevel = (int)ExplorerTreeLevel.Project;
        //                    lv.exp_TreeName = "프로젝트 : " + Value.ToString();

        //                    // 서버로 부터 리턴받은 데이터(jDic)를 추가(Add)한다.
        //                    lv.Items.Add(jDic);

        //                    // 서버로 부터 리턴받은 메타데이터(jMetaDic)를 추가(Add)한다.
        //                    lv.MetaItems.Add(jMetaDic);


        //                    // lv.exp_TreeLevel = (int)ExplorerTreeLevel.Team;
        //                    lv.exp_TreeTeamName = teamValue.ToString();


        //                    // 서버로 부터 리턴받은 팀 데이터(jTeamDic)를 추가(Add)한다.
        //                    lv.TeamItems.Add(jTeamDic);

        //                    // 서버로 부터 리턴받은 팀 메타데이터(jMetaDic)를 추가(Add)한다.
        //                    lv.MetaTeamItems.Add(jTeamMetaDic);

        //                    // TODO :서버로 부터 리턴받은 기타 데이터 및 메타 데이터 ("resultData" 영역 -> "projectEntity"와 "teamEntity" 말고)
        //                    // 그외 기타 데이터 및 메타데이터("resultCount", "resultMessage", "tenantId", "jwt", "refreshToken", "param", "payload", "actionUserInfo")
        //                    // lv.EtcmetaItem에 추가(Add) 필요시 구현 예정(2023.09.01 jbh) 
        //                    // (예시)
        //                    lv.EtcItems = jsonEtcDatas;
        //                    //lv.EtcmetaItems.Add(jEtcMetaDic);

        //                    // 새로 생성한 루트 디렉토리 데이터(ExplorerLevel 클래스 객체 lv)
        //                    // 트리뷰 영역(LevelDatas)에 추가될 데이터(List 객체 levelDatas)에 추가해준다. (levelDatas.Add)
        //                    levelDatas.Add(lv);
        //                }

        //                Index++;  // jsonDatas 인덱스 카운팅 변수

        //                // TODO : 아래 if문 필요시 구현 예정 (2023.09.01 jbh)
        //                // TODO : Dictionary<string, object> 객체 jDic 메서드 "TryGetValue" 호출문 구현(2023.09.01 jbh)
        //                // 참고 URL - https://developer-talk.tistory.com/694
        //                //if (jMetaDic != null)
        //                //{
        //                //    lv.exp_TreeLevel = (int)testExplorerTreeLevel.Project;
        //                //    // lv.exp_TreeName = "프로젝트 : " + jMetaDic.value.ToString();

        //                //    // 서버로 부터 리턴받은 데이터(jDic)를 추가(Add)한다.
        //                //    lv.metaItems.Add(jMetaDic);

        //                //    // 새로 생성한 루트 디렉토리 데이터(ExplorerLevel 클래스 객체 lv)
        //                //    // 트리뷰 영역(LevelDatas)에 추가될 데이터(List 객체 levelDatas)에 추가해준다. (levelDatas.Add)
        //                //    levelDatas.Add(lv);
        //                //}


        //                // jDic.Add("projectName", "test");

        //                // TODO : 아래 foreach문 필요시 구현 예정 (2023.09.01 jbh)
        //                //foreach (var jObj in jsonDic)
        //                //{
        //                //    // TODO : Dictionary<string, object> 객체 jDic 메서드 "TryGetValue" 호출문 구현(2023.09.01 jbh)
        //                //    // 참고 URL - https://developer-talk.tistory.com/694
        //                //    if (jsonDic.TryGetValue("projectName", out value))
        //                //    {
        //                //        lv.exp_TreeLevel = (int)testExplorerTreeLevel.Project;
        //                //        lv.exp_TreeName = "프로젝트 : " + value.ToString();

        //                //        // 서버로 부터 리턴받은 데이터(data)를 추가(Add)한다.
        //                //        // lv.Items.Add(jObj);

        //                //        // 새로 생성한 루트 디렉토리 데이터(ExplorerLevel 클래스 객체 lv)
        //                //        // 트리뷰 영역(LevelDatas)에 추가될 데이터(List 객체 levelDatas)에 추가해준다. (levelDatas.Add)
        //                //        levelDatas.Add(lv);
        //                //        break;
        //                //    }
        //                //}

        //            }
        //        }

        //        LevelDatas.Clear();  // 기존에 데이터 조회 후 남아있는 트리뷰 영역(LevelDatas) 데이터 Clear 
        //                             // 새로 데이터 조회 후 출력되는 트리뷰 영역(LevelDatas)에 데이터(levelDatas.ToArray()) 추가
        //        LevelDatas.AddRange(levelDatas.ToArray());

        //        return;
        //    }
        //    catch (Exception e)
        //    {
        //        Log.Logger.Information(e.Message);
        //        return;
        //    }

        //    //byte[] utf8Bytes = JsonSerializer.SerializeToUtf8Bytes(json);

        //    //Utf8JsonReader reader = new Utf8JsonReader(File.ReadAllBytes(jsonFilePath), options);
        //    //reader.Read();
        //    //ReadJson(ref reader, TreeItems);

        //    // TestTreeItems.Where()



        //    // var Collecion = TreeItems.Where(x => x.ParentName.Equals("projectEntity") || x.ParentName.Equals("resultData"));

        //    // TestReadJson(ref reader, TestTreeItems);
        //});
        //private ICommand _LoadCommand;

        #endregion LoadCommand
    }
}
