namespace FizzBuzzTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input =
                "Mary had a little lamb\r\nLittle lamb, little lamb\r\nMary had a little lamb\r\nIt's fleece was white as snow\r\n";

            FizzBuzzDetector detector = new FizzBuzzDetector();

            var result = detector.GetOverlappings(input);
            Console.WriteLine(result.Output);
            Console.WriteLine(result.Count);
        }
    }
}
