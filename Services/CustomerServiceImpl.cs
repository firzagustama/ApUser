using ApUser;
using Grpc.Core;
using corp.bi.go.id.ap.user.grpc;

namespace ApUser.Services
{
    public class CustomerServiceImpl : CustomerService.CustomerServiceBase
    {
        private readonly ILogger<GreeterService> _logger;

        private CustomerList _customerList;
        public CustomerServiceImpl(ILogger<GreeterService> logger)
        {
            _logger = logger;

            _customerList = new CustomerList();
            _customerList.Customers.Add(new Customer() { Id = "111", Email = "gilang.ramadhan@bi.go.id",Name = "Gilang Ramadhan",});
            _customerList.Customers.Add(new Customer() { Id = "112", Email = "firza.gustama@bi.go.id",Name = "Firza Gustama",});
            _customerList.Customers.Add(new Customer() { Id = "113", Email = "guna.wicaksana@bi.go.id",Name = "Guna Wicaksana",});
        }

        public override Task<CustomerList> getAll(Empty request, ServerCallContext context)
        {
            return Task.FromResult(_customerList);
        }

        public override Task<Customer> get(CustomerRequestId request, ServerCallContext context)
        {
            var customer = _customerList.Customers
                .Where(c => c.Id.Equals(request.Id, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault(new Customer());
            
            return Task.FromResult(customer);
        }
    }
}