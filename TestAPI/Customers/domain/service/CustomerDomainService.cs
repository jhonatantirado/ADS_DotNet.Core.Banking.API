
namespace Customers.Domain.Service
{
    using Common.Application;
    using Customer.Domain.Entity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class CustomerDomainService
    {
        public void validExistCustomer(Customer customer)
        {
            try
            {
                Notification notification = new Notification();
                if (customer == null)
                {
                    notification.addError("Customer doesn't exist.");
                    throw new ArgumentException(notification.errorMessage());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void validDoesntExistDocumentNumber(Customer customer)
        {
            try
            {
                Notification notification = new Notification();
                if (customer != null)
                {
                    notification.addError("Document Number already register.");
                    throw new ArgumentException(notification.errorMessage());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void validDoesntExistUserCustomer(Customer customer)
        {
            try
            {
                Notification notification = new Notification();
                if (customer != null)
                {
                    notification.addError("User Customer already register.");
                    throw new ArgumentException(notification.errorMessage());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void validExistCustomerLogged(Customer customer)
        {
            try
            {
                Notification notification = new Notification();
                if (customer == null)
                {
                    notification.addError("User Customer doesn't logged");
                    throw new ArgumentException(notification.errorMessage());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
