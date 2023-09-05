using CobimExplorerNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTreeView.Models.Explorer
{
    public class ExplorerView : BindableBase // ExplorerLevelView<ExplorerLevelView>
    {
        //public IDictionary<string, object> DataInfo { get => _DataInfo; set { _DataInfo = value; Changed(); } }
        //private IDictionary<string, object> _DataInfo = new Dictionary<string, object>();

        public string exp_TreeNameDesc { get => _exp_TreeNameDesc; set { _exp_TreeNameDesc = value; Changed(); } }
        private string _exp_TreeNameDesc;
    }
}
