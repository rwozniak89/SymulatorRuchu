using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit2
{
    [Serializable]
    public  class Person
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Adress { get; set; }

        public Person()
        {
            FirstName = "imię";
            LastName = "nazwisko";
            Adress = string.Empty;
        }


        public override bool Equals(object obj)
        {
            // Odkomentarzować, gdy klasa bazowa też nadpisuje Equals()
            //if(!base.Equals(obj))
            //    return false;
            // Warunek 1: obiekty porównywalne muszą istnieć.
            if (obj == null)
                return false;
            // Warunek 2: obiekty porównywalne muszą być tymi samymi typami.
            if (this.GetType() != obj.GetType())
                return false;
            // Warunek 3: porównanie pól referencyjnych (jeśli istnieją).
            // Warunek 3a: porównanie referencji na obiekty (do uzgodnienia).
            //if(!Object.ReferenceEquals(this, obj))
            //    return false;
            Person v = obj as Person;
            // Warunek 4: porównanie pól wartościowych.

            if (!this.FirstName.Equals(v.FirstName)
                || !this.LastName.Equals(v.LastName)
                || !this.Adress.Equals(v.Adress))
                return false;
            return true;
        }

        /// <summary>
        /// Nadpisanie jest wymagane, gdy nadpisujemy Equals().
        /// HasCode powinien być generowany od pola, które bezie unikalnym identyfikatorem klasy.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.FirstName);
            sb.Append(this.LastName);
            sb.Append(this.Adress);
            return sb.ToString().GetHashCode();
        }

    }
}
