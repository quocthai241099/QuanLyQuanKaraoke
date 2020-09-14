using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ThietKeControl
{
    public class txtNhapSo:TextBox
    {
        public txtNhapSo()
        {
            this.KeyPress += txtNhapSo_KeyPress;
        }
        void txtNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar))
                {
                    e.Handled=true;
                }
        }
    }
}
