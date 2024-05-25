using Domain.Interfaces.BLInterfaces;
using Domain.Interfaces.DLInterfaces;
using System.Reflection;
using Domain.Attributes;
using Domain.Entities;
using Domain.Resource;

namespace BL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        protected IBaseDL<T> baseDL;
        protected IUnitOfWork unitOfWork;
        protected readonly Type type = typeof(T);
        protected readonly List<string> messages = new();

        public BaseBL(IBaseDL<T> iBaseDL, IUnitOfWork iUnitOfWork)
        {
            baseDL = iBaseDL;
            unitOfWork = iUnitOfWork;
        }
        public async Task<int> Insert(T t)
        {
            Validate(t);
            if (messages.Count > 0)
            {
                throw new ValidateException(CommonResource.ValidateMessage, messages);
            }
            var res = await baseDL.Insert(t);
            return res;
        }

        public async Task<int> Update(T t)
        {
            Validate(t);
            if (messages.Count > 0)
            {
                throw new ValidateException(CommonResource.ValidateMessage, messages);
            }
            var res = await baseDL.Update(t);
            return res;
        }

        protected virtual void Validate(T t)
        {
            CheckRequiredField(t);
            CustomValidate(t);
        }

        protected virtual void CustomValidate(T t){}
        
        private void CheckRequiredField(T t)
        {
            PropertyInfo[] properties = type.GetProperties();

            var propsNotEmpties = properties.Where(prop => Attribute.IsDefined(prop, typeof(NotEmpty)));
            foreach (var prop in propsNotEmpties)
            {
                NotEmpty? notEmptyAttribute = prop.GetCustomAttribute(typeof(NotEmpty)) as NotEmpty;

                var propValue = prop.GetValue(t);
                if (propValue == null || string.IsNullOrEmpty(propValue.ToString()))
                {
                    string message = notEmptyAttribute != null ? $"{notEmptyAttribute.Message}" : string.Format(CommonResource.NotEmptyMessage, prop.Name);
                    messages.Add(message);
                }
            }
        }
    }
}
