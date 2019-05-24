using Sample.App;
using System;
using System.ComponentModel.DataAnnotations;

namespace _14.SampleApp.MVVM.Part2.Customers.Helpers
{
    public class EditableCustomer: ValidateViewModelBase
    {
        private Guid id;
        public Guid Id
        {
            get
            {
                return id;
            }
            set
            {
                SetProperty(ref id, value);
            }
        }

        private string firstName;
        [Required]
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                SetProperty(ref firstName, value);
            }
        }

        private string lastName;
        [Required]
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                SetProperty(ref lastName, value);
            }
        }

        private string phone;
        [Phone]
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                SetProperty(ref phone, value);
            }
        }
    }
}
