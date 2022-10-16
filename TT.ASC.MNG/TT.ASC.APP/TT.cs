namespace TT.ASC.APP
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
   public static string ReadNumberToMoney(int Money)
        {
            string[] charNumber = new string[10] { "Không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };
            string[] charMoney = new string[6] { "", "Nghìn", "Triệu", "Tỷ", "Nghìn Tỷ", "Triệu Tỷ" };
            int rain;
            int index;
            string result = "", tmp = "";
            if (Money == 0)
            {
                return "Không Đồng";
            }

            return "";
        }

        static void Main(string[] args)
        {
            Console.WriteLine(FormatDateTime(10, 10, 2022, 13, 01, 55)); // Tham số lần lượt là ngày-tháng-năm-giờ-phút-giây
            Console.WriteLine(ReadNumber("123456789"));
        }
    }
}
