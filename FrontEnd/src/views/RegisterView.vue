<template>
  <section class="bgcolor">
    <BreadCrumb :data="breadCrumbData" />
  </section>

  <section id="app2" class="bgcolor">
    <img class="Registerbg1" :src="`/images/tree-bg1.png`">
    <img class="Registerbg2" :src="`/images/tree-bg2.png`">
    <div class="container goup">
      <div class="row">
        <div class="col-sm-1 col-md-2"></div>



        <div class="col-sm-10 col-md-8">
          <div class="mytitle">
            <div>—</div>
            <div>歡迎加入ReadUse會員</div>
            <div>—</div>
          </div>

          <div class="row">
            <div class="col-3"> <label for="email">電子郵件:</label></div>
            <div class="col-9"> <input id="email" type="email" pattern="\w+([\.\-]\w+)*@\w+([\.\-]\w+)+" required></div>
            <div class="col-3"> <label for="password">密碼:</label></div>
            <div class="col-9" id="kk"> <input @focus="showHelp" @blur="hideHelp" id="password" type="password"
                pattern="(?=.*\d)(?=.*[a-zA-Z])[0-9a-zA-Z]{8,}" required></div>

            <div class="col-12 dflex">
              <div class="passwordHelp Help1">&nbsp; </div>
              <div class="passwordHelp Help2">
                &nbsp;&nbsp;密碼必須包含至少一個數字、一個英文字母，且長度至少8碼。</div>
            </div>

            <div class="col-3"> <label for="againpassword">再次輸入密碼:</label></div>
            <div class="col-9"> <input id="againpassword" type="password" pattern="(?=.*\d)(?=.*[a-zA-Z])[0-9a-zA-Z]{8,}"
                required></div>
            <div class="col-3"> <label for="username">姓名:</label></div>
            <div class="col-9"> <input id="username" type="text" required></div>
            <div class="col-3"> <label for="cellphone" pattern="09\d{8}">手機:</label></div>
            <div class="col-9"> <input id="cellphone" type="text" required></div>
          </div>
          <br>
          <div class="row" id="switch">
            <div class="col-lg-12 col-xl-7 DivC">

              <div class="dflex">
                <div class="checkboxDiv"> <input id="agree1" type="checkbox" class="form-check-input ag" required></div>

                <div>
                  <!-- Button trigger modal -->
                  <label for="agree1" class="form-check-label cl">
                    <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#Service" >我同意ReadUse會員服務條款
                    </button>
                  </label>
                </div>
              </div>

              <div class="dflex">
                <div class="checkboxDiv"> <input id="agree2" type="checkbox" class="form-check-input ag"></div>
                <div class="DivA2"><label for="agree2" class="form-check-label cl">我同意收到ReadUse優惠通知</label> </div>
              </div>
            </div>

            <div class="col-lg-12 col-xl-1 DivR"> 
              <GoogleRecaptcha />
            </div>

            <!-- Modal -->
            <div class="modal fade" id="Service" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true"
              data-bs-backdrop="false">
              <div class="modal-dialog modal-dialog-scrollable pa">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">ReadUse會員服務條款</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                  </div>
                  <div class="modal-body">
                    <p>
                      您好，我們非常榮幸能提供您ReadUse相關購物服務（以下稱本服務）。
                      為了保障您的權益，ReadUse將根據以下所載的網路服務條款，提供您便利的網路交易服務，
                      當您成為ReadUse會員，或開始實際使用本服務，均視為您已經閱讀、瞭解並同意接受本服務條款的所有內容。
                      ReadUse保留隨時修改服務使用條款之權利，增加、修改或終止後的內容，將公佈在會員服務相關網頁上，
                      不另行個別通知會員，建議會員隨時注意該等修改或變更。
                      會員於任何修改或變更後繼續使用本服務時，視為會員已閱讀、瞭解並同意接受該等修改或變更。
                      若不同意上述的服務條款修訂或更新方式，或不接受本服務條款的其他任一約定，會員應立即停止使用本服務。
                      若您未滿二十歲，請在您的家長（或監護人）陪同，一起細讀、瞭解並同意本服務條款後，您才能繼續使用本服務。
                      當您成為會員繼續使用本服務時，即推定您的家長（或監護人）已細讀、瞭解並同意接受本服務條款的所有內容及其後修改變更。
                    </p>
                    <p>
                      個人資料的蒐集、處理、利用：
                    </p>
                    <p>
                      為了確保會員之個人資料、隱私及消費者權益之保護，於交易過程中將使用會員之個人資料，謹依個人資料保護法第8條規定告知以下事項：
                      蒐集之目的：
                      蒐集之目的在於進行
                      (1) 行銷業務（法定特定目的項目編號為Ｏ四Ｏ）。
                      (2) 對消費者、客戶管理與服務（法定特定目的項目編號為Ｏ九Ｏ）。
                      (3) 統計與研究分析(法定特定目的項目編號為一五七)。
                      (4) 網路購物及其他電子商務服務及與調查（法定特定目的項目編號為一四八）
                      ReadUse將藉由加入會員之過程或進行交易之過程來蒐集個人資料。
                    </p>
                    <p>
                      蒐集之個人資料類別：
                    </p>
                    <p>
                      ReadUse於網站內蒐集的個人資料包括
                      (1) C001辨識個人者： 如會員之姓名、地址、電話、電子郵件等資訊。
                      (2) C002辨識財務者： 如信用卡或金融機構帳戶資訊。
                      (3) C011個人描述：例如：性別、出生年月日等。
                      利用期間、地區、對象及方式：
                      (1) 期間：會員當事人要求停止使用或ReadUse停止提供服務之日為止。
                      (2) 地區：會員之個人資料將使用於台灣地區。
                      (3) 利用對象及方式：會員之個人資料蒐集除用於ReadUse之會員管理、客戶管理之檢索查詢等功能外，
                      亦將利用於辨識身份、金流服務、物流服務、行銷廣宣等。例示如下：
                      以會員身份使用ReadUse提供之各項服務時，於頁面中自動顯示會員資訊。
                      為遂行交易行為：會員對商品或勞務為預約、下標、購買、參與贈獎等之活動或從事其他交易時，關於商品配送、勞務提供、價金給付、回覆客戶之詢問、ReadUse對會員之詢問、相關售後服務及其他遂行交易所必要之業務。
                      宣傳廣告或行銷等：提供會員各種電子雜誌等資訊、透過電子郵件、郵件、電話等提供與服務有關之資訊。將會員所瀏覽之內容或廣告，依客戶之個人屬性或購買紀錄、ReadUse網站之瀏覽紀錄等項目，進行個人化作業、會員使用服務之分析、新服務之開發或既有服務之改善等。針對民調、活動、留言版等之意見，或其他服務關連事項，與會員進行聯繫。
                      回覆客戶之詢問：針對會員透過電子郵件、郵件、傳真、電話或其他任何直接間接連絡方式向ReadUse所提出之詢問進行回覆。
                      其他業務附隨之事項：附隨於上述a至d.之利用目的，而為ReadUse提供服務所必要之使用。
                      對於個別服務提供者之資訊提供：會員對服務提供者之商品或勞務為預約、下標、購買、參加贈獎活動或申請其他交易時，ReadUse於該交易所必要之範圍內，得將會員之個人資料檔案提供予服務提供者，並由服務提供者負責管理該個人資料檔案。ReadUse將以規約課予服務提供者依保障會員隱私權之原則處理個人資料之義務，但無法保證服務提供者會必然遵守。詳細內容，請向個別服務提供者洽詢。
                      其他：其他符合個資法第20條規定之利用。
                    </p>
                    <p>
                      會員就個人資料之權利：
                    </p>
                    <p>
                      ReadUse所蒐集個人資料之當事人，依個人資料保護法得對ReadUse行使以下權利：
                      (1) 查詢或請求閱覽。
                      (2) 請求製給複製本。
                      (3) 請求補充或更正。
                      (4) 請求停止蒐集、處理或利用。
                      (5) 請求刪除。
                      會員如欲行使上述權利，可與ReadUse客服連絡進行申請。

                      請您注意，如拒絕提供加入會員所需必要之資料，將可能導致無法享受完整服務或完全無法使用該項服務。
                    </p>
                    <p>
                      會員註冊義務：
                    </p>
                    <p>
                      為能使用本服務，您同意以下事項：

                      依本服務註冊會員表提供您本人最新、正確的資料，且無重複註冊登入等情事。
                      及時維持並更新您的資料，確保其正確及完整。若您提供任何錯誤或不實之資料，除您必須自行負擔因此而造成的損失外，ReadUse有權不經事先通知，逕行暫停或終止您的帳號，並拒絕您使用本服務之全部或一部。
                      會員資料保護：

                      ReadUse將保護每位會員的個人資料，對於會員所提供的個人資料，除了會員可能涉及違法、侵權、違反本使用條款或各該服務之使用規範或約定、或經會員本人同意外，本公司不會將會員個人資料提供給第三人，包括贊助的廣告廠商。但會員參加ReadUse舉辦的活動(例抽獎)則例外，將把會員個人資料部分揭露給該等特定服務的合作夥伴。確保與維持會員帳號及密碼的機密安全，是您的責任。您將對利用該帳號及密碼所進行的一切行動，負完全的責任並同意以下事項：

                      您的帳號或密碼遭到盜用或有其他發生任何安全問題發生時，請立即通知ReadUse。
                      您的帳號、密碼及會員的權益僅提供您個人使用，不得轉介、轉讓或與他人合用。
                      您不可對任何人洩漏您的帳號或密碼，也不可以利用他人的帳號或密碼使用本服務。
                      帳號及密碼遭到盜用、不當使用及ReadUse無法辨認是否為本人親自使用之情況時，所造成之損害，ReadUse概不負責。
                      當您同意使用Facebook帳號或Gmail帳號登入使用本服務時，該Facebook帳號或Gmail帳號之密碼是由Facebook與Google網站所處理，ReadUse並不會接觸到該密碼，而且每一個Facebook帳號或Gmail帳號只能綁定一個ReadUse會員帳號進行登入，第一次綁定後即不能再予修改。
                      就ReadUse而言，經由登入Facebook或Gmail帳號及密碼而登入使用本服務時，該登入的帳號即代表您本人，使用者於使用本服務之任何行為，均視為您之行為，並需遵循ReadUse會員條款之各項約定。您必須妥善設定、維護及保管自己之Facebook或Gmail帳號及密碼，包含但不限使用本服務，結束時應適時登出本服務之網站並同時登出Facebook或Gmail帳號。
                      如果您洩漏自己的個人資料、密碼或付款資料，並使得第三人有使用的機會時，您必須就第三人的行為負全部責任。ReadUse並可隨時暫停或終止提供本項使用Facebook帳號或Gmail登入使用本服務之措施。
                      ReadUse已採用最嚴格的保密、監督、保護之措施，若您違反上述之規定導致您的損失，ReadUse將不負任何賠償責任。
                    </p>
                    <p>
                      使用者責任義務：
                    </p>
                    <p>
                      請提供您本人的正確資料。(若您資料填寫不實，ReadUse有權暫停或終止您的會員帳號與服務)
                      未滿十二歲兒童使用本服務時，家長（或監護人）應全程在旁陪伴。十二歲以上未滿十八歲之青少年，家長（或監護人）亦應斟酌是否同意其使用本服務。
                      使用者同意並保證不得利用本服務從事侵害他人權益或違法之行為，包括但不限於：
                      公布或傳送任何誹謗、侮辱、具威脅性、攻擊性、不雅、猥褻、不實、違反公共秩序或善良風俗或其他不法之文字、圖片或任何形式的檔案。
                      侵害、儲存或毀損ReadUse或他人名譽、隱私權、營業秘密、商標權、著作權、專利權、其他智慧財產權及其他權利。
                      違反依法律或契約所應負之保密義務。
                      冒用他人名義使用ReadUse之服務。
                      從事不法交易行為或張貼虛假不實、引誘犯罪之訊息。
                      販賣槍枝、毒品、禁藥、盜版軟體或其他違禁物品。
                      提供賭博資訊或是以任何方式引誘他人參與賭博。
                      濫發廣告郵件。
                      傳輸或散佈電腦病毒。
                      不得行使未經ReadUse同意或授權之商業行為。
                      其他ReadUse認為不適當之行為。
                      如果您利用本服務進行侵害他人權利行為或從事任何違法或相關活動，ReadUse得依法向您求償外，並得撤銷您的會員資格及永久禁止您使用本服務。
                    </p>
                    <p>
                      暫停或中斷服務：
                    </p>
                    <p>
                      發生突發性之電子設備故障，或網站設備進行必要之保養及施工。
                      網站申請之網路通訊服務被停止，無法提供服務。
                      由於自然災害等不可抗力因素，或其他非本公司所能控制而不可歸責於ReadUse，致無法提供服務。
                    </p>
                    <p>
                      資料授權：
                    </p>
                    <p>
                      任何經您上載、傳送、輸入或提供資料至ReadUse時，均視您已同意ReadUse無條件使用、修改、重製、公開播送、改作、散布、發行、公開發表該資料，並得將前述權利轉授權他人。在您同意以Facebook帳號登入會員時，均視為您已同意ReadUse使用您Facebook的頭像、帳號及暱稱做為網站上的頭像與暱稱。您並保證ReadUse在使用、修改、重製、公開播送、改作、散布、發行、公開發表、轉授該資料時，不致侵害任何第三人之智慧財產權，否則應對ReadUse負損害賠償責任。
                    </p>
                    <p>
                      拒絕或終止使用權：
                    </p>
                    <p>
                      基於公司運作與交易安全考量，ReadUse保留隨時停止提供會員服務之全部或一部份之權利。若會員違反本服務條款或任何理由(包括但不限於：訂購產品後任意退換貨、取消訂單，或本公司認為不適當而造成作業困擾或損害行為)，ReadUse得採取拒絕交易或終止您的密碼、帳號或本服務之使用，且不因此對您或任何第三人負任何賠償或補償之責任。
                    </p>
                    <p>
                      電子商務交易：
                    </p>
                    <p>
                      ReadUse盡力維護相關資料的正確性，但不保證所有出現在網頁上、或相關訊息上的資料均為完整、正確、即時的資訊。如果相關商品或服務的規格、圖片或說明有誤，仍以原廠、代理商、進口商、經銷商或服務提供者的資料為準。如果網頁上、或相關訊息所標示的價格有誤：
                      若標示價格比正確價格高，將收取較低的正確價格。
                      若標示價格比正確價格低，將保留拒絕或事後取消訂單的權利。
                      您所訂購的所有商品或服務，關於其品質、保固及售後服務等，都是由各該商品或服務的原廠、代理商、進口商、經銷商或服務提供者，依照其所制定的條件，負責對您提供品質承諾、保固及售後服務等，但ReadUse承諾協助您解決關於因為線上消費所產生的疑問或爭議。
                      您一旦在ReadUse完成訂購程序，就表示您提出要約、願意依照本約定條款及相關網頁上所載明的交易條件或限制，訂購該商品或服務。您所留存的資料(如地址、email、電話)如有變更，應立即上線修改所留存的資料，而且不得以資料不符為理由，否認訂購行為或拒絕付款。
                      您在ReadUse的所有線上消費，都以ReadUse電腦系統所自動紀錄的電子交易資料為準，若有糾紛，應以該電子交易資料為認定標準。若您發現交易資料不正確，應立即通知ReadUse。
                      退貨退款：

                      若您所訂購的商品有瑕疵，您可以要求全額退費。
                      您在ReadUse所訂購的商品，可以在十天之內要求退貨退款；但是，下列商品不在此限：
                      以數位或電磁紀錄形式儲存的商品，包括且不限於電腦程式、數位音樂檔案、錄音帶、錄影帶、CD、VCD、DVD等。
                      可供線上下載、或以線上傳輸方式提供的商品或資料(包含電子書)。
                      依照您所要求或註明的規格、需求或時間，所訂製、調整或送達的商品。
                      期刊或其他定期發行的商品。
                      依照通常運送條件，貨物取回時已逾保存期限、或已變質或損壞的商品。
                      您所退回的商品，必須保持所有商品、贈品、附件、包裝、及所有附隨文件或資料的完整性，如果有實體發票，並應連同發票一併退回；否則，ReadUse得拒絕接受您的退貨退款要求。
                      智慧財產權的保護：

                      ReadUse所使用的軟體或程式、網站上所有的內容，包括但不限於著作、圖片、檔案、資訊、資料、網站架構、網站方面的安排、網頁設計、均由本公司或其他權利人依法擁有其智慧財產權，包括但不限於商標權、專利權、著作權、營業秘密與專有技術等。任何人不得逕自使用、修改、重製、公開播送、改作、散佈、發行、公開發表、進行還原工程、解編或反向組譯。若您引用或轉載前述軟體、程式或網站內容，必須先取得本公司或其他權利人的事前書面同意。尊重智慧財產權是您應盡的義務，如有違反，除您應對ReadUse負損害賠償責任外，ReadUse並得撤銷您的會員資格及永久禁止您使用本服務。
                    </p>
                    <p>
                      準據法與管轄法院：
                    </p>
                    <p>
                      本約定條款與有關的爭議，均應依照中華民國法律予以處理，並以台灣台北地方法院為第一審管轄法院。
                    </p>
                    <p>
                      ReadUse 敬上
                    </p>
                  </div>
                  <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">取消</button>
                    <button type="button" class="btn btn-primary" data-bs-dismiss="modal" @click="userAgree">同意</button>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <br>
          <div class="d-grid gap-2">
            <button @click="sure" class="DarkGbtn">確認</button>
          </div>
          <br>
          <br>
          <br>
          <div class="col-sm-1 col-md-2"></div>
        </div>
      </div>
    </div>
    <br><br>
  </section>
