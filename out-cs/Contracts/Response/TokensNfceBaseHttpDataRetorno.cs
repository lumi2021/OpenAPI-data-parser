namespace Program.Contracts.Response
{
	public class TokensNfceBaseHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public TokensNfceBase data { get; set; }
	}
}
