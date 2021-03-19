using System;
using System.Collections.Generic;
using Aplication.Locacoes;
using Aplication.Locacoes.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
     [ApiController]
     [Route("[controller]")]
     public class LocacaoController : ControllerBase
     {

         private readonly IAplicLocacao _aplicLocacao;
         
         public LocacaoController(IAplicLocacao aplicLocacao)
         {
             _aplicLocacao = aplicLocacao;
         }

        [HttpPost]
        public IActionResult Inserir(InserirLocacaoDTO dto)
        {
            try
            {
                return Ok(_aplicLocacao.Inserir(dto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Editar(EditarLocacaoDTO dto)
        {
            try
            {
                _aplicLocacao.Editar(dto);
                return Ok();
            }            
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public List<LocacaoView> Listar()
        {
            return _aplicLocacao.Listar();
        }
     }
}