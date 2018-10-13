using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyDotLibrary
{
	public class OperationResult
	{
		public bool Success { get; set; }
		public int StatusCode { get; set; }
		public List<string> Messages { get; private set; }

		public OperationResult()
		{
			Success = true;
			StatusCode = 200;
			Messages = new List<string>();
		}

		public OperationResult(bool isSuccess, int code, string message)
		{
			Success = isSuccess;
			StatusCode = code;
			Messages = new List<string>();

			AddMessage(message);
		 
		}

		public void AddMessage(string msg){

			if (string.IsNullOrEmpty(msg)) Messages.Add(msg);
		}

		public string GetAllMessages(){
			var messages = "";

			foreach (var msg in Messages)
				messages += msg + "\r\n";

			return messages;
		}

		public void OK (){
			Success = true;
			StatusCode = 200;
		}

		public string ConvertToJSON(){
			return JsonConvert.SerializeObject(Messages);
		}


	}
}
