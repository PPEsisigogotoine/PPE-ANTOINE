using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using ModelLayer.Business;

namespace ModelLayer.Data
{
    class DaoPlacement_Obst
    {
        private Dbal thedbal;
        private DaoPlacement_Obst theDaoObstacle;

        public DaoPlacement_Obst(Dbal mydbal)
        {
            this.thedbal = mydbal;
        }

        public void Insert(Placement_Obstacle thePlacement_Obstacle)
        {
            string query = "Placement_obstacle(num_placement, reservation, obstacle) VALUES ("
                + thePlacement_Obstacle.Num_placement + ","
                + thePlacement_Obstacle.Reservation.id + ","
                + thePlacement_Obstacle.Obstacle.Id + ")";
            this.thedbal.Insert(query);
        }

        public void InsertFromCSV(string filename)
        {
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();

                var record = new Placement_Obstacle();
                var records = csv.EnumerateRecords(record);

                foreach (Placement_Obstacle r in records)
                {
                    Console.WriteLine(r.Num_placement + "-" + r.Reservation.id + "-" + r.Obstacle.Id);
                    this.Insert(record);
                }
            }

            public void Update(Placement_Obstacle myPlacement_Obstacle)
            {
                string query = "Placement_ob"
            }
    }
}
