﻿using System;
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
    public partial class Busses : Form
    {
        public Busses()
        {
            InitializeComponent();
        }

        private void btnAddBusses_Click(object sender, EventArgs e)
        {
            new AddBus().ShowDialog();
        }
    }
}
