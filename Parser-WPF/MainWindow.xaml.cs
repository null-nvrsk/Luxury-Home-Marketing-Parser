using Parser_WPF.Data;
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

namespace Parser_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MemberDbContext dbContext;



        public MainWindow(MemberDbContext dbContext)
        {
            this.dbContext = dbContext;

            InitializeComponent();

            GetMembers();
        }
        private void GetMembers()
        {
            MemberDataGrid.ItemsSource = dbContext.Members.ToList();
            QueueMemberListDataGrid.ItemsSource = dbContext.SearchMemberLists.ToList();
            QueueMemberInfoDataGrid.ItemsSource = dbContext.SearchMemberInfos.ToList();        
        }



        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            dbContext.Database.EnsureDeleted();   // удаляем бд
            dbContext.Database.EnsureCreated();   // создаем бд с новой схемой
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            // 

        }
    }
}
