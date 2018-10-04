using ProjectQUANLYSINHVIEN.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectQUANLYSINHVIEN.GUI
{
    public partial class fBaocao : Form
    {

        public fBaocao()
        {
            InitializeComponent();
        }

        private void fBaocao_Load(object sender, EventArgs e)
        {
            double DiemTong;
            int tong = fKetquahoctap.dt.Rows.Count;
            int tong1 = fKetquahoctap.dt1.Rows.Count;
            lbTensinhvien.Text = fKetquahoctap.Tensinhvien;
            lbTenlop.Text = fKetquahoctap.Tenlop;
            lbTenkhoa.Text = fKetquahoctap.Tenkhoa;
            grcDiemTkdathi.DataSource = fKetquahoctap.dt;
            grcDiemTkchuathi.DataSource = fKetquahoctap.dt1;
            DiemTong = fKetquahoctap.TD / (tong+tong1);
            lbDiemTK.Text = Convert.ToString(DiemTong);
        }
    }
}
