namespace Program.Contracts.Response
{
	public class SpedPlanoContasCfopBaseHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public SpedPlanoContasCfopBase data { get; set; }
	}
}
