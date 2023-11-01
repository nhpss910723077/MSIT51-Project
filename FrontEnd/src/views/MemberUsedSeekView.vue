<template>
    <TopBanner />
    <section>
        <BreadCrumb :data="breadCrumbData" />
    </section>

    <section id="app">
        <div class="container">
            <div class="row">
                <PageMenu :data="PageMenuData" />
                <div class="col-ms-12 col-lg-9">
                    <div class="memberContent">
                        <div class="Content">
                            <div class="title">二手書徵求</div>
                            <div class="passwordUpdate">
                                <label for="seekISBN">ISBN：</label>
                                <div class="NewPassword">
                                    <input type="text" id="seekISBN" placeholder="請輸入ISBN">
                                    <button type="submit" class="btn font-sm bg1btn" @click="BookSearch()">搜尋</button>
                                </div>

                                <label for="NewPassword">書名：</label>
                                <div class="NewPassword">
                                    <span>{{ updateData.Name }}</span>
                                </div>

                                <label for="seekPrice">徵求價格：</label>
                                <div class="PasswordConfirm">
                                    <input type="number" id="seekPrice" v-model="updateData.SeekPrice"
                                        placeholder="請輸入希望的徵求價格">
                                    <div class="dataUpdateSubmitBtn">
                                        <button class="btn bg2btn" @click="usedSeekBtn">送出
                                        </button>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>
</template>
  
<script>
import TopBanner from '@/components/shared/TopBanner.vue'
import BreadCrumb from '@/components/shared/BreadCrumb.vue'
import PageMenu from '@/components/shared/PageMenu.vue'

export default {
    name: 'MemberChangePasswordView',
    data() {
        return {
            MemberID: parseInt(sessionStorage.getItem('MemberID')),
            breadCrumbData: [
                { title: "首頁", link: "/" },
                { title: "會員中心", link: "/member/index" },
                { title: "二手書徵求", link: "" },
            ],
            PageMenuData: {
                menuName: "會員中心",
                menuLink: "/member/index",
                menuData: []
            },
            updateData: {
                ProductID: 0,
                Name: "",
                SeekPrice: 0,
            }
        }
    },
    methods: {
        BookSearch() {
            var self = this;
            var ISBN = document.querySelector("#seekISBN").value;
            if (ISBN == "") {
                Swal.fire({
                    title: "請輸入二手書的ISBN碼",
                    icon: "info",
                    timer: 1000,
                    showConfirmButton: false,
                })
                return
            }
            $.ajax({
                method: "GET",
                dataType: 'JSON',
                url: `${GetApiUrl()}/member/Step1BookSearch/${ISBN}`,
            }).done(function (data) {
                console.log(data);
                self.updateData.Name = data.Name;
                self.updateData.ProductID = data.ID;
            });
        },
        usedSeekBtn() {
            var self = this;

            if (self.updateData.ProductID == 0) {
                Swal.fire({
                    title: "請先搜尋書籍",
                    icon: "info",
                    timer: 1000,
                    showConfirmButton: false,
                });
                return;
            }

            if (self.updateData.ProductID <= 0) {
                Swal.fire({
                    title: "價格請勿為0",
                    icon: "info",
                    timer: 1000,
                    showConfirmButton: false,
                });
                return;
            }

            $.ajax({
                method: "POST",
                dataType: 'JSON',
                url: `${GetApiUrl()}/member/UsedSeek`,
                data: {
                    MemberID: sessionStorage.getItem("MemberID"),
                    ProductID: self.updateData.ProductID,
                    SeekPrice: self.updateData.SeekPrice,
                },
            })
                .done(function (data) {
                    Swal.fire({
                        title: data.title,
                        icon: data.result,
                        timer: 2000,
                        showConfirmButton: false,
                    }).then(function () {
                        document.location.href = "/member/usedSeek";
                    });

                    console.log(data);
                })
                .fail(function (data) {
                    alert("發生錯誤");
                });
        }
    },
    async mounted() {
        var self = this;

        // 取得資料
        try {
            $.ajax({
                method: "GET",
                dataType: 'JSON',
                url: `${GetApiUrl()}/member/MemberMenu`,
            }).done(function (data) {
                self.PageMenuData.menuData = data;
            });
        } catch (error) {
            console.log("發生錯誤");
        }

        var ISBN13fromProduct = checkGet("ISBN")
        if (ISBN13fromProduct == null) {
            return;
        } else {
            document.querySelector("#seekISBN").value = ISBN13fromProduct;
        }
    },
    components: {
        TopBanner,
        BreadCrumb,
        PageMenu,
    }
}
</script>
  
<style scoped src="./css/Member.css"></style>