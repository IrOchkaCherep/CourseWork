using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miracle
{
    public class Node<T>
    {
        public T data;
        public Node<T> next;
        public Node(T s, Node<T> next = null)
        {
            data = s;
        }
        public Node() {
            data = default(T);
            next = null;
        }
    }
    public class List<T>
    {
        public Node<T> head;
        public void Addition(T s)
        {
            if (head == null)
            {
                head = new Node<T>(s);
            }
            else
            {
                Node<T> tmp = head;
                Node<T> curr = new Node<T>(s);
                if ((string.Compare(head.data.ToString(),curr.data.ToString())<=0))
                {
                    curr.next = tmp;
                    head = curr;
                }
                else
                {
                    while ((tmp.next != null) && ((string.Compare(tmp.next.data.ToString(), curr.data.ToString()) > 0)))
                    {
                        tmp = tmp.next;
                    }

                    if (tmp.next == null)
                    {
                        tmp.next = new Node<T>(s);
                    }
                    else
                    {
                        curr.next = tmp.next;
                        tmp.next = curr;
                    }
                }
            }
        }

       
        
        public Node<T> Searсh(string s)
        {
            Node<T> tmp = head;
            while (tmp != null)
            {
                Program.count++;
                if (tmp.data.ToString() == s)
                {
                    return tmp;
                }
                tmp = tmp.next;
            }
            return default(Node<T>);
        }

        public void Deletion(T s)
        {
            Node<T> current = head;
            Node<T> previous = null;
            while (current != null)
            {
                if (current.data.ToString() == s.ToString())
                {
                    if (previous != null)
                    {
                        previous.next = current.next;
                    }
                    else
                    {
                        head = head.next;
                    }
                }
                previous = current;
                current = current.next;
            }
        }
    }
}
