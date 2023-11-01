/* =============== T1 =============== */
// 解析json資料
function myParseJSON(str) {
  if (typeof str == "string") {
    try {
      let obj = JSON.parse(str);
      if (obj && typeof obj == "object") {
        return obj;
      }
    } catch (e) {
      console.log(`error: ${str}!!!${e}`);
    }
  }
  return false;
}

// 取得get資料
function checkGet(str) {
  let url = new URL(location.href);
  return url.searchParams.get(str);
}

// 刪除陣列指定索引
function deleteArrayIndex(arr, index) {
  return arr.filter((value, arrIndex) => {
    return arrIndex !== index;
  });
}

// 取得API網址 判斷本地或線上
function GetApiUrl() {
  if (window.location.host == "localhost:8081" ||
      window.location.host == "localhost:8080") {
    return "https://localhost:7038";
  } else {
    return "https://msit51-t1bt-asp2.azurewebsites.net";
  }
}

/* =============== T2 =============== */
// 讀取購物車商品數量
var count = 0;
async function readCart() {
  if (sessionStorage.getItem('MemberID') == null) {
    return;
  } else {
    var MemberID = sessionStorage.getItem('MemberID');
    await $.ajax({
      method: "GET",
      dataType: "JSON",
      url: `${GetApiUrl()}/Cart/ReadCart`,
      data: { MemberID: MemberID },
    })
      .done(function (data) {
        count = data.length;
      })
      .fail(function (data) {
        console.log("發生錯誤");
      });
    cartCounter.innerHTML = count;
    count != 0
      ? (cartCounter.style.display = "inline")
      : (cartCounter.style.display = "none");
  }
}
readCart();
// 加入購物車
function addCart(Product) {
  var MemberID = sessionStorage.getItem('MemberID');
  var addData = {
    Type: "Normal",
    MemberID: MemberID,
    ProductID: Product.pID,
    UsedID: Product.uID,
  };
  // 判斷是一般商品 or 二手書
  if (Product != null) {
    "uID" in Product
      ? (addData.Type = "Customer") && (addData.UsedID = Product.uID)
      : (addData.Type = "Normal") && (addData.UsedID = null);
  }
  $.ajax({
    method: "POST",
    dataType: "JSON",
    url: `${GetApiUrl()}/Cart/AddCart`,
    data: addData,
  })
    .done(function (data) {
      Swal.fire({
        title: data.title,
        icon: "success",
        showConfirmButton: false,
        timer: 1500,
      })
      readCart();
    })
    .fail(function (data) {
      console.log("發生錯誤");
    });
}
// 購物車商品刪除
function deleteCart(Product) {
  var MemberID = sessionStorage.getItem('MemberID');
  var deleteData = {
    Type: "Normal",
    MemberID: MemberID,
    ProductID: Product.pID,
  };
  $.ajax({
    method: "POST",
    dataType: "JSON",
    url: `${GetApiUrl()}/Cart/CartDelete`,
    data: deleteData,
  })
    .done(function (data) {
      console.log(data);
      readCart();
    })
    .fail(function (data) {
      console.log("發生錯誤");
    });
}
/* =============== T3 =============== */
/* ===== 頁首 ===== */

/* ===== 頁尾 ===== */

/* =============== T4 =============== */
//Google登入
function parseJwt(token) {
  var base64Url = token.split('.')[1];
  var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
  var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
    return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
  }).join(''));
  return JSON.parse(jsonPayload);
};
function handleCallback(response) {
  //console.log(response);
  const data = parseJwt(response.credential);
  //console.log(data);

  //如果DB裡面沒有這個Account，就幫他新增，如果有就不用理他
  $.post(`${GetApiUrl()}/login/GoogleLogin`,
    {
      userEmail: data.email,
      userGoogle: data.sub,
      userName: data.name,
    }, function (rr) {
      //console.log(rr);

      //把會員ID加到sessionStorage
      sessionStorage.setItem("MemberID", rr.MemberID);
    });

  Swal.fire({
    title: '登入成功!',
    text: '即將前往會員中心。',
    icon: 'success',
    showConfirmButton: false,
  })
  setTimeout(function () { location.href = "/member/index" }, 3000);


}

//機器人
window.onLoadCallback = function () {
  grecaptcha.render('divR', {
    sitekey: '6LeF5lwoAAAAAJL0gcsnMnyzuekvEdbQFBrySFDG',
    callback: successCB,
  });
};

function successCB(token) {
  console.log(token);
  $.get(`${GetApiUrl()}/login/Robot`,
    {
      token: token,
    }, function (rr) {
      console.log(rr);

      var successValue = JSON.parse(rr.tt).success;
      console.log(successValue);

      if (successValue == true) {
        console.log("機器人成功")
        //加到cookie    
        document.cookie = 'RobotTest=true; max-age=30;';
      }
      else {
        console.log("機器人失敗")

      }

    })
};
/* =============== T5 =============== */
