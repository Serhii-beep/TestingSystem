using TestingSystem.BLL.Dtos;
using TestingSystem.DAL.Models;
using TestingSystem.BLL.Mappers;
using TestingSystem.DAL.UnitOfWork;
using System.Collections.Generic;
using System;
using System.Linq;

namespace TestingSystem.BLL.Services
{
    public class TestLevelService
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        public TestLevelService()
        {
            _unitOfWorkFactory = new UnitOfWorkFactory();
        }

        public TestLevelService(UnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public EntityOperationResult<List<TestLevelDto>> GetAllTestLevels()
        {
            List<TestLevelDto> result = new List<TestLevelDto>();
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                result = unitOfWork.TestLevel.GetAllTestLevels().ToDtoRange();
            }
            return EntityOperationResult<List<TestLevelDto>>.Success(result);
        }

        public EntityOperationResult<TestLevelDto> GetLevelById(int id)
        {
            TestLevelDto result = new TestLevelDto();
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                result = unitOfWork.TestLevel.GetTestLevelById(id)?.toDto();
            }
            return result == null ? EntityOperationResult<TestLevelDto>.Failture("No test level with such Id") :
                EntityOperationResult<TestLevelDto>.Success(result);
        }

        public EntityOperationResult<bool> DeleteTestLevel(int testLevelId)
        {
            var result = false;
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                if(unitOfWork.TestLevel.GetTestLevelById(testLevelId) == null)
                {
                    return EntityOperationResult<bool>.Failture("No test level with such Id");
                }

                unitOfWork.TestLevel.DeleteTestLevel(testLevelId);

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

        public EntityOperationResult<TestLevelDto> AddTestLevel(TestLevelDto testLevelDto)
        {
            TestLevel temp = testLevelDto.ToModel();

            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                if(unitOfWork.TestLevel.GetAllTestLevels().FirstOrDefault(tl => tl.DifficultyLevel == temp.DifficultyLevel) != null)
                {
                    return EntityOperationResult<TestLevelDto>.Failture("Such test level already exists");
                }
                unitOfWork.TestLevel.AddTestLevel(temp);

                try
                {
                    unitOfWork.SaveChanges();
                }
                catch (Exception ex)
                {
                    return EntityOperationResult<TestLevelDto>.Failture("Can`t save changes to storage. Error msg: " + ex.Message);
                }
            }

            return EntityOperationResult<TestLevelDto>.Success(temp.toDto());
        }

        public EntityOperationResult<TestLevelDto> UpdateTestLevel(int testLevelId, TestLevelDto testLevelDto)
        {
            
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                if (testLevelId != testLevelDto.Id)
                {
                    return EntityOperationResult<TestLevelDto>.Failture("Ids do not match");
                }
                if (unitOfWork.TestLevel.GetTestLevelById(testLevelId) == null)
                {
                    return EntityOperationResult<TestLevelDto>.Failture("No test level with such id");
                }

                unitOfWork.TestLevel.UpdateTestLevel(testLevelDto.ToModel());

                try
                {
                    unitOfWork.SaveChanges();
                }
                catch (Exception ex)
                {
                    return EntityOperationResult<TestLevelDto>.Failture("Can`t save changes to storage. Error msg: " + ex.Message);
                }
            }

            return EntityOperationResult<TestLevelDto>.Success(testLevelDto);

        }
    }
}
