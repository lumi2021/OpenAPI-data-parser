namespace Program.Contracts.Response
{
	public class NFeRecebidaDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<NFeRecebidaDTO> data { get; set; }
	}
}
