namespace Program.Contracts.Response
{
	public class nfeProcHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public nfeProc data { get; set; }
	}
}
