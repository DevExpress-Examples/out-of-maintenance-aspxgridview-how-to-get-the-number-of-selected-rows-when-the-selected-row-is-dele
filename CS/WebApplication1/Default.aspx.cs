using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;

namespace WebApplication1 {
    public partial class WebForm1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack)
                grid.DataBind();
        }
        private List<MyObject> GetDataSource() {
            List<MyObject> lst = new List<MyObject>();
            for (int i = 1; i <= 10; i++)
                lst.Add(new MyObject() {
                    ID = i,
                    Name = string.Format("Name_{0}", i)
                });
            return lst;
        }
        private List<MyObject> DSource {
            get {
                List<MyObject> lst = null;
                if (Session["DSource"] == null) {
                    lst = GetDataSource();
                    Session["DSource"] = lst;
                }
                else
                    lst = Session["DSource"] as List<MyObject>;
                return lst;
            }
        }
        protected void grid_DataBinding(object sender, EventArgs e) {
            (sender as ASPxGridView).DataSource = DSource;
        }
        protected void btnDeleteSelectedRows_Click(object sender, EventArgs e) {
            List<MyObject> lst = DSource;
            List<object> selectedValues = grid.GetSelectedFieldValues(grid.KeyFieldName);
            foreach (object value in selectedValues) {
                MyObject obj = lst.Find(s => s.ID == Convert.ToInt32(value));
                lst.Remove(obj);
            }
            grid.DataBind();
        }
    }
}