using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Miracle
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            ToDebug.Select();
        }

        private void ToHashTable_Click(object sender, EventArgs e)
        {
            Form2 Students = new Form2();
            Students.StartPosition = FormStartPosition.Manual;
            Students.Location = new Point(this.Width / 2 - this.Width / 2 + this.Location.X,
                                      this.Height / 2 - this.Height / 2 + this.Location.Y);
            Hide();
            Students.Show();
        }

        private void ToTree_Click(object sender, EventArgs e)
        {
            Form3 Comission = new Form3();
            Comission.StartPosition = FormStartPosition.Manual;
            Comission.Location = new Point(this.Width / 2 - this.Width / 2 + this.Location.X,
                                      this.Height / 2 - this.Height / 2 + this.Location.Y);
            Hide();
            Comission.Show();
        }

        private void ToSearch_Click(object sender, EventArgs e)
        {
            Menu Fundament = new Menu();
            Fundament.StartPosition = FormStartPosition.Manual;
            Fundament.Location = new Point(this.Width / 2 - this.Width / 2 + this.Location.X,
                                      this.Height / 2 - this.Height / 2 + this.Location.Y);
            Hide();
            Fundament.Show();
        }

        private void View_Debug_Hash_Table()
        {
            int number;
            Node<Student> tmp;
            for (int i = 0; i < Program.Table.GetSize(); i++)
            {
                if (Program.Table.table[i].head!=null)
                {
                    number = 1;
                    tmp = Program.Table.table[i].head;
                    while (tmp != null)
                    {
                        dataGridView2.Rows.Add(dataGridView2.Rows.Count + 1, i,
                        Program.Table.Hash_function(Program.Table.table[i].head.data.fio),
                        number,
                        tmp.data.fio,
                        tmp.data.group,
                        tmp.data.direction);
                        tmp = tmp.next;
                        number++;
                    }
                }
                else
                {
                    dataGridView2.Rows.Add(dataGridView2.Rows.Count + 1, "null", "null", "null", "null", "null");
                }
                
            }
        }

        void PrintTree(Tnode tmp, int h)
        {
            string str = string.Empty;
            if (tmp != null)
            {
                Comissions act = tmp.data;
                PrintTree(tmp.right, h + 4);
                for (int i = 0; i < h; i++) 
                {
                    str = str + "—"; 
                }
                str = str + tmp.data.subject + " " + tmp.data.type;
                dataGridView1.Rows.Add(str);                           
                PrintTree(tmp.left, h + 4);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView3.AllowUserToAddRows = false;
            dataGridView4.AllowUserToAddRows = false;
            View_Debug_Hash_Table();
            PrintTree(Program.Tree.root, 4);
        }

        private void Show_descendants(Tnode Selected)
        {
            if (Selected!=null)
            {
                if (Selected.left != null)
                {
                    dataGridView4.Rows.Add("Левый потомок", Selected.left.data.subject, Selected.left.data.type);
                }
                else
                {
                    dataGridView4.Rows.Add("Левый потомок", "null", "null");
                }

                if (Selected.right != null)
                {
                    dataGridView4.Rows.Add("Правый потомок", Selected.right.data.subject, Selected.right.data.type);
                }
                else
                {
                    dataGridView4.Rows.Add("Правый потомок", "null", "null");
                }
            }
        }

        private void Show_fio_list(Tnode Selected)
        {
            Node<string> tmp;
            tmp = Selected.data.fio.head;
            while (tmp != null)
            {
                dataGridView3.Rows.Add(dataGridView3.Rows.Count + 1, tmp.data);
                tmp = tmp.next;
            }
        }

        private Comissions Tree_Subject(string full)
        {
            int start = 0;
            while (full[start] =='—')
            {
                start++;
            }
            string type = full.Substring(full.LastIndexOf(" ")+1);
            string subject = full.Substring(start, full.Length - type.Length - start - 1); 
            Comissions com = new Comissions(subject,type);
            return com;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            Tnode Selected = Program.Tree.Search(Tree_Subject(dataGridView1.CurrentCell.Value.ToString()));
            Show_descendants(Selected);
            Show_fio_list(Selected);
        }
    }
}
