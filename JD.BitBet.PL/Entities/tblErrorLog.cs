namespace JD.BitBet.PL
{
    public partial class tblErrorLog
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? ErrorType { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime ErrorDateTime { get; set; }
    }
}
