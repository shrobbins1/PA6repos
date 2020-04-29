using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA6._1
{
    public partial class frmEdit : Form
    {
        private Book myBook;
        private string cwid;
        private string mode;
        public frmEdit(Object tempBook, string tempMode, string tempCwid)
        {
            myBook = (Book)tempBook;
            cwid = tempCwid;
            mode = tempMode;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            if(mode == "edit")
            {
                txtTitleDat.Text = myBook.title;
                txtAuthorData.Text = myBook.author;
                txtGenreData.Text = myBook.genre;
                txtCopiesData.Text = myBook.copies.ToString();
                txtLengthData.Text = myBook.length.ToString();
                txtISBNData.Text = myBook.isbn;
                txtCoverData.Text = myBook.cover;
                pbCover.Load(myBook.cover)
;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            myBook.title = txtTitleDat.Text;
            myBook.author =txtAuthorData.Text;
            myBook.genre = txtGenreData.Text;
            myBook.copies = int.Parse(txtCopiesData.Text);
            myBook.length = int.Parse(txtLengthData.Text);
            myBook.isbn = txtISBNData.Text;
            myBook.cover = txtCoverData.Text;
            myBook.cwid = cwid;

            BookDataBase.SaveBook(myBook, cwid, mode);
            MessageBox.Show("Content Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
