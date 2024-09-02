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
    public partial class Form3 : Form
    {
        string typeStr;
        public Form3()
        {
            InitializeComponent();
            ToTree.Select();
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

        private void ToSearch_Click(object sender, EventArgs e)
        {
            Menu Fundament = new Menu();
            Fundament.StartPosition = FormStartPosition.Manual;
            Fundament.Location = new Point(this.Width / 2 - this.Width / 2 + this.Location.X,
                                      this.Height / 2 - this.Height / 2 + this.Location.Y);
            Hide();
            Fundament.Show();
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

        private void Symmetric(Tnode root)
        {
            Node<string> tmp;
            if (root != null)
            {
                Symmetric(root.left);
                tmp = root.data.fio.head;
                while (tmp != null)
                {
                    dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, tmp.data, root.data.subject, root.data.type);
                    tmp = tmp.next;
                }
                Symmetric(root.right);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            Symmetric(Program.Tree.root);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton5.Checked && !radioButton6.Checked)
            {
                Program.ShowErrorWindow("ОШИБКА:\nвы не выбрали операцию");
                return;
            }

            if (!radioButton3.Checked && !radioButton4.Checked)
            {
                Program.ShowErrorWindow("ОШИБКА:\nне выбран тип дисциплины");
                return;
            }

            dataGridView1.Rows.Clear();
            Comissions Selected = new Comissions(Subject.Text, typeStr, Surname.Text + " " + Nam.Text + " " + Patronymic.Text);

            if(radioButton1.Checked == true)
            {
                if (Selected.Correctness_of_fio())
                {
                    if (Selected.Correctness_of_subject())
                    {
                        if(!Program.Tree.Add(Selected))
                        {
                            Symmetric(Program.Tree.root);
                            Program.ShowErrorWindow("ОШИБКА:\nбыла совершена попытка добавления несуществующего студента\nсначала добавьте студента в базу данных со студентами\n или проверьте корректность введённых данных ");
                            
                        }
                        else
                        {
                            Symmetric(Program.Tree.root);
                            Program.Save_in_File(Get_Tree_Massive(), "SavedTree");
                        }
                    }
                    else
                    {
                        Subject.Clear();
                        Symmetric(Program.Tree.root);
                        Program.ShowErrorWindow("ОШИБКА:\nдисциплина указана неверно");
                        return;
                    }

                }
                else
                {
                    Surname.Clear();
                    Nam.Clear();
                    Patronymic.Clear();
                    Symmetric(Program.Tree.root);
                    Program.ShowErrorWindow("ОШИБКА:\nФИО указано неверно");
                    return;
                }
                
            }
            else if(radioButton2.Checked)
            {
                Tnode tmp = Program.Tree.Search(Selected);
                if (tmp != null)
                {
                    if (tmp.data.fio.head.next == null)
                    {
                        Program.Tree.Del(Selected);
                    }
                    else
                    {
                        tmp.data.fio.Deletion(Selected.fio.head.data);
                    }
                    Symmetric(Program.Tree.root);
                    Program.Save_in_File(Get_Tree_Massive(), "SavedTree");
                }
                else
                {
                    Symmetric(Program.Tree.root);
                    Program.ShowErrorWindow("Предупреждение:\nбыла совершена попытка\n удаления несуществующего студента и/или дисциплины");
                }
            }
            else if (radioButton5.Checked)
            {
                Program.count = 0;
                Tnode tmp = Program.Tree.Search(Selected);
                if (tmp != null)
                {
                    Node<string> curr = tmp.data.fio.Searсh(Selected.fio.head.data);
                    if (curr!=null)
                    {
                        dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, curr.data, tmp.data.subject, tmp.data.type);
                        count.Text = Program.count.ToString();
                    }
                    else
                    {
                        dataGridView1.Rows.Add(0, "null", "null", "null");
                        count.Text = Program.count.ToString();
                        Program.ShowErrorWindow("Предупреждение:\nПоиск неудачен так как у этого студента нет задолженности по этому предмету");
                    }
                }
                else
                {
                    count.Text = Program.count.ToString();
                    dataGridView1.Rows.Add(0, "null", "null", "null");
                    Program.ShowErrorWindow("Предупреждение:\nПоиск неудачен так как такой дисциплины нет в базе");
                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            typeStr = "зачёт";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            typeStr = "экзамен";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Surname.Clear();
            Nam.Clear();
            Patronymic.Clear();
            Subject.Clear();
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            Symmetric(Program.Tree.root);
            radioButton6.Checked = false;
        }

        private string[] Get_Tree_Massive()
        {
            string[] table = new string[dataGridView1.Rows.Count];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = dataGridView1[1, i].Value.ToString() + " " + dataGridView1[2, i].Value.ToString() + " " + dataGridView1[3, i].Value.ToString();
            }
            return table;
        }
    }
}
