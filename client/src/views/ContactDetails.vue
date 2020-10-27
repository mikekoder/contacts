<template>
  <v-layout>
    <v-flex xs12 sm6 offset-sm3>
      <v-card>
        <v-card-title primary-title>
          <div>
            <h3 class="headline mb-0">Edit contact</h3>
            <div>
              <v-text-field label="First name" v-model="firstName"></v-text-field>
              <v-text-field label="Last name" v-model="lastName"></v-text-field>
              <v-text-field label="Mobile" v-model="mobile"></v-text-field>
              <v-text-field label="Email" v-model="email"></v-text-field>
            </div>
          </div>
        </v-card-title>

        <v-card-actions>
          <router-link :to="{ name: 'contacts' }">Cancel</router-link>
          <v-btn flat color="blue" @click="save">Save</v-btn>
        </v-card-actions>
      </v-card>
    </v-flex>
  </v-layout>
</template>
<script>
import contactApi from '../contactApi'
export default {
  data(){
    return {
      id: 0,
      firstName: '',
      lastName: '',
      mobile: '',
      email: ''
    }
  },
  methods:{
    save(){
      let data = {
        firstName: this.firstName,
        lastName: this.lastName,
        mobile: this.mobile,
        email: this.email
      };

      if(this.id > 0){
        data.id = this.id;
        contactApi.update(data).then(response => {
          this.$router.replace({ name: 'contacts'});
        });
      }
      else {
        contactApi.create(data).then(response => {
          this.$router.replace({ name: 'contacts'});
        });
      }
    }
  },
  created(){
    const id = this.$route.params.id;
    if(id > 0){
      contactApi.get(id).then(response => {
        const data = response.data;
        this.id = data.id;
        this.firstName = data.firstName;
        this.lastName = data.lastName;
        this.mobile = data.mobile;
        this.email = data.email;
      });
    }
  }
}
</script>