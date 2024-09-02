using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miracle
{

    public class Student
    {
        public string group;
        public string direction;
        public string fio;

        public Student()//+
        {
            group = string.Empty;
            direction = string.Empty;
            fio = string.Empty;
        }

        public Student(string fio, string group, string direction)//+
        {
            this.group = group;
            this.direction = direction;
            this.fio = fio;
        }

        public Student(string fio)//+
        {
            this.fio = fio;
        }

        public override string ToString()//+
        {
            return fio;
        }

        public bool Correctness_of_group()//+
        {
            if (string.IsNullOrEmpty(group))
            {
                return false;
            }

            if (group.Length < 14)
            {
                return false;
            }

            //корректность первой буквы
            char first = char.ToUpper(group[0]);
            if (first!='Б' && first!='С' && first!='М' && first!='А' && first!= 'О')
            {
                return false;
            }
            //корректность 4 цифр
            string second = group.Substring(1, 4);
            int n;
            if ((int.TryParse(second, out n)!=true)||(n<1000))//Тут есть 4 цифры и 1-ая не 0
            {
                return false;
            }
            else if (second[1]!='1' && second[1]!='2')
            {
                return false;
            }
            n = int.Parse(second.Substring(2, 2));
            if ((n<16)||(n>22))
            {
                return false;
            }
            else if ((group[5]!='-')||(group[8]!='.')|| (group[11] != '.'))
            {
                return false;
            }
            else if ((int.TryParse(group.Substring(6,2), out _) != true) || (int.TryParse(group.Substring(9, 2), out n) != true) || (int.TryParse(group.Substring(12, 2), out n) != true))
            {
                return false;
            }
            else
            {
                for (int i=14; i<group.Length;i++)
                {
                    if (group[i]<1072||group[i]>1103)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        public bool Correctness_of_fio()//+
        {
            if (string.IsNullOrEmpty(fio))
            {
                return false;
            }

            for (int i = 1; i < fio.Length; i++)
            {
                 if (fio[i] < 1040 || fio[i] > 1103)
                 {
                    if (fio[i] != ' ' && fio[i] != '-')
                    { 
                        return false;
                    }
                 }
            }

            for (int i = 1; i < fio.Length; i++)
            {
                if ((fio[i] >= 1040 && fio[i] < 1072)&&(fio[i-1]!=' '&& fio[i-1]!='-'))
                {
                    if (fio[i] != ' '&& fio[i] != '-')
                    {
                        return false;
                    }
                }
            }

            if (fio[0] < 1040 || fio[0] > 1071)
            {
                return false;
            }
            else
            {
                int i = 0;
                if (fio[fio.Length-1]==' ')
                {
                    fio = fio.Remove(fio.Length - 1);
                    
                }
                string k = fio;
                int words = 0;
                while (i!=-1)
                {
                    i = k.IndexOf(" ");

                    if (i!=-1)
                    {
                        words ++;
                        if ((k[k.IndexOf(" ")+1]<1040 || k[k.IndexOf(" ") + 1] > 1071))
                        {
                                return false;
                        } 
                        k = k.Remove(0, k.IndexOf(" ") + 1);
                    }
                }
                if (words<1)
                {
                    return false;
                }
                i = 0;
                k = fio;
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

        public bool Correctness_of_direction()//+
        {
            if (string.IsNullOrEmpty(direction))
            {
                return false;
            }

            if (direction[0] < 1040 || direction[0] > 1071)
            {
                return false;
            }

            for (int i = 1; i < direction.Length; i++)
            {
                if (direction[i] < 1072 || direction[i] > 1103)
                {
                    if (direction[i] != ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}       
