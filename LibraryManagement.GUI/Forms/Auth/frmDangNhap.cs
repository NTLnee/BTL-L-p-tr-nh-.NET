using BCrypt.Net;
using LibraryManagement.BLL;
using LibraryManagement.Models;

namespace LibraryManagement.GUI.Forms.Auth
{
    public partial class frmDangNhap : Form
    {
        private readonly AuthBLL _authBLL = new();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TaiKhoan? user = _authBLL.Login(username, password);

            if (user == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Đăng nhập thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Đăng nhập thành công → mở frmMain
            new frmMain(user).Show();
            this.Hide();
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnDangNhap_Click(sender, e);
        }
    }
}
