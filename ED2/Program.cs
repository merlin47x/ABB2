using System;

namespace ED2
{
    class Program
    {
        static void Main(string[] args)
        {

            Node root = new Node(100);
            root.Add(50);
            root.Add(25);
            root.Add(15);
            root.Add(40);
            root.Add(75);
            root.Add(60);
            root.Add(85);
            root.Add(150);
            root.Add(125);
            root.Add(115);
            root.Add(140);
            root.Add(175);
            root.Add(160);
            root.Add(185);
            root.PrintPre();
            root.Print();
            Console.WriteLine("##################################");
            root.Remove(100);
            root.Remove(140);
            root.Remove(75);
            root.Remove(25);
            root.Remove(160);
            root.Add(55);
            root.PrintPre();
            root.Print();
            Console.WriteLine("##################################");



        }
    }
}