using CarsAPI.Data;
using CarsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;

namespace CarsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly CarsAPIDbContext dbContext;

        public CarsController(CarsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            return Ok(await dbContext.Cars.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCar([FromRoute] Guid id)
        {
            var car = await dbContext.Cars.FindAsync(id);

            if (car == null)
                return NotFound();

            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(AddCarRequest addCarRequest)
        {
            var car = new Car
            {
                Id = Guid.NewGuid(),
                Make = addCarRequest.Make,
                Model = addCarRequest.Model,
                Year = addCarRequest.Year,
                isUsed = addCarRequest.isUsed
            };

            await dbContext.Cars.AddAsync(car);
            await dbContext.SaveChangesAsync();

            return Ok(car);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCar([FromRoute] Guid id, UpdateCarRequest updateCarRequest)
        {
            var car =  await dbContext.Cars.FindAsync(id);

            if (car == null)
                return NotFound();

            car.Make = updateCarRequest.Make;
            car.Model = updateCarRequest.Model;
            car.Year = updateCarRequest.Year;
            car.isUsed = updateCarRequest.isUsed;

            await dbContext.SaveChangesAsync();

            return Ok(car);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        // FromRoute is not needed as its specified in the route attribute, but it's there for example
        public async Task<IActionResult> DeleteCar([FromRoute] Guid id)
        {
            var car = await dbContext.Cars.FindAsync(id);

            if (car == null)
                return NotFound();

            dbContext.Remove(car);
            await dbContext.SaveChangesAsync();

            return Ok(car);
        }
    }
}
