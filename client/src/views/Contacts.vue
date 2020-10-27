<template>
  <v-layout>
    <v-flex xs12 sm6 offset-sm3>
      <h1>Contacts</h1>
      <table>
        <thead>
          <tr>
            <th>First name</th>
            <th>Last name</th>
            <th>Mobile</th>
            <th>Email</th>
            <th colspan="2"></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(contact, index) in contacts" :key="'row'+contact.id">
            <td>{{ contact.firstName }}</td>
            <td>{{ contact.lastName }}</td>
            <td>{{ contact.mobile }}</td>
            <td>{{ contact.email }}</td>
            <td>
              <router-link :to="{ name: 'contact-details', params: { id: contact.id}}">Edit</router-link>
            </td>
            <td><v-btn flat color="red" @click="deleteContact(index)">Delete</v-btn></td>
          </tr>
        </tbody>
      </table>
      <router-link :to="{ name: 'contact-details'}">Create new</router-link>
    </v-flex>
  </v-layout>
</template>

<script>
  import contactApi from '../contactApi'
  export default {
    data(){
      return {
        contacts: []
      }
    },
    methods:{
      deleteContact(index){
        contactApi.delete(this.contacts[index].id).then(response => {
          this.contacts.splice(index, 1);
        });
      }
    },
    created(){
      contactApi.getAll().then(response => {
        this.contacts = response.data;
      });
    }
  }
</script>
