import api from './api'

export default {
  getAll(){
    return api.get('contacts');
  },
  get(id){
    return api.get('contacts/' + id);
  },
  create(contact){
    return api.post('contacts', contact);
  },
  update(contact){
    return api.put('contacts/' + contact.id, contact);
  },
  delete(id){
     return api.delete('contacts/' + id);
  }
}