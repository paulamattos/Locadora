using System;
using System.Collections.Generic;
using System.Linq;
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
            novo.CPF = dto.CPF;
            novo.DataLocacao = DateTime.Now;            

            foreach (var filme in dto.Filmes)
            {
                var locacaoFilme = new LocacaoFilme()
                {
                    CodigoLocacao = filme.CodigoLocacao,
                    CodigoFilme = filme.CodigoFilme
                }; 

                novo.Filmes.Add(locacaoFilme);                        
            }

            Validar(novo);

            _repLocacao.Inserir(novo);   

            _unitOfWork.Commit();         
            
            return novo.CodigoLocacao;
        }
        
        public void Editar(EditarLocacaoDTO dto)
        {
            var locacao = _repLocacao.RecuperarPorId(dto.CodigoLocacao);

            if(locacao == null)
                throw new ArgumentNullException(string.Format("Locação de código {0} não foi localizada!", dto.CodigoLocacao));

            locacao.CPF = dto.CPF;

            Validar(locacao);

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
                DataLocacao = p.DataLocacao
            }).ToList();

            return locacoes;
        }
    }
}