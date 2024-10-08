﻿using InternPipeline.Models;
using InternPipeline.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace InternPipeline.Repositories.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly InternPipelineContext _dbContext;

        public BlogRepository(InternPipelineContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BlogModel> CreateBlog(BlogModel blogModel)
        {
            try
            {
                var blogInstance = await _dbContext.BlogTable.AddAsync(blogModel);
                await _dbContext.SaveChangesAsync();
                return blogInstance.Entity;
            }
            catch (Exception ex)
            {
                // add logger ex
            }
            return null;
        }

        
    }
}
