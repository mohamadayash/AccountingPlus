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
    public class AccountService
    {
        private AccountingPlusContext AccountingPlusContext = new AccountingPlusContext();
        private AccountRepository _AccountRepository;
        private ControlAccountRepository _ControlAccountRepository;
        TempControlAccountRepository _TempControlAccountRepository;


        public AccountRepository AccountRepository
        {
            get
            {
                if (_AccountRepository == null)
                {
                    _AccountRepository = new AccountRepository(AccountingPlusContext);
                }
                return _AccountRepository;
            }
        }

        public TempControlAccountRepository TempControlAccountRepository
        {
            get
            {
                if (_TempControlAccountRepository == null)
                {
                    _TempControlAccountRepository = new TempControlAccountRepository(AccountingPlusContext);
                }
                return _TempControlAccountRepository;
            }
        }

        public ControlAccountRepository ControlAccountRepository
        {
            get
            {
                if (_ControlAccountRepository == null)
                {
                    _ControlAccountRepository = new ControlAccountRepository(AccountingPlusContext);
                }
                return _ControlAccountRepository;
            }
        }


        public Boolean CreateAccount(Account account)
        {
            try
            {
                account.AccountRefId = Guid.NewGuid();
                AccountRepository.Add(account);
                return AccountRepository.Save();
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public Guid? CreateAccount(String AccountName,Guid ControlAccountRefId)
        {
            try
            {

                ControlAccount controlAccount = this.GetControlAccount(ControlAccountRefId);

                Account account = new Account();
                account.AccountRefId = Guid.NewGuid();
                account.AccountName = AccountName;
                account.ControlAccountRefId = ControlAccountRefId;

                string maxAccountNumber = GetMaxAccountNumber(ControlAccountRefId);

                if (maxAccountNumber == null){
                    account.AccountNumber  = controlAccount.ControlAccountNumber + "0001";
                }else{
                    account.AccountNumber = (int.Parse(GetMaxAccountNumber(ControlAccountRefId)) + 1).ToString();
                }

                
                AccountRepository.Add(account);
                if( AccountRepository.Save()){
                    return account.AccountRefId;
                }else{
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        

        public Boolean InsertControlAccount(ControlAccount controlAccount)
        {
            try
            {
                ControlAccountRepository.Add(controlAccount);
                return ControlAccountRepository.Save();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ControlAccount> GetControlAccounts()
        {
            try
            {
                return ControlAccountRepository.GetAll().OrderBy(ca=>ca.ControlAccountNumber).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ControlAccount GetControlAccount(Guid ControlAccountRefId)
        {
            try
            {
                return ControlAccountRepository.FindById(ControlAccountRefId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


          public List<TempControlAccount> GetTempControlAccounts()
        {
            try
            {
                return TempControlAccountRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public List<Account> GetAccounts(Guid controlAccountRefId)
        {
            try
            {
                return AccountRepository.FindBy(acc => acc.ControlAccount.ControlAccountRefId.Equals(controlAccountRefId)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public String GetMaxAccountNumber(Guid controlAccountRefId)
        {
            try
            {
                String str = AccountRepository.FindBy(acc => acc.ControlAccount.ControlAccountRefId.Equals(controlAccountRefId)).Max(ca=>ca.AccountNumber);
                return str;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public Boolean DeleteAccount(Guid accountRefId)
        {
            try
            {

                Account om = this.AccountRepository.FindBy(o => o.AccountRefId.Equals(accountRefId)).FirstOrDefault();
                this.AccountRepository.Delete(om);
                return this.AccountRepository.Save();
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public Boolean DeleteControlAccount(Guid controlAccountRefId)
        {
            try
            {

                ControlAccount controlaccount = this.ControlAccountRepository.FindBy(ca => ca.ControlAccountRefId.Equals(controlAccountRefId)).FirstOrDefault();
                this.ControlAccountRepository.Delete(controlaccount);
                return this.AccountRepository.Save();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
