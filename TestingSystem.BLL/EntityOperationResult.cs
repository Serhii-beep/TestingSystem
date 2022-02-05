using System.Collections.Generic;

namespace TestingSystem.BLL
{
    public class EntityOperationResult<T>
    {
        public bool IsSuccess { get; private set; }
        public T Entity { get; }
        public List<string> Errors { get; private set; }

        private EntityOperationResult(T entity)
        {
            Entity = entity;
            Errors = new List<string>();
        }

        private EntityOperationResult()
        {
            Errors = new List<string>();
        }

        public static EntityOperationResult<T> Success(T entity)
        {
            var result = new EntityOperationResult<T>(entity);
            result.IsSuccess = true;
            return result;
        }

        public static EntityOperationResult<T> Failture()
        {
            var result = new EntityOperationResult<T>();
            result.IsSuccess = false;
            return result;
        }

        public static EntityOperationResult<T> Failture(params string[] errors)
        {
            var result = Failture();
            result.Errors.AddRange(errors);
            return result;
        }

        public void AddError(params string[] errors)
        {
            Errors.AddRange(errors);
        }
    }
}
