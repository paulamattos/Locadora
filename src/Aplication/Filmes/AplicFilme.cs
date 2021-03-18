using System;
using System.Collections.Generic;
using System.Linq;
using Aplication.Filmes.DTOs;
using Domain.Base;
using Domain.Filmes;

namespace Aplication.Filmes
{
    public class AplicFilme: IAplicFilme
    {
        private readonly IRepFilme _repFilme;
        private readonly IUnitOfWork _unitOfWork;

        public AplicFilme(IRepFilme repFilme, 
                          IUnitOfWork unitOfWork)
        {
            _repFilme = repFilme;
            _unitOfWork = unitOfWork;
        }

        public int Inserir(InserirFilmeDTO dto)
        {                        
            var novo = new Filme();
            novo.Nome = dto.Nome;
            novo.DataCriacao = DateTime.Today; //a data de criação 
            novo.Ativo = dto.Ativo;
            novo.CodigoGenero = dto.CodigoGenero;
            
            Validar(novo);

            _repFilme.Inserir(novo);

            _unitOfWork.Commit();

            return novo.CodigoFilme;
        }        

        public void Editar(EditarFilmeDTO dto)
        {                        
            var filme = _repFilme.RecuperarPorId(dto.CodigoFilme);
            
            if(filme == null)
                throw new ArgumentNullException("Filme não localizado!");
                
            filme.Nome = dto.Nome;
            filme.Ativo = dto.Ativo;
            filme.CodigoGenero = dto.CodigoGenero;

            Validar(filme);                       

            _unitOfWork.Commit(); 
        }

        private void Validar(Filme dto)
        {
            if(String.IsNullOrEmpty(dto.Nome))
                throw new ArgumentException("Nome não foi informado.");
            
            if(dto.CodigoGenero == 0)
                throw new ArgumentException("Gênero não foi informado.");
        }

        public List<FilmeView> Listar()
        {
            var query = _repFilme.Listar();
            var filmes = query.Select(p => new FilmeView()
            {
                CodigoFilme = p.CodigoFilme,
                Nome = p.Nome,
                Ativo = p.Ativo,
                DataCriacao = p.DataCriacao,
                CodigoGenero = p.CodigoGenero
            }).ToList();

            return filmes;
        }

        public void Remover(int codigoFilme)
        {
            var filme = _repFilme.RecuperarPorId(codigoFilme);
            
            if(filme == null)
                throw new ArgumentNullException(string.Format("Filme código {0} não localizado!", codigoFilme));
                
            _repFilme.Remover(filme);
            _unitOfWork.Commit();            
        }

        public void RemoverFilmes(List<int> ids)
        {
            var filmes = _repFilme.Recuperar(ids);
            
            foreach(var filme in filmes)
            {
                _repFilme.Remover(filme);
            }
            _unitOfWork.Commit();
        } 
    }
}