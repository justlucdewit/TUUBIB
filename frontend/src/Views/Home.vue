<template>
  <span>
    <br><br>

    <div :style="{ padding: '25px', background: '#fff', minHeight: '150px', background: 'url(\'/home-wallpaper.png\')' }">
        <h1 style="text-align: center;font-weight: bold;font-size: 40px;color: black;">TUU Bibliotheek</h1>
    </div>

    <div :style="{ padding: '25px', background: '#fff', minHeight: '360px' }">
        <h1 style="font-weight: bold;">Toegankelijker lezen voor jongeren</h1>
        <br><br>
        <a-row>
        <a-col :span="18">Lorem ipsum dolor sit, amet consectetur adipisicing elit. Facilis, ratione at praesentium atque consequuntur illo corporis voluptatum vitae dolore aperiam sequi enim temporibus ab! Quam magnam accusantium tempore nisi illo!</a-col>
        </a-row>

        <br><br>
        <a-row>
        <a-col :span="19">Lorem ipsum dolor sit, amet consectetur adipisicing elit. Facilis, ratione at praesentium atque consequuntur illo corporis voluptatum vitae dolore aperiam sequi enim temporibus ab! Quam magnam accusantium tempore nisi illo!</a-col>
        </a-row>

        <br><br>
        <a-button type="primary">
        <a-icon type="facebook" /> Follow
        </a-button>

        <a-button style="margin-left: 20px; background: red; border: red" type="primary">
        <a-icon type="youtube" /> Subscribe
        </a-button>

        <a-button style="margin-left: 20px; background: green; border: green" type="primary">
        <a-icon type="dollar" /> Donate
        </a-button>
    </div>

    <br><br>

    <div :style="{ padding: '25px', background: '#fff', minHeight: '360px' }">
        <h1 style="font-weight: bold;">Voordelen van lezen</h1>
        <br><br>
        <a-row>
        <a-col :span="18">Lorem ipsum dolor sit, amet consectetur adipisicing elit. Facilis, ratione at praesentium atque consequuntur illo corporis voluptatum vitae dolore aperiam sequi enim temporibus ab! Quam magnam accusantium tempore nisi illo!</a-col>
        <a-col :span="6"><img src="@/assets/brain.png" style="width: 100px; margin-left: 20px"></a-col>
        </a-row>

        <br><br><br>
        <a-row>
        <a-col :span="6"><img src="@/assets/graph.png" style="width: 100px; margin-right: 20px"></a-col>
        <a-col :span="18">Lorem ipsum dolor sit, amet consectetur adipisicing elit. Facilis, ratione at praesentium atque consequuntur illo corporis voluptatum vitae dolore aperiam sequi enim temporibus ab! Quam magnam accusantium tempore nisi illo!</a-col>
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