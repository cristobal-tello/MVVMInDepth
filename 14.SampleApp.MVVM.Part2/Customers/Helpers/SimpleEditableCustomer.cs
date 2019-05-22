using Sample.App;
using System;

namespace _14.SampleApp.MVVM.Part2.Customers.Helpers
{
    public class SimpleEditableCustomer: ViewModelBase
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
