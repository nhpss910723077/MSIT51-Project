<template>
    <TopBanner />
    <section>
        <BreadCrumb :data="breadCrumbData" />
    </section>

    <section>
        <div class="container">
            <div class="row">
                <PageMenu :data="PageMenuData" />
                <div class="col-ms-12 col-lg-9 areaRight">
                    <!-- <div style="background-color:lightblue; height: 200px;"> -->


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
    name: 'MemberIndexView',
    data() {
        return {
            MemberID: parseInt(sessionStorage.getItem('MemberID')),
            breadCrumbData: [
                { title: "首頁", link: "/" },
                { title: "會員中心", link: "/member/index" },
                { title: "登出", link: "" },
            ],
            PageMenuData: {
                menuName: "會員中心",
                menuLink: "/member/index",
                menuData: []
            },

            IndexData: {
                lineBind: true,
            },
            MenuList: [],
        }
    },
    methods: {

    },
    async created() {
        var self = this;
        // 取得資料
        try {
            await $.ajax({
                method: "GET",
                dataType: 'JSON',
                url: `${GetApiUrl()}/member/IndexData/${self.MemberID}`,
            }).done(function (data) {
                self.IndexData = data;
                console.log(self.IndexData);
                console.log(self.IndexData.orderCount);
                self.IndexData.lineBind = true;
            });
        } catch (error) {
            console.log("發生錯誤");
        }

        // 取得資料
        try {
            await $.ajax({
                method: "GET",
                dataType: 'JSON',
                url: `${GetApiUrl()}/member/MemberMenu`,
            }).done(function (data) {
                self.PageMenuData.menuData = data;
                console.log(self.PageMenuData);
                Swal.fire({
                    title: "確定要登出嗎？",
                    icon: "info",
                    showConfirmButton: true,
                    showCancelButton: true,
                }).then((result) => {
                    if (result.isConfirmed) {
                        window.location.href = '/';
                        sessionStorage.clear();
                    } else if (result.isDismissed) {
                        window.history.back();
                    }
                });
            });
        } catch (error) {
            console.log("發生錯誤");
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