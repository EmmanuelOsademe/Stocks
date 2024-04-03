using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Data;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        
        public async Task<List<Comment>> GetAllAsync(){
            return await _context.Comments.Include(a => a.AppUser).ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id){
            var commentModel = await _context.Comments.Include(a => a.AppUser).FirstOrDefaultAsync(comment => comment.Id == id);
            if(commentModel == null){
                return null;
            }

            return commentModel;
        }

        public async Task<Comment> CreateAsync(Comment commentModel){
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id) {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(comment => comment.Id == id);
            if(commentModel == null){
                return null;
            }

            _context.Comments.Remove(commentModel);
            _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel){
            var existingComment = await _context.Comments.FindAsync(id);
            if(existingComment == null){
                return null;
            }

            existingComment.Title = commentModel.Title;
            existingComment.Content = commentModel.Content;

            await _context.SaveChangesAsync();
            return existingComment;
        }
    }
}