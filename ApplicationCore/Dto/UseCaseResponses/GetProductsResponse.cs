﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Dto.UseCaseResponses
{
    public class GetProductsResponse
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }    
}
