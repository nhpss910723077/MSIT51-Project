namespace MSIT51BT_ASP.Libraries {
    public class BackField {
        public BackFieldType Type { get; set; } // 類別
        public string FieldName { get; set; } // 資料庫欄位名稱
        public string Name { get; set; } // 後臺顯示名稱
        public int ColSize { get; set; } // 後臺網格欄數
        public bool CutCol { get; set; } // 是否換行
        public bool ReadOnly { get; set; } // 唯讀
		public string RefKey { get; set; } // 相依資料表鍵名
		public string RefTable { get; set; } // 相依資料表
		public string RefField { get; set; } // 相依資料表名稱

        public BackField() {
            Type = BackFieldType.Text;
            ColSize = 12;
            CutCol = false;
            ReadOnly = false;
        }





    }
}
