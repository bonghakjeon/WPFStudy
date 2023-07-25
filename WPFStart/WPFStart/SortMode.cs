using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFStart
{
    public struct SortMode
    {
        public static SortMode New = new SortMode("new", "New");
        public static SortMode Hot = new SortMode("hot", "Hot");
        public static SortMode Top = new SortMode("top", "Top");

        public static IEnumerable<SortMode> AllModes 
        { 
            get { return new[] { New, Hot, Top}; }
        }

        // private set; 의 역할 - 해당 필드 값을 읽기전용으로 쓰겠다는 것을 의미
        // 참고 URL - https://yeko90.tistory.com/entry/c-private-set-%EC%82%AC%EC%9A%A9-%EC%9D%B4%EC%9C%A0%ED%94%84%EB%9F%AC%ED%8D%BC%ED%8B%B0
        public string Name { get; private set; }

        public string Mode { get; private set; }

        // TODO : this() 생성자 추가 (2023.07.25 jbh)
        // 참고 URL - https://yeko90.tistory.com/entry/c-%EA%B8%B0%EC%B4%88-this-%ED%82%A4%EC%9B%8C%EB%93%9C-this
        private SortMode(string mode, string name) : this()
        {
            this.Mode = mode;
            this.Name = name;
        }
    }
}
