namespace Program.Contracts.Request
{
	public class PessoaCnpjCrudDTO
	{
		public uuid registroId { get; set; }
		public int pessoaId { get; set; }
		public string nome { get; set; }
		public string ie { get; set; }
		public int regimeTributario { get; set; }
		public bool industria { get; set; }
		public bool lucroReal { get; set; }
		public PessoaUsuarioCrudDTO usuario { get; set; }
		public int pessoaCNPJId { get; set; }
		public string cnpj { get; set; }
		public bool registroAtivo { get; set; }
		public PessoaRelacaoCrudDTO pessoaRelacao { get; set; }
	}
}
