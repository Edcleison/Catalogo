using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var categorias = await _produtoService.GetProdutos();
            return Ok(categorias);
        }

        [HttpGet("{id}", Name = "GetProduto")]
        public ActionResult<Categoria> Get(int id)
        {
            var produto = _produtoService.GetById(id);

            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _produtoService.Add(produtoDto);

            return new CreatedAtRouteResult("GetProduto",
                new { id = produtoDto.Id }, produtoDto);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProdutoDTO produtoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != produtoDto.Id)
            {
                return BadRequest();
            }
            _produtoService.Update(produtoDto);
            return Ok(produtoDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            var produtoDto = await _produtoService.GetById(id);
            if (produtoDto == null)
            {
                return NotFound();
            }

            await _produtoService.Remove(id);
            return Ok(produtoDto);
        }
    }
}
