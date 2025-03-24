// Copyright (c) Microsoft. All rights reserved.




namespace UseMicrosoft_KernelMemoryPlugin
{
    /// <summary>
    /// Logging handler you might want to use to
    /// see the HTTP traffic sent by SK to LLMs.
    /// </summary>
    public class HttpLogger : DelegatingHandler
    {
        public static HttpClient GetHttpClient(bool log = false)
        {
            var hc = log
                ? new HttpClient(new HttpLogger(new HttpClientHandler()))
                : new HttpClient();

            hc.Timeout = TimeSpan.FromMinutes(5);

            return hc;
        }

        public HttpLogger(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Request Body:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            //Console.WriteLine(request.ToString());
            //Console.WriteLine();
            if (request.Content != null)
            {
                Console.WriteLine(await request.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false));
            }
            Console.WriteLine();
            Console.ResetColor();


            HttpResponseMessage response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Response Body:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            //Console.WriteLine(response.ToString());
            //Console.WriteLine();
            if (response.Content != null)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false));
            }
            Console.WriteLine();
            Console.ResetColor();


            return response;
        }
    }
}