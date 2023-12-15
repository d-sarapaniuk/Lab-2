namespace Lab_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String str = new String("Cocoacoala");
            int result = str.Search("coala");

            String str1 = new String("Penguin");
            String str2 = new String("Duck");
            String str3 = new String("Coala");
            String str4 = new String("Crocodile");
            String str5 = new String("Cat");                  
            
            String[] stringsArray = {str1, str2, str3, str4, str5};
            List<String> stringsList = new List<String> { str1, str2, str3, str4 };
            stringsList.Add(str5);

            BinaryTree<String> tree = new BinaryTree<String>();
            foreach (String s in stringsList) { tree.Insert(s); }

            foreach (object obj in tree) { Console.WriteLine(obj); } // in postorder

        }
    }
}