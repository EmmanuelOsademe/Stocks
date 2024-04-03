using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;
using api.Dtos.Stock;
using api.Helpers;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Stock>> GetAllAsync(StockQuery query){
            var stocks = _context.Stocks.Include(c => c.Comments).ThenInclude(a => a.AppUser).AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.CompanyName)){
                stocks = stocks.Where(company => company.CompanyName.Contains(query.CompanyName));
            }

            if(!string.IsNullOrWhiteSpace(query.Symbol)){
                stocks = stocks.Where(company => company.Symbol.Contains(query.Symbol));
            }

            if(!string.IsNullOrWhiteSpace(query.SortBy)){
                if(query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase)){
                    stocks = query.IsDescending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
                }
                
                if(query.SortBy.Equals("CompanyName", StringComparison.OrdinalIgnoreCase)){
                    stocks = query.IsDescending ? stocks.OrderByDescending(s => s.CompanyName) : stocks.OrderBy(s => s.CompanyName);
                }
                
            }

            int skipNumber = (query.PageNumber - 1) * query.PageSize;

            stocks = stocks.Skip(skipNumber).Take(query.PageSize);

            return await stocks.ToListAsync();
        }

        public async Task<Stock> CreateAsync(Stock stockModel){
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> GetByIdAsync(int id){
            var stockModel = await _context.Stocks.Include(c => c.Comments).ThenInclude(a => a.AppUser).FirstOrDefaultAsync(x => x.Id == id);
            if(stockModel == null){
                return null;
            }
            return stockModel;
        }

        public async Task<Stock?> GetBySymbolAsync(string symbol){
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Symbol == symbol);
            if(stockModel == null){
                return null;
            }
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id){
            var stockModel = await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(x => x.Id == id);
            if(stockModel == null){
                return null;
            }

            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto){
            var existingStock = await GetByIdAsync(id);
            if(existingStock == null){
                return null;
            }

            existingStock.Symbol = stockDto.Symbol;
            existingStock.CompanyName = stockDto.CompanyName;
            existingStock.Purchase = stockDto.Purchase;
            existingStock.MarketCap = stockDto.MarketCap;
            existingStock.Industry = stockDto.Industry;
            existingStock.LastDiv = stockDto.LastDiv;

            await _context.SaveChangesAsync();
            return existingStock;
        }

        public async Task<bool> StockExists(int id){
            return await _context.Stocks.AnyAsync(s => s.Id == id);
        }
    }
}