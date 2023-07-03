using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleRegistrationSystem.Models
{

    
    public class User
    {
        private int id;

        private string firstName;

        private string secondName;

        private string email;

        private string nationality;

        private string identificationNumber;

        private DateTime birthDate;

        private string educationLevel;

        private bool gender;

        private bool haveVehicleLicense;

        private string address;

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string SecondName { get => secondName; set => secondName = value; }
        public string Email { get => email; set => email = value; }
        public string Nationality { get => nationality; set => nationality = value; }
        public string IdentificationNumber { get => identificationNumber; set => identificationNumber = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string EducationLevel { get => educationLevel; set => educationLevel = value; }
        public bool Gender { get => gender; set => gender = value; }
        public bool HaveVehicleLicense { get => haveVehicleLicense; set => haveVehicleLicense = value; }
        public string Address { get => address; set => address = value; }







    }
}
