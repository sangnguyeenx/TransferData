using System;

namespace Scan_Box
{
    public class HocSinhChuyenCap
    {
        public int ID_hs_chuyen_cap { get; set; }
        public int ID_hs { get; set; }
        public int ID_lop { get; set; }
        public string Nam_hoc { get; set; }
        public DateTime? Ngay_di_hoc { get; set; }
        public DateTime? Ngay_nhap_hoc { get; set; }
        public bool? Duyet { get; set; }
        public DateTime? Ngay_duyet { get; set; }
        public string Nguoi_duyet { get; set; }
        public DateTime? Ngay_huy_duyet { get; set; }
        public string Nguoi_huy_duyet { get; set; }
        public int? Trang_thai { get; set; }
        public int? Create_UserID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Update_UserID { get; set; }
        public DateTime? Update_Date { get; set; }
        public int? ID_ACE { get; set; }
        public int? ID_dk_xe { get; set; }
        public int? ID_cb { get; set; }
        public int? ID_dk_an { get; set; }
        public bool? Khong_an_sang { get; set; }
    }
} 