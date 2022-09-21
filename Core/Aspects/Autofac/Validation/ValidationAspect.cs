using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception///aspect metodun baş,son vb.. gibi yerlerde hata verince çalışan yapı
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)//atribute lduğu için type
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("AspectMessages.WrongValidationType");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//newleme luşturma reflection kodu
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//sınıfın type ını bbul, tipini yakala
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//parametrelerini bul, invocation metod demek
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
