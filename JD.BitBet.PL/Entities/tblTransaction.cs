namespace JD.BitBet.PL
{
    public partial class tblTransaction
    {
        public Guid Id { get; set; }
        public Guid WalletId { get; set; }
        public string? TransactionType { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
