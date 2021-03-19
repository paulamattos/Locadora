using System;
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
        public IActionResult Inserir(InserirGeneroDTO dto)
        {
            try
            {
                return Ok(_aplicGenero.Inserir(dto));
            }            
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Editar(EditarGeneroDTO dto)
        {
            try
            {             
                _aplicGenero.Editar(dto);   
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Remover/{id}")] //remove um gênero por vez
        public void Remover([FromRoute] int id)
        {
            _aplicGenero.Remover(id);
        }

        [HttpDelete] //remove uma lista de gêneros
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