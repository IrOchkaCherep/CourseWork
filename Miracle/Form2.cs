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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            ToHashTable.Select();
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

        private void ToDebug_Click(object sender, EventArgs e)
        {
            Form4 Debug = new Form4();
            Debug.StartPosition = FormStartPosition.Manual;
            Debug.Location = new Point(this.Width / 2 - this.Width / 2 + this.Location.X,
                                      this.Height / 2 - this.Height / 2 + this.Location.Y);
            Hide();
            Debug.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            View_Hash_Table();
        }
        
        private void View_Hash_Table()
        {
            Node<Student> tmp;
            for (int i = 0; i < Program.Table.GetSize(); i++)
            {
                if (Program.Table.table[i].head != null)
                {
                    tmp = Program.Table.table[i].head;
                    while (tmp != null)
                    {
                        dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, tmp.data.fio, tmp.data.group, tmp.data.direction);
                        tmp = tmp.next;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            if (radioButton1.Checked)
            {
                Student Selected = new Student(Surname.Text + " " + Nam.Text + " " + Patronimyc.Text, Group.Text, Direction.Text);

                if (Selected.Correctness_of_fio())
                {
                    if (Selected.Correctness_of_group())
                    {
                        if (Selected.Correctness_of_direction())
                        {
                            if (Program.Table.Searh(Selected.fio) == null)
                            {
                                Program.Table.Addition(Selected);
                                View_Hash_Table();
                                Program.Save_in_File(Get_Hash_Table_Massive(), "SavedTable");
                            }
                            else
                            {
                                View_Hash_Table();
                                Surname.Clear();
                                Nam.Clear();
                                Patronimyc.Clear();
                                Program.ShowErrorWindow("Предупреждение:\nбыла совершена попытка добавления повторяющегося ФИО");
                                return;
                            }
                        }
                        else
                        {
                            Direction.Clear();
                            View_Hash_Table();
                            Program.ShowErrorWindow("ОШИБКА:\nНаправление подготовки указано неверно");
                            return;
                        }
                    }
                    else
                    {
                        Group.Clear();
                        View_Hash_Table();
                        Program.ShowErrorWindow("ОШИБКА:\nНомер группы указан неверно");
                        return;
                    }
                }
                else
                {
                    Surname.Clear();
                    Nam.Clear();
                    Patronimyc.Clear();
                    View_Hash_Table();
                    Program.ShowErrorWindow("ОШИБКА:\nФИО указано неверно");
                    return;
                }
            }
            else
            {
                Student Selected = new Student(Surname.Text + " " +  Nam.Text + " " + Patronimyc.Text);

                if (radioButton2.Checked)
                {
                    if (Program.Table.Searh(Selected.fio)!=null)
                    {
                        Program.Table.Deletion(Selected);
                        View_Hash_Table();
                        Program.Tree.Delete_Students_in_Tree(Program.Tree.root, Selected.fio);
                        Program.Save_in_File(Get_Hash_Table_Massive(), "SavedTable");
                        return;
                    }
                    else
                    {
                        View_Hash_Table();
                        Program.ShowErrorWindow("Предупреждение:\nбыла попытка удаления несуществующего элемента");
                        return;
                    }
                }

                if (radioButton3.Checked)
                {
                    Program.count = 0;
                    Node<Student> tmp;
                    tmp = Program.Table.Searh(Selected.fio);
                    if (tmp!= null)
                    {
                        dataGridView1.Rows.Add(1, tmp.data.fio, tmp.data.group, tmp.data.direction);
                    }
                    else
                    {
                        dataGridView1.Rows.Add(0, "null", "null", "null", "null");
                    }
                    count.Text = Program.count.ToString();
                    return;
                }
            }

            if (radioButton4.Checked)
            {
                dataGridView1.Rows.Clear();
                groupBox1.Visible = false;
                Surname.Clear();
                Nam.Clear();
                Patronimyc.Clear();
                Group.Clear();
                Direction.Clear();
                View_Hash_Table();
                radioButton4.Checked = false;
                return;
            }

            if (!radioButton4.Checked && !radioButton3.Checked && !radioButton2.Checked && !radioButton1.Checked)
            {
                View_Hash_Table();
                Program.ShowErrorWindow("ОШИБКА:\nвы не выбрали операцию");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private string[] Get_Hash_Table_Massive()
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
//Program.Table.table[i].head.data.GetType().GetField("direction", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).GetValue(Program.Table.table[i].head.data));/*direction*/
//((Student)Program.Table.table[i].head.data).ToString("fio")/*fio*/,