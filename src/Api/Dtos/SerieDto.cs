using System;

namespace Api.Dtos
{
    public class SerieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Episodes { get; set; }
        public DateTime Release { get; set; }
    }
}