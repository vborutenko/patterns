using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Threading
{
    public static class AsyncAwait
    {
        public static void Test()
        {


        }
    }

    /// <summary>
    /// https://blog.stephencleary.com/2012/07/dont-block-on-async-code.html
    /// </summary>
    public static class DeadLock
    {
        public static async Task<string> GetJsonAsync(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var jsonString = await client.GetStringAsync(uri);
                return jsonString;
            }
        }

        // My "top-level" method.
        public static void Button1_Click()
        {
            var jsonTask = GetJsonAsync(new Uri("abc"));
            var a = jsonTask.Result;
        }
    }


    public static class Context
    {
        public static async void MyButton_Click(object sender, EventArgs e)
        {
            //// Since we asynchronously wait, the ASP.NET thread is not blocked by the file download.
            //// This allows the thread to handle other requests while we're waiting.
            //await DownloadFileAsync(...);

            // Since we resume on the ASP.NET context, we can access the current request.
            // We may actually be on another *thread*, but we have the same ASP.NET request context.
            //Response.Write("File downloaded!");
        }
    }




}
