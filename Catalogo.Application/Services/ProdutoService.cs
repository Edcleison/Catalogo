using AutoMapper;
using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Application.Services
{
    public class ProdutoService: IProdutoService
    {
        private IProdutoRepository _produtoRepository;

        private readonly IMapper _mapper;

        public ProdutoService(IMapper mapper, IProdutoRepository produtoRepository)
        {

            _produtoRepository = produtoRepository ??
                throw new ArgumentNullException(nameof(produtoRepository));

            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            var produtoEntity = await _produtoRepository.GetProdutosAsync();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtoEntity);
        }

        public async Task<ProdutoDTO> GetById(int? id)
        {
            var produtoEntity = await _produtoRepository.GetByIdAsync(id);
            return _mapper.Map<ProdutoDTO>(produtoEntity);
        }
        public async Task Add(ProdutoDTO produtoDto)
        {
            var produtoEntity = _mapper.Map<Produto>(produtoDto);
            await _produtoRepository.CreateAsync(produtoEntity);
        }
        public async Task Update(ProdutoDTO produtoDto)
        {
            var produtoEntity = _mapper.Map<Produto>(produtoDto);
            await _produtoRepository.UpdateAsync(produtoEntity);
        }
        public async Task Remove(int? id)
        {
            var produtoEntity = _produtoRepository.GetByIdAsync(id).Result;
            await _produtoRepository.RemoveAsync(produtoEntity);
        }

    }
}
