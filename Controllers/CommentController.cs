using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Interfaces;
using api.Mappers;
using api.Dtos.Comment;
using api.Models;


namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;

        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var comments = await _commentRepo.GetAllAsync();

            var commentsDto = comments.Select(comment => comment.ToCommentDto());

            return Ok(commentsDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var comment = await _commentRepo.GetByIdAsync(id);
            if(comment == null){
                return NotFound();
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpPost]
        [Route("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentRequestDto commentDto){
           if(!ModelState.IsValid) return BadRequest(ModelState);
            if(!await _stockRepo.StockExists(stockId)){
                return BadRequest("Stock does not exist");
            }

            Comment commentModel = commentDto.ToCommentFromCreate(stockId);

            await _commentRepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new {id = commentModel.Id}, commentModel.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var commentModel = await _commentRepo.DeleteAsync(id);
            if(commentModel == null){
                return NotFound("Comment not found");
            }

            return NoContent();
        }
    }
}