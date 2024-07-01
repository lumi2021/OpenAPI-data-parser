namespace Program.Contracts.Request
{
	public class PessoaCpfCrudDTO
	{
		public uuid registroId { get; set; }
		public int pessoaId { get; set; }
		public string nome { get; set; }
		public int pessoaCPFId { get; set; }
		public string cpf { get; set; }
		public bool registroAtivo { get; set; }
		public string sexo { get; set; }
		public PessoaRelacaoCrudDTO pessoaRelacao { get; set; }
		public PessoaUsuarioCrudDTO usuario { get; set; }
	}
}
