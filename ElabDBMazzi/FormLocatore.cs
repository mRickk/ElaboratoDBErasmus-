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
    public partial class FormLocatore : Form
    {
        private string id;
        private string cf;
        private Form1 form1;
        private void aggiornaAlloggi()
        {
            numericCodLocatoreAlloggi.Value = decimal.Parse(id);
            dataGridViewAlloggi.DataSource = Form1.db.Alloggi.Where(a => a.CodLocatore.Equals(id));
        }
        private void aggiornaRichieste()
        {
            var query = Form1.db.Alloggi
                .Where(a => a.CodLocatore.Equals(id))
                .Join(Form1.db.Richieste, a => a.CodAlloggio, r => r.CodAlloggio, (a, r) => new
                {
                    a.CodAlloggio,
                    a.Titolo,
                    r.CodStudente,
                    r.DataInizio,
                    r.DataFine,
                    r.Accettata
                }).AsQueryable();
            boxAlloggioRichieste.Items.AddRange(query.Select(r => (object)r.CodAlloggio).Distinct().ToArray());
            dataGridViewRichieste.DataSource = query.Join(Form1.db.Studenti, ar => ar.CodStudente, s => s.CodStudente, (ar, s) => new
                {
                    ar.CodAlloggio,
                    ar.Titolo,
                    ar.CodStudente,
                    ar.DataInizio,
                    ar.DataFine,
                    ar.Accettata,
                    s.Universita,
                    s.CodCorso,
                    s.CF
                }).Join(Form1.db.Persone, ars => ars.CF, p => p.CF, (ars, p) => new
                {
                    ars.CodAlloggio,
                    ars.Titolo,
                    ars.CodStudente,
                    ars.DataInizio,
                    ars.DataFine,
                    ars.Accettata,
                    p.Nome,
                    p.Cognome,
                    p.Mail,
                    p.DataNascita,
                    p.Stato,
                    ars.Universita,
                    ars.CodCorso,
                });
        }
        private void aggiornaPrenotazioni()
        {
            var query = Form1.db.Alloggi
                .Where(a => a.CodLocatore.Equals(id))
                .Join(Form1.db.Prenotazioni, a => a.CodAlloggio, p => p.CodAlloggio, (a, p) => new
                {
                    a.CodAlloggio,
                    a.Titolo,
                    p.CodPrenotazione,
                    p.CodStudente,
                    p.DataInizio,
                    p.DataFine,
                    p.DataPrenotazione
                }).AsQueryable();
            boxPrenotazionePrenotazioni.Items.AddRange(query.Select(p => (object)p.CodPrenotazione).ToArray());
            dataGridViewPrenotazioni.DataSource = query.Join(Form1.db.Studenti, ap => ap.CodStudente, s => s.CodStudente, (ap, s) => new
                {
                    ap.CodAlloggio,
                    ap.Titolo,
                    ap.CodPrenotazione,
                    ap.CodStudente,
                    ap.DataInizio,
                    ap.DataFine,
                    ap.DataPrenotazione,
                    s.Universita,
                    s.CodCorso,
                    s.CF
                }).Join(Form1.db.Persone, aps => aps.CF, p => p.CF, (aps, p) => new
                {
                    aps.CodPrenotazione,
                    aps.CodAlloggio,
                    aps.Titolo,
                    aps.CodStudente,
                    aps.DataInizio,
                    aps.DataFine,
                    aps.DataPrenotazione,
                    p.Nome,
                    p.Cognome,
                    p.Mail,
                    p.Stato,
                    p.DataNascita,
                    aps.Universita,
                    aps.CodCorso,
                });
        }
        public FormLocatore(string CF, string ID, Form1 form1)
        {
            this.id = ID;
            this.cf = CF;
            this.form1 = form1;            
            InitializeComponent();
            this.labelNome.Text = Form1.db.Persone.Where(p => p.CF.Equals(cf)).First().Nome;
            this.aggiornaAlloggi();
            this.aggiornaRichieste();
            this.aggiornaPrenotazioni();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            form1.Close();
        }
        private void printError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonAggiornaAlloggi_Click(object sender, EventArgs e)
        {
            this.aggiornaAlloggi();
        }

        private bool checkAlloggi()
        {
            return !string.IsNullOrWhiteSpace(boxTitoloAlloggi.Text) && boxStatoAlloggi.SelectedIndex >= 0
                && !string.IsNullOrWhiteSpace(boxCittaAlloggi.Text) && !string.IsNullOrWhiteSpace(boxCodPostaleAlloggi.Text)
                && numericNumPostiAlloggi.Value > 0 && numericAffittoAlloggi.Value > 0 && boxTipologiaAlloggi.SelectedIndex >= 0
                && (string.IsNullOrWhiteSpace(boxViaAlloggi.Text) || numericNumCivicoAlloggi.Value > 0);
        }
        private void buttonAggiungiAlloggi_Click(object sender, EventArgs e)
        {
            if (checkAlloggi())
            {
                DialogResult res = MessageBox.Show($"Sei sicuro di voler aggiungere l'alloggio indicato?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res.Equals(DialogResult.OK))
                {
                    try
                    {
                        var alloggio = new Alloggi
                        {
                            Titolo = boxTitoloAlloggi.Text,
                            Stato = boxStatoAlloggi.Text,
                            Citta = boxCittaAlloggi.Text,
                            CodPostale = boxCodPostaleAlloggi.Text,
                            Quartiere = string.IsNullOrWhiteSpace(boxQuartiereAlloggi.Text) ? null : boxQuartiereAlloggi.Text,
                            Via = string.IsNullOrWhiteSpace(boxViaAlloggi.Text) ? null : boxViaAlloggi.Text,
                            NumCivico = null,
                            Piano = null,
                            Interno = null,
                            NumPosti = (byte)numericNumPostiAlloggi.Value,
                            CostoAffitto = (int)numericAffittoAlloggi.Value,
                            Arredato = checkArredatoAlloggi.Checked,
                            CostoServizi = null,
                            Commissione = null,
                            Caparra = null,
                            CodLocatore = int.Parse(id),
                            CodTipologia = (string)boxTipologiaAlloggi.SelectedItem
                        };
                        if (numericNumCivicoAlloggi.Value > 0)
                        {
                            alloggio.NumCivico = (int)numericNumCivicoAlloggi.Value;
                        }
                        if (numericPianoAlloggi.Value > 0)
                        {
                            alloggio.NumCivico = (int)numericPianoAlloggi.Value;
                        }
                        if (numericInternoAlloggi.Value > 0)
                        {
                            alloggio.NumCivico = (int)numericInternoAlloggi.Value;
                        }
                        if (numericServiziAlloggi.Value > 0)
                        {
                            alloggio.NumCivico = (int)numericServiziAlloggi.Value;
                        }
                        if (numericCommissioneAlloggi.Value > 0)
                        {
                            alloggio.NumCivico = (int)numericCommissioneAlloggi.Value;
                        }
                        if (numericCaparraAlloggi.Value > 0)
                        {
                            alloggio.NumCivico = (int)numericCaparraAlloggi.Value;
                        }
                        Form1.db.Alloggi.InsertOnSubmit(alloggio);
                        Form1.db.SubmitChanges();
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

        private void boxViaAlloggi_TextChanged(object sender, EventArgs e)
        {
            bool flag = string.IsNullOrWhiteSpace(boxViaAlloggi.Text);            
            numericNumCivicoAlloggi.Enabled = !flag;
            numericNumCivicoAlloggi.ReadOnly = flag;
            numericPianoAlloggi.Enabled = !flag;
            numericPianoAlloggi.ReadOnly = flag;
            numericInternoAlloggi.Enabled = !flag;
            numericInternoAlloggi.ReadOnly = flag;
            if (flag)
            {
                numericNumCivicoAlloggi.Value = 0;
                numericPianoAlloggi.Value = 0;
                numericInternoAlloggi.Value = 0;
            }
        }

        private void buttonEliminaAlloggi_Click(object sender, EventArgs e)
        {
            if (numericAlloggioAlloggi.Value > 0)
            {
                DialogResult res = MessageBox.Show($"Sei sicuro di voler eliminare l'alloggio n.{numericAlloggioAlloggi.Value}?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res.Equals(DialogResult.OK))
                {
                    try
                    {
                        Form1.db.Alloggi.DeleteOnSubmit(Form1.db.Alloggi.Where(a => a.CodAlloggio.Equals(numericAlloggioAlloggi.Value)
                                    && a.CodLocatore.Equals(id)).First());
                        Form1.db.SubmitChanges();
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

        private void buttonAggiornaRichieste_Click(object sender, EventArgs e)
        {
            this.aggiornaRichieste();
        }

        private void buttonAccettaRichieste_Click(object sender, EventArgs e)
        {
            if (numericCodStudenteRichieste.Value > 0 && boxAlloggioRichieste.SelectedIndex >= 0
                && dateFineRichiesta.Enabled)
            {
                DialogResult res = MessageBox.Show($"Sei sicuro di voler accettare la richiesta indicata?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res.Equals(DialogResult.OK))
                {
                    try
                    {
                        var richiesta = Form1.db.Richieste.Where(r => r.CodAlloggio.Equals(boxAlloggioRichieste.SelectedItem)
                            && r.CodStudente.Equals(numericCodStudenteRichieste.Value)
                            && r.DataInizio.Equals(dateInizioRichiesta.Value.Date)
                            && r.DataFine.Equals(dateFineRichiesta.Value.Date)).SingleOrDefault();
                        if (richiesta != null)
                        {
                            richiesta.Accettata = true;
                            Form1.db.SubmitChanges();
                        } else
                        {
                            printError(new Exception("Richiesta non trovata!"));
                        }
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

        private void dateInizioRichiesta_ValueChanged(object sender, EventArgs e)
        {
            dateFineRichiesta.MinDate = dateInizioRichiesta.Value;
            dateFineRichiesta.Enabled = true;
        }

        private void buttonAggiornaPrenotazioni_Click(object sender, EventArgs e)
        {
            this.aggiornaPrenotazioni();
        }

        private void buttonRitiraPrenotazione_Click(object sender, EventArgs e)
        {
            if (boxPrenotazionePrenotazioni.SelectedIndex >= 0)
            {
                DialogResult res = MessageBox.Show($"Sei sicuro di voler ritirare la prenotazione n.{boxPrenotazionePrenotazioni.SelectedItem}?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res.Equals(DialogResult.OK))
                {
                    try
                    {
                        Form1.db.Prenotazioni.DeleteOnSubmit(Form1.db.Prenotazioni
                                    .Where(p => p.CodPrenotazione.Equals(boxPrenotazionePrenotazioni.SelectedItem))
                                    .First());
                        Form1.db.SubmitChanges();
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

        private void buttonHome_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }
    }
}
