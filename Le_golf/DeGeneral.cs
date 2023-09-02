using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceNamespace
{
    /// <summary>
    /// Class De general
    /// </summary>
    internal class DeGeneral
    {
        /// <summary>
        /// Nombre de face du de
        /// </summary>
        public int _size { get; private set; }

        /// <summary>
        /// Generateur de nombre aleatoire
        /// </summary>
        protected Random _random;


        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="size">Nombre de face du de</param>
        public DeGeneral(int  size=6)
        {
            this._size = size;
            _random = new Random();
        }

        public int roll()
        {
            return _random.Next(1, _size+1);
        }


    }
}
