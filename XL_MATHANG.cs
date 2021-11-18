using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_NMLT
{
    public struct MATHANG
    {
        public string maSanPham;
        public string tenSanPham;
        public NGAY hanSudung;
        public string tenCongTy;
        public int namSanXuat;
        public string loaiSanPham;
        public MATHANG(string maSanPham, string tenSanPham, NGAY hanSudung, string tenCongTy, int namSanXuat, string loaiSanPham)
        {
            this.maSanPham = maSanPham;
            this.tenSanPham = tenSanPham;
            this.hanSudung = hanSudung;
            this.tenCongTy = tenCongTy;
            this.namSanXuat = namSanXuat;
            this.loaiSanPham = loaiSanPham;
        }
    }
    class XL_MATHANG
    {
        public static bool KhongTrungMaMH_LoaiSP(MATHANG[] A, string MaMH, string LoaiSP)
        {
            for (int i = 0; i < A.Length; i++)
            {
                if (MaMH == A[i].maSanPham && LoaiSP == A[i].loaiSanPham)
                {
                    Console.WriteLine("Thêm vào mặt hàng và loại hàng đã có trong cửa hàng.");
                    return false;
                }
            }
            return true;
        }
        public static MATHANG NhapSanPham(string ghiChu)
        {
            MATHANG sp;
            Console.WriteLine(ghiChu);
            Console.WriteLine("Nhập mã sản phẩm:");
            sp.maSanPham = Console.ReadLine();            
            Console.WriteLine("Nhập tên sản phẩm:");
            sp.tenSanPham = Console.ReadLine();
            sp.hanSudung = XL_NGAY.NhapNgay("Nhập hạn sử dụng");            
            Console.WriteLine("Nhập tên Công ty:");
            sp.tenCongTy = Console.ReadLine();
            Console.WriteLine("Nhập năm sản xuất:");            
            sp.namSanXuat = int.Parse(Console.ReadLine());
            while (sp.namSanXuat < 2000 || sp.namSanXuat > 2021)
            {
                Console.WriteLine("##################################");
                Console.WriteLine($"Năm sản xuất phải nằm trong khoảng thời gian từ năm 2000 - {DateTime.Now}");
                Console.WriteLine("Nhập lại năm sản xuất:");
                sp.namSanXuat = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Nhập loại sản phẩm:");
            sp.loaiSanPham = Console.ReadLine();
            while (sp.hanSudung.year < sp.namSanXuat)
            {
                Console.WriteLine("##################################");
                Console.WriteLine("Hạn sử dụng phải sau năm sản xuất.");
                sp.hanSudung = XL_NGAY.NhapNgay("Nhập lại hạn sử dụng");
                Console.WriteLine("Nhập lại năm sản xuất:");
                sp.namSanXuat = int.Parse(Console.ReadLine());                
            } 
            
            
            return sp;
        }
        public static MATHANG NhapSanPhamTheoLoaiHang_MaSP(string MaSPThem, string LoaiHangThem)
        {
            MATHANG sp;        
            sp.maSanPham = MaSPThem;
            Console.WriteLine("Nhập tên sản phẩm:");
            sp.tenSanPham = Console.ReadLine();
            sp.hanSudung = XL_NGAY.NhapNgay("Nhập hạn sử dụng");
            Console.WriteLine("Nhập tên Công ty:");
            sp.tenCongTy = Console.ReadLine();
            Console.WriteLine("Nhập năm sản xuất:");
            sp.namSanXuat = int.Parse(Console.ReadLine());
            while (sp.namSanXuat < 2000 || sp.namSanXuat > 2021)
            {
                Console.WriteLine("##################################");
                Console.WriteLine($"Năm sản xuất phải nằm trong khoảng thời gian từ năm 2000 - {DateTime.Now}");
                Console.WriteLine("Nhập lại năm sản xuất:");
                sp.namSanXuat = int.Parse(Console.ReadLine());
            }
            sp.loaiSanPham = LoaiHangThem;
            while (sp.hanSudung.year < sp.namSanXuat)
            {
                Console.WriteLine("##################################");
                Console.WriteLine("Hạn sử dụng phải sau năm sản xuất.");
                sp.hanSudung = XL_NGAY.NhapNgay("Nhập lại hạn sử dụng");
                Console.WriteLine("Nhập lại năm sản xuất:");
                sp.namSanXuat = int.Parse(Console.ReadLine());
            }
            return sp;
        }        
        public static void XuatSanPham(MATHANG sp)
        {
            string space = " ";       
            Console.Write(sp.maSanPham);            
            for (int i = 0; i  + sp.maSanPham.Length < 15; i++)
            {
                Console.Write(space);
            }

            Console.Write(sp.tenSanPham);            
            for (int i = 0; i + sp.tenSanPham.Length < 25; i++)
            {
                Console.Write(space);
            }

            Console.Write(XL_NGAY.XuatNgay(sp.hanSudung));            
            for (int i = 0; i + XL_NGAY.XuatNgay(sp.hanSudung).ToString().Length < 16; i++)
            {
                Console.Write(space);
            }

            Console.Write(sp.tenCongTy);            
            for (int i = 0; i + sp.tenCongTy.Length < 20; i++)
            {
                Console.Write(space);
            }

            Console.Write(sp.namSanXuat);            
            for (int i = 0; i + sp.namSanXuat.ToString().Length < 15; i++)
            {
                Console.Write(space);
            }

            Console.Write(sp.loaiSanPham);
            for(int i = 0; i + sp.loaiSanPham.Length < 15; i++)
            {
                Console.Write(space);
            }
            Console.Write("||");
        }
        public static bool XuatTieuDe()
        {
            Console.WriteLine("======================================================================================================================");
            Console.WriteLine("|| STT    Mã sản phẩm      Tên sản phẩm           Hạn sử dụng     Tên công ty      Năm sản xuất     Loại sản phẩm   ||");
            Console.WriteLine("======================================================================================================================");
            return true;
        }
        public static MATHANG[] NhapMangSanPham(string ghiChu)
        {
            MATHANG[] A;
            int n;
            Console.WriteLine(ghiChu);
            Console.WriteLine("Nhap so luong san pham:");
            n = int.Parse(Console.ReadLine());
            A = new MATHANG[n];
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = NhapSanPham($"Nhap san pham thu {i + 1}");
            }
            return A;
        }
        public static void XuatMangSanPham(MATHANG[] msp)
        {
            
            string space = " ";
            XuatTieuDe();
            for (int i = 0; i < msp.Length; i++)
            {
                Console.Write($"|| SP{i + 1}");
                for (int k = 0; k + $"|| SP{i + 1}".Length <10 ; k++)
                {
                    Console.Write(space);
                }
                XuatSanPham(msp[i]);
                Console.WriteLine();
            }
            Console.WriteLine("======================================================================================================================");
        }        
        public static bool ThemSPTrongMangSP(ref MATHANG[] msp, ref LOAIHANG[] LH)
        {
            XuatMangSanPham(msp);
            Console.WriteLine("======================================================================================================================");
            MATHANG[] tempMH = new MATHANG[msp.Length + 1];
            Console.WriteLine("Nhập: 1 -- Để thêm loại sản phẩm mới hoàn toàn.");
            Console.WriteLine("Nhập: 2 -- Để thêm sản phẩm vào loại hàng và mã sản phẩm đã có sẵn");
            int codeAdd = int.Parse(Console.ReadLine());
            switch (codeAdd)
            {
                case 1:
                    for (int i = 0; i < tempMH.Length - 1; i++)
                    {
                        tempMH[i] = msp[i];
                    }
                    tempMH[tempMH.Length - 1] = NhapSanPham("Nhập sản phẩm thêm mới:");
                    msp = new MATHANG[tempMH.Length];
                    msp = tempMH;

                    LOAIHANG[] tempLH = new LOAIHANG[LH.Length + 1];
                    for (int i = 0; i < tempLH.Length - 1; i++)
                    {
                        tempLH[i] = LH[i];
                    }
                    tempLH[tempLH.Length - 1].LoaiSP = msp[msp.Length - 1].loaiSanPham;
                    tempLH[tempLH.Length - 1].MaSP = msp[msp.Length - 1].maSanPham;

                    LH = new LOAIHANG[tempLH.Length];
                    LH = tempLH;
                    XuatMangSanPham(msp);
                    break;

                case 2:

                    XL_LOAIHANG.XuatMangLoaiHang(LH, msp);
                    Console.WriteLine($"Chọn STT theo mục hàng có sẵn từ 1 - {LH.Length} để thêm sản phẩm vào loại hàng này");
                    int indexLH_Chosen = int.Parse(Console.ReadLine()) - 1;
                    string MaSPThem = LH[indexLH_Chosen].MaSP;
                    string LoaiSPThem = LH[indexLH_Chosen].LoaiSP;

                    for (int i = 0; i < tempMH.Length - 1; i++)
                    {
                        tempMH[i] = msp[i];
                    }
                    tempMH[tempMH.Length - 1] = NhapSanPhamTheoLoaiHang_MaSP(MaSPThem, LoaiSPThem);
                    msp = new MATHANG[tempMH.Length];
                    msp = tempMH;
                    XuatMangSanPham(msp);
                    break;
            }
            
            return true;
        }        
        public static bool XoaSPTrongMangSP(ref MATHANG[] MSP)
        {
            XuatMangSanPham(MSP);
            Console.WriteLine($"Chọn sản phẩm để xóa từ STT 1 - {MSP.Length}");
            int index = int.Parse(Console.ReadLine());
            index -= 1; // vì trực quan người dùng tính từ 1, nhưng mảng tính từ 0 nên trừ index để khớp với tìm kiếm người dùng
            MATHANG[] temp = new MATHANG[MSP.Length - 1];            
            for (int i = 0; i < index; i++)
            {
                temp[i] = MSP[i];
            }
            for (int i = index; i < temp.Length; i++)
            {
                temp[i] = MSP[i + 1];
            }
            MSP = new MATHANG[temp.Length];
            MSP = temp;
            XuatMangSanPham(MSP);
            return true;
        }
        public static bool XoaSPTrongMangSPTheoLoaiHang(ref MATHANG[] MSP, string dlloaihang)
        {
            MATHANG[] temp = new MATHANG[MSP.Length - 1];
            int index = -1;
            for (int i = 0; i < MSP.Length; i++)
            {
                if (MSP[i].loaiSanPham == dlloaihang)
                {
                    index = i;
                    break;
                }
            }
            if (index >=0)
            {
                for (int i = 0; i < index; i++)
                {
                    temp[i] = MSP[i];
                }
                for (int i = index; i < temp.Length; i++)
                {
                    temp[i] = MSP[i + 1];
                }
            }
            #region Gọi hàm
            /*
                for (int i = 0; i < MSP.Length; i++)
                {
                    if (dlLoaiHang == MSP[i].loaiSanPham)
                    {
                        XL_MATHANG.XoaSPTrongMangSPTheoLoaiHang(ref MSP, dlLoaiHang);
                        // Vì lúc này phần tử thứ i+1 đã dịch về vị trí i
                        // nên trừ 1 để check điều kiện 1 lần nữa
                        // trong trường hợp có các phần từ trùng liên tiếp
                        i--; 
                        
                    }
                }
            */
            #endregion
            MSP = new MATHANG[temp.Length];
            MSP = temp;            
            return true;
        }
        public static bool XoaCacMatHangCungLoaiHang(ref MATHANG[] MSP, string dlLoaiHang)
        {
            int count = 0;
            for (int i = 0; i < MSP.Length; i++)
            {
                if (MSP[i].loaiSanPham == dlLoaiHang)
                {
                    count++;
                }
            }
            MATHANG[] temp = new MATHANG[MSP.Length - count];
            for (int i = 0, j = 0; i < MSP.Length; i++)
            {
                if (MSP[i].loaiSanPham != dlLoaiHang)
                {
                    temp[j] = MSP[i];
                    j++;
                }
            }
            MSP = new MATHANG[temp.Length];
            MSP = temp;
            return true;
        }
        public static bool SuaSPTrongMangSP(ref MATHANG[] MSP, ref LOAIHANG[] LH)
        {
            XuatMangSanPham(MSP);
            Console.WriteLine($"Chọn sản phẩm để sửa từ STT 1-{MSP.Length}");
            int index = int.Parse(Console.ReadLine());
            index -= 1;
            MATHANG[] temp = new MATHANG[MSP.Length];

            Console.WriteLine("Nhập: 1 -- Sửa thành loại sản phẩm mới hoàn toàn.");
            Console.WriteLine("Nhập: 2 -- Sửa sản phẩm phân bổ vào loại hàng và mã sản phẩm đã có sẵn");
            int codeEdit = int.Parse(Console.ReadLine());
            switch (codeEdit)
            {
                case 1:
                    for (int i = 0; i < temp.Length; i++)
                    {
                        temp[i] = MSP[i];
                    }
                    temp[index] = NhapSanPham("Nhập nội dung sửa mới:");
                    MSP = temp;
                    XuatMangSanPham(MSP);

                    LOAIHANG[] tempLH = new LOAIHANG[LH.Length + 1];
                    for (int i = 0; i < tempLH.Length - 1; i++)
                    {
                        tempLH[i] = LH[i];
                    }
                    tempLH[tempLH.Length - 1].LoaiSP = MSP[index].loaiSanPham;
                    tempLH[tempLH.Length - 1].MaSP = MSP[index].maSanPham;

                    LH = new LOAIHANG[tempLH.Length];
                    LH = tempLH;
                    XL_LOAIHANG.XuatMangLoaiHang(LH, MSP);
                    break;

                case 2:
                    XL_LOAIHANG.XuatMangLoaiHang(LH, MSP);
                    Console.WriteLine($"Chọn STT theo mục hàng có sẵn từ 1 - {LH.Length} để thêm sản phẩm vào loại hàng này");
                    int indexLH_Chosen = int.Parse(Console.ReadLine()) - 1;
                    string MaSPSua = LH[indexLH_Chosen].MaSP;
                    string LoaiSPSua = LH[indexLH_Chosen].LoaiSP;
                    for (int i = 0; i < temp.Length; i++)
                    {
                        temp[i] = MSP[i];
                    }
                    temp[index] = NhapSanPhamTheoLoaiHang_MaSP(MaSPSua, LoaiSPSua);
                    MSP = temp;
                    XuatMangSanPham(MSP);
                    break;
            }

            return true;

        }
        public static bool TimSanPham(ref MATHANG[] MSP)
        {
            XuatMangSanPham(MSP);
            string space = " ";
            bool searchFinished = false;
            do
            {                
                #region Danh sách chọn
                Console.WriteLine("Vui lòng nhập số tương ứng để tìm sản phẩm theo nhu cầu:");
                Console.WriteLine("   1   Tìm sản phẩm theo mã sản phẩm");
                Console.WriteLine("   2   Tìm sản phẩm theo loại sản phẩm");
                Console.WriteLine("   3   Tìm sản phẩm theo tên công ty");
                Console.WriteLine("   4   Tìm sản phẩm theo tên sản phẩm");
                #endregion
                int option = int.Parse(Console.ReadLine());                
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Nhập mã sản phẩm cần tìm:");
                        string spCode = Console.ReadLine();
                        int countSpCode = 0;
                        XuatTieuDe();
                        for (int i = 0; i < MSP.Length; i++)
                        {
                            if (spCode == MSP[i].maSanPham)
                            {
                                Console.Write($"|| SP{i + 1}");
                                for (int k = 0; k + $"|| SP{i + 1}".Length < 10; k++)
                                {
                                    Console.Write(space);
                                }
                                XuatSanPham(MSP[i]);
                                Console.WriteLine();
                                countSpCode++;
                            }
                        }
                        Console.WriteLine("======================================================================================================================");
                        if (countSpCode == 0)
                        {
                            Console.WriteLine("Sản phẩm không tồn tại, vui lòng nhập mã sản phẩm khác.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Nhập loại sản phẩm cần tìm:");
                        string spType = Console.ReadLine();
                        int countSpType = 0;
                        XuatTieuDe();
                        for (int i = 0; i < MSP.Length; i++)
                        {
                            if (spType == MSP[i].loaiSanPham)
                            {
                                Console.Write($"|| SP{i + 1}");
                                for (int k = 0; k + $"|| SP{i + 1}".Length < 10; k++)
                                {
                                    Console.Write(space);
                                }
                                XuatSanPham(MSP[i]);
                                Console.WriteLine();
                                countSpType++;
                            }
                        }
                        Console.WriteLine("======================================================================================================================");
                        if (countSpType == 0)
                        {
                            Console.WriteLine("Sản phẩm không tồn tại, vui lòng nhập mã sản phẩm khác.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Nhập tên công ty cần tìm:");
                        string spComName = Console.ReadLine();
                        int countSpComName = 0;
                        XuatTieuDe();
                        for (int i = 0; i < MSP.Length; i++)
                        {
                            if (spComName == MSP[i].tenCongTy)
                            {
                                Console.Write($"|| SP{i + 1}");
                                for (int k = 0; k + $"|| SP{i + 1}".Length < 10; k++)
                                {
                                    Console.Write(space);
                                }
                                XuatSanPham(MSP[i]);
                                Console.WriteLine();
                                countSpComName++;
                            }
                        }
                        Console.WriteLine("======================================================================================================================");
                        if (countSpComName == 0)
                        {
                            Console.WriteLine("Sản phẩm không tồn tại, vui lòng nhập mã sản phẩm khác.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Nhập tên sản phẩm cần tìm:");
                        string spName = Console.ReadLine();
                        int countSpName = 0;
                        XuatTieuDe();
                        for (int i = 0; i < MSP.Length; i++)
                        {
                            if (spName == MSP[i].tenSanPham)
                            {
                                Console.Write($"|| SP{i + 1}");
                                for (int k = 0; k + $"|| SP{i + 1}".Length < 10; k++)
                                {
                                    Console.Write(space);
                                }
                                XuatSanPham(MSP[i]);
                                Console.WriteLine();
                                countSpName++;
                            }
                        }
                        Console.WriteLine("======================================================================================================================");
                        if (countSpName == 0)
                        {
                            Console.WriteLine("Sản phẩm không tồn tại, vui lòng nhập mã sản phẩm khác.");
                        }
                        break;

                }

                Console.WriteLine("Nhâp 'y'để thoát khỏi mục tìm kiếm mặt hàng và quay về menu chính hoặc 'n' để tiếp tục thực hiện tìm kiếm.");
                char c = char.Parse(Console.ReadLine());
                if (c == 'y')
                {
                    searchFinished = true;
                }
                else if (c == 'n')
                {
                    searchFinished = false;
                }

            } while (searchFinished == false);
            return true;
        }
        public static int DemSoLuongMatHangCungLoai(MATHANG[] MSP, string timKiem)
        {
            int count = 0;
            for (int i = 0; i < MSP.Length; i++)
            {
                if (timKiem == MSP[i].loaiSanPham)
                {
                    count++;
                }
            }
            return count;
        }

    }
}
