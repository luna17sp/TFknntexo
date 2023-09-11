namespace KNNText
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> BagOfWords = Bolsa.CreateBoW();
            KNN.kNNCalculationsAndResult(Vector.CreateVector(BagOfWords), Vector.generateInputVector(BagOfWords));
            Console.ReadKey();
        }
    }
}
