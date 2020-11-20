using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Business
{
    public class Theme
    {
        private int Id;
        private string Nom;

        public Theme(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public int id { get => id; set => id = value; }
        public string nom { get => nom; set => nom = value; }
    }
}
