using BlazorApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IHttpClientFactory httpClientFactory;
        public EmployeeService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44358/api/employees");

            var client = httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.SendAsync(request);
            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadFromJsonAsync<Employee[]>();
            }
            return null;
        }
    }
}
