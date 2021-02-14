namespace TaskerAI.MockRepository.MockData
{
    using System.Collections.Generic;
    using TaskerAI.Domain.Entities;

    internal class LocationMockData
    {
        public static IEnumerable<Location> DatabaseSeed()
        {
            return new List<Location>
            {
                Location.Create("41.1591718", "-8.6032467", 1),
                Location.Create("41.1570408", "-8.6092863", 2),
                Location.Create("41.1609995", "-8.6318888", 3),
                Location.Create("41.1344532", "-8.6072402", 4),
                Location.Create("41.1507612", "-8.6121278", 5),
                Location.Create("41.1507612", "-8.6121278", 7),
                Location.Create("41.1480466", "-8.6008611", 8),
                Location.Create("41.1480466", "-8.6008612", 9),
                Location.Create("41.1461493", "-8.6047536", 10),
                Location.Create("41.1601259", "-8.6074517", 11),
                Location.Create("41.1551315", "-8.6792639", 12),
                Location.Create("41.2431481", "-8.7239239", 13),
                Location.Create("41.1518283", "-8.603998", 14),
                Location.Create("41.1518283", "-8.603998", 15),
                Location.Create("41.1532732", "-8.6469867", 16),
                Location.Create("41.1480466", "-8.6008612", 17),
                Location.Create("41.1461493", "-8.6047536", 18),
                Location.Create("41.1601259", "-8.6074517", 19),
                Location.Create("41.1551315", "-8.6792639", 20),
                Location.Create("41.1480466", "-8.6008611", 21, "ALIAS1"),
                Location.Create("R. Conde de Vizela", "124", null, "4050-639", "Porto", "Portugal", "42.0346236", "-8.615591", "CASTLE ROCK", new[]{ "BAR", "DRINKS" }, 22),
                Location.Create("Rua Conde de Vizela", "100", null, "4415-639", "Porto", "Portugal", "41.1515413", "-8.746564", "PADARIA TEIXEIRA", new[]{ "PUTAS", "STRIP" }, 23),
                Location.Create("R. Duarte de Oliveira", "1009", null, "4415-087", "Perosinho", "Portugal", "41.0509421", "-8.6407685", "RETROSARIA BOMBOCA", new[]{ "PUTAS", "STRIP" }, 24)
            };
        }
    }
}
