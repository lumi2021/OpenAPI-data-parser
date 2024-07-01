namespace Program.Contracts.Response
{
	public class UsuarioAutenticacaoDTOHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public UsuarioAutenticacaoDTO data { get; set; }
	}
}
