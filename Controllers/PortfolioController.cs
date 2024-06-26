using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Interfaces;
using api.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using api.Models;

namespace api.Controllers
{
    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepo;
        private readonly IPortfolioRepository _portfolioRepo;
        public PortfolioController(UserManager<AppUser> userManager, IStockRepository stockRepo, IPortfolioRepository portfolioRepo)
        {
            _userManager = userManager;
            _stockRepo = stockRepo; 
            _portfolioRepo = portfolioRepo;  
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio(){
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);

            return Ok(userPortfolio);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPortfolio([FromQuery] string symbol) {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            Stock stock = await _stockRepo.GetBySymbolAsync(symbol);
            if(stock == null){
                return BadRequest("Stock not found");
            }

            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);

            if(userPortfolio.Any(e => e.Symbol.ToLower() == symbol.ToLower())){
                return BadRequest("Stock already added to portfolio");
            }

            Portfolio portfolioModel = new Portfolio
            {
                StockId = stock.Id,
                AppUserId = appUser.Id
            };

            await _portfolioRepo.CreateAsync(portfolioModel);

            if(portfolioModel == null){
                return StatusCode(500, "Could not create portfolio");
            }

            return Created();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeletePortfolio([FromQuery] string symbol){
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);

            var filteredStock = userPortfolio.Where(s => s.Symbol.ToLower() == symbol.ToLower()).ToList();
            if(filteredStock.Count() == 1){
                Portfolio  portfolio = await _portfolioRepo.DeleteAsync(appUser, symbol);

                if(portfolio == null){
                    return BadRequest("Portfolio not found");
                }

                return NoContent();
            }else{
                return BadRequest("Stock not in your portfolio");
            }

        }
    }
}