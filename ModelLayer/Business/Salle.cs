using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Business
{
    class Salle
    {
        private int _id;
        private int _idLieu;
        private int _idTheme;

        public Salle(int id, int idLieu, int idTheme)
        {
            _id = id;
            _idLieu = idLieu;
            _idTheme = idTheme;
        }

        public int id { get => _id; set => _id = value; }
        public int idLieu { get => _idLieu; set => _idLieu = value; }
        public int idTheme { get => _idTheme; set => _idTheme = value; }
    }
}
