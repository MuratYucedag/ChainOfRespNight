using ChainOfRespNight.DAL;
using ChainOfRespNight.Models;

namespace ChainOfRespNight.ChainofRespPattern
{
    public class Treasurer : Employee
    {
        private readonly Context _context;
        public Treasurer(Context context)
        {
            _context = context;
        }
        public override void ProcessRequest(CustomerViewModel customerViewModel)
        {
            if (customerViewModel.Amount <= 80000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name= customerViewModel.Name;
                customerProcess.Amount= customerViewModel.Amount;
                customerProcess.EmployeeName = "Emin Yılmaz";
                customerProcess.Description = "Talep edilen tutar veznedar tarafından ödendi";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else if (NextAprrover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = customerViewModel.Name;
                customerProcess.Amount= customerViewModel.Amount;
                customerProcess.EmployeeName = "Emin Yılmaz";
                customerProcess.Description = "Talep edilen tutar veznedar tarafından ödenemedi, işlem şube müdür yardımcısına aktarıldı";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
                NextAprrover.ProcessRequest(customerViewModel);
            }
        }
    }
}
