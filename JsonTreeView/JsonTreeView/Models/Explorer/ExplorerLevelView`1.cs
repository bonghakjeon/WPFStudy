using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTreeView.Models.Explorer
{
    public class ExplorerLevelView<T> : ExplorerView where T : ExplorerLevelView<T>
    {
    }
}
