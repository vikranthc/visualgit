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
using LibGit2Sharp;

namespace VisualGit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Style = (Style)Resources["GlassStyle"];
        }

        private void LoadGitLog_Click(object sender, RoutedEventArgs e)
        {
            Repository repo = new Repository("C:/Repos/Conservice");
            Branch master = repo.Branches.ElementAt(0);

            foreach (var commit in master.Commits)
            {
                Commit c = new Commit();
                c.Hash = commit.Id.ToString();
                c.Author = commit.Author.ToString();
                c.Message = commit.Message;

                History.Items.Add(c);
            }
        }
    }

    public struct Commit
    {
        public String Hash { get; set; }
        public String Author { get; set; }
        public String Message { get; set; }
    }
}
