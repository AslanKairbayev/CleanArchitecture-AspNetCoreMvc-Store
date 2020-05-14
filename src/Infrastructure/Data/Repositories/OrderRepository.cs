﻿using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;

        public OrderRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public async Task<IEnumerable<Order>> UnshippedOrdersWithLines()
        { 
            return await context.Orders
            .Where(w => !w.Shipped)
            .Include(i => i.Lines)
            .ThenInclude(t => t.Product).ToListAsync();
        } 

        public async Task<Order> GetOrderById(int orderId)
        {
            return await context.Orders.FirstOrDefaultAsync(f => f.Id == orderId);
        }

        public async Task Create(Order order)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync();
        }        

        public async Task MarkShipped(int orderId)
        {
            var dbEntry = await GetOrderById(orderId);

            dbEntry.Shipped = true;

            await context.SaveChangesAsync();
        }
    }
}