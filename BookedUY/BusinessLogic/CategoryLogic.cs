using DataAccessInterface;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class CategoryLogic
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryLogic(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
    }
}
