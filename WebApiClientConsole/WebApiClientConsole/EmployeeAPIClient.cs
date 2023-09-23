using FirstWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
using System.Text.Json.Serialization;
namespace WebApiClientConsole
{
    internal class EmployeeAPIClient
    {
        static Uri uri = new Uri("http://localhost:5215/");
        public static async Task CallGetEmployees()
        {
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = uri;
        //        List<EmpViewModels> employee = new List<EmpViewModels>();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        //HttpGet:
        //        HttpResponseMessage response = await client.GetAsync("GetAll");
        //        response.EnsureSuccessStatusCode();
        //        if (response.IsSuccessStatusCode)
        //        {
        //            String x = await response.Content.ReadAsStringAsync();
        //            await Console.Out.WriteLineAsync(x);
        //        }
        //    }
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                List<EmpViewModels> employees = new List<EmpViewModels>();
                client.DefaultRequestHeaders
                    .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HttpGet:
                HttpResponseMessage response = await client.GetAsync("GetAll");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    employees = JsonConvert.DeserializeObject<List<EmpViewModels>>(json);
                    foreach (EmpViewModels emp in employees)
                    {
                        await Console.Out.WriteLineAsync($"{emp.EmpID},{emp.FirstName},{emp.LastName},{emp.BirthDate},{emp.HireDate},{emp.Title}");
                    }
                }
            }
        }
        public static async Task AddNewEmployee()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                EmpViewModels empViewModels = new EmpViewModels()
                {
                    FirstName = "Sanghavai",
                    LastName = "Bhuvaneswari",
                    City = "Chennai",
                    BirthDate=new DateTime(2000,01,01),
                    HireDate=new DateTime(2023,01,01),
                    Title="Manager"
                };
                
                var mycontent = JsonConvert.SerializeObject(empViewModels);
                var buffer=Encoding.UTF8.GetBytes(mycontent);
                var byteContent=new ByteArrayContent(buffer);
                byteContent.Headers.ContentType=new MediaTypeHeaderValue("application/json");

                //HttpPost:
                HttpResponseMessage response = await client.PostAsync("AddEmployee", byteContent);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    await Console.Out.WriteLineAsync(response.StatusCode.ToString());
                }
            }
        }
    }
}


    

