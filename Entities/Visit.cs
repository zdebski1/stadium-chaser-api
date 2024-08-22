namespace stadiumChaserApi.Entities
{
    public class Visit
    {
        public int VisitId { get; set; }
        public int StadiumId { get; set; }
        public DateTime VisitDate { get; set; }
        public string? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
