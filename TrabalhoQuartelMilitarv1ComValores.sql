CREATE TABLE Veiculo (
  Vid         int IDENTITY NOT NULL, 
  NomeVeiculo varchar(255) NULL, 
  lotacao     int NULL, 
  tara        int NULL, 
  CP          int NULL, 
  Rua         varchar(255) NULL, 
  Estado      varchar(255) NULL, 
  Cid         int NOT NULL, 
  ModID       int NOT NULL, 
  CPCP        int NOT NULL, 
  PRIMARY KEY (Vid));
CREATE TABLE Classe (
  Cid       int IDENTITY NOT NULL, 
  DesClasse varchar(255) NULL, 
  PRIMARY KEY (Cid));
CREATE TABLE Modelo (
  ModID      int IDENTITY NOT NULL, 
  DescModelo varchar(255) NULL, 
  MaID       int NOT NULL, 
  PRIMARY KEY (ModID));
CREATE TABLE Marca (
  MaID      int IDENTITY NOT NULL, 
  DescMarca varchar(255) NULL, 
  PRIMARY KEY (MaID));
CREATE TABLE CodigoPostal (
  CP         int IDENTITY NOT NULL, 
  Localidade varchar(255) NULL, 
  PRIMARY KEY (CP));
CREATE TABLE Requisicoes (
  ReqID      int IDENTITY NOT NULL, 
  DataReq    datetime NULL, 
  CondutorID int NOT NULL, 
  Vid        int NOT NULL, 
  OficialID  int NOT NULL, 
  PRIMARY KEY (ReqID));
CREATE TABLE Inspecoes (
  Vid      int NOT NULL, 
  MatID    int NOT NULL, 
  DataInsp datetime NULL, 
  PRIMARY KEY (Vid, 
  MatID));
CREATE TABLE Material (
  MatID   int IDENTITY NOT NULL, 
  DescMat varchar(255) NULL, 
  TMID    int NOT NULL, 
  PRIMARY KEY (MatID));
CREATE TABLE TipoMaterial (
  TMID   int IDENTITY NOT NULL, 
  DescTM varchar(255) NULL, 
  PRIMARY KEY (TMID));
CREATE TABLE Condutor (
  CondutorID   int IDENTITY NOT NULL, 
  NomeCondutor varchar(255) NULL, 
  PRIMARY KEY (CondutorID));
CREATE TABLE Oficial (
  OficialID   int IDENTITY NOT NULL, 
  NomeOficial varchar(255) NULL, 
  CargoID     int NOT NULL, 
  PRIMARY KEY (OficialID));
CREATE TABLE Cargo (
  CargoID   int IDENTITY NOT NULL, 
  CargoDesc varchar(255) NULL, 
  PRIMARY KEY (CargoID));
CREATE TABLE Habilitacao (
  Cid        int NOT NULL, 
  CondutorID int NOT NULL, 
  DataHab    datetime NULL, 
  PRIMARY KEY (Cid, 
  CondutorID));
CREATE TABLE Contacto (
  OficialID int NOT NULL, 
  TCID      int NOT NULL, 
  NumeroC   int NULL, 
  PRIMARY KEY (OficialID, 
  TCID));
CREATE TABLE TipoContacto (
  TCID   int IDENTITY NOT NULL, 
  DescTC varchar(255) NULL, 
  PRIMARY KEY (TCID));
