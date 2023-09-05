using Stylet;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Windows.Input;
using System.Threading.Tasks;
using JsonTreeView.Models.Tree;
using JsonTreeView.Commands;
using System.Text.Json.Nodes;

namespace JsonTreeView.ViewModels
{
    public enum testExplorerTreeLevel : int
    {
        Project = 0,
        Folder  = 1,
        File    = 2
    }

    // TODO: JSON 데이터 파싱 -> TreeView 데이터 바인딩 테스트 코드 구현 (2023.09.01 jbh) 
    // TODO : propertyName "projectName"  말고 "projectEntity" 영역 관련 기타 데이터 추가해서 리스트에 넣는 방법 생각하고 구현하기 (2023.08.31 jbh)
    // 참고 URL - https://stackoverflow.com/questions/63656768/displaying-treeview-from-custom-json-with-wpf
    public class MainVM : Screen
    {
        #region 프로퍼티 

        public BindableCollection<ExplorerLevel> LevelDatas { get; } = new BindableCollection<ExplorerLevel>();

        /// <summary>
        /// TreeItems
        /// </summary>
        public ObservableCollection<TreeNode> TreeItems
        {
            get => _TreeItems;
            set
            {
                _TreeItems = value;
                NotifyOfPropertyChange();
            }
        }
        private ObservableCollection<TreeNode> _TreeItems;

        /// <summary>
        /// TestTreeItems
        /// </summary>
        public List<TreeNode> TestTreeItems
        {
            get => _TestTreeItems;
            set
            {
                _TestTreeItems = value;
                NotifyOfPropertyChange();
            }
        }
        private List<TreeNode> _TestTreeItems;

