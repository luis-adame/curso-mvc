using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto
{
    public class ProviderRegistryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }
        
        public void ValidateId()
        {
            if (Id <= 0)
                throw new Exception("'Id' must be higher than 0.");
        }

        public void ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
                throw new ArgumentNullException("'Name' must not be empty.");
        }

        public void ValidateAddress()
        {
            if (string.IsNullOrEmpty(Address))
                throw new ArgumentNullException("'Address' must not be empty.");
        }

        public void ValidatePhoneNumber()
        {
            if (string.IsNullOrEmpty(PhoneNumber))
                throw new ArgumentNullException("'PhoneNumber' must not be empty.");
        }

        public void ValidateEmailAddress()
        {
            if (string.IsNullOrEmpty(EmailAddress))
                throw new ArgumentNullException("'EmailAddress' must not be empty.");

            try
            {
                var email = new System.Net.Mail.MailAddress(EmailAddress);
            }
            catch (FormatException)
            {
                throw new ArgumentNullException("El correo es invalido");
            }
        }

        public void ValidateCity()
        {
            if (string.IsNullOrEmpty(City))
                throw new ArgumentNullException("'City' must not be empty.");
        }
    }
}
