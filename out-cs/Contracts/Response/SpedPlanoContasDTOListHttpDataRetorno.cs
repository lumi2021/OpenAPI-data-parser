namespace Program.Contracts.Response
{
	public class SpedPlanoContasDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<SpedPlanoContasDTO> data { get; set; }
	}
}
