namespace Program.Contracts.Request
{
	public class PessoaRelacaoTipoDTO
	{
		public int pessoaRelacaoTipoId { get; set; }
		public string nomeTipo { get; set; }
		public int pessoaRelacaoGrupoId { get; set; }
		public string nomeGrupo { get; set; }
	}
}
