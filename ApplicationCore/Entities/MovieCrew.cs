namespace ApplicationCore.Entities {
    public class MovieCrew {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int CrewId { get; set; }
        public string? Department { get; set; }
        public string? Job { get; set; }
    }
}