        /// <summary>
        /// SelectedItem
        /// </summary>
        public TreeNode SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                NotifyOfPropertyChange();
            }
        }
        private TreeNode _SelectedItem;

        /// <summary>
        /// LoadCommand
        /// </summary>
        //public ICommand LoadCommand => _LoadCommand = new RelayCommand(parameter =>
        //{
        //    TreeItems = new ObservableCollection<TreeNode>();
        //    // TestTreeItems = new List<TreeNode>();
        //    JsonReaderOptions options = new JsonReaderOptions
        //    {
        //        AllowTrailingCommas = true,
        //        CommentHandling = JsonCommentHandling.Skip
        //    };

        //    // TODO : JSON 파일 "example.json" 파일 경로 설정 및 File.ReadAllBytes 메서드 호출문 구현 (2023.08.31 jbh)
        //    // 참고 URL - https://blog.naver.com/heennavi1004/222100360201
        //    string jsonFilePath = @"D:\bhjeon\WPFStudy\JsonTreeView\JsonTreeView\example.json";

        //    // TODO : JSON 데이터 -> byte[] 배열 SerializeToUtf8Bytes() 변환 구현 (2023.08.31 jbh)
        //    // 참고 URL - https://developer-talk.tistory.com/213
        //    var json = File.ReadAllText(jsonFilePath);

        //    // TODO : "resultData" 영역 안에 속하는 데이터들 중 "projectEntity" 영역 안에 있는 JSON 데이터만 추출 하도록 구현 (2023.09.01 jbh) 
        //    var jtmp = (JsonObject.Parse(json)["resultData"] as JsonArray).Select(x => x["projectEntity"]);

        //    // TODO : "resultData" 영역 안에 속하는 데이터들 중 "projectEntity" 영역 말고 그외 나머지 JSON 데이터는 "인재INC"와 소통 후 필요시 해당 데이터 추출 및
        //    //        하도록 구현 (2023.09.01 jbh)
        //    var jtmpEtc = (JsonObject.Parse(json)["resultData"] as JsonArray).Select(x => x["projectEntity"]);

        //    // var jdic = jtmp.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();

        //    var jsonDatas = jtmp.Select(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x)).ToList();


        //    // 트리 뷰 영역 (LevelDatas)
        //    // 트리뷰 영역(LevelDatas)에 추가될 데이터(List 객체 levelDatas) 생성
        //    List<ExplorerLevel> levelDatas = new List<ExplorerLevel>();

        //    // 서버로 부터 리턴받은 데이터 값을 갖는 변수(var jsonDatas)를 사용해서 foreach문 실행
        //    // 변수(var jsonDatas)에는 루트 디렉토리 밑에 들어가는 하위 디렉토리 데이터 값을 가지고 있다.
        //    // ExplorerLevel 클래스 하위 프로퍼티 List 객체 Items에 json 추가
        //    foreach (var jsonDic in jsonDatas)
        //    {
        //        bool bContains = false; // bContains - 루트 디렉토리가 존재하고 그 루트 디렉토리 밑에 하위 디렉토리 데이터 추가 여부
        //        bool bMetaContains = false; // 메타 데이터 추가 여부 
        //        object value = string.Empty; // Dictionary<string, object> 객체 jDic에 속하는 Value(object 자료형) 할당받는 변수 선언

        //        // TODO : 루트 디렉토리(프로젝트 리스트) 밑에 존재하는 하위 폴더 및 파일 리스트 서버로 부터 JSON 데이터 가져오면 아래 "foreach (var level in levelDatas)" 구현하기 (2023.09.01 jbh)
        //        // 트리뷰 영역(LevelDatas)에 추가할 데이터(List 객체 levelDatas)를 가지고 foreach문 실행 
        //        // foreach문을 실행하는 이유는 List 객체 levelDatas에 루트 디렉토리가 없다면 루트 디렉토리 데이터(ExplorerLevel 클래스 객체 lv)를 
        //        // 새로 생성해주고 만약 루트 디렉토리 데이터(ExplorerLevel 클래스 객체)가 있다면 
        //        // 해당 루트 디렉토리 밑에 하위 디렉토리(ExplorerLevel 클래스에 속하는 프로퍼티 리스트 객체 Items) 데이터를 추가해 주기 위해서 이다.
        //        foreach (var level in levelDatas)
        //        {
        //            // TODO : Dictionary 관련 메서드 "TryGetValue" 호출문 구현 (2023.09.01 jbh)
        //            // 참고 URL - https://ckhyeok.tistory.com/37
        //            //if (jDic.ContainsKey("projectName"))
        //            //{
        //            //    // List 객체 (ExplorerLevel 클래스에 속하는 프로퍼티 리스트 객체 Items)에 
        //            //    // 서버로 부터 리턴받은 데이터(jDic)를 추가(Add)한다.
        //            //    var test = jDic;
        //            //    level.Items.Add(jDic);
        //            //    bContains = true;
        //            //    break; // foreach문 종료
        //            //}
        //            //else
        //            //{
        //            //    // List 객체 (ExplorerLevel 클래스에 속하는 프로퍼티 리스트 객체 metaItems)에 
        //            //    // 서버로 부터 리턴받은 데이터(jDic)를 추가(Add)한다.
        //            //    var test = jDic;
        //            //    level.metaItems.Add(jDic);
        //            //    // 루트 디렉토리가 존재하고 그 루트 디렉토리 밑에 하위 디렉토리 데이터를 추가하였으므로 
        //            //    // bool 변수 bContains 값을 true로 변경 
        //            //    bMetaContains = true;
        //            //    break; // foreach문 종료
        //            //}
        //        }

        //        // bool 변수 bContains, bMetaContains 값이 false일 경우 루트 디렉토리 데이터(ExplorerLevel 클래스 객체 lv)가 
        //        // 존재하지 않으므로 해당 if절을 실행해서 루트 디렉토리 데이터를 새로 생성해 준다.
        //        if (!bContains && !bMetaContains)
        //        {
        //            // 루트 디렉토리 데이터(ExplorerLevel 클래스 객체 lv) 객체(lv) 생성 
        //            var lv = new ExplorerLevel();

        //            // TODO : Dictionary<string, object> 클래스 객체 "jsonDic" Linq 구현 및 Dictionary<string, object> jDic에 값 할당 (2023.09.01 jbh)
        //            // 참고 URL - https://stackoverflow.com/questions/24662408/linq-dictionary-of-dictionaries
        //            Dictionary<string, object> jDic = jsonDic.Where(x => x.Key.Equals("projectName")).ToDictionary(x => x.Key, x => x.Value);

        //            // TODO : Dictionary<string, object> 클래스 객체 "jsonDic" Linq 구현 및 Dictionary<string, object> 메타데이터 jMetaDic에 값 할당 (2023.09.01 jbh)
        //            // 참고 URL - https://stackoverflow.com/questions/24662408/linq-dictionary-of-dictionaries
        //            Dictionary<string, object> jMetaDic = jsonDic.Where(x => !x.Key.Equals("projectName")).ToDictionary(x => x.Key, x => x.Value);

                    

        //            // TODO : Dictionary<string, object> 객체 jDic 메서드 "TryGetValue" 호출문 구현(2023.09.01 jbh)
        //            // 참고 URL - https://developer-talk.tistory.com/694
        //            if (jDic != null && jDic.TryGetValue("projectName", out value) && jMetaDic != null)
        //            {
        //                lv.exp_TreeLevel = (int)testExplorerTreeLevel.Project;
        //                lv.exp_TreeName = "프로젝트 : " + value.ToString();

        //                // 서버로 부터 리턴받은 데이터(jDic)를 추가(Add)한다.
        //                lv.Items.Add(jDic);

        //                // 서버로 부터 리턴받은 메타데이터(jMetaDic)를 추가(Add)한다.
        //                lv.MetaItems.Add(jMetaDic);

        //                // 새로 생성한 루트 디렉토리 데이터(ExplorerLevel 클래스 객체 lv)
        //                // 트리뷰 영역(LevelDatas)에 추가될 데이터(List 객체 levelDatas)에 추가해준다. (levelDatas.Add)
        //                levelDatas.Add(lv);
        //            }



        //            // TODO : 아래 if문 필요시 구현 예정 (2023.09.01 jbh)
        //            // TODO : Dictionary<string, object> 객체 jDic 메서드 "TryGetValue" 호출문 구현(2023.09.01 jbh)
        //            // 참고 URL - https://developer-talk.tistory.com/694
        //            //if (jMetaDic != null)
        //            //{
        //            //    lv.exp_TreeLevel = (int)testExplorerTreeLevel.Project;
        //            //    // lv.exp_TreeName = "프로젝트 : " + jMetaDic.value.ToString();

        //            //    // 서버로 부터 리턴받은 데이터(jDic)를 추가(Add)한다.
        //            //    lv.metaItems.Add(jMetaDic);

        //            //    // 새로 생성한 루트 디렉토리 데이터(ExplorerLevel 클래스 객체 lv)
        //            //    // 트리뷰 영역(LevelDatas)에 추가될 데이터(List 객체 levelDatas)에 추가해준다. (levelDatas.Add)
        //            //    levelDatas.Add(lv);
        //            //}


        //            // jDic.Add("projectName", "test");

        //            // TODO : 아래 foreach문 필요시 구현 예정 (2023.09.01 jbh)
        //            //foreach (var jObj in jsonDic)
        //            //{
        //            //    // TODO : Dictionary<string, object> 객체 jDic 메서드 "TryGetValue" 호출문 구현(2023.09.01 jbh)
        //            //    // 참고 URL - https://developer-talk.tistory.com/694
        //            //    if (jsonDic.TryGetValue("projectName", out value))
        //            //    {
        //            //        lv.exp_TreeLevel = (int)testExplorerTreeLevel.Project;
        //            //        lv.exp_TreeName = "프로젝트 : " + value.ToString();

        //            //        // 서버로 부터 리턴받은 데이터(data)를 추가(Add)한다.
        //            //        // lv.Items.Add(jObj);

        //            //        // 새로 생성한 루트 디렉토리 데이터(ExplorerLevel 클래스 객체 lv)
        //            //        // 트리뷰 영역(LevelDatas)에 추가될 데이터(List 객체 levelDatas)에 추가해준다. (levelDatas.Add)
        //            //        levelDatas.Add(lv);
        //            //        break;
        //            //    }
        //            //}
        //        }
        //    }


        //    LevelDatas.Clear();  // 기존에 데이터 조회 후 남아있는 트리뷰 영역(LevelDatas) 데이터 Clear 
        //                         // 새로 데이터 조회 후 출력되는 트리뷰 영역(LevelDatas)에 데이터(levelDatas.ToArray()) 추가
        //    LevelDatas.AddRange(levelDatas.ToArray());


        //    //List<Dictionary<string, object>>

        //    //jdic.

        //    byte[] utf8Bytes = JsonSerializer.SerializeToUtf8Bytes(json);

        //    Utf8JsonReader reader = new Utf8JsonReader(File.ReadAllBytes(jsonFilePath), options);
        //    reader.Read();
        //    ReadJson(ref reader, TreeItems);

        //    // TestTreeItems.Where()



        //    // var Collecion = TreeItems.Where(x => x.ParentName.Equals("projectEntity") || x.ParentName.Equals("resultData"));

        //    // TestReadJson(ref reader, TestTreeItems);
        //});
        //private ICommand _LoadCommand;

        /// <summary>
        /// SaveCommand
        /// </summary>
        public ICommand SaveCommand => _SaveCommand = new RelayCommand(parameter => 
        {
            JsonWriterOptions options = new JsonWriterOptions 
            { 
                Indented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            // using 선언 구현 (2023.08.31 jbh)
            // using 선언은 using 키워드 뒤에 오는 변수 선언으로서,
            // using 뒤에 있는 변수가 using을 둘러싼 범위를 벗어날 경우 Dispose 하도록 컴파일러에게 지시
            // 참고 URL - https://www.csharpstudy.com/latest/CS8-using.aspx
            using (Stream stream = File.Create("out.json"))
            {
                using (Utf8JsonWriter writer = new Utf8JsonWriter(stream, options))
                {
                    writer.WriteStartObject();
                    WriteJson(writer, TreeItems);
                }
            }
            
        });
        private ICommand _SaveCommand;

        #endregion 프로퍼티 

        #region 생성자 

        public MainVM()
        {
            TreeItems = new ObservableCollection<TreeNode>();
            TreeNode.mainVM = this;
        }

        #endregion 생성자

        #region WriteJson

        private void WriteJson(Utf8JsonWriter writer, ObservableCollection<TreeNode> items)
        {
            foreach (TreeNode node in items)
            {
                switch (node)
                {
                    case TreeValue valueNode:
                        writer.WriteString(valueNode.Name, valueNode.Value);
                        break;
                    case TreeObject objectNode:
                        writer.WriteStartObject(objectNode.Name);
                        WriteJson(writer, objectNode.Children);
                        break;
                }
            }
            writer.WriteEndObject();
        }

        #endregion WriteJson

        #region ReadJson

        private void ReadJson(ref Utf8JsonReader reader, ObservableCollection<TreeNode> items)
        {
            bool complete = false;
            string propertyName = "";
            while (!complete && reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.PropertyName:
                        propertyName = reader.GetString();
                        break;
                    case JsonTokenType.String:
                        ObservableCollection<TreeNode> etc = new ObservableCollection<TreeNode>();
                        if (propertyName.Equals("projectName"))
                            items.Add(new TreeValue { Name = propertyName, NameValue = propertyName + " : " + reader.GetString(), Value = reader.GetString() });
                        // TODO : propertyName "projectName"  말고 "projectEntity" 영역 관련 기타 데이터 추가해서 리스트에 넣는 방법 생각하고 구현하기 (2023.08.31 jbh)
                        // else

                            //items.Add(new TreeValue { Name = propertyName, EtcValue = propertyName + " : " + reader.GetString(), Value = reader.GetString() });
                            // items.Add(new TreeValue { Name = propertyName, EtcValue = propertyName + " : " + reader.GetString(), Etc = etc });
                        break;
                    case JsonTokenType.StartObject: // 시작 객체 (예) "projectEntity", "teamEntity", "resultData" 
                        // ObservableCollection<TreeNode> children = new ObservableCollection<TreeNode>();
                        //if (!propertyName.Equals("teamEntity")) 
                        //    items.Add(new TreeObject { ParentName = propertyName, Children = children });
                        // ReadJson(ref reader, children);
                        ReadJson(ref reader, items);
                        break;
                    case JsonTokenType.EndObject:
                        complete = true;
                        break;
                }
            }
        }

        private void TestReadJson(ref Utf8JsonReader reader, List<TreeNode> items)
        {
            bool complete = false;
            string propertyName = "";
            while (!complete && reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.PropertyName:
                        propertyName = reader.GetString();
                        break;
                    case JsonTokenType.String:
                        items.Add(new TestTreeValue { Name = propertyName, Value = reader.GetString() });
                        break;
                    case JsonTokenType.StartObject: // 시작 객체 (예) "projectEntity", "teamEntity" 
                        if (propertyName.Equals("teamEntity")) break;
                        //ObservableCollection<TreeNode> children = new ObservableCollection<TreeNode>();
                        List<TreeNode> children = new List<TreeNode>();
                        items.Add(new TestTreeObject { ParentName = propertyName, Children = children });
                        TestReadJson(ref reader, children);
                        break;
                    case JsonTokenType.EndObject:
                        complete = true;
                        break;
                }
            }
        }

        #endregion ReadJson
    }
}
