using ChainOfRespNight.DAL;
using ChainOfRespNight.Models;

namespace ChainOfRespNight.ChainofRespPattern
{
    public class ManagerAssistant : Employee
    {
        private readonly Context _context;
        public ManagerAssistant(Context context)
        {
            _context = context;
        }
        public override void ProcessRequest(CustomerViewModel customerViewModel)
        {
            if (customerViewModel.Amount <= 150000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = customerViewModel.Name;
                customerProcess.Amount = customerViewModel.Amount;
                customerProcess.EmployeeName = "Baki Emre Çetin";
                customerProcess.Description = "Talep edilen tutar şube müdür yardımcısı tarafından ödendi";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else if (NextAprrover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = customerViewModel.Name;
                customerProcess.Amount = customerViewModel.Amount;
                customerProcess.EmployeeName = "Baki Emre Çetin";
                customerProcess.Description = "Talep edilen tutar şube müdür yardımcısı tarafından ödenemedi, işlem şube müdürüne aktarıldı";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
                NextAprrover.ProcessRequest(customerViewModel);
            }
        }
    }
}
