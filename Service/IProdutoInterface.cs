using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_pdv.Models;

namespace dotnet_pdv.Service
{
    public interface IProdutoInterface
    {
        Task<ServiceResponse<List<ProdutoModel>>> GetProdutos();
        Task<ServiceResponse<List<ProdutoModel>>> CreateProduto(ProdutoModel novoProduto);
        Task<ServiceResponse<ProdutoModel>> GetProdutoById(int id);
        Task<ServiceResponse<List<ProdutoModel>>> UpdateProduto(ProdutoModel editadoProduto);
        Task<ServiceResponse<List<ProdutoModel>>> DeleteProduto(int id);
        
    }
}