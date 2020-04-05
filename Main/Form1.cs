using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mahjongg;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        MahjonggTable _table = new MahjonggTable();
        Tiles pA, pB, pC, pD;
        
        public Form1()
        {
            
            InitializeComponent();



            for(int i=0; i<dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 50;
                dataGridView2.Columns[i].Width = 50;
                dataGridView3.Columns[i].Width = 50;
                dataGridView4.Columns[i].Width = 50;
            }

            pA = new Tiles();
            pB = new Tiles();
            pC = new Tiles();
            pD = new Tiles();

        }

        private void btnArrange_Click(object sender, EventArgs e)
        {
            _table.Shuffle();
            int diceNum = _table.TakeDice();
            _table.ArrangeTile(diceNum,pA,pB,pC,pD);

            UpdateTilesGridView(dataGridView1, pA);
            UpdateTilesGridView(dataGridView2, pB);
            UpdateTilesGridView(dataGridView3, pC);
            UpdateTilesGridView(dataGridView4, pD);

        }

        private void UpdateTilesGridView(DataGridView grid, Tiles tiles)
        {
            grid.Rows.Clear();
            grid.Rows.Add();
            for(int i=0; i<tiles.Count;i++)
            {
                grid[i, 0].Value = tiles.item[i].GetString();
            }
        }
    }
}
