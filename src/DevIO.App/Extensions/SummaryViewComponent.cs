using DevIO.Bussiness.Interfaces;
using DevIO.Bussiness.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.App.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotificator _notificator;

        public SummaryViewComponent(INotificator notificator)
        {
            _notificator = notificator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Notification> notification = await Task.FromResult(_notificator.GetNotifications());

            notification.ForEach(x => ViewData.ModelState.AddModelError(string.Empty, x.Message));

            return View();
        }
    }
}
