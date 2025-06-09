using System.Text.Json.Serialization;

namespace WebApiApp03.Entity
{
    public class IoTDatas
    {

        public int Id { get; set; }

        public DateTime Sensing_Dt { get; set; }

        public string? Loc_Id {  get; set; }

        public double temp { get; set; }

        public double humid { get; set; }
    }
}
