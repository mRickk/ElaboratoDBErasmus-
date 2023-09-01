-- # ---------------------------------------------------------------------- #
-- # Project name:          Portale per ERASMUS+ Mobilita per tirocinio     #
-- # Author:                Riccardo Mazzi                                  #
-- # Created on:            A.A. 2022/2023                                  #
-- # ---------------------------------------------------------------------- #

--CREATE DATABASE elaboratodbmazzi;
USE elaboratodbmazzi;

-- Tables Section
-- _____________ 
     
CREATE TABLE Accordi (
     CodAccordo INT IDENTITY(1,1) PRIMARY KEY,
     DataInizio DATE NOT NULL,
     DataFine DATE NOT NULL,
     CodStudente INT NOT NULL,
     CodTirocinio INT NOT NULL,
	 CHECK (DataFine > DataInizio),
     UNIQUE(DataInizio, DataFine, CodStudente, CodTirocinio));

CREATE TABLE Alloggi (
     CodAlloggio INT IDENTITY(1,1) PRIMARY KEY,
     Titolo TEXT NOT NULL,
     Stato CHAR(2) NOT NULL,
     Citta VARCHAR(64) NOT NULL,
     CodPostale VARCHAR(16) NOT NULL,
     Quartiere VARCHAR(32),
     Via VARCHAR(64),
     NumCivico INT,
     Piano SMALLINT,
     Interno SMALLINT,
     NumPosti TINYINT NOT NULL,
     CostoAffitto MONEY NOT NULL,
     Arredato BIT NOT NULL,
     CostoServizi SMALLMONEY,
     Commissione SMALLMONEY,
     Caparra SMALLMONEY,
     CodLocatore INT NOT NULL,
     CodTipologia VARCHAR(4) NOT NULL,
     CONSTRAINT VincoloPianoInterno CHECK (
		(Piano IS NULL AND Interno IS NULL) OR
        ((Piano IS NOT NULL OR Interno IS NOT NULL) AND Via IS NOT NULL AND NumCivico IS NOT NULL))
     );

CREATE INDEX Stato ON Alloggi(Stato);
CREATE INDEX CostoAffitto ON Alloggi(CostoAffitto);

CREATE TABLE Ambiti (
     CodAmbito FLOAT PRIMARY KEY,
     Descrizione TEXT NOT NULL,
     CodCampo TINYINT NOT NULL);

CREATE TABLE Aziende (
     CodVAT INT IDENTITY(1,1) PRIMARY KEY,
     Nome VARCHAR(64) NOT NULL,
     Stato CHAR(2) NOT NULL,
     Citta VARCHAR(64) NOT NULL,
     CodPostale VARCHAR(16) NOT NULL,
     Via VARCHAR(64) NOT NULL,
     NumCivico INT NOT NULL,
     SitoWeb VARCHAR(64),
     Mail VARCHAR(64),
     Telefono VARCHAR(32),
     CodIntermediario INT NOT NULL,
     CodNACE VARCHAR(8) NOT NULL);

CREATE TABLE Campi (
     CodCampo TINYINT PRIMARY KEY,
     Descrizione TEXT NOT NULL);

CREATE TABLE Candidature (
     CodStudente INT NOT NULL,
     CodTirocinio INT NOT NULL,
     Accettata BIT NOT NULL DEFAULT 0,
     PRIMARY KEY(CodTirocinio, CodStudente));

create table Coperture (
     CodAmbito FLOAT NOT NULL,
     CodTirocinio INT NOT NULL,
     PRIMARY KEY(CodAmbito, CodTirocinio));

CREATE TABLE Intermediari (
     CodIntermediario INT IDENTITY(1,1) PRIMARY KEY,
     CF CHAR(16) NOT NULL,
	 UNIQUE(CF));

CREATE TABLE Locatori (
     CodLocatore INT IDENTITY(1,1) PRIMARY KEY,
     CF CHAR(16) NOT NULL,
	 UNIQUE(CF));

