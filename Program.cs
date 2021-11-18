using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_NMLT
{         
    class Program
    {                       
        static void Main(string[] args)
        {
            #region Yêu cầu đồ án
            /*
             Đồ án NMLT
            Deadline: 6:00PM, 17/11/2021

             Viết phần mềm quản lý cửa hàng với các chức năng sau:
            - Thêm, xóa, sửa và tìm kiếm các mặt hàng (mã, tên hàng, hạn dùng, công ty sản xuất, năm sản xuất, loại hàng).
            - Thêm, xóa, sửa và tìm kiếm các loại hàng.

            Chú ý:
            - Làm với giao diện console hoặc windows form
            - Các dữ liệu không cần lưu trữ lại
             */
            #endregion
            
            Console.OutputEncoding = Encoding.UTF8;
            #region Tạo trước các struct sản phẩm
            MATHANG A = new MATHANG("KH-SP2021", "Sony XZ Premium", new NGAY(20, 10, 2024), "Sony", 2021, "Smartphone");
            MATHANG A1 = new MATHANG("KH-SP2021", "Samsung Note 10", new NGAY(20, 10, 2030), "Samsung", 2019, "Smartphone");
            MATHANG A2 = new MATHANG("KH-SP2021", "Nokia 6800", new NGAY(20, 10, 2030), "Nokia", 2018, "Smartphone");
            MATHANG A3 = new MATHANG("KH-SP2021", "iPhone 10 Plus", new NGAY(10, 12, 2025), "Apple", 2021, "Smartphone");
            MATHANG B = new MATHANG("KH-LT2021", "Dell XPS", new NGAY(20, 10, 2030), "Dell", 2020, "Laptop");
            MATHANG B1 = new MATHANG("KH-LT2021", "HP Probook 430", new NGAY(22, 10, 2030), "HP", 2021, "Laptop");
            MATHANG C = new MATHANG("KH-SK2021", "Nike Airmax", new NGAY(20, 10, 2026), "Nike", 2021, "Sneaker");
            MATHANG C1 = new MATHANG("KH-SK2021", "Addidas Fluidstreet", new NGAY(20, 10, 2026), "Addidas", 2020, "Sneaker");
            MATHANG C2 = new MATHANG("KH-SK2021", "Addidas Ultraboost", new NGAY(20, 10, 2026), "Addidas", 2018, "Sneaker");
            MATHANG D = new MATHANG("KH-V2021", "Ví handmade", new NGAY(20, 10, 2026), "PUS-LEATHER", 2019, "Ví");
            MATHANG D1 = new MATHANG("KH-V2021", "Ví da", new NGAY(20, 10, 2026), "PUS-LEATHER", 2020, "Ví");
            MATHANG D2 = new MATHANG("KH-V2021", "Ví ATM", new NGAY(20, 10, 2026), "PUS-LEATHER", 2021, "Ví");
            #endregion
            #region Tạo mảng sản phẩm
            MATHANG[] SP0 = new MATHANG[12];
            SP0[0] = A;
            SP0[1] = A1;
            SP0[2] = A2;
            SP0[3] = A3;
            SP0[4] = B;
            SP0[5] = B1;
            SP0[6] = C;
            SP0[7] = C1;
            SP0[8] = C2;
            SP0[9] = D;
            SP0[10] = D1;
            SP0[11] = D2;
            #endregion
            #region Tạo mảng loại hàng
            LOAIHANG[] LH = new LOAIHANG[4];
            LH[0] = new LOAIHANG("Smartphone", "KH-SP2021");
            LH[1] = new LOAIHANG("Laptop", "KH-LT2021");
            LH[2] = new LOAIHANG("Sneaker", "KH-SK2021");
            LH[3] = new LOAIHANG("Ví", "KH-V2021");
            #endregion

            MATHANG[] MH = SP0;
            bool finished = false;
            do
            {
                #region Menu
                Console.WriteLine("==================================");
                Console.WriteLine("||        QUẢN LÝ CỬA HÀNG       ||               Phạm Xuân Khiêm MSSV 21880067");
                Console.WriteLine("==================================");
                Console.WriteLine("|| 0 - Xem tất cả mặt hàng.      ||");
                Console.WriteLine("|| 1 - Thêm mặt hàng.            ||");
                Console.WriteLine("|| 2 - Xóa mặt hàng.             ||");
                Console.WriteLine("|| 3 - Sửa mặt hàng              ||");
                Console.WriteLine("|| 4 - Tìm mặt hàng.             ||");
                Console.WriteLine("||             ***               ||");
                Console.WriteLine("|| 5 - Tìm kiếm theo loại hàng.  ||");
                Console.WriteLine("|| 6 - Thêm mới loại hàng.       ||");
                Console.WriteLine("|| 7 - Sửa loại hàng.            ||");
                Console.WriteLine("|| 8 - Xóa loại hàng.            ||");
                Console.WriteLine("============|| *** || ===========||");
                Console.WriteLine("Nhập số 0 để xem toàn bộ hàng trong cửa hàng");
                Console.WriteLine("Chọn thao tác cần xử lý bằng cách nhập số tương ứng từ 1 đến 8.");
                #endregion

                int option = int.Parse(Console.ReadLine());              

                switch (option)
                {
                    case 0:
                        XL_MATHANG.XuatMangSanPham(MH);
                        Console.WriteLine("********************************************");
                        Console.WriteLine("Ấn phím Enter để tiếp tục");
                        Console.ReadLine();

                        break;
                    case 1:
                        XL_MATHANG.ThemSPTrongMangSP(ref MH, ref LH);
                        Console.WriteLine("********************************************");
                        Console.WriteLine("Ấn phím Enter để tiếp tục");
                        Console.ReadLine();
                        
                        break;
                    case 2:
                        XL_MATHANG.XoaSPTrongMangSP(ref MH);
                        Console.WriteLine("********************************************");
                        Console.WriteLine("Ấn phím Enter để tiếp tục");
                        Console.ReadLine();
                        
                        break;
                    case 3:
                        XL_MATHANG.SuaSPTrongMangSP(ref MH, ref LH);
                        Console.WriteLine("*********************************************");
                        Console.WriteLine("Ấn phím Enter để tiếp tục");
                        Console.ReadLine();
                        
                        break;
                    case 4:
                        XL_MATHANG.TimSanPham(ref MH);
                        Console.WriteLine("*********************************************");
                        Console.WriteLine("Ấn phím Enter để tiếp tục");
                        Console.ReadLine();
                        
                        break;
                    case 5:
                        XL_LOAIHANG.TimTheoLoaiHang(LH, MH);
                        Console.WriteLine("********************************************");
                        Console.WriteLine("Ấn phím Enter để tiếp tục");
                        Console.ReadLine();

                        break;
                    case 6:
                        XL_LOAIHANG.ThemLoaiHang(ref LH, ref MH);
                        Console.WriteLine("********************************************");
                        Console.WriteLine("Ấn phím Enter để tiếp tục");
                        Console.ReadLine();

                        break;
                    case 7:
                        XL_LOAIHANG.SuaLoaiHang(ref LH, ref MH);
                        Console.WriteLine("********************************************");
                        Console.WriteLine("Ấn phím Enter để tiếp tục");
                        Console.ReadLine();

                        break;
                    case 8:
                        XL_LOAIHANG.XoaLoaiHang(ref LH, ref MH);
                        Console.WriteLine("********************************************");
                        Console.WriteLine("Ấn phím Enter để tiếp tục");
                        Console.ReadLine();

                        break;
                }


                Console.WriteLine("Nhập 'y' -- [Tiếp tục] để quay lại Menu thao tác hoặc nhập 'n' -- [Hủy bỏ] để thoát chương trình.");
                char c = char.Parse(Console.ReadLine());
                if (c == 'y')
                {
                    finished = false;
                }
                else if(c == 'n')
                {
                    finished = true;
                }                
            } while (finished == false);










        }






    }
}
