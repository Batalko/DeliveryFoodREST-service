using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Text.Json;

namespace DostavkaFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        DostavkaContext doscont = new DostavkaContext();
        List<Client> listclient = new List<Client>();

        [HttpGet]
        public string Get()
        {
            
            listclient = doscont.Clients.ToList();
            return JsonConvert.SerializeObject(listclient);
        }

        
        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            Client o = new Client();
            listclient = doscont.Clients.ToList();
            for (int i = 0; i < listclient.Count; i++)
            {
                if (listclient[i].IdClient == id) 
                {
                    o = listclient[i];

                }
            }
            return Results.Json(o);
        }

        
        [HttpPost]
        public void Post(string fio, string Phone, string address)
        {
            Client c = new Client { Fio = fio, Address=address, PhoneNumber = Phone };
            doscont.Clients.Add(c);
            doscont.SaveChanges();
        }

        
        [HttpPut("{id}")]
        public void Put(int id, string fio, string phone, string address)
        {

            listclient = doscont.Clients.ToList();
            for (int i = 0; i < listclient.Count; i++)
            {
                if (listclient[i].IdClient == id)
                {
                    listclient[i].Fio = fio;
                    listclient[i].PhoneNumber = phone;
                    listclient[i].Address = address;
                    doscont.SaveChanges();
                }
            }
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            doscont.Clients.Where(u => u.IdClient == id).ExecuteDelete();
            doscont.SaveChanges();
        }
    }
}
