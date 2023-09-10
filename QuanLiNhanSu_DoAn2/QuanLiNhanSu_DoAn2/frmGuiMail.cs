using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net.Mail;
using System.Net;

namespace QuanLiNhanSu_DoAn2
{
    public partial class frmGuiMail : DevExpress.XtraEditors.XtraForm
    {
        public frmGuiMail()
        {
            InitializeComponent();
        }
        void reset()
        {
            txtTieuDe.Clear();
            txtNoiDung.Clear();
        }
        void GuiMail(string from, string to, string subject, string message)
        {
            MailMessage mess = new MailMessage(from, to, subject, message);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;

            client.Credentials = new NetworkCredential(txtTaiKhoan.Text, txtMatKhau.Text);

            client.Send(mess);
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            GuiMail(txtTaiKhoan.Text, txtTo.Text, txtTieuDe.Text, txtNoiDung.Text);
            MessageBox.Show("Phản hồi ý kiến thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}