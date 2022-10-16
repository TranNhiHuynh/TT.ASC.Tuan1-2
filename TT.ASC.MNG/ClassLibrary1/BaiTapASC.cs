using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TT.ASC.DATA
{

    public static class BaiTapASC
    {

        //1. Viết hàm để định dạng ngày tháng năm, giờ phút giây
        public static DateTime FormatDateTime(int day, int month, int year, int hours, int minute, int second)
        {
            DateTime curDate = new DateTime(year, month, day, hours, minute, second);
            return curDate;
        }

        //2. Viết hàm để Đọc dãy số bất kỳ
        public static string ReadNumber(string strNumber)
        {
            string readIS = "";
            for (int i = 0; i < strNumber.Length; i++)
            {
                int number = int.Parse(strNumber[i].ToString());
                switch (number)
                {
                    case 0:
                        readIS += "Không ";
                        break;
                    case 1:
                        readIS += "Một ";
                        break;
                    case 2:
                        readIS += "Hai ";
                        break;
                    case 3:
                        readIS += "Ba ";
                        break;
                    case 4:
                        readIS += "Bốn ";
                        break;
                    case 5:
                        readIS += "Năm ";
                        break;
                    case 6:
                        readIS += "Sáu ";
                        break;
                    case 7:
                        readIS += "Bảy ";
                        break;
                    case 8:
                        readIS += "Tám ";
                        break;
                    case 9:
                        readIS += "Chín ";
                        break;
                }
            }

            return readIS;

        }

        //3. Viết hàm đọc số tiền bất kỳ
        static string[] charNumber = new string[10] { "Không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };
        static string[] charMoney = new string[6] { "", "Nghìn", "Triệu", "Tỷ", "Nghìn Tỷ", "Triệu Tỷ" };
        public static string ReadNumberToMoney(long Money)
        {
            int rain;
            int i;
            string result = "", tmp = "";
            int[] index = new int[6];
            if (Money == 0)
            {
                return "Không Đồng";
            }
            index[5] = (int)(Money / 1000000000000000);
            Money = Money - long.Parse(index[5].ToString()) * 1000000000000000;
            index[4] = (int)(Money / 1000000000000);
            Money = Money - long.Parse(index[4].ToString()) * +1000000000000;
            index[3] = (int)(Money / 1000000000);
            Money = Money - long.Parse(index[3].ToString()) * 1000000000;
            index[2] = (int)(Money / 1000000);
            index[1] = (int)((Money % 1000000) / 1000);
            index[0] = (int)(Money % 1000);

            if (index[5] > 0)
            {
                rain = 5;
            }
            else if (index[4] > 0)
            {
                rain = 4;
            }
            else if (index[3] > 0)
            {
                rain = 3;
            }
            else if (index[2] > 0)
            {
                rain = 2;
            }
            else if (index[1] > 0)
            {
                rain = 1;
            }
            else
            {
                rain = 0;
            }


            for (i = rain; i >= 0; i--)
            {
                tmp = Read3Number(index[i]);
                result += tmp;
                if (index[i] != 0) result += charMoney[i];
                if ((i > 0) && (!string.IsNullOrEmpty(tmp))) result += ",";//&& (!string.IsNullOrEmpty(tmp))
            }
            if (result.Substring(result.Length - 1, 1) == ",") result = result.Substring(0, result.Length - 1);
            result = result.Trim();
            return result.Substring(0, 1).ToUpper() + result.Substring(1);
        }
        public static string Read3Number(int number)
        {
            int tram, chuc, donvi;
            string KetQua = "";
            tram = (int)(number / 100);
            chuc = (int)((number % 100) / 10);
            donvi = number % 10;
            if ((tram == 0) && (chuc == 0) && (donvi == 0)) return "";
            if (tram != 0)
            {
                KetQua += charNumber[tram] + " trăm";
                if ((chuc == 0) && (donvi != 0)) KetQua += " linh";
            }
            if ((chuc != 0) && (chuc != 1))
            {
                KetQua += charNumber[chuc] + " mươi";
                if ((chuc == 0) && (donvi != 0)) KetQua = KetQua + " linh";
            }
            if (chuc == 1) KetQua += " mười";
            switch (donvi)
            {
                case 1:
                    if ((chuc != 0) && (chuc != 1))
                    {
                        KetQua += " mốt";
                    }
                    else
                    {
                        KetQua += charNumber[donvi];
                    }
                    break;
                case 5:
                    if (chuc == 0)
                    {
                        KetQua += charNumber[donvi];
                    }
                    else
                    {
                        KetQua += " lăm";
                    }
                    break;
                default:
                    if (donvi != 0)
                    {
                        KetQua += charNumber[donvi];
                    }
                    break;
            }
            return KetQua;
        }

        //4. Viết hàm tạo chuỗi ngẫu nhiên có 
        public static string RandomString(int stringLength)
        {
            Random rd = new Random();
            const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@$?_-";
            char[] chars = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        //5. Trả về ngày đầu tiên của tháng
        public static DateTime FirstDayOfMonth(int year, int month)
        {
            DateTime curDate = new DateTime(year, month, 1);
            return curDate;

        }

        //6. Trả về ngày cuối cùng của tháng
        public static DateTime LastDayOfMonth(int year, int month)
        {
            DateTime curDate = new DateTime(year, month, 1);
            curDate = curDate.AddMonths(1).AddDays(-1);
            return curDate;

        }
        //7. Trả về ngày đầu tuần của ngày bất kì 
        public static DateTime FirstDayOfWeek(int year, int month, int day)
        {
            DateTime curDate = new DateTime(year, month, day);
            var dayOfWeek = curDate.DayOfWeek;

            if (dayOfWeek == DayOfWeek.Sunday)
            {
                return curDate.AddDays(-6);
            }
            int offset = dayOfWeek - DayOfWeek.Monday;
            return curDate.AddDays(-offset);
        }
        //8. Trả về ngày cuối tuần của ngày bất kì 
        public static DateTime LastDayOfWeek(int year, int month, int day)
        {
            DateTime curDate = new DateTime(year, month, day);
            var dayOfWeek = curDate.DayOfWeek;
            if (dayOfWeek == DayOfWeek.Sunday)
            {
                return curDate;
            }
            int offset = dayOfWeek - DayOfWeek.Sunday;
            return curDate.AddDays((7 - offset + 1));
        }
        //9. Đếm khoảng trắng trong chuỗi
        public static int CountSpace(string str)
        {
            int count = 0;
            string str1;
            for (int i = 0; i < str.Length; i++)
            {
                str1 = str.Substring(i, 1);
                if (str1 == " ")
                    count++;
            }
            return count;
        }
        //10. Kiem tra tinh dung dan cua gmail
        public static Boolean CheckGmail(string gmail)
        {
            if (gmail.Contains("@"))
            {
                return true;
            }
            return false;
        }
        //11. Cắt chuỗi họ tên
        public static void DivName(string fullName, ref string firtName, ref string lastName)
        {
            int index = fullName.LastIndexOf(" ");
            firtName = fullName.Substring(0, index);
            lastName = fullName.Substring(index + 1);
        }
        //12. Tìm hiểu các hàm làm tròn Round,Truncate,Celling,Floor
        public static void RoundNumber(double number, ref double Round, ref double Truncate, ref double Ceiling, ref double Floor)
        {
            Round = Math.Round(number);
            Truncate = Math.Truncate(number);
            Ceiling = Math.Ceiling(number);
            Floor = Math.Floor(number);
        }
        //13. Viết hoa chữ cái đầu của mỗi chữ trong tên
        public static string toUperName(string fullName)
        {
            if (String.IsNullOrEmpty(fullName))
            {
                return fullName;
            }
            string result = "";

            string[] words = fullName.Split(' ');
            foreach (string word in words)
            {

                if (word.Trim() != "")
                {
                    if (word.Length > 1)
                    {
                        result += word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower() + " ";
                    }
                    else
                    {
                        result += word.ToUpper() + " ";
                    }
                }
            }
            return result.Trim();

        }
        //14. Đếm trong chuỗi có bao nhiêu kí tự 

        public static int CountChar(string Pstring, string Px, int[] Pindex)
        {
            int count = 0;
            string str1;
            int index = 0;
            for (int i = 0; i < Pstring.Length; i++)
            {
                str1 = Pstring.Substring(i, 1);
                if (str1 == Px.ToLower() || str1 == Px.ToUpper())
                {
                    count++;
                    Pindex[index] = i;
                    index++;
                }
            }
            return count;
        }

        public static string RandomName()
        {
            string[] ho = new string[] { "Nguyễn", "Trần", "Lê", "Hồ" };
            string[] dem = new string[] { "Văn", "Thanh", "Hoàng", "Thị", "Kim", "Ngọc" };
            string[] ten = new string[] { "Nhân", "Hậu", "Nghĩa", "Lễ", "Trí", "Tín", "Trang", "Thúy", "Phương", "Hiếu" };

            Random random = new Random();
            int rdHo = random.Next(0, ho.Length - 1);
            int rdDem = random.Next(0, dem.Length - 1);
            int rdTen = random.Next(0, ten.Length - 1);

            string FullName = ho[rdHo] + " " + dem[rdDem] + " " + ten[rdTen];
            return FullName;
        }

        public static void Main(string[] args)
        {
            /*
                Console.WriteLine(FormatDateTime(10, 10, 2022, 13, 01, 55)); // Tham số lần lượt là ngày-tháng-năm-giờ-phút-giây
                Console.WriteLine(ReadNumber("123456789"));
                Console.WriteLine(ReadNumberToMoney(1000000));
                Console.WriteLine(RandomString(12));
                Console.WriteLine(FirstDayOfMonth(2022, 10));
                Console.WriteLine(LastDayOfMonth(2022, 10));
                Console.WriteLine(FirstDayOfWeek(2022, 10, 12));
                Console.WriteLine(LastDayOfWeek(2022, 10, 12));
                Console.WriteLine(CountSpace("Hoa No Khong Mau"));
                Console.WriteLine(CheckGmail("trannhihuynh10@gmail.com"));
                string firtName = "", lastName = "";
                DivName("Trần Nhị Huynh", ref firtName, ref lastName);
                Console.WriteLine("Họ đệm:" + firtName);
                Console.WriteLine("Tên:" + lastName);
                double round = 0, truncate = 0, ceiling = 0, floor = 0;
                RoundNumber(5.2, ref round, ref truncate, ref ceiling, ref floor);
                Console.WriteLine(round + " " + truncate + " " + ceiling + " " + floor);
                Console.WriteLine(toUperName("tRan nHi huyNH"));
                int[] index = new int[50];
                int count = CountChar("Tran Nhi Huynh", "n", index);
                Console.WriteLine("So luong :" + count);
                Console.WriteLine("O cac vi tri :");
                for (int i = 0; i < count; i++)
                {
                    Console.Write(index[i]);
                    Console.Write(" ");
                }
                Console.WriteLine();
                Console.WriteLine(RandomName());
               */
            QuanLy QL = new QuanLy();
            List<LopHoc> lstLopHoc = QL.CreateListLopHoc(4);
            foreach (var lh in lstLopHoc)
            {
                Console.WriteLine("Thong tin lop hoc :");
                Console.WriteLine("ID: " + lh.ID);
                Console.WriteLine("Ma lop: " + lh.MaLop);
                Console.WriteLine("Ten lop: " + lh.TenLop);
                Console.WriteLine("So luong: " + lh.SoLuong);
                Console.WriteLine("Nam mo lop: " + lh.NamMoLop);
                Console.WriteLine("Co so dao tao: " + lh.CoSoDaoTao);
                Console.WriteLine("Hien thi: " + lh.HienThi);
            }

            List<SinhVien> lstSV = QL.CreateListSinhVien(14,lstLopHoc);
            Console.WriteLine("=============================================");
            foreach (var sv in lstSV)
            {
                Console.WriteLine("Thong tin sinh vien :");
                Console.WriteLine("ID: " +sv.ID);
                Console.WriteLine("Ma SV: " + sv.MaSV);
                Console.WriteLine("Ho dem: " + sv.HoDem);
                Console.WriteLine("Ten SV: " + sv.TenSV);
                Console.WriteLine("Gioi tinh: " + sv.GioiTinh);
                Console.WriteLine("Lop hoc: " + sv.LopHoc);
            }
            Console.ReadLine();

        }

    }
    public class BasePerson
    {
        public int ID { get; set; }
        public string Ma { get; set; }
        public string Name { get; set; }

        public BasePerson()
        {
            ID = 0;
            Ma = "";
            Name = "";
        }
        
        public BasePerson(int ID, string Ma, string Name)
        {
            this.ID = ID;
            this.Ma = Ma;
            this.Name = Name;
        }
        
        public  BasePerson Copy()
        {
            return new BasePerson(this.ID, this.Ma, this.Name);
        }

        public bool Compare(BasePerson Pbps)
        {
            if (this.ID == Pbps.ID && this.Ma == Pbps.Ma && this.Name == Pbps.Name)
                return true;
            return false;
        }

        public  void Print()
        {
            Console.WriteLine("ID là :" + this.ID);
            Console.WriteLine("Mã là :" + this.Ma);
            Console.WriteLine("Tên là :" + this.Name);
            Console.ReadLine();

        }

        public  bool ValidateData(string Ma, string Name)
        {
            if (this.Ma != null && this.Name != null)
                return true;
            return true;
        }

    }

    public class LopHoc
    {
        public int ID { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public int SoLuong { get; set; }
        public int NamMoLop { get; set; }
        public int CoSoDaoTao { get; set; }
        public bool HienThi { get; set; }

        public LopHoc()
        {   
            ID = 0;
            MaLop = "";
            TenLop = "";
            SoLuong = 0;
            NamMoLop = 0;
            CoSoDaoTao = 0;
            HienThi = false;
        }
        public LopHoc(int ID, string MaLop, string TenLop, int SoLuong, int NamMoLop, int CoSoDaoTao , bool HienThi )
        {
            this.ID = ID;
            this.MaLop = MaLop;
            this.TenLop = TenLop;
            this.SoLuong = SoLuong;
            this.NamMoLop = NamMoLop;
            this.CoSoDaoTao = CoSoDaoTao;
            this.HienThi = HienThi;
        }

        public LopHoc Copy()
        {
            return new LopHoc(this.ID, this.MaLop,this.TenLop,this.SoLuong,this.NamMoLop,this.CoSoDaoTao,this.HienThi);
        }

        public bool Compare(LopHoc PLop)
        {
            if (this.ID == PLop.ID && this.MaLop ==PLop.MaLop && this.SoLuong == PLop.SoLuong &&
             this.NamMoLop == PLop.NamMoLop && this.CoSoDaoTao ==PLop.CoSoDaoTao && this.HienThi == PLop.HienThi)
                return true;
            return false;
        }

        public void Print()
        {
            Console.WriteLine("ID: " + this.ID);
            Console.WriteLine("Mã lớp: " + this.MaLop);
            Console.WriteLine("Tên lớp: " + this.TenLop);
            Console.WriteLine("Số lượng: " + this.SoLuong);
            Console.WriteLine("Năm mở lớp: " + this.NamMoLop);
            Console.WriteLine("Cơ sở đào tạo: " + this.CoSoDaoTao);
            Console.WriteLine("Hiển thị: " + this.HienThi);
            Console.ReadLine();

        }

        public bool ValidateData(string Ma, string Name)
        {
            if (this.MaLop != null && this.TenLop != null)
                return true;
            return true;
        }
    }

    public class SinhVien 
    {
        public int ID { get; set; }
        public string MaSV { get; set; }
        public string HoDem { get; set; }
        public string TenSV { get; set; }
        public int GioiTinh { get; set; }
        public int LopHoc { get; set; }

        public SinhVien()
        {
            ID= 0;
            MaSV = "";
            HoDem = "";
            TenSV = "";
            GioiTinh = 0;
            LopHoc = 0;
        }

        public SinhVien(int ID, string MaSV, string HoDem, string TenSV, int GioiTinh, int LopHoc)
        {
            this.ID = ID;
            this.MaSV = MaSV;
            this.HoDem = HoDem;
            this.TenSV = TenSV;
            this.GioiTinh = GioiTinh;
            this.LopHoc = LopHoc;
        }

        public SinhVien Copy()
        {
            return new SinhVien(this.ID, this.MaSV, this.HoDem, this.TenSV, this.GioiTinh, this.LopHoc);
        }

        public bool Compare(SinhVien PSV)
        {
            if (this.ID == PSV.ID && this.MaSV == PSV.MaSV && this.HoDem == PSV.HoDem &&
           this.TenSV == PSV.TenSV && this.GioiTinh == PSV.GioiTinh && this.LopHoc == PSV.LopHoc)
                return true;
            return false;
        }

        public void Print()
        {
            Console.WriteLine("ID: " + this.ID);
            Console.WriteLine("Mã SV: " + this.MaSV);
            Console.WriteLine("Họ đệm: " + this.HoDem);
            Console.WriteLine("Tên SV: " + this.TenSV);
            Console.WriteLine("Giới tính: " + this.GioiTinh);
            Console.WriteLine("Lớp học: " + this.LopHoc);
            Console.ReadLine();

        }

        public bool ValidateData(string Ma, string Name)
        {
            if (this.MaSV != null && this.HoDem != null && this.TenSV != null)
                return true;
            return true;
        }
    }   
    
    public class QuanLy
    {
        public List<BasePerson> CreateListBase(int PAmount)
        {
            List<BasePerson> LstBase = new List<BasePerson>(PAmount);
            return LstBase;
        }
        public string RandomLopHoc()
        {
            string[] khoa = new string[] { "07", "08", "09", "10","11","12" };
            string[] nganh = new string[] { "DHTH", "DHTP", "QTKD", "DHAV", "DLAT&LH", "DHCK" };
            string[] index = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

            Random random = new Random();
            int rdKhoa = random.Next(0, khoa.Length - 1);
            int rdNganh = random.Next(0, nganh.Length - 1);
            int rdIndex = random.Next(0, index.Length - 1);

            string FullName = khoa[rdKhoa] + "" + nganh[rdNganh] + "" + index[rdIndex];
            return FullName;
        }

        public bool CheckMaLop(string PMaLop,  List<LopHoc> Plst)
        {
            foreach(var lh in Plst)
            {
                if (lh.MaLop == PMaLop)
                    return false;
            }

            return true;
        }
        public bool CheckMaSV(string PMaSV, List<SinhVien> Plst)
        {
            foreach (var sv in Plst)
            {
                if (sv.MaSV == PMaSV)
                    return false;
            }

            return true;
        }
        public bool CheckTenLop(string PTenLop, List<LopHoc> Plst)
        {
            foreach (var lh in Plst)
            {
                if (lh.MaLop == PTenLop)
                    return false;
            }

            return true;
        }
        public List<LopHoc> CreateListLopHoc(int PAmount)
        {
            List<LopHoc> LstLopHoc = new List<LopHoc>(PAmount);
            Random rd = new Random();
            for(int i =0; i< PAmount; i++)
            {
                string MaLop;
                do
                {
                    MaLop = rd.Next(100, 999).ToString();
                } while (CheckMaLop(MaLop, LstLopHoc) == false); 

                string TenLop;
                do
                {
                    TenLop = RandomLopHoc();
                } while (CheckTenLop(TenLop, LstLopHoc) == false);

                int NamMoLop = rd.Next(2017, 2023);
                int CoSoDaoTao = rd.Next(1, 4);
                int rdHienThi = rd.Next(1, 2);
                bool HienThi;
                if(rdHienThi == 1 )
                {
                    HienThi = true;
                }
                else
                {
                    HienThi = false;
                }
                LopHoc lh = new LopHoc(i+1,MaLop,TenLop,20,NamMoLop,CoSoDaoTao,HienThi);
                LstLopHoc.Add(lh);
            }

            return LstLopHoc;
        }
        public List<SinhVien> CreateListSinhVien(int PAmount, List<LopHoc> lstLopHoc)
        {
            List<SinhVien> listSV = new List<SinhVien>(PAmount);
            Random rd = new Random();
            string[] ho = new string[] { "Nguyễn", "Trần", "Lê", "Hồ" };
            string[] dem = new string[] { "Văn", "Thanh", "Hoàng", "Thị", "Kim", "Ngọc" };
            string[] ten = new string[] { "Nhân", "Hậu", "Nghĩa", "Lễ", "Trí", "Tín", "Trang", "Thúy", "Phương", "Hiếu" };
            int flag = rd.Next(1,2);
            for (int i = 0; i < PAmount; i++)
            {
                string MaSV;
                do
                {
                    MaSV = rd.Next(100, 999).ToString();
                } while (CheckMaSV(MaSV,listSV) == false);

                int rdHo = rd.Next(0, ho.Length - 1);
                int rdDem = rd.Next(0, dem.Length - 1);
                int rdTen = rd.Next(0, ten.Length - 1);
                int LopHoc = rd.Next(1, lstLopHoc.Count());
                string HoDem = ho[rdHo] + " " + dem[rdDem];
                string TenSV = ten[rdTen];
                int GioiTinh;
                do {
                    GioiTinh = rd.Next(1, 3); //0 : Nam - 1: Nữ
                } while (GioiTinh == flag);
                flag = GioiTinh;
                SinhVien sv = new SinhVien(i + 1, MaSV, HoDem, TenSV, GioiTinh, LopHoc);
                listSV.Add(sv);
            }
            return listSV;
        }
    }



}
