using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;
using api.Dtos.Comment;

namespace api.Mappers
{
    public static class StockMapper
    {
        public static StockDto ToStockDto(this Stock stockModel){
            return  new StockDto {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
                Comments = stockModel.Comments.Select(comment => comment.ToCommentDto()).ToList()
            };
        }

        public static Stock ToStockFromCreateDto (this CreateStockRequestDto requestStock){
            
            return new Stock {
                Symbol = requestStock.Symbol,
                CompanyName = requestStock.CompanyName,
                Purchase = requestStock.Purchase,
                LastDiv = requestStock.LastDiv,
                Industry = requestStock.Industry,
                MarketCap = requestStock.MarketCap
            };
        }
    }
}