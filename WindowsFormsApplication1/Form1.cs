using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facebook;
using System.Dynamic;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        private const string AppId = "202139416789430";
        private Uri _loginUrl;
        private Uri _logoutUrl;
        private const string _ExtendedPermissions = "user about_me,publish_stream,offline_access";
        FacebookClient fbClient = new FacebookClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            dynamic parameters = new ExpandoObject();
            parameters.client_id = AppId;
            parameters.redirect_uri = "https://www.facebook.com/connect/login_success.html";

            parameters.response_type = "token";

            parameters.display = "popup";

            if (!string.IsNullOrWhiteSpace(_ExtendedPermissions))
                parameters.scope = _ExtendedPermissions;

            var fb = new FacebookClient();
            _loginUrl = fb.GetLoginUrl(parameters);
            _logoutUrl = fb.GetLogoutUrl(parameters);

            webBrowser1.Navigate(_loginUrl.AbsoluteUri);
            webBrowser1.Navigate(_logoutUrl.AbsoluteUri);
        }
    }
}
