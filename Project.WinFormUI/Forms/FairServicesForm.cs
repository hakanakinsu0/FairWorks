using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinFormUI.Forms
{
    public partial class FairServicesForm : Form
    {
        public Building SelectedBuilding { get; set; } // Seçilen bina bilgisi
        public decimal BuildingCost { get; set; }      // Binanın maliyeti

        public FairServicesForm()
        {
            InitializeComponent();
        }
    }
}
