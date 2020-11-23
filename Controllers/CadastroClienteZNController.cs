using CadastroClienteZerrenner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroClienteZerrenner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroClienteZNController : ControllerBase
    {       

        [HttpGet]
        public IEnumerable<TbZnCadastroCliente> Get()
        {
            using (var context = new CadastroClienteZNContext())
            {
                return context.TbZnCadastroCliente.ToList();
            }
        }

        [HttpPost]
        [Route("AlterCliente")]
        public bool AlterCliente(string cliente)
        {
            try
            {
                if (!string.IsNullOrEmpty(cliente))
                {
                    TbZnCadastroCliente clienteDes = JsonConvert.DeserializeObject<TbZnCadastroCliente>(cliente);

                    using (var context = new CadastroClienteZNContext())
                    {
                        context.Entry(clienteDes).State = EntityState.Modified;
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }


        [HttpPost]
        [Route("CriarCliente")]
        public bool CriarCliente(string cliente)
        {
            try
            {
                if (!string.IsNullOrEmpty(cliente))
                {
                    TbZnCadastroCliente clienteDes = JsonConvert.DeserializeObject<TbZnCadastroCliente>(cliente);
                    clienteDes.DataCriacao = DateTime.Now;
                    using (var context = new CadastroClienteZNContext())
                    {
                        context.Entry(clienteDes).State = EntityState.Added;
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }



        [HttpPost]
        [Route("DeletarCliente")]
        public bool DeletarCliente(string cliente)
        {
            try
            {
                if (!string.IsNullOrEmpty(cliente))
                {
                    TbZnCadastroCliente clienteDes = JsonConvert.DeserializeObject<TbZnCadastroCliente>(cliente);
                    using (var context = new CadastroClienteZNContext())
                    {
                        context.TbZnCadastroCliente.Remove(context.TbZnCadastroCliente.Find(clienteDes.IdCadastroCliente));
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

    }
}