CREATE TABLE Persone (
     CF CHAR(16) PRIMARY KEY,
     Nome VARCHAR(64) NOT NULL,
     Cognome VARCHAR(64) NOT NULL,
     Mail VARCHAR(64) NOT NULL,
     Telefono VARCHAR(32) NOT NULL,
     DataNascita DATE NOT NULL,
     Stato CHAR(2) NOT NULL,
     Citta VARCHAR(64) NOT NULL,
     CodPostale VARCHAR(16) NOT NULL,
     Via VARCHAR(64) NOT NULL,
     NumCivico INT NOT NULL);

CREATE TABLE Prenotazioni (
     CodPrenotazione INT IDENTITY(1,1) PRIMARY KEY,
     DataInizio DATE NOT NULL,
     DataFine DATE NOT NULL,
     DataPrenotazione DATE NOT NULL,
     CodStudente INT NOT NULL,
     CodAlloggio INT NOT NULL,
	 CHECK (DataFine > DataInizio),
     UNIQUE(DataInizio, DataFine, CodStudente, CodAlloggio));

CREATE TABLE Richieste (
     CodAlloggio INT NOT NULL,
     CodStudente INT NOT NULL,
     DataInizio DATE NOT NULL,
     DataFine DATE NOT NULL,
     Accettata BIT NOT NULL DEFAULT 0,
	 CHECK (DataFine > DataInizio),
     PRIMARY KEY(CodAlloggio, CodStudente, DataInizio, DataFine));

CREATE TABLE Settori (
     CodNACE VARCHAR(8) PRIMARY KEY,
     Descrizione TEXT NOT NULL,
     CodCapitolo VARCHAR(8),
     CodSezione VARCHAR(8),
     CodParagrafo VARCHAR(8),
     CONSTRAINT VincoloParagrafo CHECK (
		CodParagrafo IS NULL OR
        (CodParagrafo IS NOT NULL AND CodSezione IS NOT NULL AND CodCapitolo IS NOT NULL)),
	 CONSTRAINT VincoloSezione CHECK (
		CodSezione IS NULL OR
        (CodSezione IS NOT NULL AND CodCapitolo IS NOT NULL))
     );

CREATE TABLE Studenti (
     CodStudente INT IDENTITY(1,1) PRIMARY KEY,
     CF CHAR(16) NOT NULL,
     NumMatricola INT NOT NULL,
     Universita CHAR(64) NOT NULL,
     CodCorso VARCHAR(8) NOT NULL,
     AnnoImmatricolazione SMALLINT NOT NULL,
     CV VARBINARY(MAX),
     UNIQUE(CF));
     
CREATE TABLE Tipologie (
     CodTipologia VARCHAR(4) PRIMARY KEY,
     Nome VARCHAR(64) NOT NULL);

CREATE TABLE Tirocini (
     CodTirocinio INT IDENTITY(1,1) PRIMARY KEY,
     Titolo TEXT NOT NULL,
     Stato CHAR(2) NOT NULL,
     Citta VARCHAR(64) NOT NULL,
     CodPostale VARCHAR(16) NOT NULL,
     Via VARCHAR(64) NOT NULL,
     NumCivico INT NOT NULL,
     PostiDisponibili TINYINT NOT NULL,
     InizioPeriodo DATE NOT NULL,
     FinePeriodo DATE NOT NULL,
     MinDurata TINYINT NOT NULL,
     DataScadenza DATE NOT NULL,
     Stipendio SMALLMONEY,
     CodVAT INT NOT NULL,
	 CHECK (MinDurata >= 1),
	 CHECK (FinePeriodo > InizioPeriodo),
     CHECK (DataScadenza < InizioPeriodo));

CREATE INDEX Stato ON Tirocini(Stato);
CREATE INDEX PostiDisponibili ON Tirocini(PostiDisponibili);

