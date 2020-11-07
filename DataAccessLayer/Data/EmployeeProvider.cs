using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using DataAccessLayer.Utils;

namespace DataAccessLayer.Data
{
    public class  EmployeeProvider: IEmployeeProvider
    {
        public async Task<List<EmployeeInfo>> LoadEmployees()
        {
            List<EmployeeInfo> employees;
            try
            {
                string employeesResponse;
                using (var clientClinicGroups = new HttpClient())
                {
                    clientClinicGroups.BaseAddress = new Uri(Constants.APIUrl);
                    clientClinicGroups.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    const string requestUrl = "/api/Employees";
                    employeesResponse = await clientClinicGroups.GetStringAsync(requestUrl);
                }

                employees = EmployeeInfo.GetCollectionFromJson(employeesResponse);
            }
            catch (Exception e)
            {
                throw new System.Exception("Error getting the employees", e);
            }

            return employees;
        }
    }
}
