﻿using DellChallenge.D1.Api.Dto;
using System.Collections.Generic;

namespace DellChallenge.D1.Api.Dal
{
    public interface IProductsService
    {
        ProductDto Get(int id);
        IEnumerable<ProductDto> GetAll();
        ProductDto Add(NewProductDto newProduct);
        ProductDto CreateOrUpdate(int id, NewProductDto newProduct);
        ProductDto Delete(string id);
    }
}
