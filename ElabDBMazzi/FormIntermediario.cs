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
    public partial class FormIntermediario : Form
    {
        private string cf;
        private string id;
        private Form1 form1;

        private void aggiornaAziende()
        {
            this.dataGridViewAziende.DataSource = Form1.db.Aziende
                                                    .Where(a => a.CodIntermediario.Equals(this.id)).ToList();
            var connection = Form1.db.Connection;
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT IDENT_CURRENT('Aziende') + IDENT_INCR('Aziende')";
            this.numericCodAziendaAziende.Value = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
        }
        private void initTabAziende()
        {
            this.aggiornaAziende();
            this.numericCodIntermediarioAziende.Value = int.Parse(this.id);
            this.numericCodIntermediarioAziende2.Value = int.Parse(this.id);            
        }
        private void initTabSettori()
        {
            var settori = new Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>();
            var dbSettori = Form1.db.Settori;
            foreach (var s in dbSettori)
            {
                if (s.CodCapitolo == null)
                {
                    settori.Add(s.CodNACE, new Dictionary<string, Dictionary<string, List<string>>>());
                } else if (s.CodSezione == null)
                {
                    settori[s.CodCapitolo].Add(s.CodNACE, new Dictionary<string, List<string>>());
                } else if (s.CodParagrafo == null)
                {
                    settori[s.CodCapitolo][s.CodSezione].Add(s.CodNACE, new List<string>());
                } else
                {
                    settori[s.CodCapitolo][s.CodSezione][s.CodParagrafo].Add(s.CodNACE);
                }
            }
            foreach (var capitolo in settori.Keys)
            {
                var capitoloNode = new TreeNode($"{capitolo} - {dbSettori.Where(s => s.CodNACE.Equals(capitolo)).First().Descrizione}");
                foreach (var sezione in settori[capitolo].Keys)
                {
                    var sezioneNode = new TreeNode($"{sezione} - {dbSettori.Where(s => s.CodNACE.Equals(sezione)).First().Descrizione}");
                    foreach (var paragrafo in settori[capitolo][sezione].Keys)
                    {
                        var paragrafoNode = new TreeNode($"{paragrafo} - {dbSettori.Where(s => s.CodNACE.Equals(paragrafo)).First().Descrizione}");
                        foreach (var codice in settori[capitolo][sezione][paragrafo])
                        {
                            paragrafoNode.Nodes.Add($"{codice} - {dbSettori.Where(s => s.CodNACE.Equals(codice)).First().Descrizione}");
                        }
                        sezioneNode.Nodes.Add(paragrafoNode);
                    }
                    capitoloNode.Nodes.Add(sezioneNode);
                }
                treeSettori.Nodes.Add(capitoloNode);
            }
        }
        private void aggiornaTirocini()
        {
            object filtroAzienda = boxAziendaTirocini.SelectedIndex >= 0 ? boxAziendaTirocini.SelectedItem : null;
            boxAziendaTirocini.Items.Clear();
            boxAziendaTirocini2.Items.Clear();
            boxTirocinioTirocini.Items.Clear();
            foreach (var azienda in Form1.db.Aziende.Where(a => a.CodIntermediario.Equals(id)).ToList())
            {
                boxAziendaTirocini.Items.Add(azienda.CodVAT);
                boxAziendaTirocini2.Items.Add(azienda.CodVAT);
            }
            var query = Form1.db.Tirocini
                                                .Join(Form1.db.Aziende, t => t.CodVAT, a => a.CodVAT, (t, a) => new
                                                {
                                                    t.CodTirocinio,
                                                    t.Titolo,
                                                    t.Stato,
                                                    t.Citta,
                                                    t.CodPostale,
                                                    t.PostiDisponibili,
                                                    t.InizioPeriodo,
                                                    t.FinePeriodo,
                                                    t.MinDurata,
                                                    t.DataScadenza,
                                                    t.Stipendio,
                                                    a.CodVAT,
                                                    a.Nome,
                                                    a.CodIntermediario
                                                })
                                                .Where(ta => ta.CodIntermediario.Equals(id))
                                                .AsQueryable();
            boxTirocinioTirocini.Items.AddRange(query.Select(ta => (object)ta.CodTirocinio).ToArray());
            if (filtroAzienda != null)
            {
                query = query.Where(ta => ta.CodVAT.Equals(filtroAzienda));
                boxAziendaTirocini.SelectedItem = filtroAzienda;
            }
            dataGridViewTirocini.DataSource = query;
        }
        private void initTabTirocini()
        {
            this.aggiornaTirocini();
            var campi = from c in Form1.db.Campi
                        select new { c.CodCampo, c.Descrizione };
            foreach (var c in campi)
            {
                boxCampoTirocini.Items.Add($"{c.CodCampo} {c.Descrizione}");
            }
        }
        private void aggiornaCandidature()
        {
            var query = Form1.db.Tirocini
                                .Join(Form1.db.Aziende, t => t.CodVAT, a => a.CodVAT, (t, a) => new
                                                {
                                                    t.CodTirocinio,
                                                    a.CodIntermediario
                                                })
                                .Where(ta => ta.CodIntermediario.Equals(id))
                                .AsQueryable();
            boxTirocinioCandidature.Items.AddRange(query.Select(ta => (object)ta.CodTirocinio).ToArray());
            dataGridViewCandidature.DataSource = query.Join(Form1.db.Candidature, ta => ta.CodTirocinio, c => c.CodTirocinio, (ta, c) => new
            {
                c.CodTirocinio,
                c.CodStudente,
                c.Accettata,
            }).Join(Form1.db.Studenti, tac => tac.CodStudente, s => s.CodStudente, (tac, s) => new
            {
                tac.CodTirocinio,
                tac.CodStudente,
                tac.Accettata,
                s.CF,
                s.Universita,
                s.CodCorso,
                s.AnnoImmatricolazione,
                s.CV
            }).Join(Form1.db.Persone, tacs => tacs.CF, p => p.CF, (tacs, p) => new
            {
                tacs.CodTirocinio,
                tacs.CodStudente,
                tacs.Accettata,
                p.Nome,
                p.Cognome,
                p.Mail,
                p.DataNascita,
                p.Stato,
                tacs.Universita,
                tacs.CodCorso,
                tacs.AnnoImmatricolazione,
                tacs.CV
            });
        }
        private void aggiornaAccordi()
        {
            var query = Form1.db.Tirocini
            .Join(Form1.db.Aziende, t => t.CodVAT, a => a.CodVAT, (t, a) => new
            {
                t.CodTirocinio,
                a.CodIntermediario
            })
            .Where(ta => ta.CodIntermediario.Equals(id))
            .Join(Form1.db.Accordi, ta => ta.CodTirocinio, ac => ac.CodTirocinio, (ta, ac) => new
            {
                ac.CodAccordo,
                ta.CodTirocinio,
                ac.CodStudente,
                ac.DataInizio,
                ac.DataFine
            })
            .Join(Form1.db.Studenti, tac => tac.CodStudente, s => s.CodStudente, (tac, s) => new
            {
                tac.CodAccordo,
                tac.CodTirocinio,
                tac.CodStudente,
                tac.DataInizio,
                tac.DataFine,
                s.CF,
                s.Universita,
                s.CodCorso,
                s.AnnoImmatricolazione,
                s.CV
            })
            .Join(Form1.db.Persone, tacs => tacs.CF, p => p.CF, (tacs, p) => new
            {
                tacs.CodAccordo,
                tacs.CodTirocinio,
                tacs.CodStudente,
                tacs.DataInizio,
                tacs.DataFine,
                p.Nome,
                p.Cognome,
                p.Mail,
                p.DataNascita,
                p.Stato,
                tacs.Universita,
                tacs.CodCorso,
                tacs.AnnoImmatricolazione,
                tacs.CV
            })
            .AsQueryable();
            boxAccordoAccordi.Items.AddRange(query.Select(tacsp => (object)tacsp.CodAccordo).ToArray());
            dataGridViewAccordi.DataSource = query;
        }
        public FormIntermediario(string CF, string ID, Form1 form1)
        {
            this.cf = CF;
            this.id = ID;
            this.form1 = form1;
            InitializeComponent();
            this.labelNome.Text = Form1.db.Persone.Where(p => p.CF.Equals(cf)).First().Nome;
            this.initTabAziende();
            this.initTabSettori();
            this.initTabTirocini();
            this.aggiornaCandidature();
            this.aggiornaAccordi();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            form1.Close();
        }
        private void printError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonAggiornaAziende_Click(object sender, EventArgs e)
        {
            this.aggiornaAziende();
        }
        private bool checkDatiAziende()
        {
            return numericCodAziendaAziende.Value > 0 && !string.IsNullOrWhiteSpace(boxNomeAziende.Text)
                && boxStatoAziende.SelectedIndex >= 0 && !string.IsNullOrWhiteSpace(boxCittaAziende.Text)
                && !string.IsNullOrWhiteSpace(boxViaAziende.Text) && numericNumCivicoAziende.Value > 0
                && !string.IsNullOrWhiteSpace(boxCodPostaleAziende.Text) && !string.IsNullOrWhiteSpace(boxSettoreAziende.Text);
        }
        private void buttonAggiungiAziende_Click(object sender, EventArgs e)
        {
            if (checkDatiAziende())
            {
                DialogResult res = MessageBox.Show($"Sei sicuro di voler aggiungere l'azienda n.{numericCodAziendaAziende.Value}?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res.Equals(DialogResult.OK))
                {
                    try
                    {
                        var azienda = new Aziende
                        {
                            CodVAT = (int)numericCodAziendaAziende.Value,
                            Nome = boxNomeAziende.Text,
                            Stato = boxStatoAziende.Text,
                            Citta = boxCittaAziende.Text,
                            CodPostale = boxCodPostaleAziende.Text,
                            Via = boxViaAziende.Text,
                            NumCivico = (int)numericNumCivicoAziende.Value,
                            SitoWeb = string.IsNullOrWhiteSpace(boxSitoAziende.Text) ? null : boxSitoAziende.Text,
                            Mail = string.IsNullOrWhiteSpace(boxMailAziende.Text) ? null : boxMailAziende.Text,
                            Telefono = string.IsNullOrWhiteSpace(boxTelefonoAziende.Text) ? null : boxTelefonoAziende.Text,
                            CodIntermediario = int.Parse(id),
                            CodNACE = boxSettoreAziende.Text
                        };
                        Form1.db.Aziende.InsertOnSubmit(azienda);
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

        private void buttonElimina_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"Sei sicuro di voler eliminare l'azienda n.{numericCodAziendaAziende2.Value}?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res.Equals(DialogResult.OK))
            {
                try
                {
                    Form1.db.Aziende.DeleteOnSubmit(Form1.db.Aziende
                                    .Where(a => a.CodIntermediario.Equals(id) && a.CodVAT.Equals(numericCodAziendaAziende2.Value))
                                    .First());
                    Form1.db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    printError(ex);
                }
            }
        }

        private void buttonCercaTirocini_Click(object sender, EventArgs e)
        {
            if (boxAziendaTirocini.SelectedIndex >= 0)
            {
                try
                {
                    var query = Form1.db.Tirocini.Where(t => t.CodVAT.Equals(boxAziendaTirocini.SelectedItem));
                    dataGridViewTirocini.DataSource = query;
                } catch (Exception ex)
                {
                    printError(ex);
                }
                
            } else
            {
                printError(new Exception("Inserire i campi obbligatori"));
            }
        }

        private void dateInizioTirocini_ValueChanged(object sender, EventArgs e)
        {
            dateFineTirocini.MinDate = dateInizioTirocini.Value;
            dateFineTirocini.Enabled = true;
            dateScadenzaTirocini.MaxDate = dateInizioTirocini.Value;
            dateScadenzaTirocini.Enabled = true;
        }

        private bool checkTirocini()
        {
            return !string.IsNullOrWhiteSpace(boxTitoloTirocini.Text) && boxStatoTirocini.SelectedIndex >= 0
                && !string.IsNullOrWhiteSpace(boxCittaTirocini.Text) && !string.IsNullOrWhiteSpace(boxCodPostaleTirocini.Text)
                && !string.IsNullOrWhiteSpace(boxViaTirocini.Text) && numericNumCivicoTirocini.Value > 0
                && numericPostiTirocini.Value > 0 && dateFineTirocini.Enabled
                && boxDurataTirocini.SelectedIndex >= 0 && boxAziendaTirocini2.SelectedIndex >= 0;
        }

        private void buttonCreaTirocini_Click(object sender, EventArgs e)
        {
            if (checkTirocini())
            {
                DialogResult res = MessageBox.Show($"Sei sicuro di voler aggiungere un nuovo tirocinio?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res.Equals(DialogResult.OK))
                {
                    try
                    {
                        var tirocinio = new Tirocini
                        {
                            Titolo = boxTitoloTirocini.Text,
                            Stato = boxStatoTirocini.Text,
                            Citta = boxCittaTirocini.Text,
                            CodPostale = boxCodPostaleTirocini.Text,
                            Via = boxViaTirocini.Text,
                            NumCivico = (int)numericNumCivicoTirocini.Value,
                            PostiDisponibili = (byte)numericPostiTirocini.Value,
                            InizioPeriodo = dateInizioTirocini.Value.Date,
                            FinePeriodo = dateFineTirocini.Value.Date,
                            MinDurata = byte.Parse(boxDurataTirocini.Text),
                            DataScadenza = dateScadenzaTirocini.Value.Date,
                            Stipendio = null,
                            CodVAT = int.Parse(boxAziendaTirocini2.Text)
                        };
                        if (numericStipendioTirocini.Value > 0)
                        {
                            tirocinio.Stipendio = (int)numericStipendioTirocini.Value;
                        }
                        Form1.db.Tirocini.InsertOnSubmit(tirocinio);
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

        private void buttonEliminaTirocini_Click(object sender, EventArgs e)
        {
            if (boxTirocinioTirocini.SelectedIndex >= 0)
            {
                DialogResult res = MessageBox.Show($"Sei sicuro di voler eliminare il tirocinio n.{boxTirocinioTirocini.SelectedItem}?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res.Equals(DialogResult.OK))
                {
                    try
                    {
                        Form1.db.Tirocini.DeleteOnSubmit(Form1.db.Tirocini
                                .Where(t => t.CodTirocinio.Equals(boxTirocinioTirocini.SelectedItem))
                                .First());
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

        private void buttonAggiornaTirocini_Click(object sender, EventArgs e)
        {
            this.aggiornaTirocini();
        }

        private void buttonAggiornaCandidature_Click(object sender, EventArgs e)
        {
            this.aggiornaCandidature();
        }

        private void buttonAccettaCandidature_Click(object sender, EventArgs e)
        {
            if (numericCodStudenteCandidature.Value > 0 && boxTirocinioCandidature.SelectedIndex >= 0)
            {
                DialogResult res = MessageBox.Show($"Sei sicuro di voler rimuovere l'accordo indicato?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res.Equals(DialogResult.OK))
                {
                    try
                    {
                        var cand = Form1.db.Candidature.SingleOrDefault(c =>
                                c.CodStudente.Equals(numericCodStudenteCandidature.Value)
                                && c.CodTirocinio.Equals(boxTirocinioCandidature.SelectedItem));
                        cand.Accettata = true;
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

        private void buttonAggiornaAccordi_Click(object sender, EventArgs e)
        {
            this.aggiornaAccordi();
        }

        private void buttonRitiraAccordi_Click(object sender, EventArgs e)
        {
            if (boxAccordoAccordi.SelectedIndex >= 0)
            {
                DialogResult res = MessageBox.Show($"Sei sicuro di voler accettare la candidatura indicata?", "Attenzione", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res.Equals(DialogResult.OK))
                {
                    try
                    {
                        Form1.db.Accordi.DeleteOnSubmit(Form1.db.Accordi
                            .Where(a => a.CodAccordo.Equals(boxAccordoAccordi.SelectedItem))
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
