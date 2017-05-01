using AccountingPlusDAL.Context;
using AccountingPlusDAL.Models;
using AccountingPlusDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingPlusDAL.Services
{
    public class PersonService
    {
        private AccountingPlusContext AccountingPlusContext = new AccountingPlusContext();
        private VendorRepository _VendorRepository;



        public VendorRepository VendorRepository
        {
            get
            {
                if (_VendorRepository == null)
                {
                    _VendorRepository = new VendorRepository(AccountingPlusContext);
                }
                return _VendorRepository;
            }
        }

        private CustomerRepository _CustomerRepository;



        public CustomerRepository CustomerRepository
        {
            get
            {
                if (_CustomerRepository == null)
                {
                    _CustomerRepository = new CustomerRepository(AccountingPlusContext);
                }
                return _CustomerRepository;
            }
        }


        public List<Vendor> GetVendors()
        {
            return this.VendorRepository.GetAll().ToList();
        }

        public List<Customer> GetCustomers()
        {
            return this.CustomerRepository.GetAll().ToList();
        }


        public Boolean InsertVendor(Vendor vendor)
        {
            try
            {
                VendorRepository.Add(vendor);
                return VendorRepository.Save();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean InsertCustomer(Customer customer)
        {
            try
            {
                CustomerRepository.Add(customer);
                return CustomerRepository.Save();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
