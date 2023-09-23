using FirstWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApiClientConsole
{
    internal class EmployeeAPIClient
    {
        static Uri uri = new Uri("http://localhost:5215/");
        public static async Task CallGetEmployees()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                //HttpGet:
                HttpResponseMessage response = await client.GetAsync("GetAll");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    String x = await response.Content.ReadAsStringAsync();
                    await Console.Out.WriteLineAsync(x);
                }
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                List<EmpViewModels> employees = new List<EmpViewModels>();
                client.DefaultRequestHeaders
                    .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HttpGet:
                HttpResponseMessage response = await client.GetAsync("GetAllEmployees");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    employees = JsonConvert.DeserializeObject<List<EmpViewModels>>(json);
                    foreach ( EmpViewModels emp in employees)
                    {
                        await Console.Out.WriteLineAsync($"{emp.EmpID},{emp.FirstName},{emp.HireDate}");
                    }
                }
            }
        }
    }
}


    

