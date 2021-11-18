using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_NMLT
{
    public struct LOAIHANG
    {
        public string LoaiSP;
        public string MaSP;

        public LOAIHANG(string LoaiSP, string MaSP)
        {
            this.LoaiSP = LoaiSP;
            this.MaSP = MaSP;
        }
    }

    class XL_LOAIHANG
    {
        public static bool XuatMangLoaiHang(LOAIHANG[] MangLoaiHang, MATHANG[] MSP)
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Cửa hàng có các loại hàng là:");
            string space = " ";
            for (int i = 0; i < MangLoaiHang.Length; i++)
            {
                Console.Write($"|| STT Loại hàng: {i + 1}    ");
                Console.Write($"-Loại hàng: {MangLoaiHang[i].LoaiSP}");
                for (int k = 0; k + $"-Loại hàng: {MangLoaiHang[i].LoaiSP}".Length < 30; k++)
                {
                    Console.Write(space);
                }
                Console.Write($"Số lượng SP: {XL_MATHANG.DemSoLuongMatHangCungLoai(MSP, MangLoaiHang[i].LoaiSP)}        ");
                Console.Write($"-- Mã sản phẩm: {MangLoaiHang[i].MaSP}");
                Console.WriteLine();
            }
            Console.WriteLine("============================================");
            return true;
        }
        public static bool TimTheoLoaiHang(LOAIHANG[] MangLoaiHang, MATHANG[] MSP)
        {
            XuatMangLoaiHang(MangLoaiHang, MSP);
            Console.WriteLine("Vui lòng nhập chính xác loại hàng cần tìm bằng chữ - Kèm in hoa và dấu (nếu có) để tìm sản phẩm của loại hàng này.");
            string loaiHang = Console.ReadLine();
            int count = 0;
            string space = " ";
            XL_MATHANG.XuatTieuDe();
            for (int i = 0; i < MSP.Length; i++)
            {
                if (loaiHang == MSP[i].loaiSanPham)
                {
                    Console.Write($"|| SP{i + 1}");
                    for (int k = 0; k + $"|| SP{i + 1}".Length < 10; k++)
                    {
                        Console.Write(space);
                    }
                    XL_MATHANG.XuatSanPham(MSP[i]);
                    Console.WriteLine();
                    count++;
                }
            }
            Console.WriteLine("======================================================================================================================");
            if (count == 0)
            {
                Console.WriteLine("Loại hàng bạn tìm không tồn tại, vui lòng nhập chính xác loại hàng hoặc tìm kiếm loại hàng khác.");
            }
            return true;
        }
        public static bool ThemLoaiHang(ref LOAIHANG[] MangLoaiHang, ref MATHANG[] MSP)
        {
            XuatMangLoaiHang(MangLoaiHang, MSP);
            LOAIHANG[] tempLH = new LOAIHANG[MangLoaiHang.Length + 1];
            for (int i = 0; i < tempLH.Length - 1; i++)
            {
                tempLH[i] = MangLoaiHang[i];
            }
            Console.WriteLine("Vui lòng nhập loại hàng thêm mới:");
            tempLH[tempLH.Length - 1].LoaiSP = Console.ReadLine();
            Console.WriteLine("Vui lòng nhập mã sản phẩm của loại hàng thêm mới:");
            tempLH[tempLH.Length - 1].MaSP = Console.ReadLine();
            Console.WriteLine("Đã cập nhật thêm loại hàng như sau:");
            
            MangLoaiHang = new LOAIHANG[tempLH.Length];
            MangLoaiHang = tempLH;
            XuatMangLoaiHang(MangLoaiHang, MSP);

            Console.WriteLine("Vui lòng cập nhật sản phẩm mới cho loại hàng vừa thêm");
            MATHANG[] tempMH = new MATHANG[MSP.Length + 1];
            for (int i = 0; i < tempMH.Length - 1; i++)
            {
                tempMH[i] = MSP[i];
            }
            tempMH[tempMH.Length - 1] = XL_MATHANG.NhapSanPhamTheoLoaiHang_MaSP(MangLoaiHang[MangLoaiHang.Length - 1].MaSP, MangLoaiHang[MangLoaiHang.Length - 1].LoaiSP);
            MSP = new MATHANG[tempMH.Length];
            MSP = tempMH;
            XL_MATHANG.XuatMangSanPham(MSP);
            XuatMangLoaiHang(MangLoaiHang, MSP);
            return true;
        }        
        public static bool SuaLoaiHang(ref LOAIHANG[] MangLoaiHang, ref MATHANG[] MSP)
        {
            XuatMangLoaiHang(MangLoaiHang, MSP);
            Console.WriteLine("Vui lòng nhập chính xác loại hàng cần sửa bằng chữ - Kèm in hoa và dấu (nếu có).");
            string loaiHangCS = Console.ReadLine();
            Console.WriteLine("Mỗi loại hàng sẽ có được quy định bởi 1 mã sản phẩm, do đó, vui lòng:");
            Console.WriteLine("Nhập nội dung sửa cho loại hàng:");
            string editedLoaiHang = Console.ReadLine();
            Console.WriteLine("Nhập nội dung sửa cho mã sản phẩm");
            string editedMaSP = Console.ReadLine();
            LOAIHANG[] temp = MangLoaiHang;
            int count = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].LoaiSP == loaiHangCS)
                {
                    temp[i].LoaiSP = editedLoaiHang;
                    temp[i].MaSP = editedMaSP;
                    count++;
                }
            }            
            Console.WriteLine("Đã cập nhật sửa loại hàng như sau:");
            for (int i = 0; i < temp.Length; i++)
            {
                MangLoaiHang[i] = temp[i];
            }
            
            
            if (count == 0)
            {
                Console.WriteLine("Vui lòng nhập đúng loại hàng và nội dung sửa!");
                return false;
            }
            else
            {
                for (int i = 0; i < MSP.Length; i++)
                {
                    if (loaiHangCS == MSP[i].loaiSanPham)
                    {
                        MSP[i].loaiSanPham = editedLoaiHang;
                        MSP[i].maSanPham = editedMaSP;
                    }
                }
            }
            XuatMangLoaiHang(MangLoaiHang, MSP);
            Console.WriteLine("Nhấn phím bất kỳ để xem cập nhật sản phẩm sau khi sửa loại hàng.");
            Console.ReadLine();

            XL_MATHANG.XuatMangSanPham(MSP);
            return true;
        }
        public static bool XoaLoaiHang(ref LOAIHANG[] MangLoaiHang, ref MATHANG[] MSP)
        {
            XuatMangLoaiHang(MangLoaiHang, MSP);
            LOAIHANG[] temp = new LOAIHANG[MangLoaiHang.Length - 1];
            Console.WriteLine("Vui lòng nhập chính xác loại hàng cần xóa bằng chữ - Kèm in hoa và dấu (nếu có):");
            string dlLoaiHang = Console.ReadLine();            
            int index = -1;
            for (int i = 0; i < MangLoaiHang.Length; i++)
            {
                if (MangLoaiHang[i].LoaiSP == dlLoaiHang)
                {
                    index = i;
                }
            }
            if (index >= 0)
            {
                for (int i = 0; i < index; i++)
                {
                    temp[i] = MangLoaiHang[i];
                }
                for (int i = index; i < temp.Length; i++)
                {
                    temp[i] = MangLoaiHang[i + 1];
                }
                Console.WriteLine("Đã cập nhật sau khi xóa.");
                MangLoaiHang = new LOAIHANG[temp.Length];
                MangLoaiHang = temp;
                              
                XL_MATHANG.XoaCacMatHangCungLoaiHang(ref MSP, dlLoaiHang);
                XuatMangLoaiHang(MangLoaiHang, MSP);
                Console.WriteLine("Nhấn phím bất kỳ để xem cập nhật sản phẩm sau khi xóa loại hàng");
                Console.ReadLine();
                XL_MATHANG.XuatMangSanPham(MSP);
            }
            else
            {
                Console.WriteLine("Vui lòng nhập chính xác loại hàng cần xóa!");
            }
            return true;

        }
    }
}
