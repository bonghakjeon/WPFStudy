using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestTreeView
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var subNodes = new List<ITreeNode>
            {
                new SubNode { Name = "Sub Node 1" },
                new SubNode { Name = "Sub Node 2" },
                new SubNode { Name = "Sub Node 3" },
                new SubNode { Name = "Sub Node 4" }
            };
                var nodes = new List<ITreeNode>
            {
                new Thread { Name = "Thread 1", ChildNodes = subNodes },
                new Thread { Name = "Thread 2", ChildNodes = subNodes },
                new Module { Name = "Module 1", ChildNodes = subNodes },
                new Module { Name = "Module 2", ChildNodes = subNodes }
            };
                var processes = new List<Process>
            {
                new Process{ Name = "Process1", ChildNodes = nodes },
                new Process{ Name = "Process2", ChildNodes = nodes }
            };
            TreeView.ItemsSource = processes;
        }

        public interface ITreeNode
        {
            string Name { get; set; }
            List<ITreeNode> ChildNodes { get; set; }
        }
        public class Process : ITreeNode
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public List<ITreeNode> ChildNodes { get; set; }
        }
        public class Module : ITreeNode
        {
            public string Name { get; set; }
            public List<ITreeNode> ChildNodes { get; set; }
        }
        public class Thread : ITreeNode
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public List<ITreeNode> ChildNodes { get; set; }
        }
        public class SubNode : ITreeNode
        {
            public string Name { get; set; }
            public List<ITreeNode> ChildNodes { get => null; set => throw new System.NotImplementedException(); }
        }

    }
}
