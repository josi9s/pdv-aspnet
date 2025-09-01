using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using dotnet_pdv.DataContext;
using dotnet_pdv.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_pdv.Service
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly ApplicationDbContext _context;
        public ProdutoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ProdutoModel>>> GetProdutos()
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = new ServiceResponse<List<ProdutoModel>>();

            try
            {
                serviceResponse.Dados = _context.Produto.ToList();
                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<ProdutoModel>>> CreateProduto(ProdutoModel novoProduto)
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = new ServiceResponse<List<ProdutoModel>>();

            try
            {
                if (novoProduto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoProduto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Produto.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;

        }
        public async Task<ServiceResponse<ProdutoModel>> GetProdutoById(int id)
        {
            ServiceResponse<ProdutoModel> serviceResponse = new ServiceResponse<ProdutoModel>();

            try
            {
                ProdutoModel produto = _context.Produto.FirstOrDefault(x => x.Id == id);

                if (produto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produto não localizado";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = produto;

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<ProdutoModel>>> UpdateProduto(ProdutoModel editadoProduto)
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = new ServiceResponse<List<ProdutoModel>>();

            try
            {
                ProdutoModel produto = _context.Produto.AsNoTracking().FirstOrDefault(x => x.Id == editadoProduto.Id);

                if (produto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produto não localizado.";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                _context.Produto.Update(editadoProduto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Produto.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<ProdutoModel>>> DeleteProduto(int id)
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = new ServiceResponse<List<ProdutoModel>>();
            
            try
            {
                ProdutoModel produto = _context.Produto.FirstOrDefault(x => x.Id == id);

                if (produto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produto não encontrado";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Produto.Remove(produto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Produto.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

  }
}
