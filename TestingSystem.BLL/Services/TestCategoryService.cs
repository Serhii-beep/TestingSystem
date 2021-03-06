using System.Collections.Generic;
using TestingSystem.DAL.UnitOfWork;
using TestingSystem.BLL.Dtos;
using TestingSystem.BLL.Mappers;
using TestingSystem.DAL.Models;
using System;
using System.Linq;

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

        public EntityOperationResult<TestCategoryDto> GetCategoryById(int id)
        {
            TestCategoryDto result = new TestCategoryDto();
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                result = unitOfWork.TestCategory.GetTestCategoryById(id)?.toDto();
            }
            return result == null ? EntityOperationResult<TestCategoryDto>.Failture("No test category with such Id") :
                EntityOperationResult<TestCategoryDto>.Success(result);
        }

        public EntityOperationResult<bool> DeleteCategory(int testCategoryId)
        {
            bool result = false;
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                if(unitOfWork.TestCategory.GetTestCategoryById(testCategoryId) == null)
                {
                    return EntityOperationResult<bool>.Failture("No category with such id");
                }

                unitOfWork.TestCategory.DeleteTestCategory(testCategoryId);

                try
                {
                    unitOfWork.SaveChanges();
                }
                catch (Exception ex)
                {
                    return EntityOperationResult<bool>.Failture("Can`t save changes to storage. Error msg: " + ex.Message);
                }
                result = true;
            }

            return EntityOperationResult<bool>.Success(result);
        }

        public EntityOperationResult<TestCategoryDto> AddCategory(TestCategoryDto testCategoryDto)
        {
            TestCategory temp = testCategoryDto.ToModel();

            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                if(unitOfWork.TestCategory.GetAllTestCategories().FirstOrDefault(c => c.Name == temp.Name) != null)
                {
                    return EntityOperationResult<TestCategoryDto>.Failture("Category with such name already exists");
                }
                unitOfWork.TestCategory.AddTestCategory(temp);

                try
                {
                    unitOfWork.SaveChanges();
                }
                catch (Exception ex)
                {
                    return EntityOperationResult<TestCategoryDto>.Failture("Can`t save changes to storage. Error msg: " + ex.Message);
                }
            }

            return EntityOperationResult<TestCategoryDto>.Success(temp.toDto());
        }

        public EntityOperationResult<TestCategoryDto> UpdateCategory(int testCategoryId, TestCategoryDto testCategoryDto)
        {
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                if(testCategoryId != testCategoryDto.Id)
                {
                    return EntityOperationResult<TestCategoryDto>.Failture("Ids do not match");
                }
                if(unitOfWork.TestCategory.GetTestCategoryById(testCategoryId) == null)
                {
                    return EntityOperationResult<TestCategoryDto>.Failture("No test category with such id");
                }

                unitOfWork.TestCategory.UpdateTestCategory(testCategoryDto.ToModel());

                try
                {
                    unitOfWork.SaveChanges();
                }
                catch (Exception ex)
                {
                    return EntityOperationResult<TestCategoryDto>.Failture("Can`t save changes to storage. Error msg: " + ex.Message);
                }
            }

            return EntityOperationResult<TestCategoryDto>.Success(testCategoryDto);
        }
    }
}
