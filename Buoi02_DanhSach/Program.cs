using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

struct NhanVien
{
    public string MaNV;
    public string Hoten;
    public int Namsinh;
    public string Phongban;
    public int LuongCB;
    public int Thuong;
}

class Node
{
    public int data;
    public Node next;

    public Node(int data)
    {
        this.data = data;
        this.next = null;
    }
}

class DNode
{
    public string data;
    public DNode prev;
    public DNode next;

    public DNode(string data)
    {
        this.data = data;
        this.prev = null;
        this.next = null;
    }
}

class DonHang
{
    public string MaDon;
    public DNode TrangThai;
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===Bai1Chuong4===");
        Bai1Chuong4();
        Console.WriteLine("===Bai2Chuong4===");
        Bai2Chuong4();
        Console.WriteLine("===Bai3Chuong4===");
        Bai3Chuong4();
        Console.WriteLine("===Bai4Chuong4===");
        Bai4Chuong4();
        Console.WriteLine("===Bai5Chuong4===");
        Bai5Chuong4();
        Console.WriteLine("===Bai7Chuong2===");
        Bai7Chuong2();
        Console.WriteLine("===Bai8Chuong2===");
        Bai8Chuong2();
        Console.WriteLine("===Bai9Chuong2===");
        Bai9Chuong2();
        Console.WriteLine("===Bai10Chuong2===");
        Bai10Chuong2();
        Console.WriteLine("===Bai11Chuong2===");
        Bai11Chuong2();
        Console.WriteLine("===Bai12Chuong2===");
        Bai12Chuong2();
        Console.WriteLine("===Bai13Chuong2===");
        Bai13Chuong2();
        Console.WriteLine("===Bai14Chuong2===");
        Bai14Chuong2();
        Console.WriteLine("===Bai15Chuong2===");
        Bai15Chuong2();
        Console.WriteLine("===Bai16Chuong2===");
        Bai16Chuong2();
        Console.WriteLine("===Bai17Chuong2===");
        Bai17Chuong2();
        Console.WriteLine("===Bai18Chuong2===");
        Bai18Chuong2();
    }

    static void Bai1Chuong4()
    {
        Console.Write("Nhap so phan tu n: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("a[" + i + "] = ");
            arr[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("day so vua nhap la: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
        Console.Write("Nhap gia tri can chen: ");
        int x = int.Parse(Console.ReadLine());
        Console.Write("Nhap vi tri can chen: ");
        int k = int.Parse(Console.ReadLine());
        int[] tmp = new int[arr.Length + 1];
        for (int i = 0; i < k; i++)
        {
            tmp[i] = arr[i];
        }
        tmp[k] = x;
        for (int i = k; i < arr.Length; i++)
        {
            tmp[i + 1] = arr[i];
        }
        arr = tmp;
        Console.WriteLine("day so sau khi chen la: ");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }

    static void Bai2Chuong4()
    {
        NhanVien[] DS = null;

        void Nhap()
        {
            Console.Write("Nhap so nhan vien: ");
            int n = int.Parse(Console.ReadLine());
            DS = new NhanVien[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhan vien thu " + (i + 1) + ":");
                Console.Write("  Ma NV: "); DS[i].MaNV = Console.ReadLine();
                Console.Write("  Ho ten: "); DS[i].Hoten = Console.ReadLine();
                Console.Write("  Nam sinh: "); DS[i].Namsinh = int.Parse(Console.ReadLine());
                Console.Write("  Phong ban: "); DS[i].Phongban = Console.ReadLine();
                Console.Write("  Luong CB: "); DS[i].LuongCB = int.Parse(Console.ReadLine());
                Console.Write("  Thuong: "); DS[i].Thuong = int.Parse(Console.ReadLine());
            }
        }

        int ThucLinh(int x)
        {
            return DS[x].LuongCB + DS[x].Thuong;
        }

        void InNV(int i)
        {
            Console.WriteLine(DS[i].MaNV + " | " + DS[i].Hoten + " | " + DS[i].Namsinh +
                              " | " + DS[i].Phongban + " | " + DS[i].LuongCB +
                              " | " + DS[i].Thuong + " | " + ThucLinh(i));
        }

        long TongThucLinh()
        {
            long tong = 0;
            for (int i = 0; i < DS.Length; i++)
                tong += ThucLinh(i);
            return tong;
        }

        void LuongCBThapNhat()
        {
            int min = int.MaxValue;
            for (int i = 0; i < DS.Length; i++)
                if (min > DS[i].LuongCB)
                    min = DS[i].LuongCB;

            for (int i = 0; i < DS.Length; i++)
                if (DS[i].LuongCB == min)
                    InNV(i);
        }

        int DemThuong()
        {
            int dem = 0;
            for (int i = 0; i < DS.Length; i++)
                if (DS[i].Thuong >= 1200000)
                    dem++;
            return dem;
        }

        void SapXep()
        {
            for (int i = 0; i < DS.Length - 1; i++)
                for (int j = i + 1; j < DS.Length; j++)
                {
                    int ss = string.Compare(DS[i].Phongban, DS[j].Phongban);
                    bool doiCho = false;
                    if (ss > 0) doiCho = true;
                    else if (ss == 0 && string.Compare(DS[i].MaNV, DS[j].MaNV) < 0)
                        doiCho = true;

                    if (doiCho)
                    {
                        NhanVien tg = DS[i];
                        DS[i] = DS[j];
                        DS[j] = tg;
                    }
                }
        }

        void TangLuong()
        {
            for (int i = 0; i < DS.Length; i++)
                DS[i].LuongCB = (int)(DS[i].LuongCB * 1.05);
        }

        Nhap();

        Console.WriteLine("a. Tong thuc linh: " + TongThucLinh());

        Console.WriteLine("b. Nhan vien co luong CB thap nhat:");
        LuongCBThapNhat();

        Console.WriteLine("c. So nhan vien co thuong >= 1200000: " + DemThuong());

        SapXep();
        Console.WriteLine("d. Danh sach sau khi sap xep:");
        for (int i = 0; i < DS.Length; i++) InNV(i);

        TangLuong();
        Console.WriteLine("e. Danh sach sau khi tang luong 5%:");
        for (int i = 0; i < DS.Length; i++) InNV(i);
    }

    static void Bai3Chuong4()
    {
        int[,] a = new int[100, 100];
        int n = 0;

        void Nhap()
        {
            do
            {
                Console.Write("Nhap n (0 <= n < 100): ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n >= 100);

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.Write("a[" + i + "," + j + "] = ");
                    a[i, j] = int.Parse(Console.ReadLine());
                }
        }

        void HienThi()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(a[i, j] + "\t");
                Console.WriteLine();
            }
        }

        long TongTatCa()
        {
            long t = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    t += a[i, j];
            return t;
        }

        int DuongNhoNhat()
        {
            int min = int.MaxValue;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (a[i, j] > 0 && a[i, j] < min)
                        min = a[i, j];
            return min;
        }

        long TongCheoPhu()
        {
            long t = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (j == (n - 1) - i)
                        t += a[i, j];
            return t;
        }

        bool CheoChinhTangDan()
        {
            int[] tg = new int[n];
            for (int i = 0; i < n; i++)
                tg[i] = a[i, i];

            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (tg[i] >= tg[j])
                        return false;
            return true;
        }

        Nhap();
        Console.WriteLine("Ma tran:");
        HienThi();

        Console.WriteLine("a. Tong tat ca phan tu: " + TongTatCa());

        int kq = DuongNhoNhat();
        if (kq == int.MaxValue) Console.WriteLine("b. Khong co so duong");
        else Console.WriteLine("b. Gia tri duong nho nhat: " + kq);

        Console.WriteLine("c. Tong duong cheo phu: " + TongCheoPhu());

        if (CheoChinhTangDan()) Console.WriteLine("d. Duong cheo chinh tang dan");
        else Console.WriteLine("d. Duong cheo chinh KHONG tang dan");
    }

    static void Bai4Chuong4()
    {
        Node pHead = null;

        void Nhap()
        {
            Console.Write("Nhap so phan tu: ");
            int n = int.Parse(Console.ReadLine());
            Node tail = null;
            for (int i = 0; i < n; i++)
            {
                Console.Write("Phan tu thu " + i + ": ");
                Node p = new Node(int.Parse(Console.ReadLine()));
                if (pHead == null)
                    pHead = tail = p;
                else
                {
                    tail.next = p;
                    tail = p;
                }
            }
        }

        void HienThi()
        {
            for (Node p = pHead; p != null; p = p.next)
                Console.Write(p.data + " ");
            Console.WriteLine();
        }

        int DemBangX(int x)
        {
            int d = 0;
            for (Node p = pHead; p != null; p = p.next)
                if (p.data == x)
                    d = d + 1;
            return d;
        }

        int DuongNhoNhat()
        {
            int minduong = int.MaxValue;
            for (Node p = pHead; p != null; p = p.next)
                if (p.data > 0 && p.data < minduong)
                    minduong = p.data;
            return minduong;
        }

        bool XoaX(int x)
        {
            Node p = pHead;
            Node t = null;

            while (p != null && p.data != x)
            {
                t = p;
                p = p.next;
            }

            if (p == null)
                return false;

            if (p == pHead)
                pHead = p.next;
            else
                t.next = p.next;

            return true;
        }

        Nhap();
        Console.Write("Danh sach: ");
        HienThi();

        Console.Write("Nhap x: ");
        int giaTri = int.Parse(Console.ReadLine());

        Console.WriteLine("a. So phan tu bang x: " + DemBangX(giaTri));

        int kq = DuongNhoNhat();
        if (kq == int.MaxValue)
            Console.WriteLine("b. Khong co so duong");
        else
            Console.WriteLine("b. Phan tu duong nho nhat: " + kq);

        if (XoaX(giaTri))
        {
            Console.Write("c. Danh sach sau khi xoa x dau tien: ");
            HienThi();
        }
        else
            Console.WriteLine("c. Khong tim thay x de xoa");
    }

    static void Bai5Chuong4()
    {
        Node l = null;

        void Nhap()
        {
            Console.Write("Nhap so phan tu: ");
            int n = int.Parse(Console.ReadLine());
            Node tail = null;
            for (int i = 0; i < n; i++)
            {
                Console.Write("Phan tu thu " + i + ": ");
                Node p = new Node(int.Parse(Console.ReadLine()));
                if (l == null)
                    l = tail = p;
                else
                {
                    tail.next = p;
                    tail = p;
                }
            }
        }

        void HienThi()
        {
            for (Node p = l; p != null; p = p.next)
                Console.Write(p.data + " ");
            Console.WriteLine();
        }

        int LonNhat()
        {
            int max = int.MinValue;
            for (Node p = l; p != null; p = p.next)
                if (p.data > max)
                    max = p.data;
            return max;
        }

        long Tong()
        {
            long t = 0;
            for (Node p = l; p != null; p = p.next)
                t = t + p.data;
            return t;
        }

        bool KTNT(int x)
        {
            if (x < 2) return false;
            for (int i = 2; i * i <= x; i++)
                if (x % i == 0)
                    return false;
            return true;
        }

        int DemNguyenTo()
        {
            int dem = 0;
            for (Node p = l; p != null; p = p.next)
                if (KTNT(p.data))
                    dem = dem + 1;
            return dem;
        }

        void DemAmDuongKhong(out int am, out int duong, out int khong)
        {
            am = 0; duong = 0; khong = 0;
            for (Node p = l; p != null; p = p.next)
            {
                if (p.data < 0) am++;
                else if (p.data > 0) duong++;
                else khong++;
            }
        }

        int DemBangX(int x)
        {
            int d = 0;
            for (Node p = l; p != null; p = p.next)
                if (p.data == x)
                    d = d + 1;
            return d;
        }

        int DuongNhoNhat()
        {
            int minduong = int.MaxValue;
            for (Node p = l; p != null; p = p.next)
                if (p.data > 0 && p.data < minduong)
                    minduong = p.data;
            return minduong;
        }

        Nhap();
        Console.Write("Danh sach: ");
        HienThi();

        if (l == null)
        {
            Console.WriteLine("Danh sach rong");
            return;
        }

        Console.WriteLine("a. Phan tu lon nhat: " + LonNhat());
        Console.WriteLine("b. Tong cac phan tu: " + Tong());
        Console.WriteLine("c. So nguyen to: " + DemNguyenTo());

        int soAm, soDuong, soKhong;
        DemAmDuongKhong(out soAm, out soDuong, out soKhong);
        Console.WriteLine("d. Am: " + soAm + ", Duong: " + soDuong + ", Khong: " + soKhong);

        Console.Write("Nhap x: ");
        int giaTri = int.Parse(Console.ReadLine());
        Console.WriteLine("e. So phan tu bang x: " + DemBangX(giaTri));

        int kq = DuongNhoNhat();
        if (kq == int.MaxValue)
            Console.WriteLine("f. Khong co so duong");
        else
            Console.WriteLine("f. Phan tu duong nho nhat: " + kq);
    }

    static void Bai7Chuong2()
    {
        Console.Write("Nhap so ngay n: ");
        int n = int.Parse(Console.ReadLine());
        if (n <= 0)
        {
            Console.WriteLine("So ngay khong hop le");
            return;
        }
        double[] nhietDo = new double[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Nhiet do ngay " + (i + 1) + ": ");
            nhietDo[i] = double.Parse(Console.ReadLine());
        }

        int ngayMax = 0;
        int ngayMin = 0;
        double tong = 0;
        for (int i = 0; i < n; i++)
        {
            if (nhietDo[i] > nhietDo[ngayMax]) ngayMax = i;
            if (nhietDo[i] < nhietDo[ngayMin]) ngayMin = i;
            tong += nhietDo[i];
        }

        Console.WriteLine("Ngay nong nhat: ngay " + (ngayMax + 1) + " (" + nhietDo[ngayMax] + ")");
        Console.WriteLine("Ngay lanh nhat: ngay " + (ngayMin + 1) + " (" + nhietDo[ngayMin] + ")");
        Console.WriteLine("Nhiet do trung binh: " + Math.Round(tong / n, 2));
    }

    static void Bai8Chuong2()
    {
        Console.Write("Nhap chuoi: ");
        string s = Console.ReadLine().ToLower();

        StringBuilder sb = new StringBuilder();
        foreach (char c in s)
        {
            if (char.IsLetterOrDigit(c))
                sb.Append(c);
            else
                sb.Append(' ');
        }

        string[] tu = sb.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> dem = new Dictionary<string, int>();
        foreach (string t in tu)
        {
            if (dem.ContainsKey(t))
                dem[t]++;
            else
                dem[t] = 1;
        }

        List<KeyValuePair<string, int>> ds = new List<KeyValuePair<string, int>>(dem);
        ds.Sort((p, q) => q.Value != p.Value ? q.Value.CompareTo(p.Value) : string.Compare(p.Key, q.Key));

        Console.WriteLine("So lan xuat hien cua moi tu:");
        foreach (KeyValuePair<string, int> kv in ds)
            Console.WriteLine(kv.Key + ": " + kv.Value);
    }

    static void Bai9Chuong2()
    {
        bool LaNguyenTo(int x)
        {
            if (x < 2) return false;
            for (int d = 2; d * d <= x; d++)
                if (x % d == 0)
                    return false;
            return true;
        }

        bool LaHoanHao(int x)
        {
            if (x < 2) return false;
            int tong = 0;
            for (int d = 1; d <= x / 2; d++)
                if (x % d == 0)
                    tong += d;
            return tong == x;
        }

        Console.Write("Nhap so phan tu n: ");
        int n = int.Parse(Console.ReadLine());
        int[] a = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("a[" + i + "] = ");
            a[i] = int.Parse(Console.ReadLine());
        }

        int demNguyenTo = 0;
        Console.Write("So nguyen to: ");
        for (int i = 0; i < n; i++)
            if (LaNguyenTo(a[i]))
            {
                Console.Write(a[i] + " ");
                demNguyenTo++;
            }
        Console.WriteLine("(co " + demNguyenTo + " so)");

        int demChan = 0;
        Console.Write("So chan: ");
        for (int i = 0; i < n; i++)
            if (a[i] % 2 == 0)
            {
                Console.Write(a[i] + " ");
                demChan++;
            }
        Console.WriteLine("(co " + demChan + " so)");

        int demHoanHao = 0;
        Console.Write("So hoan hao: ");
        for (int i = 0; i < n; i++)
            if (LaHoanHao(a[i]))
            {
                Console.Write(a[i] + " ");
                demHoanHao++;
            }
        Console.WriteLine("(co " + demHoanHao + " so)");
    }

    static void Bai10Chuong2()
    {
        Console.Write("Nhap so dong m: ");
        int m = int.Parse(Console.ReadLine());
        Console.Write("Nhap so cot n: ");
        int n = int.Parse(Console.ReadLine());
        int[,] a = new int[m, n];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
            {
                Console.Write("a[" + i + "," + j + "] = ");
                a[i, j] = int.Parse(Console.ReadLine());
            }

        int top = 0;
        int bottom = m - 1;
        int left = 0;
        int right = n - 1;

        Console.Write("Ma tran theo thu tu xoan oc: ");
        while (top <= bottom && left <= right)
        {
            for (int j = left; j <= right; j++)
                Console.Write(a[top, j] + " ");
            top++;

            for (int i = top; i <= bottom; i++)
                Console.Write(a[i, right] + " ");
            right--;

            if (top <= bottom)
            {
                for (int j = right; j >= left; j--)
                    Console.Write(a[bottom, j] + " ");
                bottom--;
            }

            if (left <= right)
            {
                for (int i = bottom; i >= top; i--)
                    Console.Write(a[i, left] + " ");
                left++;
            }
        }
        Console.WriteLine();
    }

    static void Bai11Chuong2()
    {
        Console.Write("Nhap cap ma tran vuong n: ");
        int n = int.Parse(Console.ReadLine());
        int[,] a = new int[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
            {
                Console.Write("a[" + i + "," + j + "] = ");
                a[i, j] = int.Parse(Console.ReadLine());
            }

        bool donVi = true;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
            {
                if (i == j && a[i, j] != 1) donVi = false;
                if (i != j && a[i, j] != 0) donVi = false;
            }

        bool doiXung = true;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (a[i, j] != a[j, i])
                    doiXung = false;

        if (donVi) Console.WriteLine("La ma tran don vi");
        else Console.WriteLine("Khong phai ma tran don vi");

        if (doiXung) Console.WriteLine("La ma tran doi xung");
        else Console.WriteLine("Khong phai ma tran doi xung");
    }

    static void Bai12Chuong2()
    {
        Console.Write("Nhap so dong m: ");
        int m = int.Parse(Console.ReadLine());
        Console.Write("Nhap so cot n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Nhap so min: ");
        int soMin = int.Parse(Console.ReadLine());
        if (soMin > m * n) soMin = m * n;

        bool[,] coMin = new bool[m, n];
        Random rd = new Random();
        int dat = 0;
        while (dat < soMin)
        {
            int r = rd.Next(m);
            int c = rd.Next(n);
            if (!coMin[r, c])
            {
                coMin[r, c] = true;
                dat++;
            }
        }

        int[,] dem = new int[m, n];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
            {
                if (coMin[i, j]) continue;
                int d = 0;
                for (int di = -1; di <= 1; di++)
                    for (int dj = -1; dj <= 1; dj++)
                    {
                        if (di == 0 && dj == 0) continue;
                        int u = i + di;
                        int v = j + dj;
                        if (u >= 0 && u < m && v >= 0 && v < n && coMin[u, v])
                            d++;
                    }
                dem[i, j] = d;
            }

        Console.WriteLine("Bang minesweeper (* la min, so la so min xung quanh):");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (coMin[i, j]) Console.Write("* ");
                else Console.Write(dem[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Bai13Chuong2()
    {
        Node TaoDanhSach()
        {
            Console.Write("Nhap so phan tu: ");
            int n = int.Parse(Console.ReadLine());
            Node dau = null;
            Node duoi = null;
            for (int i = 0; i < n; i++)
            {
                Console.Write("Phan tu thu " + i + ": ");
                Node p = new Node(int.Parse(Console.ReadLine()));
                if (dau == null)
                    dau = duoi = p;
                else
                {
                    duoi.next = p;
                    duoi = p;
                }
            }
            return dau;
        }

        void HienThi(Node dau)
        {
            for (Node p = dau; p != null; p = p.next)
                Console.Write(p.data + " ");
            Console.WriteLine();
        }

        Node head = TaoDanhSach();
        Console.Write("Danh sach ban dau: ");
        HienThi(head);

        Node previous = null;
        Node current = head;
        Node next = null;
        while (current != null)
        {
            next = current.next;
            current.next = previous;
            previous = current;
            current = next;
        }
        head = previous;

        Console.Write("Danh sach sau khi dao nguoc: ");
        HienThi(head);
    }

    static void Bai14Chuong2()
    {
        Node NhapDanhSach(string tieuDe)
        {
            Console.WriteLine(tieuDe + " (nhap theo thu tu tang dan)");
            Console.Write("Nhap so phan tu: ");
            int n = int.Parse(Console.ReadLine());
            Node dau = null;
            Node duoi = null;
            for (int i = 0; i < n; i++)
            {
                Console.Write("Phan tu thu " + i + ": ");
                Node p = new Node(int.Parse(Console.ReadLine()));
                if (dau == null)
                    dau = duoi = p;
                else
                {
                    duoi.next = p;
                    duoi = p;
                }
            }
            return dau;
        }

        void HienThi(Node dau)
        {
            for (Node p = dau; p != null; p = p.next)
                Console.Write(p.data + " ");
            Console.WriteLine();
        }

        Node Gop(Node l1, Node l2)
        {
            Node dau = new Node(0);
            Node duoi = dau;
            while (l1 != null && l2 != null)
            {
                if (l1.data <= l2.data)
                {
                    duoi.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    duoi.next = l2;
                    l2 = l2.next;
                }
                duoi = duoi.next;
            }
            if (l1 != null)
                duoi.next = l1;
            else
                duoi.next = l2;
            return dau.next;
        }

        Node ds1 = NhapDanhSach("Danh sach thu nhat");
        Node ds2 = NhapDanhSach("Danh sach thu hai");

        Console.Write("Danh sach 1: ");
        HienThi(ds1);
        Console.Write("Danh sach 2: ");
        HienThi(ds2);

        Node ketQua = Gop(ds1, ds2);
        Console.Write("Danh sach sau khi gop: ");
        HienThi(ketQua);
    }

    static void Bai15Chuong2()
    {
        Console.Write("Nhap so phan tu: ");
        int n = int.Parse(Console.ReadLine());
        Node head = null;
        Node tail = null;
        for (int i = 0; i < n; i++)
        {
            Console.Write("Phan tu thu " + i + ": ");
            Node p = new Node(int.Parse(Console.ReadLine()));
            if (head == null)
                head = tail = p;
            else
            {
                tail.next = p;
                tail = p;
            }
        }

        Console.Write("Noi nut cuoi toi vi tri (0.." + (n - 1) + ", nhap -1 neu khong co chu trinh): ");
        int viTri = int.Parse(Console.ReadLine());
        if (viTri >= 0 && viTri < n)
        {
            Node q = head;
            for (int i = 0; i < viTri; i++)
                q = q.next;
            tail.next = q;
        }

        Node rua = head;
        Node tho = head;
        bool coChuTrinh = false;
        while (tho != null && tho.next != null)
        {
            rua = rua.next;
            tho = tho.next.next;
            if (rua == tho)
            {
                coChuTrinh = true;
                break;
            }
        }

        if (coChuTrinh)
            Console.WriteLine("Danh sach CO chu trinh");
        else
            Console.WriteLine("Danh sach KHONG co chu trinh");
    }

    static void Bai16Chuong2()
    {
        DNode current = null;

        void TruyCap(string trang)
        {
            DNode moi = new DNode(trang);
            if (current != null)
            {
                current.next = moi;
                moi.prev = current;
            }
            current = moi;
        }

        void Back()
        {
            if (current != null && current.prev != null)
            {
                current = current.prev;
                Console.WriteLine("Quay lai: " + current.data);
            }
            else
                Console.WriteLine("Khong the quay lai");
        }

        void Forward()
        {
            if (current != null && current.next != null)
            {
                current = current.next;
                Console.WriteLine("Tien toi: " + current.data);
            }
            else
                Console.WriteLine("Khong the tien toi");
        }

        int chon;
        do
        {
            Console.WriteLine();
            Console.WriteLine("Trang hien tai: " + (current == null ? "(chua co)" : current.data));
            Console.WriteLine("1. Truy cap trang moi");
            Console.WriteLine("2. Back");
            Console.WriteLine("3. Forward");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon: ");
            if (!int.TryParse(Console.ReadLine(), out chon))
                chon = -1;

            if (chon == 1)
            {
                Console.Write("Nhap dia chi trang web: ");
                TruyCap(Console.ReadLine());
            }
            else if (chon == 2)
                Back();
            else if (chon == 3)
                Forward();
        } while (chon != 0);
    }

    static void Bai17Chuong2()
    {
        DNode head = null;
        DNode tail = null;
        DNode current = null;

        void ThemBaiHat(string ten)
        {
            DNode moi = new DNode(ten);
            if (head == null)
            {
                head = tail = current = moi;
            }
            else
            {
                tail.next = moi;
                moi.prev = tail;
                tail = moi;
            }
        }

        bool XoaBaiHat(string ten)
        {
            DNode p = head;
            while (p != null && p.data != ten)
                p = p.next;
            if (p == null)
                return false;

            if (p.prev != null)
                p.prev.next = p.next;
            else
                head = p.next;

            if (p.next != null)
                p.next.prev = p.prev;
            else
                tail = p.prev;

            if (current == p)
                current = (p.next != null) ? p.next : p.prev;

            return true;
        }

        void Next()
        {
            if (current != null && current.next != null)
                current = current.next;
            else
                Console.WriteLine("Day la bai cuoi playlist");
        }

        void Previous()
        {
            if (current != null && current.prev != null)
                current = current.prev;
            else
                Console.WriteLine("Day la bai dau playlist");
        }

        void HienThi()
        {
            if (head == null)
            {
                Console.WriteLine("Playlist rong");
                return;
            }
            for (DNode p = head; p != null; p = p.next)
            {
                if (p == current)
                    Console.WriteLine("-> " + p.data + "  (dang phat)");
                else
                    Console.WriteLine("   " + p.data);
            }
        }

        int chon;
        do
        {
            Console.WriteLine();
            Console.WriteLine("1. Them bai hat");
            Console.WriteLine("2. Xoa bai hat");
            Console.WriteLine("3. Next");
            Console.WriteLine("4. Previous");
            Console.WriteLine("5. Hien thi playlist");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon: ");
            if (!int.TryParse(Console.ReadLine(), out chon))
                chon = -1;

            if (chon == 1)
            {
                Console.Write("Nhap ten bai hat: ");
                ThemBaiHat(Console.ReadLine());
            }
            else if (chon == 2)
            {
                Console.Write("Nhap ten bai hat can xoa: ");
                if (!XoaBaiHat(Console.ReadLine()))
                    Console.WriteLine("Khong tim thay bai hat");
            }
            else if (chon == 3)
            {
                Next();
                HienThi();
            }
            else if (chon == 4)
            {
                Previous();
                HienThi();
            }
            else if (chon == 5)
                HienThi();
        } while (chon != 0);
    }

    static void Bai18Chuong2()
    {
        DNode choXuLy = new DNode("Cho xu ly");
        DNode dangGiao = new DNode("Dang giao");
        DNode hoanThanh = new DNode("Hoan thanh");
        choXuLy.next = dangGiao;
        dangGiao.prev = choXuLy;
        dangGiao.next = hoanThanh;
        hoanThanh.prev = dangGiao;

        List<DonHang> dsDon = new List<DonHang>();

        DonHang TimDon(string ma)
        {
            foreach (DonHang d in dsDon)
                if (d.MaDon == ma)
                    return d;
            return null;
        }

        void HienThi()
        {
            if (dsDon.Count == 0)
            {
                Console.WriteLine("Chua co don hang");
                return;
            }
            foreach (DonHang d in dsDon)
                Console.WriteLine(d.MaDon + " - " + d.TrangThai.data);
        }

        int chon;
        do
        {
            Console.WriteLine();
            Console.WriteLine("1. Them don hang");
            Console.WriteLine("2. Chuyen sang trang thai tiep theo");
            Console.WriteLine("3. Quay lai trang thai truoc");
            Console.WriteLine("4. Hien thi don hang");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon: ");
            if (!int.TryParse(Console.ReadLine(), out chon))
                chon = -1;

            if (chon == 1)
            {
                Console.Write("Nhap ma don hang: ");
                string maDon = Console.ReadLine();
                if (TimDon(maDon) != null)
                    Console.WriteLine("Ma don hang da ton tai");
                else
                {
                    DonHang moi = new DonHang();
                    moi.MaDon = maDon;
                    moi.TrangThai = choXuLy;
                    dsDon.Add(moi);
                }
            }
            else if (chon == 2 || chon == 3)
            {
                Console.Write("Nhap ma don hang: ");
                DonHang don = TimDon(Console.ReadLine());
                if (don == null)
                    Console.WriteLine("Khong tim thay don hang");
                else if (chon == 2)
                {
                    if (don.TrangThai.next == null)
                        Console.WriteLine("Don hang da hoan thanh");
                    else
                        don.TrangThai = don.TrangThai.next;
                }
                else
                {
                    if (don.TrangThai.prev == null)
                        Console.WriteLine("Don hang dang o trang thai dau");
                    else
                        don.TrangThai = don.TrangThai.prev;
                }
            }
            else if (chon == 4)
                HienThi();
        } while (chon != 0);
    }
}