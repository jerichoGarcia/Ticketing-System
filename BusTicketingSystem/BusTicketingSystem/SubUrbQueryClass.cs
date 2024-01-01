using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace BusTicketingSystem
{
    internal class SubUrbQueryClass
    {
        private SqlConnection sqlConnect;
        private SqlCommand SqlCommand;
        private SqlDataAdapter SqlAdapter;
        private SqlDataReader SqlReader;

        private string connectionString;

        public DataTable dataTable = new DataTable();
        public BindingSource bindingSource = new BindingSource();

        public string _Bustype, PlateNo;
        public int _BusNo, _Capacity;

        public SubUrbQueryClass()
        {
            connectionString = @"Data Source=jericho-garcia;Initial Catalog=SubUrbTicketingDB;Integrated Security=True";
            sqlConnect = new SqlConnection(connectionString);
            dataTable = new DataTable();
            bindingSource = new BindingSource();
        }
        public bool DisplayTripList()
        {
            string ViewClubMembers = "SELECT StudentId, FirstName, MiddleName, LastName, Age, Gender, Program FROM ClubMembers ";
            SqlAdapter = new SqlDataAdapter(ViewClubMembers, sqlConnect);
            dataTable.Clear();
            SqlAdapter.Fill(dataTable);
            bindingSource.DataSource = dataTable;

            return true;
        }
        //addbus and view list
        public bool DisplayBusList()
        {
            string ViewBusList = "SELECT * FROM tblBus ";
            SqlAdapter = new SqlDataAdapter(ViewBusList, sqlConnect);
            dataTable.Clear();
            SqlAdapter.Fill(dataTable);
            bindingSource.DataSource = dataTable;

            return true;
        }
        public bool addBus( string BusType, string PlateNo, int BusNo, int Capacity)
        {
            SqlCommand = new SqlCommand("INSERT INTO tblBus VALUES ( @BusType, @PlateNo, @BusNo, @Capacity)", sqlConnect);

            //SqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
           // SqlCommand.Parameters.Add("@RegistrationID", SqlDbType.BigInt).Value = StudentID;
            SqlCommand.Parameters.Add("@BusType", SqlDbType.VarChar).Value = BusType;
            SqlCommand.Parameters.Add("@PlateNo", SqlDbType.VarChar).Value = PlateNo;
            SqlCommand.Parameters.Add("@BusNo", SqlDbType.Int).Value = BusNo;
            SqlCommand.Parameters.Add("@Capacity", SqlDbType.Int).Value = Capacity;
 

            sqlConnect.Open();
            SqlCommand.ExecuteNonQuery();
            sqlConnect.Close();

            return true;
        }
        //end of addbus and view list

        //addDriver and view list
        public bool DisplayDriverList()
        {
            string ViewBusList = "SELECT * FROM tblDriver ";
            SqlAdapter = new SqlDataAdapter(ViewBusList, sqlConnect);
            dataTable.Clear();
            SqlAdapter.Fill(dataTable);
            bindingSource.DataSource = dataTable;

            return true;
        }
        public bool addDriver (string DriverName, string Address, int ContactNo, int License)
        {
            SqlCommand = new SqlCommand("INSERT INTO tblDriver VALUES ( @DriverName, @Address, @ContactNum, @License)", sqlConnect);

            //SqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            // SqlCommand.Parameters.Add("@RegistrationID", SqlDbType.BigInt).Value = StudentID;
            SqlCommand.Parameters.Add("@DriverName", SqlDbType.VarChar).Value = DriverName;
            SqlCommand.Parameters.Add("@Address", SqlDbType.VarChar).Value = Address;
            SqlCommand.Parameters.Add("@ContactNum", SqlDbType.Int).Value = ContactNo;
            SqlCommand.Parameters.Add("@License", SqlDbType.Int).Value = License;


            sqlConnect.Open();
            SqlCommand.ExecuteNonQuery();
            sqlConnect.Close();

            return true;
        }
        //end of addDriver and viewlist
    }
}
