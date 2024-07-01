namespace Program.Contracts.Response
{
	public class PessoaCnpjConsultaDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<PessoaCnpjConsultaDTO> data { get; set; }
	}
}
