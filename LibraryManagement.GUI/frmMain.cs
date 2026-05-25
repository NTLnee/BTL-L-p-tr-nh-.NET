using LibraryManagement.Models;

namespace LibraryManagement.GUI
{
    public partial class frmMain : Form
    {
        private TaiKhoan _currentUser;

        public frmMain(TaiKhoan user)
        {
            InitializeComponent();
            _currentUser = user;
            ApplyPermission(user.Role);
        }

        // Load form con vào panel chính
        private void LoadChildForm(Form form)
        {
            foreach (Control c in panelMain.Controls)
                c.Dispose();

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            panelMain.Controls.Add(form);
            panelMain.Tag = form;
            form.BringToFront();
            form.Show();
        }

        // Phân quyền ẩn/hiện menu theo Role
        private void ApplyPermission(string role)
        {
            // Ví dụ — đặt tên button sidebar đúng với Designer
            btnAdmin.Visible    = (role == "Admin");
            btnBaoCao.Visible   = (role != "DocGia");
            btnMuonSach.Visible = (role != "DocGia");
            btnDocGia.Visible   = (role != "DocGia");
        }

        // === CÁC NÚT SIDEBAR ===
        private void btnSach_Click(object sender, EventArgs e)
            => LoadChildForm(new Forms.Books.frmQuanLySach());

        private void btnDocGia_Click(object sender, EventArgs e)
            => LoadChildForm(new Forms.Readers.frmQuanLyDocGia());

        private void btnMuonSach_Click(object sender, EventArgs e)
            => LoadChildForm(new Forms.Borrowing.frmMuonSach());

        private void btnBaoCao_Click(object sender, EventArgs e)
            => LoadChildForm(new Forms.Reports.frmBaoCao());

        private void btnAdmin_Click(object sender, EventArgs e)
            => LoadChildForm(new Forms.Admin.frmQuanLyTaiKhoan());

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                new Forms.Auth.frmDangNhap().Show();
                this.Close();
            }
        }
    }
}
