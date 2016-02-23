using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lv01_Controllers;

namespace DesktopUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Test();
        }

        void Test()
        {
            Controller C = new Controller();
            C.Test();
        }
    }
}
