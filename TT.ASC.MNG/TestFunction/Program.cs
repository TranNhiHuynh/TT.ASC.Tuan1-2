// See https://aka.ms/new-console-template for more information

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
        for(int i = 0; i < strNumber.Length; i++)
        {
            int number = int.Parse(strNumber[i].ToString());
            switch(number)
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
        string result = "", tmp ="";
        int[] index = new int[6];
        if(Money == 0)
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
    static void Main(string[] args)
    {
        Console.WriteLine(FormatDateTime(10,10,2022,13,01,55)); // Tham số lần lượt là ngày-tháng-năm-giờ-phút-giây
        Console.WriteLine(ReadNumber("123456789"));
        Console.WriteLine(ReadNumberToMoney(1000000));
    }
}
