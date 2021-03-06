﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WeMo_Switch.Classes;

namespace WeMo_Switch
{
    public partial class StartForm : Form
    {
        private string ipAddr;

        public StartForm()
        {
            InitializeComponent();
            lblVersion.Text = Program.devVersion;
            txtIPAddr.Text = "192.168.2.36";    // test IP
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ipAddr = txtIPAddr.Text;
            this.Cursor = Cursors.WaitCursor;
            ControllerForm newForm = new ControllerForm(ipAddr);
            this.Hide();
            try
            {
                newForm.ShowDialog();
            }
            catch
            {

            }
            this.Cursor = Cursors.Default;
            this.Show();

            
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            btnRefresh.Enabled = false;
            LocateWeMo pingTest = new LocateWeMo();
            int maxTimes = 100; 
            progFind.Maximum = maxTimes;
            progFind.Minimum = 0;
            progFind.Step = 1;
            pingTest.findAllDevices(ref txtResults, ref progFind);
            btnRefresh.Enabled = true;
            this.Cursor = Cursors.Default;
            
        }

        private void txtResults_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
