namespace Program.Contracts.Response
{
	public class NCMInsertAllErrosDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<NCMInsertAllErrosDTO> data { get; set; }
	}
}
