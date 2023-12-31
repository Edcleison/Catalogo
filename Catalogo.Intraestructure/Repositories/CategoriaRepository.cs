﻿using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using Catalogo.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Infraestructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private ApplicationDbContext _categoriaContext;

        public CategoriaRepository(ApplicationDbContext categoriaContext)
        {
            _categoriaContext = categoriaContext;
        }

        public async Task<Categoria> CreateAsync(Categoria categoria)
        {
            _categoriaContext.Add(categoria);
            await _categoriaContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> GetByIdAsync(int? id)
        {
            return await _categoriaContext.Categorias.FindAsync(id);
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            return await _categoriaContext.Categorias.ToListAsync();
        }

        public async Task<Categoria> RemoveAsync(Categoria categoria)
        {
            _categoriaContext.Remove(categoria);
            await _categoriaContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> UpdateAsync(Categoria categoria)
        {
            _categoriaContext.Update(categoria);
            await _categoriaContext.SaveChangesAsync();
            return categoria;
        }
    }
}
