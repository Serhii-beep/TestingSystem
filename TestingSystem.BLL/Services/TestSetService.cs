using TestingSystem.BLL.Dtos;
using TestingSystem.BLL.Mappers;
using TestingSystem.DAL.UnitOfWork;
using TestingSystem.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System;

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

        public EntityOperationResult<bool> DeleteTestSet(int testSetId)
        {
            bool result = false;

            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {

                if(unitOfWork.TestSet.GetTestSetById(testSetId) == null)
                {
                    return EntityOperationResult<bool>.Failture("No test set with such Id");
                }
                
                unitOfWork.TestSet.DeleteTestSet(testSetId);

                try
                {
                    unitOfWork.SaveChanges();
                }
                catch(Exception ex)
                {
                    return EntityOperationResult<bool>.Failture("Can`t save changes to storage. Error msg: " + ex.Message);
                }
                result = true;
            }

            return EntityOperationResult<bool>.Success(result);
        }

        public EntityOperationResult<TestSetDto> AddTestSet(TestSetDto testSetDto)
        {
            var temp = testSetDto.ToModel();

            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                if (unitOfWork.TestLevel.GetTestLevelById(temp.TestLevelId) == null)
                {
                    return EntityOperationResult<TestSetDto>.Failture("No test level with such id");
                }
                if (unitOfWork.TestCategory.GetTestCategoryById(temp.TestCategoryId) == null)
                {
                    return EntityOperationResult<TestSetDto>.Failture("No category with such id");
                }
                
                unitOfWork.TestSet.AddTestSet(temp);

                try
                {
                    unitOfWork.SaveChanges();
                }
                catch (Exception ex)
                {
                    return EntityOperationResult<TestSetDto>.Failture("Can`t save changes to storage. Error msg: " + ex.Message);
                }
            }

            return EntityOperationResult<TestSetDto>.Success(temp.toDto());
        }

        public EntityOperationResult<TestSetDto> UpdateTestSet(int testSetId, TestSetDto testSetDto)
        {

            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                if(testSetId != testSetDto.Id)
                {
                    return EntityOperationResult<TestSetDto>.Failture("Ids do not match");
                }
                if(unitOfWork.TestSet.GetTestSetById(testSetId) == null)
                {
                    return EntityOperationResult<TestSetDto>.Failture("No test set with such id");
                }

                unitOfWork.TestSet.UpdateTestSet(testSetDto.ToModel());

                try
                {
                    unitOfWork.SaveChanges();
                }
                catch (Exception ex)
                {
                    return EntityOperationResult<TestSetDto>.Failture("Can`t save changes to storage. Error msg: " + ex.Message);
                }
            }

            return EntityOperationResult<TestSetDto>.Success(testSetDto);

        }
    }
}
