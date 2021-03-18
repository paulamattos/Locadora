using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Aplication.Locacoes.DTOs;
using Domain.Base;
using Domain.Locacoes;

namespace Aplication.Locacoes
{
    public class AplicLocacao: IAplicLocacao
    {
 
        private readonly IRepLocacao _repLocacao;
        private readonly IUnitOfWork _unitOfWork;

        public AplicLocacao(IRepLocacao repLocacao,
                            IUnitOfWork unitOfWork)
        {
            _repLocacao = repLocacao;
            _unitOfWork = unitOfWork;
        }

        public int Inserir(InserirLocacaoDTO dto)
        {
            var novo = new Locacao();
            
            using(var scope = new TransactionScope())
            {                
                novo.CPF = dto.CPF;
                novo.DataLocacao = DateTime.Now;            

                Validar(novo);

                _repLocacao.Inserir(novo);   
                _unitOfWork.Commit();  

                InserirFilmes(novo.CodigoLocacao, dto.Filmes);                                     

                scope.Complete();
            }
            
            return novo.CodigoLocacao;
        }
        
        public void Editar(EditarLocacaoDTO dto)
        {
            using(var scope = new TransactionScope())
            {  
                var locacao = _repLocacao.RecuperarPorId(dto.CodigoLocacao);

                if(locacao == null)
                    throw new ArgumentNullException(string.Format("Locação de código {0} não foi localizada!", dto.CodigoLocacao));

                locacao.CPF = dto.CPF;

                Validar(locacao);

                _unitOfWork.Commit();

                if(dto.Filmes != null && dto.Filmes.Any())
                {
                    _repLocacao.RemoverFilmes(_repLocacao.RecuperarFilmesLocacao(locacao.CodigoLocacao));
                    _unitOfWork.Commit();

                    InserirFilmes(locacao.CodigoLocacao, dto.Filmes);
                }                                

                scope.Complete();
            }
        }

        private void InserirFilmes(int codigoLocacao, List<LocacaoFilmesDTO> dto)
        {
            foreach (var filme in dto)
            {
                var locacaoFilme = new LocacaoFilme()
                {
                    CodigoLocacao = codigoLocacao,
                    CodigoFilme = filme.CodigoFilme
                };                     
                _repLocacao.InserirFilme(locacaoFilme);   
            }
            _unitOfWork.Commit();
        }

        private void Validar(Locacao dto)
        {
            if(string.IsNullOrEmpty(dto.CPF))
                throw new ArgumentException("CPF não foi informado!");
        }
        
        public List<LocacaoView> Listar(){
            var query = _repLocacao.Listar();
            var locacoes = query.Select(p => new LocacaoView()
            {
                CodigoLocacao = p.CodigoLocacao,
                CPF = p.CPF, 
                DataLocacao = p.DataLocacao,
                Filmes = p.Filmes.Select(x => new LocacaoFilmesDTO()
                            {
                             CodigoFilme = x.CodigoFilme,
                             CodigoLocacao = x.CodigoLocacao
                            }).ToList()               
            }).ToList();

            return locacoes;
        }
    }
}