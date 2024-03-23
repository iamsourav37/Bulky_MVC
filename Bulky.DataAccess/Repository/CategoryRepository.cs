using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDBContext _dBContext;

        public CategoryRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            this._dBContext = dBContext;
        }
        public void Save()
        {
            _dBContext.SaveChanges();
        }

        public void Update(Category category)
        {
            _dBContext.Category.Update(category);
        }
    }
}
