using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Business
{
    class Transaction
    {
        private int _id;
        private char _operation;
        private int _montant;
        private int _reservation;
        private int _idClient;

        public Transaction(int id, char operation, int montant, int reservation, int idClient)
        {
            _id = id;
            _operation = operation;
            _montant = montant;
            _reservation = reservation;
            _idClient = idClient;
        }

        public int id { get => _id ; set => _id = value; }
        public char operation { get => _operation; set => _operation = value; }
        public int montant { get => _montant; set => _montant= value; }
        public int reservation { get => _reservation; set => _reservation = value; }
        public int idClient { get => _idClient; set => _idClient = value; }
    }
}
