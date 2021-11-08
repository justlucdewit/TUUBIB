<template>
  <a-layout id="app">
    <a-layout-sider class="sider-trigger" v-model="collapsed" collapsible>
      <img src="@/assets/logo.png" id="logo" :class="{ 'small': collapsed }" />

      <h2 class="name">
        TUU BIB
      </h2>

      <a-menu theme="dark" mode="inline" v-model="page">
         <a-menu-item key="1">
          <a-icon type="home" />
          <span>Home</span>
        </a-menu-item>

        <a-menu-item key="2">
          <a-icon type="book" />
          <span>Boeken</span>
        </a-menu-item>

        <a-menu-item key="3">
          <a-icon type="contacts" />
          <span>Contact</span>
        </a-menu-item>
      </a-menu>
    </a-layout-sider>
    
    <a-layout>
      <a-layout-header style="background: #fff; padding: 0">
        <b style="margin-left: 40px;">TUU Bibliotheek Systeem</b>
      </a-layout-header>

      <a-layout-content style="margin: 0 16px">
        <Home v-if="page[0] == '1'" />
        <Books v-if="page[0] == '2'" />
        <Contacts v-if="page[0] == '3'" />
      </a-layout-content>

      <a-layout-footer style="text-align: center">
        TUU BIB ©2021 Created by Luc de Wit
      </a-layout-footer>
    </a-layout>
  </a-layout>
</template>

<script>
import Home from "./Views/Home.vue";
import Books from "./Views/Books.vue";
import Contacts from "./Views/Contacts.vue";

export default {
  components: {
    Home,
    Books,
    Contacts
  },

  data() {
    return {
      collapsed: false,
      page: ['1']
    }
  }
};
</script>

<style lang="scss">
#logo {
  width: 100px;
  margin-left: 52px;
  margin-top: 20px;

  &.small {
    width: 35px;
    margin-bottom: 15px;
    margin-left: 23px;
  }
}

#app {
  min-height: 100vh;
}

.name {
  font-weight: bold;
  color: white;
  text-align: center;
  margin-bottom: 40px;

}


</style>