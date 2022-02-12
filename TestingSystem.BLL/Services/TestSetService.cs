using TestingSystem.BLL.Dtos;
using TestingSystem.BLL.Mappers;
using TestingSystem.DAL.UnitOfWork;
using TestingSystem.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace TestingSystem.BLL.Services
{
    public class TestSetService
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        public TestSetService()
        {
            _unitOfWorkFactory = new UnitOfWorkFactory();
        }

        public TestSetService(UnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public EntityOperationResult<List<TestSetDto>> GetAllTestSets()
        {
            List<TestSetDto> result = new List<TestSetDto>();
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                result = unitOfWork.TestSet.GetAllTestSets().ToDtoRange();
            }
            return EntityOperationResult<List<TestSetDto>>.Success(result);
        }

        public EntityOperationResult<List<TestSetDto>> GetTestSetsByCategory(int categoryId)
        {
            List<TestSetDto> result = new List<TestSetDto>();
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                if(unitOfWork.TestCategory.GetTestCategoryById(categoryId) == null)
                {
                    return EntityOperationResult<List<TestSetDto>>.Failture("No test category with such Id");
                }
                result = unitOfWork.TestSet.GetAllTestSets().Where(ts => ts.TestCategoryId == categoryId).ToDtoRange();
            }
            return EntityOperationResult<List<TestSetDto>>.Success(result);
        }

        public EntityOperationResult<List<TestSetDto>> GetTestSetsByLevel(int levelId)
        {
            List<TestSetDto> result = new List<TestSetDto>();
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                if(unitOfWork.TestLevel.GetTestLevelById(levelId) == null)
                {
                    return EntityOperationResult<List<TestSetDto>>.Failture("No test level with such Id");
                }
                result = unitOfWork.TestSet.GetAllTestSets().Where(ts => ts.TestLevelId == levelId).ToDtoRange();
            }
            return EntityOperationResult<List<TestSetDto>>.Success(result);
        }

        public EntityOperationResult<List<TestSetDto>> GetTestsByLevelCategory(int levelId, int categoryId)
        {
            List<TestSetDto> result = new List<TestSetDto>();
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                if (unitOfWork.TestLevel.GetTestLevelById(levelId) == null)
                {
                    return EntityOperationResult<List<TestSetDto>>.Failture("No test level with such Id");
                }
                if (unitOfWork.TestCategory.GetTestCategoryById(categoryId) == null)
                {
                    return EntityOperationResult<List<TestSetDto>>.Failture("No test category with such Id");
                }
                result = unitOfWork.TestSet.GetAllTestSets().Where(ts => ts.TestLevelId == levelId && ts.TestCategoryId == categoryId).ToDtoRange();
            }
            return EntityOperationResult<List<TestSetDto>>.Success(result);
        }
    }
}
