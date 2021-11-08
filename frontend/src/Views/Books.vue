<template>
  <span>
    <br><br>

    <div :style="{ padding: '25px', background: '#fff' }">
      <h1 style="font-weight: bold;">Boeken</h1>

      <a-row>
        <a-col :span="4">Zoeken:</a-col>
        <a-col :span="20"><a-input v-model="bookSearchQuery"><a-icon slot="prefix" type="search" /></a-input></a-col>
      </a-row>

      <br><br><br>

      <a-button @click="addBookPopup = true">Toevoegen</a-button>

      <br /><br />
      
      <a-table :columns="columns" :data-source="filteredBooks" :customRow="customRow">
        <span slot="tags" slot-scope="tags">
          <a-tag v-for="tag in splitTags(tags)" color="blue">{{ tag }}</a-tag>
        </span>
      </a-table>

      <a-modal v-model="addBookPopup">
        <a-row>
          <a-col :span="10">
            Boek cover:

            <a-upload :file-list="fileList" :before-upload="beforeUpload">
              <template v-if="addBook.coverBase64 === ''">
                <a-button><a-icon type="upload" />Upload cover</a-button>
              </template>
              <template v-else>
                <img style="width: 200px" :src="addBook.coverBase64" alt="">
              </template>
            </a-upload>
          </a-col>
          
          <a-col :span="12">
            <a-row style="margin-left: 20px;">
              <a-col :span="8">Titel</a-col>
              <a-col :span="16"><a-input v-model="addBook.title"></a-input></a-col>
            </a-row>

            <br>

            <a-row style="margin-left: 20px;">
              <a-col :span="8">Auteur</a-col>
              <a-col :span="16"><a-input v-model="addBook.author"></a-input></a-col>
            </a-row>

            <br>

            <a-row style="margin-left: 20px;">
              <a-col :span="8">Paginas</a-col>
              <a-col :span="16"><a-input v-model="addBook.pages" type="number"></a-input></a-col>
            </a-row>

            <br>

            <a-row style="margin-left: 20px;">
              <a-col :span="8">Genres</a-col>
              <a-col :span="16"><a-input v-model="addBook.tags"></a-input></a-col>
            </a-row>
          </a-col>
        </a-row>

        <template #footer>
          <a-button key="back" @click="addBookPopup = false">
            Annuleren
          </a-button>
          <a-button key="submit" type="primary" @click="uploadNewBook">
            Toevoegen
          </a-button>
        </template>
      </a-modal>

      <a-modal v-model="showDetails">
        <a-row>
          <a-col :span="10"><img :src="detailRecord.coverBase64" style="width: 100%;" /></a-col>
          <a-col :span="12">
            <a-row style="margin-left: 20px;">
              <a-col :span="8">Titel</a-col>
              <a-col :span="16">{{ detailRecord.title }}</a-col>
            </a-row>

            <br>

            <a-row style="margin-left: 20px;">
              <a-col :span="8">Auteur</a-col>
              <a-col :span="16">{{ detailRecord.author }}</a-col>
            </a-row>

            <br>

            <a-row style="margin-left: 20px;">
              <a-col :span="8">Paginas</a-col>
              <a-col :span="16">{{ detailRecord.pages }}</a-col>
            </a-row>

            <br>

            <a-row style="margin-left: 20px;">
              <a-col :span="8">Genres</a-col>
              <a-col :span="16">
                <a-tag v-for="tag in splitTags(detailRecord.tags)" color="blue">{{ tag }}</a-tag>
              </a-col>
            </a-row>
          </a-col>
        </a-row>

        <template #footer>
          <a-button key="back" type="primary" @click="showDetails = false;editBookPopup=true;editBook=detailRecord">
            Wijzigen
          </a-button>
          <a-button key="back" type="danger" @click="deleteBook(detailRecord);showDetails = false">
            Verwijderen
          </a-button>
          <a-button key="back" @click="showDetails = false">
            Sluiten
          </a-button>
        </template>
      </a-modal>

      <a-modal v-model="editBookPopup">
        <a-row>
          <a-col :span="10">
            Boek cover:

            <a-upload :file-list="fileList" :before-upload="beforeEdit">
              <template v-if="editBook.coverBase64 === ''">
                <a-button><a-icon type="upload" />Upload cover</a-button>
              </template>
              <template v-else>
                <img style="width: 200px" :src="editBook.coverBase64" alt="">
              </template>
            </a-upload>
          </a-col>
          
          <a-col :span="12">
            <a-row style="margin-left: 20px;">
              <a-col :span="8">Titel</a-col>
              <a-col :span="16"><a-input v-model="editBook.title"></a-input></a-col>
            </a-row>

            <br>

            <a-row style="margin-left: 20px;">
              <a-col :span="8">Auteur</a-col>
              <a-col :span="16"><a-input v-model="editBook.author"></a-input></a-col>
            </a-row>

            <br>

            <a-row style="margin-left: 20px;">
              <a-col :span="8">Paginas</a-col>
              <a-col :span="16"><a-input v-model="editBook.pages" type="number"></a-input></a-col>
            </a-row>

            <br>

            <a-row style="margin-left: 20px;">
              <a-col :span="8">Genres</a-col>
              <a-col :span="16"><a-input v-model="editBook.tags"></a-input></a-col>
            </a-row>
          </a-col>
        </a-row>

        <template #footer>
          <a-button key="back" @click="editBookPopup = false">
            Annuleren
          </a-button>
          <a-button key="submit" type="primary" @click="editBookInDb(editBook);editBookPopup = false">
            Wijzigen
          </a-button>
        </template>
      </a-modal>
    </div>
  </span>
