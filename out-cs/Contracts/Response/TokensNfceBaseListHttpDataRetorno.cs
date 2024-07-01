namespace Program.Contracts.Response
{
	public class TokensNfceBaseListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<TokensNfceBase> data { get; set; }
	}
}
