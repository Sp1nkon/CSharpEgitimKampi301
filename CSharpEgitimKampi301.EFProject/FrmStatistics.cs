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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            
            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text = db.Location.Sum(x=>x.LocationCapacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAvgCapacity.Text = db.Location.Average(x => x.LocationCapacity).ToString();
            lblAvgLocationPrice.Text = db.Location.Average(x => x.LocationPrice).ToString() + " ₺ ";
            
            int lastCountryID = db.Location.Max(x => x.LocationID);
            lblLastCountry.Text = db.Location.Where(x => x.LocationID == lastCountryID).Select(y => y.LocationCountry).FirstOrDefault();ToString();

            lblCappadociaLocationCapacity.Text = db.Location.Where(x => x.LocationCity == "Kapadokya").Select(y => y.LocationCapacity).FirstOrDefault().ToString();
            lblTurkiyeCapacityAvg.Text = db.Location.Where(x => x.LocationCountry == "Türkiye").Average(y => y.LocationCapacity).ToString();

            var romaGuideID = db.Location.Where(x => x.LocationCity == "Roma Turistik").Select(y => y.GuideID).FirstOrDefault();
            lblRomaGuideName.Text = db.Guide.Where(x => x.GuideID == romaGuideID).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();

            var maxCapacity = db.Location.Max(x => x.LocationCapacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x => x.LocationCapacity == maxCapacity).Select(y => y.LocationCity).FirstOrDefault().ToString();

            var maxPrice = db.Location.Max(x => x.LocationPrice);
            lblMaxPriceLocation.Text = db.Location.Where(x => x.LocationPrice == maxPrice).Select(y => y.LocationCity).FirstOrDefault().ToString();

            var guideIDByNameAysegulCinar = db.Guide.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar").Select(y => y.GuideID).FirstOrDefault();
            lblAysegulCınarLocationCount.Text = db.Location.Where(x => x.GuideID == guideIDByNameAysegulCinar).Count().ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblAvgLocationPrice_Click(object sender, EventArgs e)
        {

        }

        private void lblRomaGuideName_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}
