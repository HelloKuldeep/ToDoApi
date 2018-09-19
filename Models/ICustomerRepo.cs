using System.Collections.Generic;
namespace TodoApi.Models{
    public interface ICustomerRepo {
        List<Customer> GetAll();
        Customer GetCustomer(int id);
        bool PostCustomer(Customer cust);
        bool PutCustomer(int id, Customer cust);
        bool DeleteCustomer(int id);
    }
}