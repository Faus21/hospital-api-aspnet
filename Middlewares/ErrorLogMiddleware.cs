namespace Task9.Middlewares
{
    public class ErrorLogMiddleware 
    {

        private readonly RequestDelegate _next;

        private readonly string _path = @"Middlewares\log.txt";

        public ErrorLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            
            await _next(context);

            if (context.Response.StatusCode != 200)
            {
                using (StreamWriter sw = new StreamWriter(_path))
                {
                    await sw.WriteLineAsync(context.Response.StatusCode.ToString());
                }
            }
        }
    }
}