-- FK Section
-- ___________________ 

ALTER TABLE Accordi ADD CONSTRAINT FKTirocinante
	FOREIGN KEY (CodStudente) REFERENCES Studenti(CodStudente) ON DELETE CASCADE;

ALTER TABLE Accordi ADD CONSTRAINT FKSvolgimento
	FOREIGN KEY (CodTirocinio) REFERENCES Tirocini(CodTirocinio) ON DELETE CASCADE;

ALTER TABLE Alloggi ADD CONSTRAINT FKPubblicazione
    FOREIGN KEY (CodLocatore) REFERENCES Locatori(CodLocatore) ON DELETE CASCADE;

ALTER TABLE Alloggi ADD CONSTRAINT FKAppartenenza
    FOREIGN KEY (CodTipologia) REFERENCES Tipologie(CodTipologia) ON DELETE CASCADE;

ALTER TABLE Ambiti ADD CONSTRAINT FKComposizione
	FOREIGN KEY (CodCampo) REFERENCES Campi(CodCampo) ON DELETE CASCADE;

ALTER TABLE Aziende ADD CONSTRAINT FKRappresentanza
	FOREIGN KEY (CodIntermediario) REFERENCES Intermediari(CodIntermediario) ON DELETE CASCADE;

ALTER TABLE Aziende ADD CONSTRAINT FKClassificazione
	FOREIGN KEY (CodNACE) REFERENCES Settori(CodNACE) ON DELETE CASCADE;

ALTER TABLE Candidature ADD CONSTRAINT FKCand_Studente 
	FOREIGN KEY (CodStudente) REFERENCES Studenti(CodStudente) ON DELETE CASCADE;

ALTER TABLE Candidature ADD CONSTRAINT FKCan_Tirocinio
	FOREIGN KEY (CodTirocinio) REFERENCES Tirocini(CodTirocinio) ON DELETE CASCADE;

ALTER TABLE Coperture ADD CONSTRAINT FKCop_Ambito
	FOREIGN KEY (CodAmbito) REFERENCES Ambiti(CodAmbito) ON DELETE CASCADE;

ALTER TABLE Coperture ADD CONSTRAINT FKCop_Tirocinio
    FOREIGN KEY (CodTirocinio) REFERENCES Tirocini(CodTirocinio) ON DELETE CASCADE;

ALTER TABLE Intermediari ADD CONSTRAINT FKInterm_Persona
	FOREIGN KEY (CF) REFERENCES Persone(CF) ON DELETE CASCADE;

ALTER TABLE Locatori ADD CONSTRAINT FKLocat_Persona
	FOREIGN KEY (CF) REFERENCES Persone(CF) ON DELETE CASCADE;

ALTER TABLE Prenotazioni ADD CONSTRAINT FKAffituario
    FOREIGN KEY (CodStudente) REFERENCES Studenti(CodStudente) ON DELETE CASCADE;

ALTER TABLE Prenotazioni ADD CONSTRAINT FKAffitto
    FOREIGN KEY (CodAlloggio) REFERENCES Alloggi(CodAlloggio) ON DELETE CASCADE;

ALTER TABLE Richieste ADD CONSTRAINT FKRic_Studente
    FOREIGN KEY (CodStudente) REFERENCES Studenti(CodStudente) ON DELETE CASCADE;

ALTER TABLE Richieste ADD CONSTRAINT FKRic_Alloggio
    FOREIGN KEY (CodAlloggio) REFERENCES Alloggi(CodAlloggio) ON DELETE CASCADE;

ALTER TABLE Studenti ADD CONSTRAINT FKStud_Persona
    FOREIGN KEY (CF) references Persone(CF) ON DELETE NO ACTION;

ALTER TABLE Tirocini ADD CONSTRAINT FKProposta
    FOREIGN KEY (CodVAT) REFERENCES Aziende(CodVAT) ON DELETE CASCADE;
