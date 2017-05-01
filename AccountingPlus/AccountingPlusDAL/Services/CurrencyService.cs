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
    public class CurrencyService
    {
        private AccountingPlusContext AccountingPlusContext = new AccountingPlusContext();
        private CurrencyRepository _CurrencyRepository;



        public CurrencyRepository CurrencyRepository
        {
            get
            {
                if (_CurrencyRepository == null)
                {
                    _CurrencyRepository = new CurrencyRepository(AccountingPlusContext);
                }
                return _CurrencyRepository;
            }
        }


        public List<Currency> GetCurrencies()
        {
            return this.CurrencyRepository.GetAll().ToList();
        }

        public Boolean InsertCurrency(Currency currency)
        {
            try
            {
                this.CurrencyRepository.Add(currency);
                return this.CurrencyRepository.Save();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
