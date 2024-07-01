namespace Program.Contracts.Response
{
	public class PessoaRelacaoBaseDTOHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public PessoaRelacaoBaseDTO data { get; set; }
	}
}
