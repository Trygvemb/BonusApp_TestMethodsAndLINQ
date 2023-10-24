namespace BonusApp
{
    

    internal class Program
    {
        delegate int AddNumbers(int x, int y);
        
        static void Main(string[] args)
        {



            AddNumbers Add = delegate (int x, int y)
            {
                int result = x + y;
                return result;
            };

            Func<int, int, int> addWithLambda = (x, y) => x + y;
            Func<int, int> addTenTimes = x => x * 10;
            Func<int, int> addWithItself = x => x * x;

            int sum = Add(5, 3);
            int sum2 = addWithLambda(5, 3);
            int sum3 = addTenTimes(10);
            int sum4 = addWithItself(10);

            Console.WriteLine("sum " + sum); // Output: 8
            Console.WriteLine("sum2 " + sum2); // Output: 8
            Console.WriteLine("sum3 " + sum3); // Output: 100
            Console.WriteLine("sum4 " + sum4); // Output: 100


            Console.ReadKey();

            Console.WriteLine("Hi there. Run the unittests! Remember to debug.");


        }
        
    }
}