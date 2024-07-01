namespace Program.Contracts.Response
{
	public class NFeEmitidaDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<NFeEmitidaDTO> data { get; set; }
	}
}
