﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Business
{
    class Obstacle
    {
        private int id;
        private string nom;
        private string photo;
        private string commentaire;
        private int difficulte;
        private int prix;
        private Theme idTheme;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Photo { get => photo; set => photo = value; }
        public string Commentaire { get => commentaire; set => commentaire = value; }
        public int Difficulte { get => difficulte; set => difficulte = value; }
        public int Prix { get => prix; set => prix = value; }
        public Theme IdTheme { get => idTheme; set => idTheme = value; }

        public Obstacle(int id, string nom, string photo, string commentaire, int difficulté, int prix, Theme unTheme)
        {
            Id = id;
            Nom = nom;
            Photo = photo;
            Commentaire = commentaire;
            Difficulte = difficulté;
            Prix = prix;
            IdTheme = unTheme;
        }

        public Obstacle()
        {

        }
    }
}
