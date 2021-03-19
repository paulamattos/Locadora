using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Aplication.Generos.DTOs;
using Domain.Base;
using Domain.Generos;

namespace Aplication.Generos
{
    public class AplicGenero: IAplicGenero
    {
        private readonly IRepGenero _repGenero;
        private readonly IUnitOfWork _unitOfWork;
        
        public AplicGenero(IRepGenero repGenero, 
                            IUnitOfWork unitOfWork)
        {
            _repGenero = repGenero;
            _unitOfWork = unitOfWork;
        }

        public int Inserir(InserirGeneroDTO dto)
        {                 
            var novo = new Genero()
            {
                Nome = dto.Nome,
                DataCriacao = DateTime.Today, //a data de criação não precisa vir do front, pego a data atual e ela não é alterada
                Ativo = dto.Ativo
            };

            Validar(novo);
            
            _repGenero.Inserir(novo);
            _unitOfWork.Commit();                

            return novo.CodigoGenero;  //retorno o ID do novo registro para controle do front          
        }        

        public void Editar(EditarGeneroDTO dto)
        {                        
            var genero = _repGenero.RecuperarPorId(dto.CodigoGenero);
            
            if (genero == null)
                throw new ArgumentNullException(string.Format("Gênero de código {0} não foi localizado!", dto.CodigoGenero));
                        
            genero.Nome = dto.Nome;
            genero.Ativo = dto.Ativo;

            Validar(genero);    

            _unitOfWork.Commit();                         
        }

        private void Validar(Genero dto)
        {
            if(String.IsNullOrEmpty(dto.Nome))
                throw new ArgumentException("Nome não foi informado.");
        }

        public List<GeneroView> Listar()
        {
            var query = _repGenero.Listar();
            var generos = query.Select(p => new GeneroView()
            {
                CodigoGenero = p.CodigoGenero,
                Nome = p.Nome,                
                Ativo = p.Ativo,
                DataCriacao = p.DataCriacao
            }).ToList();

            return generos;
        }

        public void Remover(int codigoGenero)
        {
            var genero = _repGenero.RecuperarPorId(codigoGenero);
            
            if (genero == null)
                throw new ArgumentNullException(string.Format("Gênero de código {0} não foi localizado!", codigoGenero));
                        
            _repGenero.Remover(genero);
            _unitOfWork.Commit();
        }

        public void RemoverGeneros(List<int> IdsGeneros)
        {            
            _repGenero.Remover(IdsGeneros);
            _unitOfWork.Commit();                                        
        }
    }
}