using System.Collections.Generic;
using TestingSystem.DAL.UnitOfWork;
using TestingSystem.BLL.Dtos;
using TestingSystem.BLL.Mappers;

namespace TestingSystem.BLL.Services
{
    public class TestCategoryService
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        public TestCategoryService()
        {
            _unitOfWorkFactory = new UnitOfWorkFactory();
        }

        public TestCategoryService(UnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public EntityOperationResult<List<TestCategoryDto>> GetAllCategories()
        {
            List<TestCategoryDto> result = new List<TestCategoryDto>();
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var resultEntities = unitOfWork.TestCategory.GetAllTestCategories();
                result = resultEntities.ToDtoRange();
            }
            return EntityOperationResult<List<TestCategoryDto>>.Success(result);
        }
    }
}
