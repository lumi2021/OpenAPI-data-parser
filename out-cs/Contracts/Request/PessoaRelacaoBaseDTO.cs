namespace Program.Contracts.Request
{
	public class PessoaRelacaoBaseDTO
	{
		public int pessoaRelacaoId { get; set; }
		public int pessoaIdRelacaoPai { get; set; }
		public int pessoaIdRelacaoFilho { get; set; }
		public int pessoaRelacaoTipoId { get; set; }
		public int sistemaId { get; set; }
	}
}
