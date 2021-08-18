using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
	
	public class StudentController : ApiController
    {
        private readonly StudentRepository StudentRepository;

        public StudentController()
        {
            StudentRepository = new StudentRepository();

        }
        [Microsoft.AspNetCore.Mvc.HttpGet]

        public IEnumerable<StudentInfo> Get()
        {
            return StudentRepository.GetAll();

        }

        public StudentInfo Get(int id)
        {
            return StudentRepository.GetById(id);

        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public void Post([System.Web.Http.FromBody] StudentInfo stud)
        {
            if (ModelState.IsValid)
                StudentRepository.Add(stud);
        }

        [Microsoft.AspNetCore.Mvc.HttpPut]

        public void Put(int id, [System.Web.Http.FromBody] StudentInfo stud)
        {
            stud.StudeId = id;
            if (ModelState.IsValid)
            StudentRepository.Update(stud);
        }
        [Microsoft.AspNetCore.Mvc.HttpDelete]
        public void Delete(int id)
        {
            StudentRepository.Delete(id);
        }

    }
}
