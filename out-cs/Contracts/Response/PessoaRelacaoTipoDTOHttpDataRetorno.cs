namespace Program.Contracts.Response
{
	public class PessoaRelacaoTipoDTOHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public PessoaRelacaoTipoDTO data { get; set; }
	}
}
