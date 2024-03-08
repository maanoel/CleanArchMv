using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private IMapper _mapper;
        private IProductRepository _repository;

        public ProductService(IProductRepository repository, IMapper mapper) 
        { 
            _mapper = mapper;
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task Add(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _repository.Create(productEntity);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productEntity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var productEntity = _repository.GetProductsCategoryAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity = await _repository.GetProductsAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task Remove(int? id)
        {
            var productEntity = await _repository.GetByIdAsync(id);
            await _repository.Remove(productEntity);  
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _repository.Update(productEntity);
        }
    }
}
