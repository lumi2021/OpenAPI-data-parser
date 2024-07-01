namespace Program.Contracts.Response
{
	public class PessoaCpfConsultaDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<PessoaCpfConsultaDTO> data { get; set; }
	}
}
