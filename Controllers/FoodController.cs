using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Newtonsoft.Json;

namespace DostavkaFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        DostavkaContext doscont = new DostavkaContext();
        List <Food> listfood = new List<Food>();


        [HttpGet]
        public string Get()
        {
           
            listfood = doscont.Foods.ToList();
            return JsonConvert.SerializeObject(listfood);
        }

        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            Food o = new Food();
            listfood = doscont.Foods.ToList();
            for (int i = 0; i < listfood.Count; i++)
            {
                if (listfood[i].IdFood == id)
                {
                    o = listfood[i];
                }
                
            }
            return Results.Json(o);
        }

        [HttpPut("{id}")]
        public void Put(int id,string name, string type, string note, float price)
        {
            listfood = doscont.Foods.ToList();
            for (int i = 0; i < listfood.Count; i++)
            {
                if (listfood[i].IdFood == id)
                {
                    listfood[i].Name = name;  listfood[i].Type = type;listfood[i].Price = price;listfood[i].Note = note;    
                    
                    doscont.SaveChanges();
                }
            }

        }

        [HttpPost]
        public void Post(string name, string type, string note, float price)
        {
            Food f = new Food { Name = name,Type = type,Price = price, Note = note};
            doscont.Foods.Add(f);
            doscont.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            doscont.Foods.Where(u => u.IdFood == id).ExecuteDelete();
            doscont.SaveChanges();
        }
    }
}
