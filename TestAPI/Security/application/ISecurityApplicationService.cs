using Customer.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.application
{
    public interface ISecurityApplicationService
    {
        CustomerDto login(CustomerDto customerDto);
    }
}
