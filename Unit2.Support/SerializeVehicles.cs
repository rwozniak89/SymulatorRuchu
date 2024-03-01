using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Unit2.Support
{
    public static class SerializeVehicles
    {
        /// <summary>
        /// Zapisuje instajcję obiektu do pliku binarnego.
        /// <para>obiekt (i wsztskie dziedziczące) musi mieć atrybut [Serializable].</para>
        /// <para>Aby zapobiec serializacji pola, musi mieć ona atrybut [NonSerialized]; nie dotyczy to właściwości.</para>
        /// </summary>
        /// <typeparam name="T">Typ obiektu zapisywanego do pliku binarnego.</typeparam>
        /// <param name="filePath">Pełna nazwa pliku binarnego do zapisu.</param>
        /// <param name="objectToWrite">Instancja obiektu zapisywana do pliku binarnego.</param>
        /// <param name="append">Jeśli false plik będzie nadpisany, jeśli istnieje. Jeśli true zawartość będzie dopisywana do pliku.</param>
        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        /// <summary>
        /// Czyta instancję obiektu z pliku binarnego.
        /// </summary>
        /// <typeparam name="T">Typ obiektu czytany z pliku binarnego.</typeparam>
        /// <param name="filePath">Pełna nazwa pliku, z którego czytana jest instancja obiektu.</param>
        /// <returns>Zwraca nową instancję obiektu przeczytaną z pliku binarnego.</returns>
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                return (T)binaryFormatter.Deserialize(stream);
            }
        }
    }
}
