﻿using AutoMapper;
using BikeStoreApp_BackEnd.Data;
using BikeStoreApp_BackEnd.DTO;
using BikeStoreApp_BackEnd.Exceptions;
using BikeStoreApp_BackEnd.IServices;
using BikeStoreApp_BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeStoreApp_BackEnd.Services
{
    public class ProductService:IProductService
    {
        private readonly BikeStoreContext _context;
        private readonly IMapper _mapper;
        public ProductService(BikeStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductDTO> AddProduct(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);
        }
        public async Task<ProductDTO> UpdateProduct(int productId, ProductDTO productDTO)
        {
            var existingProduct = await _context.Products.FindAsync(productId);
            if (existingProduct == null)
                throw new EntityNotFoundException("Product not found");
            existingProduct.ProductName = productDTO.ProductName;
            existingProduct.Description = productDTO.Description;
            existingProduct.Price = productDTO.Price;
            existingProduct.StockQuantity = productDTO.StockQuantity;
            existingProduct.CategoryId = productDTO.CategoryId;
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(existingProduct);
        }
        public async Task DeleteProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new EntityNotFoundException("Product not found");
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
        public async Task<ProductDTO> GetProductById(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new EntityNotFoundException("Product not found");
            return _mapper.Map<ProductDTO>(product);
        }
        public async Task<List<ProductDTO>> GeBikesByCategory(string category)
        {
            return await _context.Products
                .Where(p => p.Category.CategoryName == category)
                .Select(p => new ProductDTO
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryName = p.Category.CategoryName,
                    BrandName = p.Brand.BrandName,
                    StockQuantity = p.StockQuantity,
                    Image = p.Image
                }).ToListAsync();
        }
        public async Task<Product> GetBikeByBrand(string brand)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Brand.BrandName == brand);
        }
        public async Task<Product> GetBikeBySearch(string searchBy, string filterValue)
        {
            if (searchBy == "Name")
            {
                return await _context.Products.FirstOrDefaultAsync(p => p.ProductName.Contains(filterValue));
            }
            else if (searchBy == "Category")
            {
                return await _context.Products.FirstOrDefaultAsync(p => p.Category.CategoryName == filterValue);
            }
            else if (searchBy == "Price")
            {
                if (double.TryParse(filterValue, out double parsedPrice))
                {
                    return await _context.Products.FirstOrDefaultAsync(p => p.Price == parsedPrice);
                }
                else
                {
                    // Handle invalid price format (e.g., return null or throw an exception)
                    return null;
                }
            }
            else if (searchBy == "Brand")
            {
                return await _context.Products.FirstOrDefaultAsync(p => p.Brand.BrandName.Contains(filterValue));
            }
            return null;
        }

    }
}
