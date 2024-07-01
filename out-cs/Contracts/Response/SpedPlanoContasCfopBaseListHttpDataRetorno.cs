namespace Program.Contracts.Response
{
	public class SpedPlanoContasCfopBaseListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<SpedPlanoContasCfopBase> data { get; set; }
	}
}
