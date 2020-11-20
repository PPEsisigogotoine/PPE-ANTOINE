using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Business
{
    class Utilisateur
    {
        private int _id;
        private char _roleUser;
        private int _idVille;
        private string _identifiant;
        private string _mdp;

        public Utilisateur(int id, char roleUser, int idVille, string identifiant, string mdp)
        {
            _id = id;
            _roleUser = roleUser;
            _idVille = idVille;
            _identifiant = identifiant;
            _mdp = mdp;
        }

        public int id { get => _id; set => _id = value; }
        public char roleUser { get => _roleUser; set => _roleUser = value; }
        public int idVille { get => _idVille; set => _idVille = value; }
        public string identifiant { get => _identifiant; set => _identifiant = value; }
        public string mdp { get => _mdp; set => _mdp = value; }
    }
}
