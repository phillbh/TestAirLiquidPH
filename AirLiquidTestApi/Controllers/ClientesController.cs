using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirLiquidTestApi.Model;
using Newtonsoft.Json;

namespace AirLiquidTestApi.Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class ClientesController : ControllerBase
	{
		private readonly DBContext _context;

		public ClientesController(DBContext context)
		{
			_context = context;
		}

		[HttpGet]
		public DefaultRetorno GetCliente(string id)
		{
			DefaultRetorno retorno = new DefaultRetorno();

			try
			{
				var cliente = _context.clientes.FirstOrDefault(x => x.Id == id);

				if (cliente == null)
				{
					retorno.Mensagem = "Cliente não localizado.";
					retorno.Status = 0;

					return retorno;
				}
				else
				{
					retorno.Mensagem = "Sucesso";
					retorno.ListaObjeto.Add(JsonConvert.SerializeObject(cliente));
					retorno.Status = 0;

					return retorno;
				}
				
			}
			catch (Exception ex)
			{
				retorno.Mensagem = ex.Message;
				retorno.Status = 1;
				return retorno;
			}
		}

		[HttpPut]
		public DefaultRetorno PutCliente(Cliente cliente)
		{
			DefaultRetorno retorno = new DefaultRetorno();

			try
			{
				var oldCliente = _context.clientes.FirstOrDefault(x => x.Id == cliente.Id);

				if (oldCliente == null)
				{
					retorno.Mensagem = "Registro anterior não localizado.";
					retorno.Status = 1;
					return retorno;
				}
				else
				{
					oldCliente.Nome = cliente.Nome;
					oldCliente.Idade = cliente.Idade;
					_context.SaveChanges();

					retorno.Mensagem = "Dados atualizados com sucesso.";
					retorno.Status = 0;
					return retorno;
				}

			}
			catch (Exception ex)
			{
				retorno.Mensagem = ex.Message;
				retorno.Status = 1;
				return retorno;
			}
		
		}

		[HttpPost]
		public DefaultRetorno PostCliente(Cliente cliente)
		{
			DefaultRetorno retorno = new DefaultRetorno();
			try
			{
				if (string.IsNullOrEmpty(cliente.Id))
					cliente.Id = Guid.NewGuid().ToString();

				if (string.IsNullOrEmpty(cliente.Nome) || cliente.Idade == 0)
				{
					retorno.Mensagem = "Verifique os dados informados em Nome e Idade";
					retorno.Status = 1;
					return retorno;
				}

				_context.clientes.Add(cliente);
				_context.SaveChanges();

				retorno.Mensagem = "Sucesso";
				retorno.ListaObjeto.Add(JsonConvert.SerializeObject(cliente));
				retorno.Status = 0;

				return retorno;
			}
			catch (Exception ex)
			{
				retorno.Mensagem = ex.Message;
				retorno.Status = 1;
				return retorno;
			}
		}

		[HttpDelete]
		public DefaultRetorno DeleteCliente(string id)
		{
			DefaultRetorno retorno = new DefaultRetorno();
			try
			{
				var cliente = _context.clientes.FirstOrDefault(x => x.Id == id);

				if(cliente == null)
				  {
					retorno.Mensagem = "Cliente não localizado.";
					retorno.Status = 0;

					return retorno;
				}
				else
				{
					_context.clientes.Remove(cliente);
					_context.SaveChanges();

					retorno.Mensagem = "Cliente excluído com sucesso.";
					retorno.Status = 0;

					return retorno;
				}
			}
			catch(Exception ex)
			{
				retorno.Mensagem = ex.Message;
				retorno.Status = 1;
				return retorno;
			}
		}

	}
}
