using Npgsql;
using System.Data;
namespace TugasPbo
{
    class getting_data
    {
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=husnan22;database=karyawan;");
        }
        public bool ExecuteQuery(out bool karyawan)

        {
            karyawan = true;
            try
            {

                NpgsqlConnection con = koneksi();
                con.Open();
                string sql = "select * from karyawan";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return karyawan;
            }
            catch (Exception)
            {
                karyawan = false;
                return karyawan;
            }

        }
    }
    class operasi
    {
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=husnan22;database=karyawan;");
        }
        public bool insert(ref bool karyawan)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("insert into karyawan(nama,alamat,no_hp,email) values('arya','balinese','083849328808','arya@mail.com')", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                karyawan = true;
                return karyawan;
            }
            catch (Exception)
            {
                return karyawan;
            }
        }
        public bool update(ref bool karyawan)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("update karyawan set nama = luffy,alamat = yogyaklitih, no_hp = 082139242512, email = luffyprank@mail.com where id_karyawan = 4", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                karyawan = true;
                return karyawan;
            }
            catch (Exception)
            {
                return karyawan;
            }
        }
        public bool Delete(ref bool karyawan)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("delete from karyawan where id_karyawan = 1", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                karyawan = true;
                return karyawan;
            }
            catch (Exception)
            {
                return karyawan;
            }
        }
    }
    class program_utama
    {
        static void Main(string[] args)
        {
            bool karyawan;
            bool ingfo = false;
            getting_data dat = new getting_data();
            operasi op = new operasi();
            if (dat.ExecuteQuery(out karyawan) == true)
            {
                Console.WriteLine("data terkonfirmasi");
            }
            else if (dat.ExecuteQuery(out karyawan) == false)
            {
                Console.WriteLine("data tidak terkonfirmasi");
            }
            if (op.insert(ref ingfo) == true)
            {
                Console.WriteLine("insert sukses");
            }
            else if (op.insert(ref ingfo) == false)
            {
                Console.WriteLine("insert gagal");
            }
            if (op.update(ref ingfo) == true)
            {
                Console.WriteLine("update sukses");
            }
            else if (op.update(ref ingfo) == false)
            {
                Console.WriteLine("update gagal");
            }
            if (op.Delete(ref ingfo) == true)
            {
                Console.WriteLine("delete sukses");
            }
            else if (op.Delete(ref ingfo) == false)
            {
                Console.WriteLine("delete gagal");
            }
        }
    }
}
