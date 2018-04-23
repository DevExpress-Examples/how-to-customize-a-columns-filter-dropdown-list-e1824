using System.Collections.Generic;
using System.Windows.Controls;
using DevExpress.AgDataGrid;
using DevExpress.Data.Filtering;

namespace AgDataGrid_CustomizeFilterDropdown {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            grid.DataSource = ProductList.GetData();
        }

        private void grid_ShowFilterPopup(object sender, DevExpress.AgDataGrid.ShowFilterPopupEventArgs e) {
            if (e.Column.FieldName != "UnitPrice") return;
            e.FilterBox.FilterItems.Clear();
            List<object> filterItems = new List<object>();
            filterItems.Add(new FilterInfo(CriteriaOperator.Parse("[UnitPrice] < 50"), "Less than $50"));
            filterItems.Add(new FilterInfo(CriteriaOperator.Parse("[UnitPrice] >= 50 AND [UnitPrice] < 100"), "Between $50 And $100"));
            e.FilterBox.FilterItems = filterItems;
        }
    }
}
