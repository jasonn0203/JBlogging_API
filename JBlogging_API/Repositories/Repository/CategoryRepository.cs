using AutoMapper;
using JBlogging_API.DTOs.Category;
using JBlogging_API.Models;
using JBlogging_API.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace JBlogging_API.Repositories.Repository
{
    public class CategoryRepository : IGeneralRepository<CategoryDTO>
    {
        private readonly JbloggingContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(JbloggingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var categoryList = await _context.Categories.ToListAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoryList);
        }

        public async Task<CategoryDTO?> GetByIDAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task AddAsync(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(int id, CategoryDTO categoryDTO)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category != null)
            {
                _mapper.Map(categoryDTO, category);

                _context.Categories.Update(category);

                await _context.SaveChangesAsync();
            }

        }
        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category != null)
            {
                _context.Categories.Remove(category);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CategoryDTO?>?> GetByNameAsync(string name)
        {
            var categoriesByName = await _context.Categories.Where(c => c.CateName.Contains(name)).ToListAsync();
            if (categoriesByName != null)
            {
                return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesByName);
            }

            return null;

        }
    }
}
