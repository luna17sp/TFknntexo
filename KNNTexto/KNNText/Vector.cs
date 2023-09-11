using System.Text;

namespace KNNText
{
    class Vector
    {
        public String label { get; set; }
        public int[] vector { get; set; }

        private static dynamic cleanedFiles;
        private static int[] inputVector;
        private static String[] wordsInInput = System.Text.RegularExpressions.Regex.Split(File.ReadAllText(@"..\..\..\Datos\Input\Input.txt"), @"[\s,;:.!?-]+");

        public Vector(string label, int[] vector)
        {
            this.label = label;
            this.vector = vector;
        }

        public static List<String> GetWordsFromInput()
        {
            List<String> listOfInputWords = new List<String>();

            foreach (var word in wordsInInput)
            {

                var builder = new StringBuilder();

                foreach (char letter in word)
                {

                    if (letter <= 90 && letter >= 69 || letter >= 97 && letter <= 122)
                    {
                        builder.Append(letter);
                    }

                    listOfInputWords.Add(builder.ToString().ToLower());
                }
            }
            return listOfInputWords;
        }
        public static int[] generateInputVector(List<String> BagOfWords)
        {

            inputVector = new int[BagOfWords.Count];

            for (int i = 0; i < BagOfWords.Count; i++)
            {
                if (wordsInInput.Contains(BagOfWords[i]))
                {
                    inputVector[i] = 1;
                }
                else
                {
                    inputVector[i] = 0;
                }
            }
            return inputVector;

        }
        public static List<Vector> CreateVector(List<String> BagOfWords)
        {
            List<Vector> listOfVectors = new List<Vector>();
            cleanedFiles = Directory.EnumerateFiles(@"..\..\..\Datos\TextoLimpio\", "*.txt");

            foreach (var cleanedFile in cleanedFiles)
            {
                // Carga todas las palabras de ese archivo en una matriz de cadenas.
                String[] Words = System.Text.RegularExpressions.Regex.Split(File.ReadAllText(cleanedFile), @"[\s,;:.!?-]+");
                String label = "";
                int[] temporaryVectorList = new int[BagOfWords.Count];

                // Por cada palabra de la Bolsa de palabras en el archivo de texto limpio. 
                //compruebe si la PALABRA está presente en el archivo, devuelva el valor 1, de lo contrario 0.
                for (int i = 0; i < BagOfWords.Count; i++)
                {
                    if (Words.Contains(BagOfWords[i]))
                    {
                        temporaryVectorList[i] = 1;
                    }
                    else
                    {
                        temporaryVectorList[i] = 0;
                    }
                }

                // Según el nombre del archivo de texto limpio, identifica a qué tema pertenece y guárdalo como la etiqueta adjunta.
                if (cleanedFile.Contains("politic"))
                {
                    label = "politico";
                }
                else if (cleanedFile.Contains("sport"))
                {
                    label = "deportivo";
                }

                // Agregue una nueva entrada a mi listOfVector con el Vector de objeto, que consta de una etiqueta para identificar su pertenencia, 
                //junto con un vector int de 0,0,0,0,1,1,1, etc.
                listOfVectors.Add(new Vector(label, temporaryVectorList));
            }
            return listOfVectors;
        }
    }

}
