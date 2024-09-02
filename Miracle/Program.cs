using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Miracle
{
    class Program
    {
        static public Hash_table Table = new Hash_table(15);
        static public Binary_tree Tree = new Binary_tree();
        static string[] StudentsF = File.ReadAllLines("Студенты СД.txt");
        static string[] ComissionF = File.ReadAllLines("Задолженности СД.txt");
        static public int count = 0;

        static void Read_f1(Student[] mas)
        {
            string k = string.Empty;
            int ind = 0;
            foreach (string str in StudentsF)
            {
                k = str;
                mas[ind].fio = k.Substring(0, k.IndexOf(" ")) + " ";
                k = k.Remove(0, k.IndexOf(" ") + 1);

                mas[ind].fio = mas[ind].fio + k.Substring(0, k.IndexOf(" ")) + " ";
                k = k.Remove(0, k.IndexOf(" ") + 1);

                mas[ind].fio = mas[ind].fio + k.Substring(0, k.IndexOf(" "));
                k = k.Remove(0, k.IndexOf(" ") + 1);

                mas[ind].group = k.Substring(0, k.IndexOf(" "));
                k = k.Remove(0, k.IndexOf(" ") + 1);

                mas[ind].direction = k;
                ind++;
            }
        }

        static public Hash_table HTable()
        {
            int size = StudentsF.Length;
            Student[] mas_f = new Student[size];
            for (int i = 0; i < size; i++)
            {
                mas_f[i] = new Student();
            }
            Read_f1(mas_f);
            foreach (Student f in mas_f)
            {
                Table.Addition(f);
            }
            return Table;
        }

        static void Read_f2(Comissions[] mas)
        {
            string fio = string.Empty;
            string k = string.Empty;
            int ind = 0;
            foreach (string str in ComissionF)
            {
                k = str;
                fio = k.Substring(0, k.IndexOf(" ")) + " ";
                k = k.Remove(0, k.IndexOf(" ") + 1);

                fio = fio + k.Substring(0, k.IndexOf(" ")) + " ";
                k = k.Remove(0, k.IndexOf(" ") + 1);

                fio = fio + k.Substring(0, k.IndexOf(" "));
                k = k.Remove(0, k.IndexOf(" ") + 1);

                mas[ind].fio = new List<string>();
                mas[ind].fio.Addition(fio);

                mas[ind].type = k.Substring(0, k.IndexOf(" "));
                k = k.Remove(0, k.IndexOf(" ") + 1);

                mas[ind].subject = k;

                ind++;
            }
        }

        static public Binary_tree BinTree()
        {
            int r_1 = ComissionF.Length;
            Comissions[] mas_a = new Comissions[r_1];
            for (int i = 0; i < r_1; i++)
            {
                mas_a[i] = new Comissions();
            }
            Read_f2(mas_a);
            foreach (Comissions s in mas_a)
            {
                Tree.Add(s);
            }
            return Tree;;
        }

        public static void Save_in_File(string[] data, string name)
        {
            string path = @"C:\Users\gemin\source\repos\Miracle\Miracle\bin\Debug\" + name + ".txt";
            File.WriteAllText(path, String.Empty);
            for (int i = 0; i < data.Length; i++)
            {
                File.AppendAllText(path, data[i] + "\n");
            }
        }

        public static void ShowErrorWindow(string s)
        {
            Form5 error = new Form5();
            error.Message = s;
            error.ShowDialog();
        }

        [STAThread]
        static void Main()
        {
            HTable();
            BinTree();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}
