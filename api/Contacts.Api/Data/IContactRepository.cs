using System.Collections.Generic;

namespace Contacts.Api.Data
{
    public interface IContactRepository
    {
        void Delete(int id);
        Contact Get(int id);
        IEnumerable<Contact> GetAll();
        void Save(Contact contact);
    }
}