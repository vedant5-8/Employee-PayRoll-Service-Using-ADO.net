using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Text.Json.Nodes;

namespace JSON_Server_Test
{
    public class Employee
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
    }

    [TestClass]
    public class JsonServerTestcase
    {
        RestClient client;
        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:3000");
        }

        private RestResponse getEmployeeList()
        {
            // arrange
            RestRequest request = new RestRequest("/Employee", Method.Get);

            RestResponse response = client.Execute(request);
            return response;

        }

        // UC 1: Retrieve all employees in EmployeePayroll JSON Server

        [TestMethod]
        public void OnCallingListReturnEmployeeList()
        {
            RestResponse response = getEmployeeList();

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Employee> dataResponse = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(8, dataResponse.Count());

            foreach(Employee emp in dataResponse)
            {
                Console.WriteLine("id: {0}, Name: {1}, Salary: {2}", emp.id, emp.Name, emp.Salary);
            }
        }

        // UC2: Add a new employee to the EmployeePayroll JSON Server

        [TestMethod]
        public void givenEmployeeOnPostShouldReturnAddedEmployees()
        {
            RestRequest request = new RestRequest("/Employee", Method.Post);
            JsonObject jObjectBody = new JsonObject();
            jObjectBody.Add("Name", "Sumit");
            jObjectBody.Add("Salary", "15000");

            request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);

            RestResponse response = client.Execute(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Employee dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("Sumit", dataResponse.Name);
            Assert.AreEqual("15000", dataResponse.Salary);
            Console.WriteLine(response.Content);
        }

    }
}