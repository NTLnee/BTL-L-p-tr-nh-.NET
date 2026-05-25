using LibraryManagement.GUI.Forms.Auth;

namespace LibraryManagement.GUI;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new frmDangNhap());  // ← Sửa từ Form1 thành frmDangNhap
    }
}
