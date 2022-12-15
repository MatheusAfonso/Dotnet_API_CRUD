using Dotnet_API_CRUD.DTO;
using Dotnet_API_CRUD.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Dotnet_API_CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly DBContext DBContext;

        public ProdutosController(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }

        [HttpGet("GetProdutos")]
        public async Task<ActionResult<List<ProdutosDTO>>> Get()
        {
            var List = await DBContext.Produtos.Select(
                produto => new ProdutosDTO
                {
                    id = produto.id,
                    descProduto = produto.descProduto,
                    situacao = produto.situacao,
                    dtFabricacao = produto.dtFabricacao,
                    dtValidade = produto.dtValidade,
                    cdFornecedor = produto.cdFornecedor,
                    descFornecedor = produto.descFornecedor,
                    cnpjFornecedor = produto.cnpjFornecedor
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

        [HttpGet("GetProdutoById")]
        public async Task<ActionResult<ProdutosDTO>> GetProdutoById(int id)
        {
            ProdutosDTO Produtos = await DBContext.Produtos.Select(
                    produto => new ProdutosDTO
                    {
                        id = produto.id,
                        descProduto = produto.descProduto,
                        situacao = produto.situacao,
                        dtFabricacao = produto.dtFabricacao,
                        dtValidade = produto.dtValidade,
                        cdFornecedor = produto.cdFornecedor,
                        descFornecedor = produto.descFornecedor,
                        cnpjFornecedor = produto.cnpjFornecedor
                    })
                .FirstOrDefaultAsync(produto => produto.id == id);

            if (Produtos == null)
            {
                return NotFound();
            }
            else
            {
                return Produtos;
            }
        }

        [HttpPost("InsertProduto")]
        public async Task<String> InsertProduto(ProdutosDTO Produtos)
        {
            int result = DateTime.Compare(Produtos.dtValidade, Produtos.dtFabricacao);

            if (result < 0)
            {
                return "Data de fabricação não pode ser maior que data de validade";
            }
            else if (result == 0)
            {
                return "Data de fabricação não pode ser igual a data de validade";
            }
            else
            {
                var entity = new Produtos()
                {
                    descProduto = Produtos.descProduto,
                    situacao = Produtos.situacao,
                    dtFabricacao = Produtos.dtFabricacao,
                    dtValidade = Produtos.dtValidade,
                    cdFornecedor = Produtos.cdFornecedor,
                    descFornecedor = Produtos.descFornecedor,
                    cnpjFornecedor = Produtos.cnpjFornecedor
                };

                DBContext.Produtos.Add(entity);
                await DBContext.SaveChangesAsync();

                return "Ok";
            }
        }

        [HttpPut("UpdateProduto")]
        public async Task<String> UpdateProduto(ProdutosDTO Produtos)
        {
            int result = DateTime.Compare(Produtos.dtValidade, Produtos.dtFabricacao);

            if (result < 0)
            {
                return "Data de fabricação não pode ser maior que data de validade";
            }
            else if (result == 0)
            {
                return "Data de fabricação não pode ser igual a data de validade";
            }
            else
            {
                var entity = await DBContext.Produtos.FirstOrDefaultAsync(s => s.id == Produtos.id);

                entity.id = Produtos.id;
                entity.descProduto = Produtos.descProduto;
                entity.situacao = Produtos.situacao;
                entity.dtFabricacao = Produtos.dtFabricacao;
                entity.dtValidade = Produtos.dtValidade;
                entity.cdFornecedor = Produtos.cdFornecedor;
                entity.descFornecedor = Produtos.descFornecedor;
                entity.cnpjFornecedor = Produtos.cnpjFornecedor;

                await DBContext.SaveChangesAsync();
                return "Ok";
            }
        }

        [HttpDelete("DeleteProduto/{id}")]
        public async Task<HttpStatusCode> DeleteProduto(int id)
        {
            ProdutosDTO Produtos = await DBContext.Produtos.Select(
                    produto => new ProdutosDTO
                    {
                        id = produto.id,
                        descProduto = produto.descProduto,
                        situacao = produto.situacao,
                        dtFabricacao = produto.dtFabricacao,
                        dtValidade = produto.dtValidade,
                        cdFornecedor = produto.cdFornecedor,
                        descFornecedor = produto.descFornecedor,
                        cnpjFornecedor = produto.cnpjFornecedor
                    })
                .FirstOrDefaultAsync(produto => produto.id == id);

            if (Produtos == null)
            {
                return HttpStatusCode.NotFound;
            }
            else
            {
                var entity = await DBContext.Produtos.FirstOrDefaultAsync(s => s.id == Produtos.id);

                entity.id = Produtos.id;
                entity.descProduto = Produtos.descProduto;
                entity.situacao = "I";
                entity.dtFabricacao = Produtos.dtFabricacao;
                entity.dtValidade = Produtos.dtValidade;
                entity.cdFornecedor = Produtos.cdFornecedor;
                entity.descFornecedor = Produtos.descFornecedor;
                entity.cnpjFornecedor = Produtos.cnpjFornecedor;

                await DBContext.SaveChangesAsync();
                return HttpStatusCode.OK;
            }

        }
    }
}
