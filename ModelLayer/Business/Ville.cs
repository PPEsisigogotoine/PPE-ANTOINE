using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Business
{
    class Ville
    {

        private int _id;
        private string _nom;

        public Ville(int id, string nom)
        {
            _id = id;
            _nom = nom;
        }
        public int id { get => _id; set => _id = value; }
        public string nom { get => _nom; set => _nom = value; } 
    }
}
