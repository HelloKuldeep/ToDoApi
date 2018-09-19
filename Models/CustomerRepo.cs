using System.Collections.Generic;
using System.Linq;
namespace TodoApi.Models{
    public class CustomerRepo : ICustomerRepo {   
        static List<Customer> customers = new List<Customer>(){
            new Customer{ Id = 101, Name = "Rakesh"},
            new Customer{ Id = 102, Name = "Deepak"}
        };
        public List<Customer> GetAll(){
            return customers;
        }
        public Customer GetCustomer(int id){
            return customers.FirstOrDefault( cust => cust.Id == id );
        }

        public bool PostCustomer(Customer cust){
            if(customers.Find( c => c.Id == cust.Id ) == null){
                customers.Add(cust);
                return true;                
            }
            return false;
        }
        public bool PutCustomer(int id, Customer cust){
            Customer temp = customers.Find( c => c.Id == id );
            if(temp != null){
                customers.Remove(temp);
                customers.Add(cust);
                return true;                
            }
            return false;
        }
        public bool DeleteCustomer(int id){
            Customer temp = customers.Find( c => c.Id == id );
            if(temp != null){
                customers.Remove(temp);
                return true;                
            }
            return false;
        }
    }
}