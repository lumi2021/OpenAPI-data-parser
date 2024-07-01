namespace Program.Contracts.Response
{
	public class BancosClienteDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<BancosClienteDTO> data { get; set; }
	}
}
