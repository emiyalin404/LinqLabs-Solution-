using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmLINQ架構介紹_InsideLINQ : Form
    {
        public FrmLINQ架構介紹_InsideLINQ()
        {
            InitializeComponent();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            ArrayList arrList = new ArrayList();
                arrList.Add(2);
                arrList.Add(4);

            var q = from n in arrList.Cast<int>()
                    select new { N = n };
            this.dataGridView1.DataSource = q.ToList();
                    }

        private void button7_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Fill(nwDataSet1.Products);
            var q = (from p in nwDataSet1.Products
                     orderby p.UnitsInStock descending
                     select p).Take(5);
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] a= { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            this.productsTableAdapter1.Fill(nwDataSet1.Products);

            listBox1.Items.Add("Sum = " + a.Sum());
            listBox1.Items.Add("max = " + a.Max());
            listBox1.Items.Add("min = " + a.Min());
            listBox1.Items.Add("Avg = " + a.Average());
            listBox1.Items.Add("count = " + a.Count());
            this.listBox1.Items.Add("Max UnitPrice=" + this.nwDataSet1.Products.Max(p => p.UnitPrice));
            this.listBox1.Items.Add("Max UnitPrice=" + $"{this.nwDataSet1.Products.Average(p =>  p.UnitPrice):c2}");
        }
    }
}