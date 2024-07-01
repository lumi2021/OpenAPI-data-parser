namespace Program.Contracts.Response
{
	public class PessoaCpfCrudDTOHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public PessoaCpfCrudDTO data { get; set; }
	}
}
