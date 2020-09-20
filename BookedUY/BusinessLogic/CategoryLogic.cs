using DataAccessInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class CategoryLogic
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryLogic(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
    }
}
