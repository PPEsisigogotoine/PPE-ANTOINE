using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using ModelLayer.Business;

namespace ModelLayer.Data
{
    class DaoObstacle
    {
        private Dbal thedbal;
        private DaoObstacle theDaoObstacle;


        public DaoObstacle(Dbal mydbal)
        {
            this.thedbal = mydbal;
        }

        public void Insert(Obstacle theObstacle)
        {
            string query = "Obstacle(id, nom, photo, commentaire, difficulte, prix, theme) VALUES ("
                + theObstacle.Id + ",'"
                + theObstacle.Nom + "','"
                + theObstacle.Photo + "','"
                + theObstacle.Commentaire + "',"
                + theObstacle.Difficulte + ",'"
                + theObstacle.Prix + ",'"
                + theObstacle.IdTheme.id + ")";
            this.thedbal.Insert(query);
        }

        public void InsertFromCSV(string filename)
        {
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();

                var record = new Obstacle();
                var records = csv.EnumerateRecords(record);

                foreach (Obstacle r in records)
                {
                    Console.WriteLine(r.Id + "-" + r.Nom);
                    this.Insert(record);
                }
            }
        }

        public void Update(Obstacle myObstacle)
        {
            string query = "Obstacle SET id= "
                + myObstacle.Id
                + ", nom = '" + myObstacle.Nom
                + "', photo = '" + myObstacle.Photo
                + "', commentaire = '" + myObstacle.Commentaire
                + "', difficulte = " + myObstacle.Difficulte
                + ", prix = " + myObstacle.Prix
                + ", theme = " + myObstacle.IdTheme.id;

            this.thedbal.Update(query);

        }

        public List<Obstacle> SelectAll()
        {
            List<Obstacle> listObstacle = new List<Obstacle>();
            DataTable myTable = this.thedbal.SelectAll("Obstacle");

            foreach (DataRow r in myTable.Rows)
            {
                listObstacle.Add(new Obstacle((int)r["id"], (string)r["nom"], (string)r["photo"], (string)r["commentaire"], (int)r["difficulte"], (int)r["prix"], (Theme)r["theme"]));

            }
            return listObstacle;
        }

        public Obstacle SelectById(int id)
        {
            DataRow rowObstacle = this.thedbal.SelectById("Obstacle", id);
            Obstacle myObstacle = this.theDaoObstacle.SelectById((int)rowObstacle["nom"]);

            return new Obstacle((int)rowObstacle["id"], (string)rowObstacle["nom"], (string)rowObstacle["photo"], (string)rowObstacle["commentaire"], (int)rowObstacle["difficulte"], (int)rowObstacle["prix"], (Theme)rowObstacle["theme"]);

        }

        public Obstacle SelectByName(string name)
        {
            string search = "nom = '" + name + "'";
            DataTable tableObstacle = this.thedbal.SelectByField("Obstacle", search);
            Obstacle myObstacle = this.theDaoObstacle.SelectById((int)tableObstacle.Rows[0]["nom"]);
            return new Obstacle((int)tableObstacle.Rows[0]["id"], (string)tableObstacle.Rows[0]["nom"], (string)tableObstacle.Rows[0]["photo"], (string)tableObstacle.Rows[0]["commentaire"], (int)tableObstacle.Rows[0]["difficulte"], (int)tableObstacle.Rows[0]["prix"], (Theme)tableObstacle.Rows[0]["theme"]);

        }

        public void Delete(Obstacle unObstacle)
        {
            string query = "Obstacle where id = " + unObstacle.Id + ";";
            this.thedbal.Delete(query);
        }
    }
}
