
using GeorgianCollegeAD_Project.Controllers;
using GeorgianCollegeAD_Project.Data;
using GeorgianCollegeAD_Project.Models;
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
        private TaskTypesController controller;

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

            for (int i = 0; i <= 5; i++)
            {
                var taskType = new TaskType
                { 
                    TaskTypeName = "Task " + i.ToString(),
                    TaskTypeDescription = ""

                };

                _context.Add(taskType);
            }
 
            _context.SaveChanges();

            //arrang
            controller = new TaskTypesController(_context);
        }

        [TestMethod]
        public void IndexLoadsIndexView()
        {
            //arrang
            //var controller = new TaskTypesController(_context);

            //act
            var result = (ViewResult)controller.Index().Result;

            //assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexLoadsTaskTypes()
        {
            //arrang
            //var controller = new TaskTypesController(_context);

            //act
            var result = (ViewResult)controller.Index().Result;
            List<TaskType> model = (List<TaskType>)result.Model; //convert data to a list of tasktypes for compariosn

            //assert
            CollectionAssert.AreEqual(_context.TaskTypes.ToList(),model);
        }

        [TestMethod]
        public void DetailsNoIdLoads404()
        {
            //arrang
            //var controller = new TaskTypesController(_context);

            //act - calls details without ids
            var result = (ViewResult)controller.Details(null).Result;

            //assert
            Assert.AreEqual("404", result.ViewName);
        }

        [TestMethod]
        public void DetailsNoTaskTypesLoads404()
        {
            //arrang
            _context.TaskTypes = null;

            //act - pass in an id
            var result = (ViewResult)controller.Details(1).Result;

            //assert
            Assert.AreEqual("404", result.ViewName);
        }

        [TestMethod]
        public void DetailsInvalidIdLoads404()
        { 

            //act - pass in an id
            var result = (ViewResult)controller.Details(10).Result;

            //assert
            Assert.AreEqual("404", result.ViewName);
        }

        [TestMethod]
        public void DetailsValidIdLoadsTaskTypes()
        {

            //act - pass in an id
            var result = (ViewResult)controller.Details(2).Result;
            var model = (TaskType)result.Model;
            //assert
            Assert.AreEqual(_context.TaskTypes.Find(2), model);
        }

        [TestMethod]
        public void DetailsValidIdLoadsDetailsView()
        {

            //act - pass in an id
            var result = (ViewResult)controller.Details(2).Result; 
            //assert
            Assert.AreEqual("Details",result.ViewName);
        }

        [TestMethod]
        public void CreateLoadsCreateView()
        {
            //arrang
            //var controller = new TaskTypesController(_context);

            //act
            var result = (ViewResult)controller.Create();

            //assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void EditNoIdLoads404()
        {
            //arrang
            //var controller = new TaskTypesController(_context);

            //act - calls details without ids
            var result = (ViewResult)controller.Edit(null).Result;

            //assert
            Assert.AreEqual("404", result.ViewName);
        }

        [TestMethod]
        public void EditNoTaskTypesLoads404()
        {
            //arrang
            _context.TaskTypes = null;

            //act - pass in an id
            var result = (ViewResult)controller.Edit(1).Result;

            //assert
            Assert.AreEqual("404", result.ViewName);
        }

        [TestMethod]
        public void EditInvalidIdLoads404()
        {

            //act - pass in an id
            var result = (ViewResult)controller.Edit(10).Result;

            //assert
            Assert.AreEqual("404", result.ViewName);
        }

        [TestMethod]
        public void EditsValidIdLoadsTaskTypes()
        {

            //act - pass in an id
            var result = (ViewResult)controller.Edit(2).Result;
            var model = (TaskType)result.Model;
            //assert
            Assert.AreEqual(_context.TaskTypes.Find(2), model);
        }

        [TestMethod]
        public void EditValidIdLoadsDetailsView()
        {

            //act - pass in an id
            var result = (ViewResult)controller.Edit(2).Result;
            //assert
            Assert.AreEqual("Edit", result.ViewName);
        }


    }
}
