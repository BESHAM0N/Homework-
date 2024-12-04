using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Converter
{
    public sealed class Product : IProduct
    {
        public ProductType ProductType { get; private set;}
        
        public Product(ProductType productType)
        {
            ProductType = productType;
        }

        
    }
}