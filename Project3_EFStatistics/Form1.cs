using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Project3_EFStatistics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EFStatisticsEntities context = new EFStatisticsEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            #region Kategori Sayısı
            int categoryCount = context.Categories.Count();
            lblCategoryCount.Text = categoryCount.ToString();
            #endregion
            #region Ürün Sayısı
            int productCount = context.Products.Count();
            lblProductCount.Text = productCount.ToString();
            #endregion
            #region Müşteri Sayısı
            int customerCount = context.Customers.Count();
            lblCustomerCount.Text = customerCount.ToString();
            #endregion
            #region Sipariş Sayısı
            int orderCount = context.Orders.Count();
            lblOrderCount.Text = orderCount.ToString();
            #endregion
            #region Toplam Ürün Stoğu
            int? totalProductStock = context.Products.Sum(p => p.Stock);
            lblTotalProductStock.Text = totalProductStock.ToString();
            #endregion
            #region Ortalama Ürün Fiyatı
            decimal avgProductPrice = context.Products.Average(p => p.Price).Value;
            lblAvgProductPrice.Text = avgProductPrice.ToString("0.00 ₺");
            #endregion
            #region Toplam Meyve Sayısı
            int totalFruitCount = context.Products.Where(p => p.CategoryId == 1).Sum(p => p.Stock).Value;
            lblTotalFruitCount.Text = totalFruitCount.ToString();
            #endregion
            #region Airfryer Toplam Kar
            int? airfryerTotalProfitIsStock = context.Products.Where(p => p.ProductId == 7).Select(p => p.Stock).FirstOrDefault();
            decimal? airfryerTotalProfitIsUnitPrice = context.Products.Where(p => p.ProductId == 7).Select(p => p.Price).FirstOrDefault();
            decimal? airfryerTotalProfit = airfryerTotalProfitIsStock * airfryerTotalProfitIsUnitPrice;
            lblAirfryerTotalProfit.Text = airfryerTotalProfit.Value.ToString("0.00 ₺");
            #endregion
            #region 100'den Az Stoklu Ürünler
            var productStockSmallerThan100 = context.Products.Where(p => p.Stock < 100).Count();
            lblProductStockSmallerThan100.Text = productStockSmallerThan100.ToString();
            #endregion
            #region Aktif Sebze Stoğu
            var activeVegetableStock = context.Products
                .Where(p => p.IsStatus == true && p.CategoryId == 
                (context.Categories
                .Where(c => c.CategoryName == "Sebze")
                .Select(c => c.CategoryId).FirstOrDefault()))
                .Sum(p => p.Stock);
            lblActiveVegetableStock.Text = activeVegetableStock.ToString();
            #endregion

            #region Türkiye'den Verilen Siparişler
            List<int> customersInTurkiyeCount = context.Customers
                .Where(c => c.Country == "Türkiye")
                .Select(c => c.CustomerId).ToList();
            int orderCountInTurkiye = context.Orders
                .Where(o =>
                customersInTurkiyeCount
                .Contains(o.CustomerId.Value)).Count();
            lblTurkiyeOrderCount.Text = orderCountInTurkiye.ToString();
            #endregion
            #region Toplam Kazanç
            decimal? totalBalance = context.Orders.Sum(o => o.TotalPrice);
            lblTotalBalance.Text = totalBalance.Value.ToString("0.00 ₺");
            #endregion
            #region Meyve Satışından Kazanç
            decimal? fruitTotalBalance = (
                from o in context.Orders
                join p in context.Products on o.ProductId equals p.ProductId
                join c in context.Categories on p.CategoryId equals c.CategoryId
                where c.CategoryName == "Meyve" 
                select o.TotalPrice).Sum();
            lblFruitTotalBalance.Text = fruitTotalBalance.Value.ToString("0.00 ₺");
            #endregion
            #region Elektronik Ürün Satışından Kazanç
            decimal? electronicProductTotalBalance = (
                from o in context.Orders
                join p in context.Products on o.ProductId equals p.ProductId
                join c in context.Categories on p.CategoryId equals c.CategoryId
                where c.CategoryName == "Ev Aletleri" || c.CategoryName == "Akıllı Telefon" || c.CategoryName == "Teknoloji"
                select o.TotalPrice).Sum();
            lblElectronicProductTotalBalance.Text = electronicProductTotalBalance.Value.ToString("0.00 ₺");
            #endregion
            #region Son Eklenen Ürün
            string lastProduct = context.Products.OrderByDescending(p => p.ProductId).Take(1).Select(p => p.ProductName).First();
            lblLastProduct.Text = lastProduct;
            #endregion
            #region Son Eklenen Ürünün Kategorisi
            int lastProductCategoryId = context.Products
                .OrderByDescending(p => p.ProductId).Take(1)
                .Select(p => p.CategoryId).First() ?? 0;
            string lastProductCategoryName = context.Categories
                .Where(c => c.CategoryId == lastProductCategoryId)
                .Select(c => c.CategoryName)
                .First();
            lblLastAddCategoryNameByProduct.Text = lastProductCategoryName;
            #endregion
            #region Aktif Ürün Sayısı
            int activeProductCount = context.Products
                .Where(p => p.IsStatus == true)
                .Count();
            lblActiveProductCount.Text = activeProductCount.ToString();
            #endregion
            #region Toplam Kola Kazancı
            int? cokeStock = context.Products
                .Where(p => p.ProductName == "Kola")
                .Select(p => p.Stock)
                .FirstOrDefault();
            decimal? cokeBalance = context.Products
                .Where(p => p.ProductName == "Kola")
                .Select(p => p.Price).FirstOrDefault();
            lblTotalBalanceByCoke.Text = (cokeStock * cokeBalance).Value.ToString("0.00 ₺");
            #endregion
            #region Son Sipariş Veren Müşteri
            string lastCustomer = (
                from o in context.Orders
                join c in context.Customers on o.CustomerId equals c.CustomerId
                orderby o.OrderId descending
                select c.CustomerName
                ).FirstOrDefault();
            lblLastCustomer.Text = lastCustomer;
            #endregion
            #region Toplam Ülke Sayısı
            int totalCountry = context.Customers
                .Select(c => c.Country)
                .Distinct().Count();
            lblTotalCountry.Text = totalCountry.ToString();
            #endregion
        }
    }
}
