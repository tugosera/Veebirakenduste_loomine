using Microsoft.AspNetCore.Mvc;

namespace veeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrimitiividController : ControllerBase
    {

        // GET: primitiivid/hello-world
        [HttpGet("hello-world")]
        public string HelloWorld()
        {
            return "Hello world at " + DateTime.Now;
        }

        // GET: primitiivid/hello-variable/mari
        [HttpGet("hello-variable/{nimi}")]
        public string HelloVariable(string nimi)
        {
            return "Hello " + nimi;
        }

        // GET: primitiivid/add/5/6
        [HttpGet("add/{nr1}/{nr2}")]
        public int AddNumbers(int nr1, int nr2)
        {
            return nr1 + nr2;
        }

        // GET: primitiivid/multiply/5/6
        [HttpGet("multiply/{nr1}/{nr2}")]
        public int Multiply(int nr1, int nr2)
        {
            return nr1 * nr2;
        }

        // GET: primitiivid/do-logs/5
        [HttpGet("do-logs/{arv}")]
        public void DoLogs(int arv)
        {
            for (int i = 0; i < arv; i++)
            {
                Console.WriteLine("See on logi nr " + i);
            }
        }

        [HttpGet("random/{nr1}/{nr2}")]
        public int GetRandomBetween(int nr1, int nr2)
        {
            Random rand = new Random();
            int min = Math.Min(nr1, nr2);
            int max = Math.Max(nr1, nr2);
            return rand.Next(min, max + 1);
        }

        [HttpGet("age/{birthYear}")]
        [HttpGet("age/{birthYear}/{birthMonth}/{birthDay}")]
        public string GetAge(int birthYear, int birthMonth, int birthDay)
        {
            DateTime today = DateTime.Today;
            DateTime birthdayThisYear;

            try
            {
                birthdayThisYear = new DateTime(today.Year, birthMonth, birthDay);
            }
            catch
            {
                return "Некорректные данные: неверный месяц или день.";
            }

            int age = today.Year - birthYear;

            if (today < birthdayThisYear)
            {
                age--;
            }

            return $"Ты {age} лет(года) {(today >= birthdayThisYear ? "т.к. день рождения в этом году уже был" : "т.к. день рождения в этом году ещё не был")}.";
        }

    }
}