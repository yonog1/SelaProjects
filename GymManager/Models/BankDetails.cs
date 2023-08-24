namespace GymManager.Models
{
    internal class BankDetails
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                //validate name
                name = value;
            }
        }

        private int branch;
        public int Branch
        {
            get { return branch; }
            set
            {
                branch = value;
            }
        }

        private int accountNumber;
        public int AccountNumber
        {
            get { return accountNumber; }
            set
            {
                accountNumber = value;
            }
        }



    }
}
