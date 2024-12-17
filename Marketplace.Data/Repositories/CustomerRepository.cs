using Marketplace.Core.Entities;
using Marketplace.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Data.Repositories
{
    public class CustomerRepository(DataContext context) : Repository<Customer>(context), ICustomerRepository
    {
    }
}
