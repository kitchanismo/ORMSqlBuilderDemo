using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ORM.SqlBuilder;

namespace ORM.SQLBuilderDemo
{
    public partial class SQLDemo : Form
    {
        private SqlBuilder<User> _builder;

        public SQLDemo()
        {
            InitializeComponent();

            _builder = new SqlBuilder<User>();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var sql = _builder.Select(new { Firstname = String.Empty, Lastname = String.Empty });

            MessageBox.Show(sql);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            var sql = _builder.SelectAll;

            MessageBox.Show(sql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sql = _builder.Insert;

            MessageBox.Show(sql);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var sql = _builder.Update;

            MessageBox.Show(sql);
        }

        private void btbDelete_Click(object sender, EventArgs e)
        {
            var sql = _builder.Delete;

            MessageBox.Show(sql);
        }
    }
}
