using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class Frm作業_1 : Form
    {
        public Frm作業_1()
        {
            InitializeComponent();
            this.productsTableAdapter1.Fill(nwDataSet1.Products);

            students_scores = new List<Student>()
                                         {
                                            new Student{ Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                                            new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "ddd", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
                                            new Student{ Name = "fff", Class = "CS_102", Chi = 80, Eng = 80, Math = 80, Gender = "Female" },

                                          };
        }

        public void Theclear()
        {
            this.dataGridView1.Columns.Clear();
            this.dataGridView2.Columns.Clear();


        }


        List<Student> students_scores;

        public class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public int Chi { get; set; }
            public int Eng { get; internal set; }
            public int Math { get; set; }
            public string Gender { get; set; }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
        int i;
        int T;
        int B;
        //int c;
        //int f;
        //public static int f(int i, int c)
        //{
        //    return i * (c - 1);
        //}
   
        public void button13_Click(object sender, EventArgs e)
        {
            //Theclear();
            //c += 1;
            //f = (c - 1);

            //T += i;
            B = T;
            i = (Convert.ToInt32(textBox1.Text));
            var q = (from n in nwDataSet1.Products
                     select n).Skip(B).Take(i);
            this.dataGridView1.DataSource = q.ToList();

            //B = T + i;
            T += i;
            //if(i)

            //this.nwDataSet1.Products.Take(10);//Top 10 Skip(10)

            //Distinct()
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Theclear();
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();
            //this.dataGridView1.DataSource = files;
            var q = from n in files
                    where n.Extension == ".log"
                    select n;


            this.dataGridView1.DataSource = q.ToList();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            #region 搜尋 班級學生成績
            Theclear();
            // 
            // 共幾個 學員成績 ?						
            this.dataGridView1.DataSource = students_scores;
 
            #endregion

        }

        private void button37_Click(object sender, EventArgs e)
        {
            //new {.....  Min=33, Max=34.}
            // 找出 'aaa', 'bbb' 'ccc' 學員 國文數學兩科 科目成績  |		

            //個人 所有科的  sum, min, max, avg


        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.ordersTableAdapter1.Fill(nwDataSet1.Orders);
            dataGridView1.DataSource = nwDataSet1.Orders;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Theclear();
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();
            //this.dataGridView1.DataSource = files;
            var q = from n in files
                    where n.CreationTime.Year == 2019
                    select n;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Theclear();
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();
            //this.dataGridView1.DataSource = files;
            var q = from n in files
                    where n.Length > 100000
                    select n;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Theclear();
        }

        private void Frm作業_1_Load(object sender, EventArgs e)
        {

            this.ordersTableAdapter1.Fill(nwDataSet1.Orders);
            var q = from s in nwDataSet1.Orders
                    select s.OrderDate.Year;

            List<int> list = new List<int>();
            foreach (var item in q.Distinct())
                comboBox1.Items.Add(item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Theclear();
            this.ordersTableAdapter1.Fill(nwDataSet1.Orders);
            this.order_DetailsTableAdapter1.Fill(nwDataSet1.Order_Details);

            var q = from p in nwDataSet1.Orders
                    where p.OrderDate.Year.ToString() == comboBox1.Text && !p.IsShipPostalCodeNull() && !p.IsShipRegionNull() && !p.IsShippedDateNull()
                    select p;
            this.dataGridView1.DataSource = q.ToList();

            var q1 = from b in q.ToList()
                     join a in nwDataSet1.Order_Details
                            on b.OrderID equals a.OrderID
                     select a;
            this.dataGridView2.DataSource = q1.ToList();
            //join a in nwDataSet1.Order_Details
            //        on p.OrderID equals a.OrderID
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //c -= 1;
            i = (Convert.ToInt32(textBox1.Text));
            B -= i;

            var q = (from n in nwDataSet1.Products
                     select n).Skip(B).Take(i);
            this.dataGridView1.DataSource = q.ToList();
            T = B + i;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Theclear();
            //找出 前面三個 的學員所有科目成績
            var q = (from p in students_scores
                     orderby p.Name
                     select p).Take(3);
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Theclear();
            //找出 後面三個 的學員所有科目成績
            var q = (from p in students_scores
                     orderby p.Name
                     select p).Skip(students_scores.Count - 3)/*.Take(students_scores.Count-3)*/;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
             Theclear();
            // 找出 Name 'aaa','bbb','ccc' 的學成績	 
            // //IEnumerable<string> q = students_scores.Where<string>( n=> n ="aaa")
            var q = from p in students_scores
                    where p.Name == "aaa" || p.Name == "bbb" || p.Name == "ccc"
                    select p;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Theclear();
            // 找出學員 'bbb' 的成績
            var q = from p in students_scores
                    where p.Name == "bbb"
                    select p;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Theclear();
            //找出除了 'bbb' 學員的學員的所有成績('bbb' 退學)
            var q = from p in students_scores
                    where p.Name != "bbb"
                    select p;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Theclear();
            //數學不及格... 是誰
            var q = from p in students_scores
                    where p.Math <60
                    select p;
            this.dataGridView1.DataSource = q.ToList();
        }
    }
}