ALTER TABLE Veiculo ADD CONSTRAINT FKVeiculo450386 FOREIGN KEY (Cid) REFERENCES Classe (Cid);
ALTER TABLE Veiculo ADD CONSTRAINT FKVeiculo585050 FOREIGN KEY (ModID) REFERENCES Modelo (ModID);
ALTER TABLE Veiculo ADD CONSTRAINT FKVeiculo694500 FOREIGN KEY (CPCP) REFERENCES CodigoPostal (CP);
ALTER TABLE Inspecoes ADD CONSTRAINT FKInspecoes384383 FOREIGN KEY (Vid) REFERENCES Veiculo (Vid);
ALTER TABLE Inspecoes ADD CONSTRAINT FKInspecoes102187 FOREIGN KEY (MatID) REFERENCES Material (MatID);
ALTER TABLE Material ADD CONSTRAINT FKMaterial364907 FOREIGN KEY (TMID) REFERENCES TipoMaterial (TMID);
ALTER TABLE Requisicoes ADD CONSTRAINT FKRequisicoe23812 FOREIGN KEY (CondutorID) REFERENCES Condutor (CondutorID);
ALTER TABLE Oficial ADD CONSTRAINT FKOficial836722 FOREIGN KEY (CargoID) REFERENCES Cargo (CargoID);
ALTER TABLE Requisicoes ADD CONSTRAINT FKRequisicoe19853 FOREIGN KEY (Vid) REFERENCES Veiculo (Vid);
ALTER TABLE Requisicoes ADD CONSTRAINT FKRequisicoe360593 FOREIGN KEY (OficialID) REFERENCES Oficial (OficialID);
ALTER TABLE Habilitacao ADD CONSTRAINT FKHabilitaca521887 FOREIGN KEY (Cid) REFERENCES Classe (Cid);
ALTER TABLE Habilitacao ADD CONSTRAINT FKHabilitaca189163 FOREIGN KEY (CondutorID) REFERENCES Condutor (CondutorID);
ALTER TABLE Contacto ADD CONSTRAINT FKContacto490275 FOREIGN KEY (OficialID) REFERENCES Oficial (OficialID);
ALTER TABLE Contacto ADD CONSTRAINT FKContacto422324 FOREIGN KEY (TCID) REFERENCES TipoContacto (TCID);
ALTER TABLE Modelo ADD CONSTRAINT FKModelo41650 FOREIGN KEY (MaID) REFERENCES Marca (MaID);


-- =============================================
-- 1. DADOS DE SUPORTE (Necessários para as FKs)
-- =============================================

-- Inserir Marcas
INSERT INTO Marca (DescMarca) VALUES ('Mercedes-Benz'), ('Land Rover'), ('Toyota'), ('IVECO'), ('MAN'), ('Renault');

-- Inserir Modelos (Assumindo IDs 1 a 6 para as Marcas acima)
INSERT INTO Modelo (DescModelo, MaID) VALUES 
('Sprinter', 1), ('Defender 110', 2), ('Hilux 4x4', 3), ('Trakker', 4), 
('TGX 26.440', 5), ('GBC 180', 6), ('Land Cruiser', 3), ('Atego', 1);

-- Inserir Classes
INSERT INTO Classe (DesClasse) VALUES ('Ligeiro Passageiros'), ('Ligeiro Mercadorias'), ('Pesado de Tropas'), ('Pesado de Mercadorias'), ('Tático/Blindado');

-- Inserir Códigos Postais
INSERT INTO CodigoPostal (Localidade) VALUES ('Lisboa'), ('Porto'), ('Coimbra'), ('Évora'), ('Braga');

-- Inserir Cargos
INSERT INTO Cargo (CargoDesc) VALUES ('Coronel'), ('Tenente-Coronel'), ('Major'), ('Capitão'), ('Tenente'), ('Alferes'), ('Sargento-Ajudante');


-- =============================================
-- 2. INSERIR 10 OFICIAIS
-- =============================================

INSERT INTO Oficial (NomeOficial, CargoID) VALUES 
('António Silva', 1),    -- Coronel
('Carlos Oliveira', 2),  -- Tenente-Coronel
('Maria João Bento', 3), -- Major
('Ricardo Pereira', 4),  -- Capitão
('José Rodrigues', 4),   -- Capitão
('Luísa Fernandes', 5),  -- Tenente
('Nuno Santos', 5),      -- Tenente
('Paulo Gouveia', 6),    -- Alferes
('Sérgio Matos', 3),     -- Major
('Beatriz Costa', 4);    -- Capitão


