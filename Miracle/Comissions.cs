using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miracle
{
    public class Comissions//+
    {
        public List<string> fio;
        public string type;
        public string subject;

        public Comissions()//+
        {
            subject = string.Empty;
            type = string.Empty;
            fio = new List<string>();
        }

        public Comissions(string fio)//+
        {
            subject = string.Empty;
            type = string.Empty;
            this.fio = new List<string>();
            this.fio.Addition(fio);
        }

        public Comissions(string subject, string type, string fio)//+
        {
            this.subject = subject;
            this.type = type;
            this.fio = new List<string>();
            this.fio.Addition(fio);
        }

        public Comissions(string subject, string type)//+
        {
            this.subject = subject;
            this.type = type;
            this.fio = new List<string>();
        }

        public static bool operator < (Comissions a, Comissions b)//+
        {
            int A = 0, B = 0;
            if (a.type == "экзамен")
            {
                A++;
            }
            if (b.type == "экзамен")
            {
                B++;
            }
            for (int i = 0; i < a.subject.Length; i++)
            {
                A += Math.Abs(a.subject[i]);
            }
            for (int i = 0; i < b.subject.Length; i++)
            {
                B += Math.Abs(b.subject[i]);
            }
            if (A < B) { return true;}
            return false;
        }

        public static bool operator > (Comissions a, Comissions b)//+
        {
            int A = 0, B = 0;
            if (a.type == "экзамен")
            {
                A++;
            }
            if (b.type == "экзамен")
            {
                B++;
            }
            for (int i = 0; i < a.subject.Length; i++)
            {
                A += Math.Abs(a.subject[i]);
            }
            for (int i = 0; i < b.subject.Length; i++)
            {
                B += Math.Abs(b.subject[i]);
            }
            if (A > B) { return true;}
            return false;
        }

        public bool Correctness_of_fio()//+
        {
            if (string.IsNullOrEmpty(fio.head.data))
            {
                return false;
            }

            for (int i = 1; i < fio.head.data.Length; i++)
            {
                if (fio.head.data[i] < 1040 || fio.head.data[i] > 1103)
                {
                    if (fio.head.data[i] != ' ' && fio.head.data[i] != '-')
                    {
                        return false;
                    }
                }
            }

            for (int i = 1; i < fio.head.data.Length; i++)
            {
                if ((fio.head.data[i] >= 1040 && fio.head.data[i] < 1072) && (fio.head.data[i - 1] != ' ' && fio.head.data[i - 1] != '-'))
                {
                    if (fio.head.data[i] != ' ' && fio.head.data[i] != '-')
                    {
                        return false;
                    }
                }
            }

            if (fio.head.data[0] < 1040 || fio.head.data[0] > 1071)
            {
                return false;
            }
            else
            {
                int i = 0;
                if (fio.head.data[fio.head.data.Length - 1] == ' ')
                {
                    fio.head.data = fio.head.data.Remove(fio.head.data.Length - 1);
                }

                string k = fio.head.data;
                int words = 0;
                while (i != -1)
                {
                    i = k.IndexOf(" ");
                    if (i != -1)
                    {
                        words++;
                        if ((k[k.IndexOf(" ") + 1] < 1040 || k[k.IndexOf(" ") + 1] > 1071))
                        {
                            return false;
                        }
                        k = k.Remove(0, k.IndexOf(" ") + 1);
                    }
                }

                if (words < 1)
                {
                    return false;
                }

                i = 0;
                k = fio.head.data;
                while (i != -1)
                {
                    i = k.IndexOf("-");
                    if (i != -1)
                    {
                        if ((k[k.IndexOf("-") + 1] < 1040 || k[k.IndexOf("-") + 1] > 1071))
                        {
                            return false;
                        }
                        k = k.Remove(0, k.IndexOf("-") + 1);
                    }
                }
            }
            return true;
        }

        public bool Correctness_of_subject()//+
        {
            if (string.IsNullOrEmpty(subject))
            {
                return false;
            }

            if (subject[0] < 1040 || subject[0] > 1071)
            {
                return false;
            }

            for (int i = 1; i < subject.Length; i++)
            {
                if (subject[i] < 1072 || subject[i] > 1103)
                {
                    if (subject[i] != ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

}
