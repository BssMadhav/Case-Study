using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;

namespace Project_2.CommonMethodObjects
{
    public class EmployeeObjects
    {
        public string baseURL = "http://dummy.restapiexample.com/api/v1";
        public RestResponse response;
        public dynamic id;
        public void GetListOfUserRequest()
        {
            RestClient client = new RestClient(baseURL);
            RestRequest request = new RestRequest("/employees", Method.Get);
            response = client.Execute(request);
        }
        public void verifyGetResult()
        {
            dynamic deserializerAPI = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
            var value = deserializerAPI.data[0].employee_name;
            Assert.AreEqual("Tiger Nixon", value.Value);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }
        public void Postcreatenewemployee()
        {
            RestClient client = new RestClient(baseURL);
            RestRequest request = new RestRequest("/create", Method.Post);
            request.AddBody("{\"name\":\"Madhav\",\"salary\":\"123\",\"age\":\"23\"}");
            response = client.Execute(request);
        }
        public void VerifyPostResult()
        {
            dynamic deserializerAPI = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
            var value = deserializerAPI["data"]["name"];
            Assert.AreEqual("Madhav", value.Value);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            id = deserializerAPI["data"]["id"].Value;
            CreateTextFile();
        }

        public void CreateTextFile()
        {
            string filepath = @"C:\Users\mindtreefeb84\source\repos\Project 2\Project 2\id.txt";

            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }

            using (FileStream fs = File.Create(filepath))
            {
                Byte[] title = new UTF8Encoding(true).GetBytes("Encoding");
                fs.Write(title, 0, title.Length);
                byte[] author = new UTF8Encoding(true).GetBytes("Test");
                fs.Write(author, 0, author.Length);
            }

            using (StreamWriter sq = File.CreateText(filepath))
            {
                sq.WriteLine(id);
            }
        }

        public void ReadTextFile()
        {
            string s = "";

            string filepath = @"C:\Users\mindtreefeb84\source\repos\Project 2\Project 2\id.txt";

            using (StreamReader sr = File.OpenText(filepath))
            {
                while((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                    id = s;
                }
            }
        }
        public void DeleteRequest()
        {
            RestClient client = new RestClient(baseURL);
            ReadTextFile();
            RestRequest request = new RestRequest("/delete/"+id, Method.Get);
            response = client.Execute(request);
        }

        public void VerifyDeleteRequest()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        public void GetEmployee()
        {
            RestClient client = new RestClient(baseURL);
            ReadTextFile();
            RestRequest request = new RestRequest("/employee/"+id, Method.Get);
            response = client.Execute(request);
        }
        public void verifyGetResultSpecificEmployee()
        {
            dynamic deserializerAPI = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
            var value = deserializerAPI["status"];
            Assert.AreEqual("sucess", value.Value);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }
    }
}
