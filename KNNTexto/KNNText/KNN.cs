using KNNText;

namespace KNNText
{
    class KNN
    {
        // El Valor decide con cuántos vecinos debemos comparar tu texto. Queremos tantos como tenga sentido.
        private static int kValue = 3;


        // Calcula la distancia entre vectores y en base a eso la aplicación detectará la categoría del artículo
        public static void kNNCalculationsAndResult(List<Vector> listOfVectors, int[] inputVector)
        {
            //una lista inicializada que contendrá todas las distancias junto con sus etiquetas
            List<Resultados> vectorResults = new List<Resultados>();

            for (int l = 0; l < listOfVectors.Count; l++)
            {
                double denominator = 0;

                // Calcula la diferencia entre el índice [i] en el vector de entrada con el índice [i] del primer vector de prueba
                for (int i = 0; i < inputVector.Length; i++)
                {
                    denominator += Math.Pow(inputVector[i] - (int)listOfVectors.ElementAt(l).vector.GetValue(i), 2);
                }
                // Basado en la suma total anterior, obtenga la distancia haciendo un cálculo de raíz cuadrada
                double distance = Math.Sqrt(denominator);
                vectorResults.Add(new Resultados(listOfVectors.ElementAt(l).label, distance));
            }

            //ordenamos las distancias de menor a mayor y guardamos el resultado en una nueva lista
            List<Resultados> orderedResultList = vectorResults.OrderBy(o => o.result).ToList();

            //imprime todas nuestras distancias + sus etiquetas.
            Console.WriteLine("Ordenar por distancia: ");
            Console.WriteLine("con k  = " + kValue);
            Console.WriteLine("Orden / Distancia / Tipo");
            Console.WriteLine("==========================");
            int order = 0;
            ; foreach (var result in orderedResultList)
            {
                Console.WriteLine("  " + ++order + "  :   " + string.Format("{0:0.000}", result.result) + "   :  " + result.label.ToString());
            }

            int counterPolitic = 0;
            int counterSport = 0;

            for (int i = 0; i < kValue; i++)
            {
                if (orderedResultList.ElementAt(i).label.ToString().Equals("politico"))
                {
                    counterPolitic++;
                }
                else if (orderedResultList.ElementAt(i).label.ToString().Equals("deportivo"))
                {
                    counterSport++;
                }
            }
            // check if the input text whether is a politic or a sport article
            if (counterPolitic > counterSport)
            {
                Console.WriteLine("Su texto es reconocido como artículo político");
            }
            else if (counterPolitic < counterSport)
            {
                Console.WriteLine("Tu texto es reconocido como artículo deportivo");
            }
            else if (counterPolitic == counterSport)
            {
                Console.WriteLine("Con el valor k actual no podemos determinar a qué se parece más el artículo.");
            }
        }
    }
}
