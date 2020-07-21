using ExemploNotifications.Domain.Services.Abstraction;
using Marraia.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExemploNotifications.Domain.Services
{
    public class StudentDomainService : IStudentDomainService
    {
        private readonly ISmartNotification _notification;
        public StudentDomainService(ISmartNotification notification)
        {
            _notification = notification;
        }

        public Student Insert(Student input)
        {
            if (input.Age <= 0)
                _notification.NewNotificationBadRequest("Campo idade é obrigatório");

            if (string.IsNullOrEmpty(input.Nome))
                _notification.NewNotificationBadRequest("Campo nome é obrigatório");

            if (!_notification.IsValid())
            {
                return default;
            }


            return input;
        }
    }
}
