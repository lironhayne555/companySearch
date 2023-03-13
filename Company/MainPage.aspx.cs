using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Company.AppService;
using Company.Module;

namespace Company
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<Customer> CompanySearch(string company, string name, string phone)
        {
            Server s = new Server();
            return s.GetDataSearch(company, name, phone);
        }
    }
}