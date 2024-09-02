using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miracle
{
    class Hash_table
    {
		private int size;
		public List<Student>[] table;
		public Hash_table(int size)
		{
			this.size = size;
			table = new List<Student>[size];
			for (int i = 0; i < size; i++)
			{
				 table[i] = new List<Student>();
			}
		}

		public int Hash_function(string s)
		{
			int rez = 0;

			for (int i = 0; i < s.Length; i++)
			{
				rez = rez + s[i];
			}
			rez = Math.Abs(rez);
			if (rez >= size)
			{
				rez = rez % size;
			}
			return rez;
		}

		public void Addition(Student s)
		{
			int ind = Hash_function(s.fio);
			if (table[ind].Searсh(s.fio)!=null)
			{
				return;
			}
			else
			{
				table[ind].Addition(s);
			}
		}

		public int GetSize()
        {
			return size;
        }

        public Node<Student> Searh(string s)
        {
            int ind = Hash_function(s);
            return table[ind].Searсh(s);
        }
        public void Deletion(Student s)
        {
            int ind = Hash_function(s.fio);
            table[ind].Deletion(s);
        }

    }
}
