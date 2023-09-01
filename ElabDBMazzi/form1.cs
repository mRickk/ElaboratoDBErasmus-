using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElabDBMazzi
{
    public partial class Form1 : Form
    {
        private string accesso = "";
        private string cf = "";
        private string id = "";
        public static ElaboratoMazziDataClassesDataContext db = new ElaboratoMazziDataClassesDataContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void boxAccesso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkAccesso.Visible == true)
            {
                checkAccesso.Visible = false;
                checkCF.Visible = false;
                boxCF.Text = "";
                boxCF.Enabled = false;
                checkID.Visible = false;
                boxID.Text = "";
                boxID.Enabled = false;
            }
            var box = (ComboBox)sender;
            accesso = box.SelectedItem.ToString();
            checkAccesso.Visible = true;
            boxCF.Enabled = true;
        }

        private void boxCF_TextChanged(object sender, EventArgs e)
        {
            if (checkCF.Visible == true)
            {
                checkCF.Visible = false;
                checkID.Visible = false;
                boxID.Text = "";
                boxID.Enabled = false;
            }
            var box = (TextBox)sender;
            cf = box.Text;
            var ris = (from persona in db.Persone
                       where persona.CF.Equals((object)cf)
                       select persona).Count();
            if (accesso != "" && ris == 1)
            {
                checkCF.Visible = true;
                boxID.Enabled = true;
            }
        }

        private bool isIDcorrect()
        {
            if (accesso != "" && cf != "" && int.TryParse(id, out int idInt))
            {
                var ris = 0;
                switch (accesso)
                {
                    case "Studente":
                        ris = (from studente in db.Studenti
                               where studente.CF.Equals(cf)
                               where studente.CodStudente.Equals((object)idInt)
                               select studente).Count();
                        break;
                    case "Locatore":
                        ris = (from locatore in db.Locatori
                               where locatore.CF.Equals(cf)
                               where locatore.CodLocatore.Equals((object)idInt)
                               select locatore).Count();
                        break;
                    case "Intermediario":
                        ris = (from intermediario in db.Intermediari
                               where intermediario.CF.Equals(cf)
                               where intermediario.CodIntermediario.Equals((object)idInt)
                               select intermediario).Count();
                        break;
                    default:
                        return false;

                }
                return ris == 1;
            }
            return false;
        }

        private void boxID_TextChanged(object sender, EventArgs e)
        {
            if (checkID.Visible == true)
            {
                checkID.Visible = false;
                buttonConnect.Enabled = false;
            }
            var box = (TextBox)sender;
            id = box.Text;
            if (isIDcorrect())
            {
                checkID.Visible = true;
                buttonConnect.Enabled = true;
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            switch (accesso)
            {
                case "Studente":
                    var formStud = new FormStudente(cf, id, this);
                    formStud.Show();
                    this.Hide();
                    break;
                case "Locatore":
                    var formLoc = new FormLocatore(cf, id, this);
                    formLoc.Show();
                    this.Hide();
                    break;
                case "Intermediario":
                    var formInt = new FormIntermediario(cf, id, this);
                    formInt.Show();
                    this.Hide();
                    break;
                default:
                    return;

            }
        }

        private void buttonRegistrati_Click(object sender, EventArgs e)
        {
            var formReg = new FormRegistrazione();
            formReg.Show();
        }
    }
}
