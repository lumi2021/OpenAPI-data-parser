namespace Program.Contracts.Response
{
	public class SpedPlanoContasBaseHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public SpedPlanoContasBase data { get; set; }
	}
}
