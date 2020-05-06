﻿using Core.Dto.UseCaseRequests;
using Core.Dto.UseCaseResponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCases
{
    public sealed class UpdateProductDetailUseCase : IUpdateProductDetailUseCase
    {
        private readonly IProductRepository repository;

        public UpdateProductDetailUseCase(IProductRepository repo)
        {
            repository = repo;
        }

        public async Task<bool> Handle(UpdateProductDetailRequest request, IOutputPort<UpdateProductDetailResponse> outputPort)
        {
            var product = await repository.GetProductById(request.Id);

            if (product != null)
            {
                var response = await repository.Update(new Product
                {
                    Id = request.Id,
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    Category = request.Category
                });

                outputPort.Handle(response.Success ? new UpdateProductDetailResponse(true) : new UpdateProductDetailResponse(false, "Operation failed"));

                return response.Success;
            }

            outputPort.Handle(new UpdateProductDetailResponse(false, $"ProductId - {request.Id} not found"));

            return false;
        }
    }
}
