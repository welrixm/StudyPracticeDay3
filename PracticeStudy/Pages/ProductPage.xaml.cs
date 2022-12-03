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
using System.Windows.Threading;
using PracticeStudy.Components;

namespace PracticeStudy.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();

            ListProduct.ItemsSource = DBConnect.db.Product.ToList();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateData;
            timer.Start();
        }
        public void UpdateData(object sender, object e)
        {
            var HistoryProduct = DBConnect.db.Product.ToList();
            ListProduct.ItemsSource = HistoryProduct;
            ListProduct.ItemsSource = DBConnect.db.Product.Where(x => x.Name.StartsWith(TxtSearch.Text) || x.Description.StartsWith(TxtSearch.Text)).ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CbDown_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ListProduct.ItemsSource = DBConnect.db.Product.OrderByDescending(x => x.Name).ToList();
            ListProduct.ItemsSource = DBConnect.db.Product.OrderByDescending(x => x.DateOfAddition).ToList();
        }

        private void CbUp_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ListProduct.ItemsSource = DBConnect.db.Product.OrderBy(x => x.Name).ToList();
            ListProduct.ItemsSource = DBConnect.db.Product.OrderBy(x => x.DateOfAddition).ToList();
        }

        //private void RbUp_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    gridList.ItemsSource = DBConnect.db.Product.OrderBy(x => x.Name).ToList();
        //    gridList.ItemsSource = DBConnect.db.Product.OrderBy(x => x.DateOfAddition).ToList();
        //}

        //private void RbDown_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    gridList.ItemsSource = DBConnect.db.Product.OrderByDescending(x => x.Name).ToList();
        //}


    }
}
