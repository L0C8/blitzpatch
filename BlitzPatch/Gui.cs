using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlitzPatch
{
    public partial class Gui : Form
    {
        public Gui()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            // unit editor
            uniteditor_factions_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            uniteditor_factions_combo.Items.AddRange(GameData.factions);
            uniteditor_factions_combo.SelectedIndex = 0;
            //
            uniteditor_unitfaction_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            uniteditor_unitfaction_combo.Items.AddRange(GameData.factions);
            uniteditor_unitfaction_combo.SelectedItem = 1;
            uniteditor_unittype_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            uniteditor_unittype_combo.Items.AddRange(GameData.units_ald);
            uniteditor_unittype_combo.SelectedItem = 1;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void uniteditor_unitfaction_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Console.WriteLine(uniteditor_unitfaction_combo.SelectedIndex);
            uniteditor_unittype_combo.Items.Clear();
            switch (uniteditor_unitfaction_combo.SelectedIndex)
            {
                case (0):
                    uniteditor_unittype_combo.Items.AddRange(GameData.units_ald);
                    break;
                case (1):
                    uniteditor_unittype_combo.Items.AddRange(GameData.units_sov);
                    break;
                case (2):
                    uniteditor_unittype_combo.Items.AddRange(GameData.units_ger);
                    break;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
