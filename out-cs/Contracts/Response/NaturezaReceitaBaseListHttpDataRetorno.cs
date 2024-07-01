namespace Program.Contracts.Response
{
	public class NaturezaReceitaBaseListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<NaturezaReceitaBase> data { get; set; }
	}
}
