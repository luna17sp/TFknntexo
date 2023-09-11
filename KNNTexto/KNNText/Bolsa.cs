using System.Text;

namespace KNNText
{
    class Bolsa
    {
        private static List<String> BagOfWords = new List<String>();
        private static dynamic path = Directory.EnumerateFiles(@"..\..\..\Datos\Entrenamiento", "*.txt");

        // Crear bolsa de palabras
        public static List<String> CreateBoW()
        {
            int article = 1;

            foreach (string file in path)
            {
                var everyWords = System.Text.RegularExpressions.Regex.Split(File.ReadAllText(file), @"[\s,;:.!?-]+");

                //Creando nuevos archivos con las palabras limpias con SteamWriter
                TextWriter tw;
                if (file.Contains("politic"))
                {
                    tw = new StreamWriter(@"..\..\..\Datos\TextoLimpio\politic" + article.ToString() + ".txt");
                }
                else if (file.Contains("sport"))
                {
                    tw = new StreamWriter(@"..\..\..\Datos\TextoLimpio\sport" + article.ToString() + ".txt");
                }
                else
                {
                    tw = new StreamWriter(@"..\..\..\Datos\TextoLimpio\unkown" + article.ToString() + ".txt");
                }

                // Obtener todas las palabras de archivos txt
                foreach (var word in everyWords)
                {
                    var builder = new StringBuilder();
                    foreach (char letter in word)
                    {
                        // Si el carácter coincide con el alfabeto latino básico (sin caracteres ni puntuaciones especiales)
                        //Entonces el programa los agregará al StringBuilder
                        if (letter <= 90 && letter >= 65 || letter >= 97 && letter <= 122)
                        {
                            builder.Append(letter.ToString().ToLower());
                        }
                    }

                    // Todas las palabras que tengan más de 2 caracteres se agregarán a la lista
                    if (builder.Length > 3)
                    {
                        tw.WriteLine(builder);

                        if (!BagOfWords.Contains(builder.ToString()))
                        {
                            BagOfWords.Add(builder.ToString());
                        }
                    }
                }
                tw.Close();
                article++;
            }
            return BagOfWords;
        }
    }
}
