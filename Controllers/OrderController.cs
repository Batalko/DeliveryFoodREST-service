using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;


namespace DostavkaFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        DostavkaContext doscont = new DostavkaContext();
        List<Order> listorders = new List<Order>();

        [HttpGet]
        public string Get()
        {

            listorders = doscont.Orders.ToList();
            return JsonConvert.SerializeObject(doscont.Orders.ToList());
        }

        
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            Order o = new Order();
            listorders = doscont.Orders.ToList();
            for (int i = 0; i < listorders.Count; i++)
            {
                if(listorders[i].IdOrder == id)
                    o = listorders[i];
            }
            return Results.Json(o);
        }

        
        [HttpPost]
        public void Post(int idfood, int IdClient, int number, float summa)
        {
            Order o = new Order { IdClient = IdClient, IdFood=idfood, Number =number, Summa=summa };
            doscont.Orders.Add(o);
            doscont.SaveChanges();
        }


        [HttpPut("{id}")]
        public void Put(int id, int idfood, int IdClient, int number, float summa)
        {
            listorders = doscont.Orders.ToList();
            for (int i = 0; i < listorders.Count; i++)
            {
                if (listorders[i].IdOrder == id)
                {
                    listorders[i].IdFood = idfood;
                    listorders[i].Number = number;
                    listorders[i].Summa = summa;
                    listorders[i].IdClient=IdClient;
                    doscont.SaveChanges();
                }
            }
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            doscont.Orders.Where(u => u.IdOrder == id).ExecuteDelete();
            doscont.SaveChanges();
        }
    }
}
