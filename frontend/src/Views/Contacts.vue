<template>
  <span>
    <br><br>

    <div :style="{ padding: '25px', background: '#fff', minHeight: '360px' }">
        <h1 style="font-weight: bold;">Contact</h1>
        <a-row>
          <a-col :span="18">U kunt contact opnemen via de volgende platformen:</a-col>
        </a-row>

        <br><br>
        <a-row>
          <a-col :span="4"><a-icon type="phone" style="scale: 3;padding-left: 10px;" /></a-col>
          <a-col :span="20"><h2><a>06 12345678</a></h2></a-col>
        </a-row>

        <br><br>
        <a-row>
          <a-col :span="4"><a-icon type="mail" style="scale: 3;padding-left: 10px;" /></a-col>
          <a-col :span="20"><h2><a>tuu.bib@gmail.com</a></h2></a-col>
        </a-row>

        <br><br>
        <a-row>
          <a-col :span="4"><a-icon type="facebook" style="scale: 3;padding-left: 10px;" /></a-col>
          <a-col :span="20"><h2><a>tuubib</a></h2></a-col>
        </a-row>

        <br><br>
        <a-row>
          <a-col :span="4"><a-icon type="twitter" style="scale: 3;padding-left: 10px;" /></a-col>
          <a-col :span="20"><h2><a>@tuubib</a></h2></a-col>
        </a-row>
    </div>
  </span>
</template>

<script>
export default {

}
</script>

<style>

</style>