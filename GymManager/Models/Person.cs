namespace GymManager.Models
{
    internal class Person
    {
        private string id;

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }

        public bool IsActive { get; set; } = true;

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
            }
        }

        private char gender;

        public char Gender
        {
            get { return gender; }
            set
            {
                gender = value;
            }
        }

        private string birthDate;

        public string BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
            }
        }

        private string city;

        public string City
        {
            get { return city; }
            set
            {
                city = value;
            }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
            }
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
            }
        }


    }
}
