using ResumeCollectingSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            positionList.Items.Clear();
            //Position position = new Position();
            //position.Name = positionNameTxtBox.Text;
            IEnumerable<Position> positions = PositionRepo.GetAll();

            foreach (Position position in positions)
            {
                positionList.Items.Add(position.Name);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'resumeCollectingSystemDataSet2.Gender' table. You can move, or remove it, as needed.
            this.genderTableAdapter.Fill(this.resumeCollectingSystemDataSet2.Gender);
            // TODO: This line of code loads data into the 'resumeCollectingSystemDataSet1.Degree' table. You can move, or remove it, as needed.
            this.degreeTableAdapter.Fill(this.resumeCollectingSystemDataSet1.Degree);
            // TODO: This line of code loads data into the 'resumeCollectingSystemDataSet.Position' table. You can move, or remove it, as needed.
            this.positionTableAdapter.Fill(this.resumeCollectingSystemDataSet.Position);

        }
    }
}
