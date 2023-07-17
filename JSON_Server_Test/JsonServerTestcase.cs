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
            Assert.AreEqual(13, dataResponse.Count());

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


        // UC3: Add multiple new employees to the EmployeePayroll JSON Server
        [TestMethod]
        public void givenMultipleEmployeesOnPostShouldReturnAddedEmployees()
        {
            List<Employee> employeeList = new List<Employee>();
            employeeList.Add(new Employee { Name = "Sumit", Salary = "15000" });
            employeeList.Add(new Employee { Name = "Amit", Salary = "20000" });
            employeeList.Add(new Employee { Name = "Rahul", Salary = "25000" });

            foreach (Employee emp in employeeList)
            {
                RestRequest request = new RestRequest("/Employee", Method.Post);
                JsonObject jObjectBody = new JsonObject();
                jObjectBody.Add("Name", emp.Name);
                jObjectBody.Add("Salary", emp.Salary);

                request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);

                RestResponse response = client.Execute(request);

                Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
                Employee dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
                Assert.AreEqual(emp.Name, dataResponse.Name);
                Assert.AreEqual(emp.Salary, dataResponse.Salary);
                Console.WriteLine(response.Content);
            }
        }

        [TestMethod]
        public void givenEmployeeNameOnPutShouldReturnUpdatedEmployee()
        {
            RestRequest request = new RestRequest("/Employee", Method.Get);
            RestResponse response = client.Execute(request);
            List<Employee> dataResponseList = JsonConvert.DeserializeObject<List<Employee>>(response.Content);

            Employee employee = dataResponseList.Find(emp => emp.Name == "Sumit");
            if (employee != null)
            {
                employee.Salary = "30000";
                request = new RestRequest("/Employee/" + employee.id, Method.Put);
                JsonObject jObjectBody = new JsonObject();
                jObjectBody.Add("Name", employee.Name);
                jObjectBody.Add("Salary", employee.Salary);

                request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);

                response = client.Execute(request);

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
                Employee dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
                Assert.AreEqual(employee.Salary, dataResponse.Salary);
                Console.WriteLine(response.Content);
            }
        }

        [TestMethod]
        public void givenEmployeeNameOnDeleteShouldReturnSuccessStatus()
        {
            RestRequest request = new RestRequest("/Employee", Method.Get);
            RestResponse response = client.Execute(request);
            List<Employee> dataResponse = JsonConvert.DeserializeObject<List<Employee>>(response.Content);

            Employee employee = dataResponse.Find(emp => emp.Name == "Sumit");
            if (employee != null)
            {
                request = new RestRequest("/Employee/" + employee.id, Method.Delete);

                response = client.Execute(request);

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }


    }
}