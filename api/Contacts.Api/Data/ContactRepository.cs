using Marten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Api.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDocumentStore _documentStore;
        public ContactRepository(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }
        public IEnumerable<Contact> GetAll()
        {
            using (var session = _documentStore.LightweightSession())
            {
                return session.Query<Contact>().ToList();
            }
        }
        public Contact Get(int id)
        {
            using (var session = _documentStore.LightweightSession())
            {
                return session.Load<Contact>(id);
            }
        }
        public void Save(Contact contact)
        {
            using (var session = _documentStore.LightweightSession())
            {
                session.Store(contact);
                session.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var session = _documentStore.LightweightSession())
            {
                session.Delete<Contact>(id);
                session.SaveChanges();
            }

        }
    }
}
