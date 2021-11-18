using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_NMLT
{
    public struct NGAY
    {
        public int date;
        public int month;
        public int year;
        public NGAY(int date, int month, int year)
        {
            this.date = date;
            this.month = month;
            this.year = year;
        }
    }

    class XL_NGAY
    {
        public static NGAY NhapNgay(string ghiChu)
        {
            NGAY n;
            Console.WriteLine(ghiChu);
            Console.WriteLine("Nhập ngày:");
            n.date = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập tháng:");
            n.month = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập năm:");
            n.year = int.Parse(Console.ReadLine());
            while (KiemTraNhapNgayTrongThang(n.date, n.month, n.year) == false)
            {
                Console.WriteLine("Nhập lại ngày:");
                n.date = int.Parse(Console.ReadLine());             
            }

            return n;
        }
        public static string XuatNgay(NGAY n)
        {
            return ($"{n.date}/{n.month}/{n.year}");
        }
        public static bool KiemTraNhapNgayTrongThang(int ngay, int thang, int nam)
        {
            if (thang == 4 || thang == 6 || thang == 9 || thang == 11)
            {
                if (ngay > 31)
                {
                    Console.WriteLine("Số ngày tối đa trong tháng này là 31 ngày.");
                    return false;
                }
            }
            else if (thang == 2)
            {
                if ((nam % 400 == 00) || (nam % 4 == 0 && nam % 100 != 0))
                {
                    if (ngay > 29)
                    {
                        Console.WriteLine("Số ngày tối đa trong tháng này là 29 ngày.");
                        return false;
                    }
                }
                else
                {
                    if (ngay > 28)
                    {
                        Console.WriteLine("Số ngày tối đa trong tháng này là 28 ngày");
                        return false;
                    }
                }
            }
            else
            {
                if (ngay > 30)
                {
                    Console.WriteLine("Số ngày tối đa trong tháng này là 30 ngày.");
                    return false;
                }
            }
            return true;
        }
    }
}
