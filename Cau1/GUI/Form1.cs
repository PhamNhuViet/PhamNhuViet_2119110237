using Cau1.BAL;
using Cau1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cau1
{
    public partial class Form1 : Form
    {
        EmployeeBAL epBAL = new EmployeeBAL();
        DepartmentBAL deBAL = new DepartmentBAL();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<EmployeeBEL> lstep = epBAL.ReadEmployee();
            foreach (EmployeeBEL ep in lstep)
            {
                dtngaysinh.Format = DateTimePickerFormat.Short;
                dataGridView1.Rows.Add(ep.EmployeeId, ep.EmployeeName, ep.EmployeeDateBirth.ToShortDateString(), ep.EmployeeGender, ep.EmployeePlaceBirth, ep.NameDepartment);
            }
            List<DepartmentBEL> lstDepartment = deBAL.ReadDepartmentList();
            foreach (DepartmentBEL department in lstDepartment)
            {
                combodonvi.Items.Add(department);
            }

            combodonvi.DisplayMember = "Name";
        }

        private void dtg_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbId.Text = dataGridView1.Rows[idx].Cells[0].Value.ToString();
                tbName.Text = dataGridView1.Rows[idx].Cells[1].Value.ToString();
                dtngaysinh.Text = dataGridView1.Rows[idx].Cells[2].Value.ToString();
                string cb = dataGridView1.Rows[idx].Cells[3].Value.ToString();
                if (cb == "True")
                {
                    cbgoitinh.Checked = true;
                }
                else
                {
                    cbgoitinh.Checked = false;
                }
                tbnoisinh.Text = dataGridView1.Rows[idx].Cells[4].Value.ToString();
                combodonvi.Text = dataGridView1.Rows[idx].Cells[5].Value.ToString();
                tbId.Enabled = false;
            }
        }

        private void btnEXIT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát hay không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                this.Close();
        }

        private void btnDELETE_Click(object sender, EventArgs e)
        {
            if (tbId.Text == "")
            {
                MessageBox.Show("Không có đối tượng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            if (MessageBox.Show("Bạn có muốn xóa hay không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                EmployeeBEL ep = new EmployeeBEL();
                ep.EmployeeId = tbId.Text.ToString();

                epBAL.DeleteEmployee(ep);
                int idx = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(idx);
            }
        }
    }
}
