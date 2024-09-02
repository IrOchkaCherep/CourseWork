using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Miracle
{
    
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            ToSearch.Select();

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

        private void ToDebug_Click(object sender, EventArgs e)
        {
            Form4 Debug = new Form4();
            Debug.StartPosition = FormStartPosition.Manual;
            Debug.Location = new Point(this.Width / 2 - this.Width / 2 + this.Location.X,
                                      this.Height / 2 - this.Height / 2 + this.Location.Y);
            Hide();
            Debug.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
        }

        private void Save_Rezault_in_File(string s, string path)
        {
            File.AppendAllText(path,s); 
        }

        private void Show_Search(Tnode tmp)
        {
            Node<Student> Row_head = new Node<Student>();
            if (tmp != null)
            {
                Node<string> curr = tmp.data.fio.head;
                while (curr != null)
                {
                    int ind = Program.Table.Hash_function(curr.data);
                    Row_head = Program.Table.table[ind].head;
                    while (Row_head != null)
                    {
                        if ((Row_head.data.group == Group.Text) && (Row_head.data.fio == curr.data))
                        {
                            dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, curr.data, tmp.data.type);
                            break;
                        }
                        Row_head = Row_head.next;
                        Program.count++;
                    }
                    curr = curr.next;
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
         {
            Program.count = 0;
            dataGridView1.Rows.Clear();
            Comissions Credit = new Comissions(Subject.Text,"зачёт");
            Comissions Exam = new Comissions(Subject.Text, "экзамен");
            Student check = new Student();
            check.group = Group.Text;
            if (check.Correctness_of_group())
            {
                if (Credit.Correctness_of_subject())
                {
                    Tnode tmp1 = Program.Tree.Search(Credit);
                    Tnode tmp2 = Program.Tree.Search(Exam);

                    if ((tmp1 == null) && (tmp2 == null))
                    {
                        dataGridView1.Rows.Add(0, "null", "null");
                        count.Text = Program.count.ToString();
                        Program.ShowErrorWindow("Предупреждение:\nпоиск был неудачен так как ни у кого нет задолженности по данной дисциплине");
                        return;
                    }
                    else
                    {
                        Show_Search(tmp1);
                        Show_Search(tmp2);
                        count.Text = Program.count.ToString();
                        Program.Save_in_File(Get_Search_Massive(), "SavedSearch");
                        if (dataGridView1.Rows.Count == 0)
                        {
                            dataGridView1.Rows.Add(0, "null", "null");
                            count.Text = Program.count.ToString();
                            Program.ShowErrorWindow("Предупреждение:\nпоиск был неудачен так как ни у кого в заданной вами группе нет задолженности по данной дисциплине");
                        }
                    }
                }
                else
                {
                    Subject.Clear();
                    Program.ShowErrorWindow("ОШИБКА:\nдисциплина указана неверно");
                    return;
                }
            }
            else
            {
                Group.Clear();
                Program.ShowErrorWindow("ОШИБКА:\nгруппа указана неверно");
                return;
            }
        }

        private string[] Get_Search_Massive()
        {
            string[] table = new string[dataGridView1.Rows.Count];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = dataGridView1[1, i].Value.ToString() + " " + dataGridView1[2, i].Value.ToString();
            }
            return table;
        }
    }
}
