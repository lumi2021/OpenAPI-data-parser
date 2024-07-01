namespace Program.Contracts.Response
{
	public class ContadorClienteDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<ContadorClienteDTO> data { get; set; }
	}
}
