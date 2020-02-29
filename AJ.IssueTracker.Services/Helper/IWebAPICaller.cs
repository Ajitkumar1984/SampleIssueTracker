using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJ.IssueTracker.Services
{
   public  interface IWebAPICaller
    {
        Task<APICallResult<TReturnValue>> GetAsJsonAsync<TReturnValue>(string url);
        Task<APICallResult<TReturnValue>> GetAsJsonAsync<TParameter, TReturnValue>(string url, TParameter model);
        Task<APICallResult<string>> GetAsStringAsync(string url);
        Task<APICallResult<string>> GetAsStringAsync<TParameter, TReturnValue>(string url, TParameter model);
        Task<APICallResult<TReturnValue>> PostAsJsonAsync<TParameter, TReturnValue>(string url, TParameter model);
        Task<APICallResult<TReturnValue>> PutAsJsonAsync<TParameter, TReturnValue>(string url, TParameter model);
    }
}
