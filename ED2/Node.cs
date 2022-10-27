using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED2
{
    internal class Node
    {
        public int num;
        public Node ses = null!;
        public Node sdi = null!;



        public Node(int num)
        {
            this.num = num;

        }
        public void Add(int key)
        {
            if (ses != null)
                if (ses.num == -1)
                    ses = null!;
            if (sdi != null)
                if (sdi.num == -1)
                    sdi = null!;
            if (key < num)
            {
                if (ses != null)
                {
                    ses.Add(key);
                }
                else
                {
                    ses = new Node(key);
                }
            }
            else
            {
                if (sdi != null)
                {
                    sdi.Add(key);
                }
                else
                {
                    sdi = new Node(key);
                }
            }
        }

        public Node Remove(int key)
        {
            if (ses != null)
                if (ses.num == -1)
                    ses = null!;
            if (sdi != null)
                if (sdi.num == -1)
                    sdi = null!;

            if (key == num)
            {
                if (ses == null & sdi == null)
                {
                    return null;
                }
                if (ses == null)
                {
                    return sdi;
                }
                if (sdi == null)
                {
                    return ses;
                }
                Node h = ses;
                while (h.sdi != null)
                {
                    if (h.sdi.num != -1)
                        h = h.sdi;
                    else
                    {
                        break;
                    }
                }
                int aux = h.num;
                Remove(h.num);
                num = aux;
                return this;
            }
            if (key < num)
            {
                if (ses != null)
                    ses = ses.Remove(key);


            }
            else if (key > num)
            {
                if (sdi != null)
                    sdi = sdi.Remove(key);

            }
            return this;

        }
        public Node Find(int key)
        {
            if (key < num)
            {
                if (ses != null)
                    return ses.Find(key);
                else
                {
                    Node node = new Node(-1);
                    return node;
                }

            }
            else if (key > num)
            {
                if (sdi != null)
                    return sdi.Find(key);
                else
                {
                    Node node = new Node(-1);
                    return node;
                }

            }
            else
            {
                return this;
            }
        }


        public int Altura()
        {
            if (ses == null && sdi == null)
            {
                return 0;
            }
            else if (ses != null && sdi != null)
            {
                return 1 + Math.Max(ses.Altura(), sdi.Altura());
            }
            else if (ses == null && sdi != null) { return 1 + Math.Max(-1, sdi.Altura()); }
            else if (ses != null && sdi == null) { return 1 + Math.Max(ses.Altura(), -1); }
            else
            {
                return -1;
            }
        }

        public void PrintP(List<(int count, Node node, string p)> nodes, int count, int alt, string p = "")
        {
            bool v = false;

            nodes.Add((count, this, p));

            if (ses != null)
            {
                count++;
                ses.PrintP(nodes, count, alt, "/");
                v = true;

            }
            else
            {
                if (alt > count)
                {
                    count++;
                    Node fnull = new Node(-1);
                    this.ses = fnull;
                    ses.PrintP(nodes, count, alt, "/");
                    v = true;
                }
            }
            if (sdi != null)
            {
                count++;
                if (v)
                    count--;

                sdi.PrintP(nodes, count, alt, "\\");
            }
            else
            {
                if (v)
                    count--;
                if (alt > count)
                {
                    count++;

                    Node fnull = new Node(-1);
                    this.sdi = fnull;
                    sdi.PrintP(nodes, count, alt, "\\");
                }
            }
        }
        public void PrintPre()
        {

            Console.Write("<");
            Console.Write(this.num);
            Console.Write(">");
            if (ses != null)
            {
                ses.PrintPre();

            }
            if (sdi != null)
            {
                sdi.PrintPre();
            }
        }
        public void Print()
        {
            var nodes = new List<(int count, Node node, string p)>();
            int count = 0;
            int alt = Altura();

            PrintP(nodes, count, alt);
            Console.WriteLine();

            string x = new String(' ', alt);
            string x1 = new String(" ");
            for (int j = 0; j <= alt; j++)
            {

                x = new String(' ', (alt - j) * 6);
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (nodes[i].count == j)
                    {

                        Console.Write(x);
                        if (nodes[i].node.num == -1)
                        {
                            Console.Write(x1 + x1 + x1 + x1 + x1 + x1);
                        }
                        else
                        {
                            if (nodes[i].p == "\\")
                            {
                                Console.Write("\\");
                            }
                            Console.Write("<");
                            Console.Write("{0:d3}", nodes[i].node.num);
                            Console.Write(">");
                            if (nodes[i].p == "/")
                                Console.Write("/");
                        }

                    }
                }
                Console.WriteLine();
            }
        }


    }
}