-- =============================================
-- 3. INSERIR 10 VEÍCULOS
-- =============================================

-- Campos: NomeVeiculo, lotacao, tara, CP, Rua, Estado, Cid, ModID, CPCP
INSERT INTO Veiculo (NomeVeiculo, lotacao, tara, CP, Rua, Estado, Cid, ModID, CPCP) VALUES 
('Viatura Tática 01', 3, 2500, 1000, 'Ala Norte', 'Operacional', 5, 2, 1),
('Transporte Tropas A', 22, 8000, 2000, 'Hangar 1', 'Operacional', 3, 6, 2),
('Viatura Comando', 5, 2200, 1000, 'Ala Norte', 'Oficina', 1, 7, 1),
('Camião Logístico', 3, 12000, 4000, 'Hangar 2', 'Operacional', 4, 5, 3),
('Pick-up Patrulha 1', 5, 2800, 1200, 'Portaria', 'Operacional', 2, 3, 4),
('Viatura Instrução', 9, 3500, 1500, 'Hangar 1', 'Operacional', 1, 1, 5),
('Ambulância Militar', 4, 3800, 1500, 'Centro Médico', 'Operacional', 2, 8, 1),
('Viatura Tática 02', 3, 2500, 1000, 'Ala Norte', 'Abatido', 5, 2, 1),
('Camião Cisterna', 2, 14000, 5000, 'Hangar 2', 'Operacional', 4, 4, 2),
('Pick-up Patrulha 2', 5, 2800, 1200, 'Portaria', 'Operacional', 2, 3, 4);


-- =============================================
-- 4. DADOS EXTRA (Opcional - Condutores e Contactos)
-- =============================================

INSERT INTO Condutor (NomeCondutor) VALUES ('Cabo Manuel Silva'), ('Soldado João Rato'), ('Sargento Pedro Lima');

INSERT INTO TipoContacto (DescTC) VALUES ('Telemóvel'), ('Email'), ('Extensão Interna');

INSERT INTO Contacto (OficialID, TCID, NumeroC) VALUES (1, 1, 912345678), (1, 3, 404);

-- =============================================
-- 5. INSERIR REQUISIÇÕES (Histórico de Uso)
-- =============================================

-- Campos: DataReq, CondutorID, Vid, OficialID
-- Nota: O ReqID é IDENTITY, por isso não é incluído.

INSERT INTO Requisicoes (DataReq, CondutorID, Vid, OficialID) VALUES 
('2024-05-10 08:30:00', 1, 1, 4),  -- Cabo Manuel Silva levou Viatura Tática 01 (Capitão Ricardo)
('2024-05-10 09:15:00', 2, 2, 3),  -- Soldado João Rato levou Transporte Tropas A (Major Maria)
('2024-05-11 14:00:00', 3, 5, 5),  -- Sargento Pedro Lima levou Pick-up Patrulha 1 (Capitão José)
('2024-05-12 07:00:00', 1, 9, 2),  -- Cabo Manuel Silva levou Camião Cisterna (Ten-Coronel Carlos)
('2024-05-12 10:30:00', 2, 6, 6),  -- Soldado João Rato levou Viatura Instrução (Tenente Luísa)
('2024-05-13 08:00:00', 3, 7, 1),  -- Sargento Pedro Lima levou Ambulância Militar (Coronel António)
('2024-05-14 16:45:00', 1, 10, 7), -- Cabo Manuel Silva levou Pick-up Patrulha 2 (Tenente Nuno)
('2024-05-15 09:00:00', 2, 4, 3),  -- Soldado João Rato levou Camião Logístico (Major Maria)
('2024-05-16 11:20:00', 3, 1, 4),  -- Sargento Pedro Lima levou Viatura Tática 01 (Capitão Ricardo)
('2024-05-17 05:30:00', 1, 2, 2);  -- Cabo Manuel Silva levou Transporte Tropas A (Ten-Coronel Carlos)