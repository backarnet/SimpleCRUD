using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCRUD
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadGrids();
        }

        private void LoadGrids()
        {
            using (DBContext cxt = new DBContext())
            {
                dataGridView1.DataSource = cxt.Set<Auth>().ToList();
                dataGridView2.DataSource = cxt.Set<Post>().Include("Auth").ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (DBContext cxt = new DBContext())
                {
                    cxt.Set<Auth>().Add(new Auth
                    {
                        Name = textBox1.Text,
                    });
                    cxt.SaveChanges();
                    LoadGrids();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (DBContext cxt = new DBContext())
                {
                    var auth = cxt.Set<Auth>().Find((int)dataGridView1.SelectedRows[0].Cells["Id"].Value);
                    cxt.Set<Post>().Add(new Post
                    {
                        Title = textBox2.Text,
                        Auth = auth,
                    });
                    cxt.SaveChanges();
                    LoadGrids();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (DBContext cxt = new DBContext())
                {
                    var auth = cxt.Set<Auth>().Find((int)dataGridView1.SelectedRows[0].Cells["Id"].Value);
                    cxt.Set<Auth>().Remove(auth);
                    cxt.SaveChanges();
                    LoadGrids();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (DBContext cxt = new DBContext())
                {
                    var post = cxt.Set<Post>().Find((int)dataGridView2.SelectedRows[0].Cells["Id"].Value);
                    cxt.Set<Post>().Remove(post);
                    cxt.SaveChanges();
                    LoadGrids();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
