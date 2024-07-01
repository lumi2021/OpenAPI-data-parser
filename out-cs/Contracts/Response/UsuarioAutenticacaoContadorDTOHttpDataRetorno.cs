namespace Program.Contracts.Response
{
	public class UsuarioAutenticacaoContadorDTOHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public UsuarioAutenticacaoContadorDTO data { get; set; }
	}
}
