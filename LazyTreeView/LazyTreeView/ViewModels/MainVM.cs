using LazyTreeView.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyTreeView.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        // TODO: 오류 코드 "CS8370" 오류 메시지 "'nullable 참조 형식' 기능은 C# 7.3에서 사용할 수 없습니다. 8.0 이상의 언어 버전을 사용하세요." .Net 8.0 이상 언어 버전 설치 (2023.07.17 jbh)
        // 참고 URL - https://drehzr.tistory.com/872
        // TODO : 경고 메시지 코드 "CS8632" 경고 메시지 "c# 경고 CS8632 nullable 참조 형식에 대한 주석은 코드에서 '#nullable' 주석 컨텍스트 내에만 사용되어야 합니다." 로직 보완 (2023.07.17 jbh)
        // 참고 URL - https://kukuta.tistory.com/359
        // C# Nullable 타입 참고 URL - https://www.csharpstudy.com/CSharp/CSharp-nullable.aspx
#nullable enable   // 참조 타입 변수라도 null을 대입하면 경고

        public event PropertyChangedEventHandler? PropertyChanged;     // nullable 전처리 중이지만 null 허용

#nullable disable  // nullable 전처리 비활성화

        /// <summary>
        /// LazyTreeNode 아이템 생성해주는 메서드 "CreateNode"
        /// </summary>
        public LazyTreeNode CreateNode(string key, string text)
        {
            var node = new LazyTreeNode { Key = key, Text = text };

            // node가 펼쳐졌을 경우(화면에 출력되는 부모노드 "홍길동" 또는 "김이박"을 더블클릭한 경우) 이벤트 "Node_OnExpanded" 추가 
            node.OnExpanded += Node_OnExpanded;

            return node;
        }

        /// <summary>
        /// node가 펼쳐졌을 경우(화면에 출력되는 부모노드 "홍길동" 또는 "김이박"을 더블클릭한 경우) 실행되는 이벤트 메서드 "Node_OnExpanded"
        /// </summary>
        /// <param name="obj"></param>
        private void Node_OnExpanded(LazyTreeNode node)
        {
            // 부모 노드(parent) 밑에 자식 노드(Children) "가나다" 추가 
            // Collection Children Nullable(물음표 ?) 삭제 (경고 메시지가 출력되기 때문)
            // 어차피 _children 값이 null 이여도 싱글톤 패턴으로 인해 _children 값은 null이다.
            // node.Children.Add(CreateNode("3", "가나다"));

            // 조건을 줘서(switch - case) node의 자식 노드(Children) 만들기 
            switch (node.Key)
            {
                case "1":
                    // Key "1"의 값인 "홍길동"의 자식 노드로 "홍길동의 자식" 추가 
                    // "홍길동의 자식" 노드를 계속 클릭해도 그 밑에 자식 노드가 생기지 않는다. (switch - case문에서 case "3": 가 존재하지 않기 때문)
                    node.Children.Add(CreateNode("3", "홍길동의 자식"));
                    break;
                case "2":
                    // Key "2"의 값인 "김이박"의 자식 노드로 "김이박의 자식" 추가 
                    // "김이박의 자식" 노드를 계속 클릭해도 그 밑에 자식 노드가 생기지 않는다. (switch - case문에서 case "4": 가 존재하지 않기 때문)
                    node.Children.Add(CreateNode("4", "김이박의 자식"));
                    break;
                
            }

        }

        public MainVM()
        {
            // Collection PathNodes 객체 생성 
            PathNodes = new();

            // PathNodes에 LazyTreeNode 아이템 2개 추가 
            PathNodes.Add(CreateNode("1", "홍길동"));
            PathNodes.Add(CreateNode("2", "김이박"));
        }

        public ObservableCollection<LazyTreeNode> PathNodes { get; set; }
    }
}
