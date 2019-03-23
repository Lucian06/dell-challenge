using System.Collections.Generic;
using System.Linq;
using DellChallenge.D1.Api.Dto;

namespace DellChallenge.D1.Api.Dal
{
    public class ProductsService : IProductsService
    {
        private readonly ProductsContext _context;

        public ProductsService(ProductsContext context)
        {
            _context = context;
        }

        public ProductDto Get(int id)
        {
            return _context.Products.Where(w => w.Id == id.ToString()).Select(s => new ProductDto() { Id = s.Id, Name = s.Name, Category = s.Category }).FirstOrDefault(); ;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _context.Products.Select(p => MapToDto(p));
        }

        public ProductDto Add(NewProductDto newProduct)
        {
            var product = MapToData(newProduct);
            _context.Products.Add(product);
            _context.SaveChanges();
            var addedDto = MapToDto(product);
            return addedDto;
        }

        public ProductDto CreateOrUpdate(int id, NewProductDto newProduct)
        {
            var product = _context.Products.Where(w => w.Id == id.ToString()).FirstOrDefault();
            if (product != null)
            {
                product.Category = newProduct.Category;
                product.Name = newProduct.Name;
                _context.Products.Update(product);
                _context.SaveChanges();
                return MapToDto(product);
            }
            else
                return Add(newProduct);

        }

        public ProductDto Delete(string id)
        {
            var product = _context.Products.Where(w => w.Id == id.ToString()).FirstOrDefault();
            if (product != null)
            {
                _context.Products.Remove(product);
                return MapToDto(product);
            }
            else
                return null;
        }

        private Product MapToData(NewProductDto newProduct)
        {
            return new Product
            {
                Category = newProduct.Category,
                Name = newProduct.Name
            };
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }
    }
}
