using ORM.SqlBuilder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ORM.SQLBuilderDemo
{
    public partial class SQLDemo2 : Form
    {
        public SQLDemo2()
        {
            InitializeComponent();

            _sql = new SqlBuilder<User>();

            _conn = new SqlConnection(Database.ConnectionString);

            _db = new Database(_conn);

        }
        
        private SqlBuilder<User> _sql;

        private Database _db;

        private IDbConnection _conn;

        private string _dummyData => Guid.NewGuid().ToString().Substring(0, 5);


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadUser(_sql.SelectAll);
        }

        private void LoadUser(string sql, Dictionary<string, object> parameters = null)
        {

            _conn.Open();

            var reader = _db.GetCommand(sql, parameters).ExecuteReader();

            lvUsers.Items.Clear();

            while (reader.Read())
            {
                ListViewItem item = lvUsers.Items.Add(reader["Id"].ToString());

                item.SubItems.Add(reader["Firstname"].ToString());

                item.SubItems.Add(reader["Lastname"].ToString());
            }

            _conn.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@Firstname", "%" + txtSearch.Text + "%" }
            };

            LoadUser(_sql.Select(new { Firstname = String.Empty }), parameters);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@Firstname", _dummyData },

                { "@Lastname", _dummyData }
            };

            CommandExecute(_sql.Insert, parameters);

            LoadUser(_sql.SelectAll);
        }

        void CommandExecute(string sql, Dictionary<string, object> parameters = null)
        {
            _conn.Open();

            _db.GetCommand(sql, parameters).ExecuteNonQuery();

            _conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@Id", 2 },

                { "@Firstname", _dummyData },

                { "@Lastname", _dummyData }
            };

            CommandExecute(_sql.Update, parameters);
            
            LoadUser(_sql.SelectAll);
          
        }


        private void btbDelete_Click(object sender, EventArgs e)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@Id", 2 }
            };

            CommandExecute(_sql.Delete, parameters);

            LoadUser(_sql.SelectAll);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            LoadUser(_sql.SelectAll);
        }

        

       
    }
}
