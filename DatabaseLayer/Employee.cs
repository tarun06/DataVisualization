using Newtonsoft.Json;

namespace DatabaseLayer
{
    public class Employee
    {
        [JsonProperty("employeeCode")]
        public int EmployeeCode { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("jobTitleName")]
        public string JobTitleName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }
    }
}