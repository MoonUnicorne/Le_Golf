using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceNamespace;

namespace BalleNamespace
{
    internal class Balle
    {
        public int _dimention {get; private set;}
        public int[] _coordonee {get; private set;}

        public Balle(int dimention)
        {
            if (dimention <= 0)
            {
                throw new ArgumentException("USAGE : La dimention de la balle doit être un nombre entier > 0");
            }
            _dimention = dimention;
            _coordonee = new int[dimention];

        }
)

    }
}
