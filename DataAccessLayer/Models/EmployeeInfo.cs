using System.Collections.Generic;
using System.Runtime.Serialization;
using DataAccessLayer.Utils;
using Newtonsoft.Json;

namespace DataAccessLayer.Models
{
    public class EmployeeInfo
    {
        [DataMember(Name = "Id", EmitDefaultValue = false)]
        public long Id { get; set; }

        [DataMember(Name = "Name", IsRequired = false, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "ContractTypeName", IsRequired = false, EmitDefaultValue = false)]
        public string ContractTypeName { get; set; }

        [DataMember(Name = "RoleId", IsRequired = false, EmitDefaultValue = false)]
        public long RoleId { get; set; }

        [DataMember(Name = "RoleName", IsRequired = false, EmitDefaultValue = false)]
        public string RoleName { get; set; }

        [DataMember(Name = "RoleDescription", IsRequired = false, EmitDefaultValue = false)]
        public string RoleDescription { get; set; }

        [DataMember(Name = "HourlySalary", IsRequired = false, EmitDefaultValue = false)]
        public long HourlySalary { get; set; }

        [DataMember(Name = "MonthlySalary", IsRequired = false, EmitDefaultValue = false)]
        public long MonthlySalary { get; set; }

        public static List<EmployeeInfo> GetCollectionFromJson(string json)
        {
            return JsonConvert.DeserializeObject<List<EmployeeInfo>>(json);
        }
    }
}
