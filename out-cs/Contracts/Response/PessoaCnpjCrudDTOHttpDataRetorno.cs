namespace Program.Contracts.Response
{
	public class PessoaCnpjCrudDTOHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public PessoaCnpjCrudDTO data { get; set; }
	}
}
