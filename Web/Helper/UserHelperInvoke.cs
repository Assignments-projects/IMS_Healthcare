namespace Web.Helper
{
	public class UserHelperInvoke
	{
		private readonly RequestDelegate _req;

        public UserHelperInvoke(RequestDelegate req)
        {
            _req = req;
        }

		public async Task InvokeAsync(HttpContext context)
		{
			// Initialize UserHelper with IHttpContextAccessor
			UserHelper.Initialize(new HttpContextAccessor { HttpContext = context });

			await _req(context);
		}
	}
}
