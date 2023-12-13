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
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaRepository _categoriaRepository;

        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
        {
            var categoriasEntity = await _categoriaRepository.GetCategoriasAsync();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
        }
        public async Task<CategoriaDTO> GetById(int? id)
        {
            var categoriasEntity = await _categoriaRepository.GetByIdAsync(id);
            return _mapper.Map<CategoriaDTO>(categoriasEntity);
        }

        public async Task Add(CategoriaDTO categoriaDto)
        {
            var categoriasEntity = _mapper.Map<Categoria>(categoriaDto);
            await _categoriaRepository.CreateAsync(categoriasEntity);
        }

        public async Task Update(CategoriaDTO categoriaDto)
        {
            var categoriasEntity = _mapper.Map<Categoria>(categoriaDto);
            await _categoriaRepository.UpdateAsync(categoriasEntity);
        }

        public async Task Remove(int? id)
        {
            var categoriasEntity = _categoriaRepository.GetByIdAsync(id).Result;
            await _categoriaRepository.RemoveAsync(categoriasEntity);
        }
    }
}
