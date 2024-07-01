namespace Program.Contracts.Response
{
	public class UsuarioHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public Usuario data { get; set; }
	}
}