</template>

<script>
import axios, { Axios } from "axios"

const apiBaseUrl = "https://localhost:5001";

export default {
  computed: {
    filteredBooks() {
      return this.books.filter(book => {
        return this.bookSearchQuery === '' ||
        book.title.toLowerCase().includes(this.bookSearchQuery.toLowerCase()) ||
        book.author.toLowerCase().includes(this.bookSearchQuery.toLowerCase()) ||
        book.tags.toLowerCase().includes(this.bookSearchQuery.toLowerCase())
      })
    }
  },

  methods: {
    async editBookInDb(book) {
      await axios.patch(`${apiBaseUrl}/books`, {
        title: book.title,
        pageCount: book.pages,
        authorName: book.author,
        genres: book.tags,
        coverBase64: book.coverBase64,
        id: book.id
      });

      await this.reloadBooks();
    },

    async deleteBook(book) {
      await axios.delete(`${apiBaseUrl}/books/${book.id}`);

      await this.reloadBooks();
    },

    async reloadBooks() {
      this.books = [];

      this.$nextTick(async () => {
        var data = (await axios.get(`${apiBaseUrl}/books`)).data;
    
        let i = 0;

        data = data.map(book => {
          const item = {};

          item.title = book.title;
          item.author = book.authorName;
          item.pages = book.pageCount;
          item.tags = book.genres;
          item.key = i++;
          item.coverBase64 = book.coverBase64;
          item.id = book.id;

          return item;
        });

        this.books = data;
      });
    },

    getBase64(file) {
      var reader = new FileReader();
      reader.readAsDataURL(file);

      reader.onload = () => {
        this.addBook.coverBase64 = reader.result;
        console.log(reader.result)
      };
    },

    getBase64ForEdit(file) {
      var reader = new FileReader();
      reader.readAsDataURL(file);

      reader.onload = () => {
        this.editBook.coverBase64 = reader.result;
        console.log(reader.result)
      };
    },

    beforeUpload(a) {
      this.getBase64(a)
    },

    beforeEdit(a) {
      this.getBase64ForEdit(a)
    },

    async uploadNewBook() {
      this.addBook.pages = Number(this.addBook.pages)
      console.log(this.addBook)

      await axios.post(`${apiBaseUrl}/books`, {
        title: this.addBook.title,
        pageCount: this.addBook.pages,
        authorName: this.addBook.author,
        genres: this.addBook.tags,
        coverBase64: this.addBook.coverBase64
      });

      this.addBook = {
        author: "",
        pages: 0,
        tags: "",
        title: "",
        coverBase64: ""
      };

      this.addBookPopup = false;

      await this.reloadBooks();
    },

    splitTags(list) {
      if (!list)
        return list;
      
      return list.split(',')
    },

    clickedRow(record) {
      this.showDetails = true;
      this.detailRecord = record;
    },

    customRow(record) {
      return {
        on: {
          click: (event) => {this.clickedRow(record);}
        }
      };
    }
  },

  mounted() {
    this.reloadBooks();  
  },

  data() {
    return {
      showDetails: false,
      detailRecord: {},
      addBookPopup: false,
      fileList: [],
      bookSearchQuery: "",
      addBook: {
        author: "",
        pages: 0,
        tags: "",
        title: "",
        coverBase64: ""
      },
      editBookPopup: false,
      editBook: {
        author: "",
        pages: 0,
        tags: "",
        title: "",
        coverBase64: ""
      },

      columns: [
        {
          title: 'Titel',
          dataIndex: 'title',
        },
        {
          title: 'Auteur',
          dataIndex: 'author',
        },
        {
          title: 'Paginas',
          dataIndex: 'pages',
        },
        {
          title: 'Genres',
          dataIndex: 'tags',
          key: 'tags',
          scopedSlots: { customRender: 'tags' }
        }
      ],

      books: []
    };
  }
};
</script>

<style>

</style>