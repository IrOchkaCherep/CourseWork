using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miracle
{
    public class Tnode
    {
        public Comissions data; 
        public Tnode left, right;
        public Tnode(Comissions s)
        {
            data = s;
            left = right = null;
        }
    }

    public class Binary_tree
    {
        public Tnode root;
        public bool Add(Comissions s)
        {
            if (Program.Table.table[Program.Table.Hash_function(s.fio.head.data)].Searсh(s.fio.head.data) != null)
            {
                root = Add(s, root);
                return true;
            }
            return false;
        }

        private Tnode Add(Comissions s, Tnode root)
        {
            if (root == null)
            {
                root = new Tnode(s);
                return root;
            }
            else if (root.data < s)
            {
                root.right = Add(s, root.right);
            }
            else if ((root.data.fio.Searсh(s.fio.head.data)!=null)&&(root.data.subject == s.subject)&&(root.data.type == s.type))
            {
                return root;
            }
            else if ((root.data.subject == s.subject)&&(root.data.type ==s.type))
            {
                root.data.fio.Addition(s.fio.head.data);
                return root;
            }
            else if (root.data > s)
            {
                root.left = Add(s, root.left);
            }
            return root;
        }

        public void Del(Comissions s)
        {
            root = Delete(root, s);
        }

        private void ExtraDelete(Tnode node, Tnode root)
        {
            if (node.right != null)
            {
                ExtraDelete(node.right, root);
            }
            else
            {
                root.data = node.data;
                root.left = Delete(root.left, root.data);
            }
        }

        private Tnode Delete(Tnode root, Comissions s)
        {
            if (root == null)
            {
                return root;
            }
            else
            {
                if (root.data < s)
                {
                    root.right = Delete(root.right, s);
                }
                else if (root.data > s)
                {
                    root.left = Delete(root.left, s);
                }
                else if (root.right == null)
                {
                    return root.left;

                }
                else if (root.left == null)
                {
                    return root.right;
                }
                else
                {
                    ExtraDelete(root.left, root);
                }
            }

            return root;
        }


        public Tnode Search(Comissions s)
        {
            return Search(root, s);

        }

        private Tnode Search(Tnode root, Comissions s)
        {
            if ((root == null)|| ((root.data.subject == s.subject) && (root.data.type == s.type)))
            {
                Program.count++;//считает количество шагов при поиске
                return root;
            }
            else if (root.data < s)
            {
                Program.count++;
                return root = Search(root.right, s);
            }
            else if ((root.data.subject == s.subject) && (root.data.type == s.type))
            {
                Program.count++;
                return root;
            }
            else if (root.data > s)
            {
                Program.count++;
                return root = Search(root.left, s);
            }
            return root;
        }

        public void Delete_Students_in_Tree(Tnode root, string fio)//замена на максимальный слева
        {
            Node<string> tmp;
            Node<string> curr = new Node<string>();
            curr.data = fio;
            if (root != null)
            {
                Delete_Students_in_Tree(root.left, fio);
                tmp = root.data.fio.head;
                while (tmp != null)
                {
                    if ((tmp.data == curr.data) && (root.data.fio.head.next == null))
                    {
                        Program.Tree.Del(root.data);
                    }
                    else
                    {
                        root.data.fio.Deletion(fio);
                    }
                    tmp = tmp.next;
                }
                Delete_Students_in_Tree(root.right, fio);
            }
        }
    }
}
