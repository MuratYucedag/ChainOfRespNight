using ChainOfRespNight.Models;

namespace ChainOfRespNight.ChainofRespPattern
{
    public abstract class Employee
    {
        protected Employee NextAprrover;
        public void SetNextApprover(Employee employee)
        {
            this.NextAprrover = employee;
        }
        public abstract void ProcessRequest(CustomerViewModel customerViewModel);
    }
}