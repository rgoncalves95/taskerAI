namespace TaskerAI.Application
{

    //public class LocationParser : IFileParser<Location[]>
    //{
    //    public Location[] Parse(Stream stream)
    //    {
    //        using (var reader = new CsvReader(new StreamReader(stream), CultureInfo.InvariantCulture))
    //        {
    //            reader.Context.RegisterClassMap<Map>();
    //            Location[] records = reader.GetRecords<Location>().ToArray();
    //            return records;
    //        }
    //    }

    //    private sealed class Map : ClassMap<Location>
    //    {
    //        public Map()
    //        {
    //            Map(m => m.Id).Ignore();
    //            Map(m => m.Latitude).Ignore();
    //            Map(m => m.Longitude).Ignore();
    //            Map(m => m.Street);
    //            Map(m => m.Door);
    //            Map(m => m.Floor);
    //            Map(m => m.ZipCode);
    //            Map(m => m.City);
    //            Map(m => m.Country);
    //            Map(m => m.Alias).Optional();
    //            Map(m => m.Tags).Convert(r => r.Row.GetField("Tags")?.Split("|")).Optional();
    //        }
    //    }
    //}
}
