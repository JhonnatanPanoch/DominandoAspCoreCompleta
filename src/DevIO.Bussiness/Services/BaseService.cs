using DevIO.Bussiness.Interfaces;
using DevIO.Bussiness.Models;
using DevIO.Bussiness.Notifications;
using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace DevIO.Bussiness.Services
{
    public abstract class BaseService
    {
        private readonly INotificator _notificator;

        protected BaseService(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected void Notificar(string msg)
        {
            _notificator.Handle(new Notification(msg));
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var item in validationResult.Errors)
            {
                Notificar(item.ErrorMessage);
            }
        }

        protected async Task<bool> RunValidation<TV, TE>(TV validation, TE entity)
            where TV : AbstractValidator<TE>
            where TE : Entity
        {
            var validator = await validation.ValidateAsync(entity);
            if (validator.IsValid)
            {
                return true;
            }
            else
            {
                Notificar(validator);
                return false;
            }
        }
    }
}