</template>

<script>
import BreadCrumb from '@/components/shared/BreadCrumb.vue'
import GoogleRecaptcha from '@/components/shared/GoogleRecaptcha.vue'
export default {
  name: 'RegisterView',
  data() {
    return {
      breadCrumbData: [
        { title: "首頁", link: "/" },
        { title: "註冊", link: "" },
      ],
    }
  },
  methods: {
    //確認按鈕
    sure() {
      //recaptcha機器人檢查
      if (!document.cookie.includes("RobotTest")) {
        Swal.fire({
          icon: 'error',
          title: '註冊失敗!',
          text: '未通過機器人測試',
        })
        return;
      };
      //格式檢查
      var regex1 = new RegExp("[0-9a-zA-Z_]+([.-][0-9a-zA-Z_]+)*@[0-9a-zA-Z_]+([.-][0-9a-zA-Z_]+)+");
      if (!regex1.test(email.value)) {

        Swal.fire({
          icon: 'error',
          title: '註冊失敗!',
          text: '會員信箱格式錯誤',
        })
        return;
      }


      var regex2 = new RegExp("(?=.*[0-9])(?=.*[a-zA-Z])[0-9a-zA-Z]{8,}");
      if (!regex2.test(password.value)) {

        Swal.fire({
          icon: 'error',
          title: '註冊失敗!',
          text: '密碼格式錯誤',
        })
        return;
      }
      var regex3 = new RegExp("09[0-9]{8}");
      if (!regex3.test(cellphone.value)) {

        Swal.fire({
          icon: 'error',
          title: '註冊失敗!',
          text: '手機格式錯誤',
        })
        return;
      }

      //檢查再次輸入密碼欄位
      if (againpassword.value != password.value) {
        Swal.fire({
          icon: 'error',
          title: '註冊失敗!',
          text: '密碼與再次輸入密碼欄位須一致',
        })
        return;
      }
      //檢查會員服務條款欄位
      if (agree1.checked != true) {
        Swal.fire({
          icon: 'error',
          title: '註冊失敗!',
          text: '須同意ReadUse會員服務條款才能註冊會員',
        })
        return;
      }
      //檢查DB是否有重複的帳號了
      $.post(`${GetApiUrl()}/login/CheckEmail`,
        { userEmail: email.value },
        function (rr) {
          console.log(rr);

          if (rr.result == "exist") {
            Swal.fire({
              icon: 'error',
              title: '註冊失敗!',
              text: '已經使用此Email註冊會員了',
            })

          }
          else {
            $.post(`${GetApiUrl()}/login/DoRegister`,
              {
                userEmail: email.value,
                userPassword: password.value,
                userName: username.value,
                userPhone: cellphone.value
              }, function (rr) {
                console.log(rr);

                if (rr.result == "success") {
                  Swal.fire(
                    '註冊成功!',
                    '請至Email收取驗證信，以開通會員帳戶。',
                    'success'
                  ).then(
                    function (result) {
                      if (result.value) {
                        location.href = "/";
                      }
                    })


                }
                else {
                  Swal.fire({
                    icon: 'error',
                    title: '註冊失敗!',
                    text: '請重新註冊',
                  })
                }
              })
          }
        })
    },

    //密碼提示
    showHelp() {
      $('.passwordHelp').show("3ms");
    },
    hideHelp() {
      $('.passwordHelp').hide("3ms")
    },

    userAgree() {
      $('#agree1').prop('checked', true);
    },


  },
  async created() {
    var self = this;
    try {

    } catch (error) {
      console.log("發生錯誤");
    }
  },
  components: {
    BreadCrumb,
    GoogleRecaptcha,
  },
  mounted() {
    //密碼提示
    $('.passwordHelp').hide();
  }
}

</script>

<style  src="./css/Login&news.css"></style>