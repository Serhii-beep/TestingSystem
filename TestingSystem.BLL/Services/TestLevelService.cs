using TestingSystem.BLL.Dtos;
using TestingSystem.DAL.Models;
using TestingSystem.BLL.Mappers;
using TestingSystem.DAL.UnitOfWork;
using System.Collections.Generic;

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
    }
}
