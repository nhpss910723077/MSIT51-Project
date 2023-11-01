namespace MSIT51BT_ASP.Libraries {
    public enum BackFieldType {
        Text = 0, // 純文字
        Img = 1, // 純圖片
        Input = 2, // 文字輸入
        Number = 3, // 數字輸入
        Textarea = 4, // 多行文字輸入
        Select = 5, // 下拉選單
        Upload = 6, // 檔案上傳
        Datepicker = 7, // 日期選擇
		Switch = 8, // 開關
		Sort = 9, // 排序
		OX = 10, // 顯示O或X(boolen)
		ISBN = 11, // ISBN輸入框
		OrderDetail = 12, // 訂單細項
		SearchInput = 13, // 搜尋輸入
		SearchSelect = 14 // 搜尋下拉選單
	}
}