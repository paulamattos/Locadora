using System.Collections.Generic;
using Aplication.Generos;
using Aplication.Generos.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneroController : ControllerBase
    {
        public readonly IAplicGenero _aplicGenero;
        
        public GeneroController(IAplicGenero aplicGenero)
        {
            _aplicGenero = aplicGenero;
        }

        [HttpPost]
        public int Inserir(InserirGeneroDTO dto)
        {
            return _aplicGenero.Inserir(dto);
        }

        [HttpPut]
        public void Editar(EditarGeneroDTO dto)
        {
            _aplicGenero.Editar(dto);
        }

        [HttpDelete("Remover/{id}")]        
        public void Remover([FromRoute] int id)
        {
            _aplicGenero.Remover(id);
        }

        [HttpDelete]
        public void RemoverGeneros([FromQuery] List<int> ids)
        {
            _aplicGenero.RemoverGeneros(ids);
        }

        [HttpGet]
        public List<GeneroView> Listar()
        {
            return _aplicGenero.Listar();
        }
    }
}