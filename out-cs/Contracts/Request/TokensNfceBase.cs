namespace Program.Contracts.Request
{
	public class TokensNfceBase
	{
		public int tokenNfceId { get; set; }
		public int identificadorCsc { get; set; }
		public string tokenCscNfce { get; set; }
		public DateTime validadeToken { get; set; }
		public bool ambienteProducao { get; set; }
	}
}
