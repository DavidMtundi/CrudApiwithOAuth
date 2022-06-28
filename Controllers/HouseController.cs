using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OOauthApi.Interfaces;
using OOauthApi.Models;

namespace OOauthApi.Controllers
{
    [ApiController]
    [Authorize("ApiScope")]

    public class HouseController : ControllerBase
    {

        private IHouse house;
        public HouseController(IHouse _house)
        {
            this.house = _house;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetHouses()
        {
            return Ok(house.getAllHouses());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetHouse(int id)
        {
            var housefound = house.getHouse(id);
            if (housefound != null)
            {

                return Ok(house.getHouse(id));
            }
            return NotFound($"The house with id {id} was not found");
        }
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult CreateHouse(Housemodel _house)
        {
            return Ok(house.createHouse(_house));
        }
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteHouse(Housemodel housemodel)
        {
            Housemodel _hou = house.getHouse(housemodel.Id);
            if (_hou != null)
            {
                house.deleteHouse(housemodel);
                return Ok($"House with id {housemodel.Id} has been created succesfuly");
            }
            return NotFound($"The house with id {housemodel.Id} was not found");
        }
    }
}
