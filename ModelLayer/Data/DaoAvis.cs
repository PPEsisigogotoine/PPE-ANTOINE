using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Business;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Data;
using System.Runtime.CompilerServices;
using System.IO;
using CsvHelper;
using System.Globalization;

namespace ModelLayer.Data
{
    public class DaoAvis
    {
        private Dbal thedbal;
        private DaoAvis theDaoAvis;

        public DaoAvis(Dbal mydbal)
        {
            this.thedbal = mydbal;
        }


        public void Insert(Avis theAvis)
        {
            string query = "Avis(id, idClient, note, commentaire, idTheme) VALUES ("
                + theAvis.Id + ","
                + theAvis.IdClient.Id + ","
                + theAvis.Note + ","
                + theAvis.Commentaire + ","
                + theAvis.IdTheme.Id + "')";
            this.thedbal.Insert(query);
        }

        public void InsertFromCSV(string filename)
        {
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();

                var record = new Avis();
                var records = csv.EnumerateRecords(record);

                foreach (Avis r in records)
                {
                    Console.WriteLine(r.Id + "---" + r.Note);
                    this.Insert(record);
                }
            }
        }

        public void Update(Avis myAvis)
        {
            string query = "Avis SET id = " + myAvis.Id
                + ", idClient = " + myAvis.IdClient.Id
                + ", note =" + myAvis.Note
                + ", commentaire = '" + myAvis.Commentaire.Replace("'", "''")
                + "', idTheme = " + myAvis.IdTheme.id
                + "where id = " + myAvis.Id;
            this.thedbal.Update(query);
        }


        public List<Avis> SelectAll()
        {
            List<Avis> listAvis = new List<Avis>();
            DataTable myTable = this.thedbal.SelectAll("Avis");

            foreach (DataRow r in myTable.Rows)
            {
                listAvis.Add(new Avis((int)r["id"], (Client)r["idClient"], (int)r["note"], (string)r["commentaire"], (Theme)r["idTheme"]));
            }
            return listAvis;
        }

        public Avis SelectById(int id)
        {
            DataRow rowAvis = this.thedbal.SelectById("Avis", id);
            Avis myAvis = this.theDaoAvis.SelectById((int)rowAvis["idClient"]);
            return new Avis((int)rowAvis["id"], (Client)rowAvis["idClient"], (int)rowAvis["note"], (string)rowAvis["commentaire"], (Theme)rowAvis["idTheme"]);
        }

        public void Delete(Avis unAvis)
        {
            string query = " Avis where id = " + unAvis.Id + ";";

            this.thedbal.Delete(query);
        }
    }
}
