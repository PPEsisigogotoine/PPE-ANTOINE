using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Business
{
    class Reservation
    {

        private DateTime _dateRes;
        private int _id;
        private int _idClient;
        private int _idSalle;
        private int _prix;
        private int _idTechnicien;
        private int _nbClient;
        private int _idTheme;

        public Reservation(DateTime dateRes, int id, int idClient, int idSalle, int prix, int idTechnicien, int nbClient, int idTheme)
        {
            _dateRes = dateRes;
            _id = id;
            _idClient = idClient;
            _idSalle = idSalle;
            _prix = prix;
            _idTechnicien = idTechnicien;
            _nbClient = nbClient;
            _idTheme = idTheme;
        }
        public DateTime dateRes { get => _dateRes; set => _dateRes = value; }
        public int id { get => _id; set => _id = value; }
        public int idClient { get => _idClient; set => _idClient = value; }
        public int idSalle { get => _idSalle; set => _idSalle = value; }
        public int prix { get => _prix; set => _prix = value; }
        public int idTechnicien { get => _idTechnicien; set => _idTechnicien = value; }
        public int nbClient { get => _nbClient; set => _nbClient = value; }
        public int idTheme { get => _idTheme; set => _idTheme = value; }
    }
}
