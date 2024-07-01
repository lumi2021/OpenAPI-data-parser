namespace Program.Contracts.Response
{
	public class NaturezaReceitaBaseHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public NaturezaReceitaBase data { get; set; }
	}
}
