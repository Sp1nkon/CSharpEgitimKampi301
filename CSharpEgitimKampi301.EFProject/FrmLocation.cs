using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        private void FrmLocaiton_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideID
            }).ToList();

            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "GuideID";
            cmbGuide.DataSource= values;
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.LocationCapacity = byte.Parse(nudCapacity.Value.ToString());
            location.LocationCity=txtCity.Text;
            location.LocationCountry=txtCountry.Text;
            location.LocationPrice=decimal.Parse(txtPrice.Text);
            location.DayNight=txtDayNight.Text;
            location.GuideID=int.Parse(cmbGuide.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme İşlemi Başarılı! ");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var deleteValue = db.Location.Find(id);
            db.Location.Remove(deleteValue);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Başarılı! ");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtID.Text);
            var updateValue = db.Location.Find(id);
            updateValue.DayNight= txtDayNight.Text;
            updateValue.LocationPrice=decimal.Parse(txtPrice.Text);
            updateValue.LocationCapacity=byte.Parse(nudCapacity.Value.ToString());
            updateValue.LocationCity=txtCity.Text;
            updateValue.LocationCountry=txtCountry.Text;
            updateValue.GuideID = int.Parse(cmbGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Başarılı! ");
        } 
    }
}
