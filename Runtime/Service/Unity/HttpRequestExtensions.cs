using System.Threading.Tasks;
using BornToCompile.AsyncUtilities;

namespace BornToCompile.Http.Service.Unity
{
	public static class HttpRequestExtensions
	{
		public static async Task<HttpResponse> SendAsync(this IHttpRequest request)
		{
			var waitForHttpResponse = new WaitForHttpRequest();
			HttpResponse response = null;

			void HandleResponse(HttpResponse httpResponse)
			{
				response = httpResponse;
				waitForHttpResponse.HasResponded = true;
			}

			request
				.OnSuccess(HandleResponse)
				.OnError(HandleResponse)
				.OnNetworkError(HandleResponse)
				.Send();

			await waitForHttpResponse;
			return response;
		}
	}
}