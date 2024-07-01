namespace Program.Contracts.Response
{
	public class PessoaRelacaoGrupoDTOHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public PessoaRelacaoGrupoDTO data { get; set; }
	}
}
