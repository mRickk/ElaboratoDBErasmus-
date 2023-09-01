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
    public partial class FormStudente : Form
    {
        private string cf;
        private string id;
        private bool dateTirocinioHasChanged;
        private bool dateAlloggioHasChanged;
        private Form1 form1;


        private void initTirociniTab()
        {
            this.labelNome.Text = (from p in Form1.db.Persone
                                   where p.CF.Equals(cf)
                                   select p.Nome).FirstOrDefault().ToString();
            var campi = from c in Form1.db.Campi
                        select new { c.CodCampo, c.Descrizione };
            foreach (var c in campi)
            {
                this.boxCampo.Items.Add($"{c.CodCampo} {c.Descrizione}");
            }
            this.dateInizio.MinDate = DateTime.Now;
            this.dateFine.MinDate = DateTime.Now;
            this.dateFine.Enabled = false;
            this.dateTirocinioHasChanged = false;
        }

        private void aggiornaCandidature()
        {
            this.dataGridViewCandidature.DataSource = Form1.db.Candidature
                                                        .Where(c => c.CodStudente.Equals(this.id)).ToList();
        }

        private void initCandidatureTab()
        {
            this.aggiornaCandidature();
            this.numericCodStudente.Value = int.Parse(id);
            this.numericCodStudente2.Value = int.Parse(id);
        }

        private void aggiornaAccordi()
        {
            this.dataGridViewAccordi.DataSource = Form1.db.Accordi
                                                    .Where(a => a.CodStudente.Equals(this.id)).ToList();
            this.boxTirocinioAccordi.Items.AddRange(Form1.db.Candidature
                .Where(c => c.CodStudente.Equals(id) && c.Accettata == true)
                .Select(c => (object)c.CodTirocinio)
                .Distinct()
                .ToArray());
        }
        private void initAccordiTab()
        {
            this.aggiornaAccordi();
            this.numericCodStudente3.Value = int.Parse(id);
        }
        private void initAlloggiTab()
        {
            this.dateInizioAlloggi.Value = DateTime.Now;
            this.dateFineAlloggi.Value = DateTime.Now;
            this.dateFineAlloggi.Enabled = false;
            this.dateAlloggioHasChanged = false;
        }
        private void aggiornaRichieste()
        {
            this.dataGridViewRichieste.DataSource = Form1.db.Richieste
                                                        .Where(r => r.CodStudente.Equals(this.id)).ToList();
        }
        private void initRichiesteTab()
        {
            this.numericCodStudente4.Value = int.Parse(this.id);
            this.numericCodStudente5.Value = int.Parse(this.id);
            this.aggiornaRichieste();
            this.dateInizioRichiesta.Value = DateTime.Now;
            this.dateFineRichiesta.Value = DateTime.Now;
            this.dateFineRichiesta.Enabled = false;
            this.dateInizioRichiesta2.Value = DateTime.Now;
            this.dateFineRichiesta2.Value = DateTime.Now;
            this.dateFineRichiesta2.Enabled = false;
        }
        private void aggiornaPrenotazioni()
        {
            this.dataGridViewPrenotazioni.DataSource = Form1.db.Prenotazioni
                                                        .Where(p => p.CodStudente.Equals(this.id)).ToList();
            this.boxAlloggioPrenotazioni.Items.AddRange(Form1.db.Richieste
                .Where(r => r.CodStudente.Equals(id) && r.Accettata == true)
                .Select(r => (object)r.CodAlloggio)
                .ToArray());
        }
        private void initPrenotazioniTab()
        {
            this.aggiornaPrenotazioni();
            this.numericCodStudente6.Value = int.Parse(this.id);
        }
        public FormStudente(string CF, string ID, Form1 form1)
        {
            this.cf = CF;
            this.id = ID;
            this.form1 = form1;
            InitializeComponent();
            this.initTirociniTab();
            this.initCandidatureTab();
            this.initAccordiTab();
            this.initAlloggiTab();
            this.initRichiesteTab();
            this.initPrenotazioniTab();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                form1.Close();
            }            
        }

        private void boxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.boxCampo.SelectedIndex == 0)
            {
                this.boxCampo.SelectedIndex = -1;
            }
        }

        private void boxStato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.boxStato.SelectedIndex == 0)
            {
                this.boxStato.SelectedIndex = -1;
            }
            this.boxCitta.Text = "";
        }

        private void boxDurata_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.boxDurata.SelectedIndex == 0)
            {
                this.boxDurata.SelectedIndex = -1;
            }
        }

        private void dateInizio_ValueChanged(object sender, EventArgs e)
        {
            this.dateFine.MinDate = this.dateInizio.Value;
            this.dateFine.Enabled = true;
            this.dateTirocinioHasChanged = true;
        }

        private void printError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonCerca_Click(object sender, EventArgs e)
        {
            try
            { 
                var query = Form1.db.Tirocini.Where(t => t.PostiDisponibili > 0 && t.DataScadenza.Date >= DateTime.Now.Date).AsQueryable();
                if (this.boxCampo.SelectedIndex > 0)
                {
                    var ambiti = Form1.db.Ambiti.Where(a => a.CodCampo.Equals(this.boxCampo.SelectedIndex)).Select(a => a.CodAmbito).ToList();
                    var coperture = Form1.db.Coperture.Where(c => ambiti.Contains(c.CodAmbito)).Select(c => c.CodTirocinio).Distinct().ToList();
                    query = query.Where(t => coperture.Contains(t.CodTirocinio));
                }
                if (this.boxStato.SelectedIndex > 0)
                {
                    query = query.Where(t => t.Stato.Equals(this.boxStato.Text));
                }
                if (!string.IsNullOrWhiteSpace(this.boxCitta.Text))
                {
                    query = query.Where(t => t.Citta.Equals(this.boxCitta.Text));
                }
                if (this.numericStipendio.Value > 0)
                {
                    query = query.Where(t => t.Stipendio > this.numericStipendio.Value);
                }
                if (this.dateTirocinioHasChanged)
                {
                    query = query.Where(t => t.InizioPeriodo > this.dateInizio.Value.Date && t.FinePeriodo < this.dateFine.Value.Date);
                }                
                if (this.boxDurata.SelectedIndex > 0 && int.TryParse(this.boxDurata.Text, out int minDurata))
                {
                    query = query.Where(t => t.MinDurata.Equals(minDurata));
                }
                if (this.numericCodAzienda.Value > 0)
                {
                    query = query.Where(t => t.CodVAT.Equals(this.numericCodAzienda.Value));
                }
                this.dataGridViewTirocini.DataSource = query;
            } catch (Exception ex)
            {
                printError(ex);
            }
        }

        private void buttonAggiorna_Click(object sender, EventArgs e)
        {
            this.aggiornaCandidature();
        }

        private void buttonInvia_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"Sei sicuro di voler inviare una candidatura per il tirocinio n.{this.numericCodTirocinio.Value}?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res.Equals(DialogResult.OK))
            {
                try
                {
                    var cand = new Candidature
                    {
                        CodStudente = int.Parse(this.id),
                        CodTirocinio = (int)this.numericCodTirocinio.Value,
                        Accettata = false
                    };
                    Form1.db.Candidature.InsertOnSubmit(cand);
                    Form1.db.SubmitChanges();
                } catch (Exception ex)
                {
                    printError(ex);
                }
                
            }
        }

        private void buttonRitira_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"Sei sicuro di voler ritirare la candidatura per il tirocinio n.{this.numericCodTirocinio2.Value}?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res.Equals(DialogResult.OK))
            {
                try
                {
                    Form1.db.Candidature.DeleteOnSubmit(Form1.db.Candidature.Where(c => c.CodStudente.Equals(int.Parse(id)))
                        .Where(c => c.CodTirocinio.Equals(this.numericCodTirocinio2.Value)).First());
                    Form1.db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    printError(ex);
                }

            }
        }

        private void buttonAggiornaAccordi_Click(object sender, EventArgs e)
        {
            this.aggiornaAccordi();
        }

        private void buttonRitiraAccordo_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"Sei sicuro di voler ritirare l'accordo n.{this.numericAccordo.Value}?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res.Equals(DialogResult.OK))
            {
                try
                {
                    Form1.db.Accordi.DeleteOnSubmit(Form1.db.Accordi.Where(a => a.CodAccordo.Equals(this.numericAccordo.Value)).First());
                    Form1.db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    printError(ex);
                }

            }
        }

        private void boxStatoAziende_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.boxStatoAziende.SelectedIndex == 0)
            {
                this.boxStatoAziende.SelectedIndex = -1;
            }
        }

        private void buttonCercaAziende_Click(object sender, EventArgs e)
        {
            try
            {
                var query = Form1.db.Aziende.AsQueryable();
                if (this.numericCodAziendaAziende.Value > 0)
                {
                    query = query.Where(a => a.CodVAT.Equals(this.numericCodAziendaAziende.Value));
                }
                if (this.boxStatoAziende.SelectedIndex > 0)
                {
                    query = query.Where(a => a.Stato.Equals(this.boxStatoAziende.Text));
                }
                if (!string.IsNullOrWhiteSpace(this.boxCittaAziende.Text))
                {
                    query = query.Where(a => a.Citta.Equals(this.boxCittaAziende.Text));
                }               
                this.dataGridViewAziende.DataSource = query;
            }
            catch (Exception ex)
            {
                printError(ex);
            }
        }

        private void boxTipologia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.boxTipologia.SelectedIndex == 0)
            {
                this.boxTipologia.SelectedIndex = -1;
            }
        }

        private void boxStatoAlloggi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.boxStatoAlloggi.SelectedIndex == 0)
            {
                this.boxStatoAlloggi.SelectedIndex = -1;
            }
        }

        private void dateInizioAlloggi_ValueChanged(object sender, EventArgs e)
        {
            this.dateFineAlloggi.MinDate = this.dateInizioAlloggi.Value;
            this.dateFineAlloggi.Enabled = true;
            this.dateAlloggioHasChanged = true;
        }

        private void buttonCercaAlloggi_Click(object sender, EventArgs e)
        {
            if (this.dateAlloggioHasChanged)
            {
                try
                {
                    var dataInizioAlloggio = this.dateInizioAlloggi.Value.Date;
                    var dataFineAlloggio = this.dateFineAlloggi.Value.Date;
                    var query = Form1.db.Alloggi
                        .Where(a => a.NumPosti > Form1.db.Prenotazioni
                                .Where(p => p.CodAlloggio.Equals(a.CodAlloggio))
                                .Where(p => (p.DataInizio < dataInizioAlloggio && p.DataFine > dataFineAlloggio)
                                    || (p.DataInizio > dataInizioAlloggio && p.DataInizio < dataFineAlloggio || p.DataFine > dataInizioAlloggio && p.DataFine < dataFineAlloggio))
                                .Count())
                        .AsQueryable();
                    if (this.boxTipologia.SelectedIndex > 0)
                    {
                        query = query.Where(a => a.CodTipologia.Equals(this.boxTipologia.Text));
                    }
                    if (this.boxStatoAlloggi.SelectedIndex > 0)
                    {
                        query = query.Where(a => a.Stato.Equals(this.boxStatoAlloggi.Text));
                    }
                    if (!string.IsNullOrWhiteSpace(this.boxCittaAlloggi.Text))
                    {
                        query = query.Where(a => a.Citta.Equals(this.boxCittaAlloggi.Text));
                    }                    
                    query = query.Where(a => a.CostoAffitto >= this.numericAffittoMin.Value);
                    if (this.numericAffittoMax.Value > 0)
                    {
                        query = query.Where(a => a.CostoAffitto <= this.numericAffittoMax.Value);
                    }
                    if (this.checkArredato.Checked)
                    {
                        query = query.Where(a => a.Arredato.Equals(this.checkArredato.Checked));
                    }
                    if (this.checkCommissione.Checked)
                    {
                        query = query.Where(a => !a.Commissione.HasValue);
                    }
                    this.dataGridViewAlloggi.DataSource = query;
                }
                catch (Exception ex)
                {
                    printError(ex);
                }
            } else
            {
                printError(new Exception("Inserire i campi obbligatori"));
            }           
        }

        private void dateInizioRichiesta_ValueChanged(object sender, EventArgs e)
        {
            this.dateFineRichiesta.MinDate = this.dateInizioRichiesta.Value;
            this.dateFineRichiesta.Enabled = true;
        }

        private void dateInizioRichiesta2_ValueChanged(object sender, EventArgs e)
        {
            this.dateFineRichiesta2.MinDate = this.dateInizioRichiesta2.Value;
            this.dateFineRichiesta2.Enabled = true;
        }

        private void buttonAggiornaAlloggi_Click(object sender, EventArgs e)
        {
            this.aggiornaRichieste();
        }

        private void buttonCrea_Click(object sender, EventArgs e)
        {
            if (this.dateFineRichiesta.Enabled)
            {
                DialogResult res = MessageBox.Show($"Sei sicuro di voler creare una richiesta per l'alloggio n.{this.numericCodAlloggio.Value}?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res.Equals(DialogResult.OK))
                {
                    try
                    {
                        var richiesta = new Richieste
                        {
                            CodStudente = int.Parse(this.id),
                            CodAlloggio = (int)this.numericCodAlloggio.Value,
                            DataInizio = this.dateInizioRichiesta.Value.Date,
                            DataFine = this.dateFineRichiesta.Value.Date,
                            Accettata = false
                        };
                        Form1.db.Richieste.InsertOnSubmit(richiesta);
                        Form1.db.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        printError(ex);
                    }
                }
            } else
            {
                printError(new Exception("Inserire i campi obbligatori"));
            }
        }

        private void buttonCancella_Click(object sender, EventArgs e)
        {
            if (this.dateFineRichiesta2.Enabled)
            {
                DialogResult res = MessageBox.Show($"Sei sicuro di voler cancellare la richiesta per l'alloggio n.{this.numericCodAlloggio2.Value}?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res.Equals(DialogResult.OK))
                {
                    try
                    {
                        Form1.db.Richieste.DeleteOnSubmit(Form1.db.Richieste.Where(r => r.CodStudente.Equals(int.Parse(this.id))
                            && r.CodAlloggio.Equals((int)this.numericCodAlloggio2.Value)
                            && r.DataInizio.Equals(this.dateInizioRichiesta2.Value.Date)
                            && r.DataFine.Equals(this.dateFineRichiesta2.Value.Date)).First());
                        Form1.db.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        printError(ex);
                    }
                }
            } else
            {
                printError(new Exception("Inserire i campi obbligatori"));
            }
        }

        private void buttonAggiornaPrenotazioni_Click(object sender, EventArgs e)
        {
            this.aggiornaPrenotazioni();
        }

        private void buttonRitiraPrenotazione_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"Sei sicuro di voler ritirare la prenotazione n.{this.numericCodPrenotazione.Value}?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res.Equals(DialogResult.OK))
            {
                try
                {
                    Form1.db.Prenotazioni.DeleteOnSubmit(Form1.db.Prenotazioni.Where(p => p.CodPrenotazione.Equals(this.numericCodPrenotazione.Value)).First());
                    Form1.db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    printError(ex);
                }

            }
        }

        private void dateInizioAccordi_ValueChanged(object sender, EventArgs e)
        {
            dateFineAccordi.MinDate = dateInizioAccordi.Value;
            dateFineAccordi.Enabled = true;
        }

        private void buttonCreaAccordi_Click(object sender, EventArgs e)
        {
            if (boxTirocinioAccordi.SelectedIndex >= 0
                && dateFineAccordi.Enabled)
            {
                DialogResult res = MessageBox.Show($"Sei sicuro di voler creare l'accordo indicato?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res.Equals(DialogResult.OK))
                {
                    try
                    {
                        var accordo = new Accordi
                        {
                            DataInizio = dateInizioAccordi.Value.Date,
                            DataFine = dateFineAccordi.Value.Date,
                            CodStudente = int.Parse(id),
                            CodTirocinio = (int)boxTirocinioAccordi.SelectedItem
                        };
                        Form1.db.Accordi.InsertOnSubmit(accordo);
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

        private void buttonCreaPrenotazioni_Click(object sender, EventArgs e)
        {
            if (boxAlloggioPrenotazioni.SelectedIndex >= 0
                && dateFinePrenotazioni.Enabled)
            {
                DialogResult res = MessageBox.Show($"Sei sicuro di voler creare la prenotazione indicata?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res.Equals(DialogResult.OK))
                {
                    try
                    {
                        var prenotazione = new Prenotazioni
                        {
                            DataInizio = dateInizioPrenotazioni.Value.Date,
                            DataFine = dateFinePrenotazioni.Value.Date,
                            DataPrenotazione = DateTime.Now.Date,
                            CodStudente = int.Parse(id),
                            CodAlloggio = (int)boxAlloggioPrenotazioni.SelectedItem
                        };
                        Form1.db.Prenotazioni.InsertOnSubmit(prenotazione);
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

        private void dateInizioPrenotazioni_ValueChanged(object sender, EventArgs e)
        {
            dateFinePrenotazioni.MinDate = dateInizioPrenotazioni.Value;
            dateFinePrenotazioni.Enabled = true;
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }
    }
}
