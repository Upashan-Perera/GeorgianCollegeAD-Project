
using GeorgianCollegeAD_Project.Controllers;
using GeorgianCollegeAD_Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgianCollegeAD_ProjectTests
{
    [TestClass] //indicating that this file contains unit tests to be executed and evaluated
    public class TaskTypesControllerTests
    {
        private ApplicationDbContext _context;

        //special startup method that runs before unit tests avoiding repetition
        [TestInitialize]
        public void TestInitialize()
        {
            //setting up in-memory db
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options); ;

            //creating mockdata in the in-memory db unit test the TaskTypesController methods in the web app
 
        }

        [TestMethod]
        public void IndexLoadsIndexView()
        {


            //arrang
            var controller = new TaskTypesController(_context);

            //act
            var result = (ViewResult)controller.Index().Result;

            //assert
            Assert.AreEqual("Index", result.ViewName);
        }

         
    }
}
