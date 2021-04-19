using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeDB
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
         private void mainForm_Load(object sender, EventArgs e)
         {
                // TODO: This line of code loads data into the 'personnelDataSet.Employee' table. You can move, or remove it, as needed.
                this.employeeTableAdapter.Fill(this.personnelDataSet.Employee);
         }
        private void employeeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.personnelDataSet);

        }
        private void btnDetails_Click(object sender, EventArgs e)
        {
            Details detailsForm = new Details();//Create an instance of new form
            detailsForm.ShowDialog();//shift the focus to the new form
            employeeTableAdapter.Fill(personnelDataSet.Employee);//refill the dataset after closing the new form
        }

        private void btnSortPayAsc_Click(object sender, EventArgs e)
        {
            employeeTableAdapter.FillByHourlyPayAsc(personnelDataSet.Employee);//Call the ascending sort method written in table adpter
        }

        private void btnSortPayDesc_Click(object sender, EventArgs e)
        {
            employeeTableAdapter.FillByHourlyPayDesc(personnelDataSet.Employee);//Call the descending sort method written in table adpter
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();//Create an instance of new form
            searchForm.ShowDialog();//shift the focus to the new form
        }

        private void btnHighestPayRate_Click(object sender, EventArgs e)
        {
            MessageBox.Show(employeeTableAdapter.FindMaxPay().ToString());//Call the table adapter query to return the max pay rate
        }

        private void btnLowestPayRate_Click(object sender, EventArgs e)
        {
            MessageBox.Show(employeeTableAdapter.FindMinPay().ToString());//Call the table adapter query to return the min pay rate
        }
    }
}
