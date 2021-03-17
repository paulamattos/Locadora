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
        public int Inserir(InserirFilmeDTO dto)
        {
            return _aplicFilme.Inserir(dto);
        }


        [HttpPut]
        public void Editar(EditarFilmeDTO dto)
        {
            _aplicFilme.Editar(dto);
        }

        [HttpGet]
        public List<FilmeView> ListarFilmes()
        {
            return _aplicFilme.ListarFilmes();
        }

        [HttpDelete("Remover/{id}")]        
        public void Remover([FromRoute] int id)
        {
            _aplicFilme.Remover(id);
        } 

        [HttpDelete]
        public void RemoverFilmes([FromQuery] List<int> ids)
        {
            _aplicFilme.RemoverFilmes(ids);
        }
    }
}