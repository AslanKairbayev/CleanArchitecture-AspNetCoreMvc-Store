﻿using Core.Interactors;
using Core.Interfaces.UseCases;
using Core.UseCases;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IGetProductsByParamUseCase, GetProductsByParamUseCase>();
            services.AddScoped<IGetProductsUseCase, GetProductsUseCase>();
            services.AddScoped<IGetProductDetailUseCase, GetProductDetailUseCase>();
            services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
            services.AddScoped<IUpdateProductDetailUseCase, UpdateProductDetailUseCase>();
            services.AddScoped<IRemoveProductUseCase, RemoveProductUseCase>();
            services.AddScoped<IGetCategoriesUseCase, GetCategoriesUseCase>();

            services.AddScoped<IGetCartUseCase, GetCartUseCase>();
            services.AddScoped<IAddToCartUseCase, AddToCartUseCase>();
            services.AddScoped<IRemoveFromCartUseCase, RemoveFromCartUseCase>();

            services.AddScoped<IGetUnshippedOrdersUseCase, GetUnshippedOrdersUseCase>();
            services.AddScoped<ICheckoutUseCase, CheckoutUseCase>();
            services.AddScoped<IMarkOrderShippedUseCase, MarkOrderShippedUseCase>();

            services.AddTransient<ILoginUseCase, LoginUseCase>();
            services.AddTransient<ILogoutUseCase, LogoutUseCase>();

            return services;
        }
    }
}
