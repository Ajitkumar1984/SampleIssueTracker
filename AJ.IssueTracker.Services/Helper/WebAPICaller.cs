using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AJ.IssueTracker.Services
{

    public class WebAPICaller : IWebAPICaller
        {
        const string JSON_CONTENT_TYPE = "application/json";
            private readonly HttpClient httpClient;
            public WebAPICaller(string url)
            {
                httpClient = new HttpClient
                {
                    BaseAddress = new Uri(url)
                };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JSON_CONTENT_TYPE));
            }

       
        public  async Task<APICallResult<TReturnValue>> GetAsJsonAsync<TReturnValue>(string url)
          {
             APICallResult<TReturnValue> result = new APICallResult<TReturnValue>();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    result.Succeeded = true;
                    result.Value = await response.Content.ReadAsAsync<TReturnValue>();
                }
                else
                {
                    result.Succeeded = true;
                    result.ErrorMessage = response.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = true;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public async Task<APICallResult<TReturnValue>> GetAsJsonAsync<TParameter,TReturnValue>(string url,TParameter model)
        {
            APICallResult<TReturnValue> result = new APICallResult<TReturnValue>();
            string urlwithquerystring = url + "?" + HttpHelper.ToQueryString<TParameter>(model);
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(new Uri(urlwithquerystring));
                if (response.IsSuccessStatusCode)
                {
                    result.Succeeded = true;
                    result.Value = await response.Content.ReadAsAsync<TReturnValue>();
                }
                else
                {
                    result.Succeeded = true;
                    result.ErrorMessage = response.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = true;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public async Task<APICallResult<string>> GetAsStringAsync(string url)
        {
            APICallResult<string> result = new APICallResult<string>();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(new Uri(url));
                if (response.IsSuccessStatusCode)
                {
                    result.Succeeded = true;
                    result.Value = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    result.Succeeded = true;
                    result.ErrorMessage = response.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = true;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public async Task<APICallResult<string>> GetAsStringAsync<TParameter, TReturnValue>(string url, TParameter model)
        {
            APICallResult<string> result = new APICallResult<string>();
            string urlwithquerystring = url + "?" + HttpHelper.ToQueryString<TParameter>(model);
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(new Uri(urlwithquerystring));
                if (response.IsSuccessStatusCode)
                {
                    result.Succeeded = true;
                    result.Value = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    result.Succeeded = true;
                    result.ErrorMessage = response.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = true;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        
        public async Task<APICallResult<TReturnValue>> PostAsJsonAsync<TParameter, TReturnValue>(string url, TParameter model)
        {
            APICallResult<TReturnValue> result = new APICallResult<TReturnValue>();
            try
            {
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, model);
                if (response.IsSuccessStatusCode)
                {
                    result.Succeeded = true;
                    result.Value = await response.Content.ReadAsAsync<TReturnValue>();
                }
                else
                {
                    result.Succeeded = true;
                    result.ErrorMessage = response.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = true;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public async Task<APICallResult<TReturnValue>> PutAsJsonAsync<TParameter, TReturnValue>(string url, TParameter model)
        {
            APICallResult<TReturnValue> result = new APICallResult<TReturnValue>();
            try
            {
                HttpResponseMessage response = await httpClient.PutAsJsonAsync(url, model);
                if (response.IsSuccessStatusCode)
                {
                    result.Succeeded = true;
                    result.Value = await response.Content.ReadAsAsync<TReturnValue>();
                }
                else
                {
                    result.Succeeded = true;
                    result.ErrorMessage = response.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = true;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

    }
}
