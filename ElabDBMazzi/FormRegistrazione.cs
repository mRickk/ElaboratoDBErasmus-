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
    public partial class FormRegistrazione : Form
    {
        private bool prevFlagPersona = false;
        private bool prevFlagRuolo = false;
        public FormRegistrazione()
        {
            InitializeComponent();
        }

        private void printError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void boxCF_TextChanged(object sender, EventArgs e)
        {
            bool flagPersona = !string.IsNullOrWhiteSpace(boxCF.Text)
                && boxCF.Text.Length == 16
                && Form1.db.Persone.Where(p => p.CF.Equals(boxCF.Text)).Count() == 0;
            if (flagPersona != prevFlagPersona)
            {
                boxNome.Enabled = flagPersona;
                boxCognome.Enabled = flagPersona;
                boxMail.Enabled = flagPersona;
                boxTelefono.Enabled = flagPersona;
                dateNascita.Enabled = flagPersona;
                boxStato.Enabled = flagPersona;
                boxCitta.Enabled = flagPersona;
                boxCodPostale.Enabled = flagPersona;
                boxVia.Enabled = flagPersona;
                numericNumCivico.Enabled = flagPersona;
                numericNumCivico.ReadOnly = !flagPersona;
                prevFlagPersona = flagPersona;
            }
            
        }

        private void boxAccesso_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flagRuolo = boxRuolo.SelectedItem.Equals("Studente");
            if (flagRuolo != prevFlagRuolo)
            {
                boxUniversita.Enabled = flagRuolo;
                boxCorso.Enabled = flagRuolo;
                dateImmatricolazione.Enabled = flagRuolo;
                numericMatricola.Enabled = flagRuolo;
                numericMatricola.ReadOnly = !flagRuolo;
                prevFlagRuolo = flagRuolo;
            }
        }

        private bool checkPersona()
        {
            if (prevFlagPersona)
            {
                return !string.IsNullOrWhiteSpace(boxNome.Text) && !string.IsNullOrWhiteSpace(boxCognome.Text)
                    && !string.IsNullOrWhiteSpace(boxMail.Text) && !string.IsNullOrWhiteSpace(boxTelefono.Text)
                    && boxStato.SelectedIndex >= 0 && !string.IsNullOrWhiteSpace(boxCitta.Text)
                    && !string.IsNullOrWhiteSpace(boxCodPostale.Text) && !string.IsNullOrWhiteSpace(boxVia.Text)
                    && numericNumCivico.Value > 0;
            }
            return true;
        }

        private bool checkRuolo()
        {
            if (prevFlagRuolo)
            {
                return numericMatricola.Value > 0 && !string.IsNullOrWhiteSpace(boxUniversita.Text)
                    && !string.IsNullOrWhiteSpace(boxCorso.Text);
            }
            return true;
        }

        private void buttonRegistrati_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(boxCF.Text) && boxRuolo.SelectedIndex >= 0
                && checkPersona() && checkRuolo()) {
                DialogResult res = MessageBox.Show($"Sei sicuro di voler registrarti con CF = {boxCF.Text}?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res.Equals(DialogResult.OK))
                {
                    try
                    {
                        if (prevFlagPersona)
                        {
                            var persona = new Persone
                            {
                                CF = boxCF.Text,
                                Nome = boxNome.Text,
                                Cognome = boxCognome.Text,
                                Mail = boxMail.Text,
                                Telefono = boxTelefono.Text,
                                DataNascita = dateNascita.Value.Date,
                                Stato = boxStato.Text,
                                Citta = boxCitta.Text,
                                CodPostale = boxCodPostale.Text,
                                Via = boxVia.Text,
                                NumCivico = (int)numericNumCivico.Value
                            };
                            Form1.db.Persone.InsertOnSubmit(persona);
                            Form1.db.SubmitChanges();
                        }
                        int id = 0;
                        if (prevFlagRuolo)
                        {
                            var studente = new Studenti
                            {
                                CF = boxCF.Text,
                                NumMatricola = (int)numericMatricola.Value,
                                Universita = boxUniversita.Text,
                                CodCorso = boxCorso.Text,
                                AnnoImmatricolazione = (short)dateImmatricolazione.Value.Year,
                                CV = null
                            };
                            Form1.db.Studenti.InsertOnSubmit(studente);
                            Form1.db.SubmitChanges();
                            id = Form1.db.Studenti.Where(s => s.CF.Equals(studente.CF)).Select(s => s.CodStudente).FirstOrDefault();
                        } else if (boxRuolo.SelectedItem.Equals("Locatore"))
                        {
                            var locatore = new Locatori
                            {
                                CF = boxCF.Text
                            };
                            Form1.db.Locatori.InsertOnSubmit(locatore);
                            Form1.db.SubmitChanges();
                            id = Form1.db.Locatori.Where(l => l.CF.Equals(locatore.CF)).Select(l => l.CodLocatore).FirstOrDefault();
                        } else if (boxRuolo.SelectedItem.Equals("Intermediario"))
                        {
                            var intermediario = new Intermediari
                            {
                                CF = boxCF.Text
                            };
                            Form1.db.Intermediari.InsertOnSubmit(intermediario);
                            Form1.db.SubmitChanges();
                            id = Form1.db.Intermediari.Where(i => i.CF.Equals(intermediario.CF)).Select(i => i.CodIntermediario).FirstOrDefault();
                        } else
                        {
                            throw new Exception("An error occured during the registration");
                        }
                        MessageBox.Show($"Ricordati di memorizzare il tuo ID personale che dovrai utilizzare durante il login. ID = {id}", "Registrazione effettuata!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception ex)
                    {
                        printError(ex);
                    }

                }
            } else
            {
                printError(new Exception("Inserire i campi obbligatori"));
            }
        }
    }
}
