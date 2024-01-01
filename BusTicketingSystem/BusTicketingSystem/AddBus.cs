using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusTicketingSystem
{
    public partial class AddBus : Form
    {
        Busses Busses = new Busses();

        private SubUrbQueryClass SubUrbQuery;
        private string BusType, PlateNo;
        private int BusNo, Capacity;
        public AddBus()
        {
            InitializeComponent();
            
        }
        private void AddBus_Load(object sender, EventArgs e)
        {
           SubUrbQuery = new SubUrbQueryClass();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            BusType = txtBusType.Text;
            PlateNo = txtPlateNo.Text;
            BusNo = Convert.ToInt32(txtBusNo.Text);
            Capacity = Convert.ToInt32(txtCapacity.Text);
            SubUrbQuery.addBus(BusType, PlateNo, BusNo, Capacity);

            MessageBox.Show("Successfully Added!", "Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
        public void RefreshBusList()
        {
            SubUrbQuery.DisplayBusList();
            Busses.dgvBusses.DataSource = SubUrbQuery.bindingSource;
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       
    }
}
