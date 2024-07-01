namespace Program.Contracts.Request
{
	public class UsuarioDTO
	{
		public uuid idRegistro { get; set; }
		public string senha { get; set; }
		public string nomeUsuario { get; set; }
		public int usuarioFuncaoId { get; set; }
		public int usuarioId { get; set; }
		public int pessoaIdContador { get; set; }
		public bool solicitaTrocaSenha { get; set; }
		public bool resetarSenha { get; set; }
		public string token { get; set; }
		public string funcao { get; set; }
		public bool usuarioContador { get; set; }
		public bool usuarioAdm { get; set; }
	}
}
