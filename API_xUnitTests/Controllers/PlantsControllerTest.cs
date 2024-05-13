using API.Controllers;
using API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_xUnitTests.Controllers
{
    public class PlantsControllerTest
    {
        PlantsController _controller;
        IPlantsService _service;
        public PlantsControllerTest()
        {
            _controller = new PlantsController(_service);
        }

        [Fact]
        public void GetAllPlantsTest()
        {
            var result = _controller.GetPlants();
        }
    }
}
