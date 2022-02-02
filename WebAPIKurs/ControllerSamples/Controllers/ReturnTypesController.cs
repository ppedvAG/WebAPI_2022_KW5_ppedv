using ControllerSamples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControllerSamples.Controllers
{
    //https:/localhost:5001/api/ReturnTypes/GetCurr
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnTypesController : ControllerBase
    {
        //Alles sind GET-MEthode (rufen Daten von der WebAPI ab)


        //Native Datentypen kann man zurückgeben (string, int, float, decimal, DateTime....usw) 
        [HttpGet("GetCurrentTime")] 
        public string GetCurrentTime()
        {
            return DateTime.Now.ToString();
        }

        //ContentResult liefert einen string zurück 
        [HttpGet("GetCurrentTime2")]
        public ContentResult GetCurrentTime2()
        {
            return Content(DateTime.Now.ToString());
        }

        [HttpGet("/GetCurrentTime3")]
        public ContentResult GetCurrentTime3()
        {
            return Content(DateTime.Now.ToString());
        }


        #region Komplexen Objekte
        [HttpGet("GetComplexObject")]
        public Car GetComplexObject()
        {
            Car car = new Car();
            car.Brand = "BMW";
            car.Model = "Z8";
            car.ConstructorYear = 2022;

            return car; //200er + JSON-Struktur 
        }

        [HttpGet("GetCarList")]
        public List<Car> GetCarList()
        {
            Car car = new Car();
            car.Brand = "BMW";
            car.Model = "Z8";
            car.ConstructorYear = 2022;

            Car car1 = new Car();
            car1.Brand = "BMW";
            car1.Model = "Z3";
            car1.ConstructorYear = 2002;

            Car car2 = new Car();
            car2.Brand = "BMW";
            car2.Model = "James Bond Auto";
            car2.ConstructorYear = 2003;


            List<Car> carList = new List<Car>();
            carList.Add(car);
            carList.Add(car1);
            carList.Add(car2);
            
            
            return carList;
        }

        #endregion
        [HttpGet("GetCarWith_IActionResult")]
        public IActionResult GetCarWith_IActionResult()
        {
            Car car = new Car();
            car.Brand = "BMW";
            car.Model = "Z8";
            car.ConstructorYear = 2022;

            if (car.Brand != "BMW")
                return BadRequest(); //400 Fehler Code wird via Response an Client übermittelt

            if (car.Brand == string.Empty)
                return NotFound(); //404


            return Ok(car); //JSON-Struktur + 200er Status Code

        }

        [HttpGet("GetCarWithActionResult")]
        public ActionResult GetCarWithActionResult()
        {
            Car car = new Car();
            car.Brand = "BMW";
            car.Model = "Z8";
            car.ConstructorYear = 2022;

            if (car.Brand != "BMW")
                return BadRequest(); //400 Fehler Code wird via Response an Client übermittelt

            if (car.Brand == string.Empty)
                return NotFound(); //404


            return Ok(car); //JSON-Struktur + 200er Status Code
        }

        //Asychrone
        [HttpGet("GetCarWithActionResultAsync")]
        public async Task<ActionResult> GetCarWithActionResultAsync()
        {
            await Task.Delay(1000);

            Car car = new Car();
            car.Brand = "BMW";
            car.Model = "Z8";
            car.ConstructorYear = 2022;

            return Ok(car); //200er Codee
        }

        [HttpGet("GetCarIEnumerable")]
        public IEnumerable<Car>  GetCars()
        {
            Car car = new Car();
            car.Brand = "BMW";
            car.Model = "Z8";
            car.ConstructorYear = 2022;

            Car car1 = new Car();
            car1.Brand = "BMW";
            car1.Model = "Z3";
            car1.ConstructorYear = 2002;

            Car car2 = new Car();
            car2.Brand = "BMW";
            car2.Model = "James Bond Auto";
            car2.ConstructorYear = 2003;


            List<Car> carList = new List<Car>();
            carList.Add(car);
            carList.Add(car1);
            carList.Add(car2);

            foreach (Car currentCar in carList)
            {
                yield return currentCar;
            }

            
        } //Methode wird immer  noch hier verlassen 


        [HttpGet("GetCarIAsyncEnumerable")]
        public async IAsyncEnumerable<Car> GetCarsAsyncEnumerable()
        {
            Car car = new Car();
            car.Brand = "BMW";
            car.Model = "Z8";
            car.ConstructorYear = 2022;

            Car car1 = new Car();
            car1.Brand = "BMW";
            car1.Model = "Z3";
            car1.ConstructorYear = 2002;

            Car car2 = new Car();
            car2.Brand = "BMW";
            car2.Model = "James Bond Auto";
            car2.ConstructorYear = 2003;


            List<Car> carList = new List<Car>();
            carList.Add(car);
            carList.Add(car1);
            carList.Add(car2);

            foreach (Car currentCar in carList)
            {
                await Task.Delay(2000);
                yield return currentCar;
            }
        }
    }
}
