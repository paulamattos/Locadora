using System.Collections.Generic;
using Aplication.Locacoes;
using Aplication.Locacoes.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
     [ApiController]
     [Route("[controller]")]
     public class LocadoraController : ControllerBase
     {

         private readonly IAplicLocacao _aplicLocacao;
         
         public LocadoraController(IAplicLocacao aplicLocacao)
         {
             _aplicLocacao = aplicLocacao;
         }

        [HttpPost]
        public int Inserir(InserirLocacaoDTO dto)
        {
            return _aplicLocacao.Inserir(dto);
        }

        [HttpPut]
        public void Editar(EditarLocacaoDTO dto)
        {
            _aplicLocacao.Editar(dto);
        }

        [HttpGet]
        public List<LocacaoView> Listar()
        {
            return _aplicLocacao.Listar();
        }
     }
}