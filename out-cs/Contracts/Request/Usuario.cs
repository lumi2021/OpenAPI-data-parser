namespace Program.Contracts.Request
{
	public class Usuario
	{
		public uuid guid { get; set; }
		public int usuarioLogadoId { get; set; }
		public DateTime dataHora { get; set; }
		public bool registroAtivo { get; set; }
		public string ipAcesso { get; set; }
		public int proprietarioRegistroPessoaId { get; set; }
		public int usuarioId { get; set; }
		public string senha { get; set; }
		public string nomeUsuario { get; set; }
		public int pessoaId { get; set; }
		public Pessoa pessoa { get; set; }
		public int usuarioFuncaoId { get; set; }
		public UsuarioFuncao usuarioFuncao { get; set; }
	}
}
