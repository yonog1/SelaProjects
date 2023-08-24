namespace GymManager.Models
{
    internal class Coach : Person
    {
        public BankDetails bankDetails { get; set; }

        private string profession;

        public string Profession
        {
            get { return profession; }
            set
            {
                profession = value;
            }
        }


    }
}
