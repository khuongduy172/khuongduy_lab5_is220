using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TestDeThi.Models
{
    public class DataContext
    {
        public string ConnnectionString { get; set; }
        public DataContext(string connectionstring)
        {
            ConnnectionString = connectionstring;
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConnnectionString);
        }

        public int sqlThemCH (CanHoModel canho)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                var sql = "insert into CANHO values (@macanho, @tenchuho)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("macanho", canho.MaCanHo);
                cmd.Parameters.AddWithValue("tenchuho", canho.TenChuHo);
                return cmd.ExecuteNonQuery();
            }
        }
        public List<object> sqlLocBaoTri (int solan)
        {
            List<object> list = new List<object>();
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                var sql = "SELECT NV.TenNhanVien, NV.SoDienThoai, COUNT(*) AS SoLan " +
                    "FROM NHANVIEN NV, NV_BT " +
                    "WHERE NV.MaNhanVien = NV_BT.MaNhanVien " +
                    "GROUP BY NV.MaNhanVien, NV.TenNhanVien, NV.SoDienThoai " +
                    "HAVING COUNT(*) >= @solan";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("solan", solan);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new
                        {
                            tenNhanVien = reader["TenNhanVien"].ToString(),
                            soDienThoai = reader["SoDienThoai"].ToString(),
                            soLan = Convert.ToInt32(reader["SoLan"])
                        });
                    }
                    reader.Close();
                }
            }
            return list;
        }
        public List<NhanVienModel> sqlListNhanVien()
        {
            List<NhanVienModel> list = new List<NhanVienModel>();
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                var sql = "SELECT * FROM NHANVIEN";
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NhanVienModel() { 
                            MaNhanVien = reader["MaNhanVien"].ToString(),
                            TenNhanVien = reader["TenNhanVien"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            GioiTinh = Convert.ToBoolean(reader["GioiTinh"]),
                        });
                    }
                    reader.Close();
                }
            }
            return list;
        }
        public List<NVBTModel> sqlListNVBT(string manhanvien)
        {
            List<NVBTModel> list = new List<NVBTModel>();
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                var sql = "SELECT * FROM NV_BT" +
                    " Where MaNhanVien = @manhanvien;";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("manhanvien", manhanvien);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NVBTModel()
                        {
                            MaNhanVien = reader["MaNhanVien"].ToString(),
                            MaThietBi = reader["MaThietBi"].ToString(),
                            MaCanHo = reader["MaCanHo"].ToString(),
                            LanThu = Convert.ToInt32(reader["LanThu"]),
                            NgayBaoTri = Convert.ToDateTime(reader["NgayBaoTri"]),
                        });
                    }
                    reader.Close();
                }
            }
            return list;
        }
        public NVBTModel sqlGetNVBTByKey (string manv, string matb, string mach, int lanthu)
        {
            NVBTModel result = new NVBTModel();
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                var sql = "SELECT * FROM NV_BT" +
                    " Where MaNhanVien = @manhanvien" +
                    " And MaThietBi = @matb" +
                    " And MaCanHo = @mach " +
                    " And LanThu = @lanthu;";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("manhanvien", manv);
                cmd.Parameters.AddWithValue("matb", matb);
                cmd.Parameters.AddWithValue("mach", mach);
                cmd.Parameters.AddWithValue("lanthu", lanthu);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.MaNhanVien = reader["MaNhanVien"].ToString();
                        result.MaThietBi = reader["MaThietBi"].ToString();
                        result.MaCanHo = reader["MaCanHo"].ToString();
                        result.LanThu = Convert.ToInt32(reader["LanThu"]);
                        result.NgayBaoTri = Convert.ToDateTime(reader["NgayBaoTri"]);
                    }
                    reader.Close();
                }
            }
            return result;
        }
        public int sqlDeleteBaotri (string manv, string matb, string mach, int lanthu)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                var sql = "DELETE from NV_BT " +
                    "WHERE MaThietBi = @matb " +
                    "AND MaCanHo = @mach " +
                    "AND MaNhanVien = @manv " +
                    "AND LanThu = @lanthu;";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("matb", matb);
                cmd.Parameters.AddWithValue("mach", mach);
                cmd.Parameters.AddWithValue("manv", manv);
                cmd.Parameters.AddWithValue("lanthu", lanthu);
                return cmd.ExecuteNonQuery();
            }
        }
        public int sqlUpdateBaotri(string manv, string matb, string mach, int lanthu, DateTime ngay)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                var sql = "INSERT INTO NV_BT VALUES (@manv, @matb, @mach, @lanthu, @ngay); ";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("manv", manv);
                cmd.Parameters.AddWithValue("matb", matb);
                cmd.Parameters.AddWithValue("mach", mach);
                cmd.Parameters.AddWithValue("lanthu", lanthu);
                cmd.Parameters.AddWithValue("ngay", ngay);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
