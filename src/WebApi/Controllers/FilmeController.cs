using System;
using System.Collections.Generic;
using Aplication.Filmes;
using Aplication.Filmes.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IAplicFilme _aplicFilme;

        public FilmeController(IAplicFilme aplicFilme)
        {
            _aplicFilme = aplicFilme;
        }

        [HttpPost]
        public IActionResult Inserir(InserirFilmeDTO dto)
        {
            try
            {
                return Ok(_aplicFilme.Inserir(dto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut]
        public IActionResult Editar(EditarFilmeDTO dto)
        {
            try 
            {
                _aplicFilme.Editar(dto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpGet]
        public List<FilmeView> Listar()
        {
            return _aplicFilme.Listar();
        }

        [HttpDelete("Remover/{id}")] //remove um filme por vez        
        public void Remover([FromRoute] int id)
        {
            _aplicFilme.Remover(id);
        } 

        [HttpDelete] //remove uma lista de filmes
        public void RemoverFilmes([FromQuery] List<int> ids)
        {
            _aplicFilme.RemoverFilmes(ids);
        }
    }
}