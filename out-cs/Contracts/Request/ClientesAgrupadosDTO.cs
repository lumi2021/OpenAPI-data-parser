namespace Program.Contracts.Request
{
	public class ClientesAgrupadosDTO
	{
		public uuid idRegistro { get; set; }
		public int codPessoaContador { get; set; }
		public int ano { get; set; }
		public int mes { get; set; }
		public List<ContadorClienteDTO> listaContadorClientes { get; set; }
	}
}
