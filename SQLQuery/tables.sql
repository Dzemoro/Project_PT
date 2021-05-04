CREATE TABLE Devices (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  name varchar(255) NOT NULL,
  power float NOT NULL,
  gain float NOT NULL
);

CREATE TABLE Wires (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  name varchar(255) NOT NULL
);

CREATE TABLE WiresAttenuation (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  frequency float NOT NULL,
  value float NOT NULL,
  wire_id INTEGER,
  FOREIGN KEY (wire_id) REFERENCES Wires (id)
);

CREATE TABLE Connectors (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  name varchar(255) NOT NULL,
  attenuation float NOT NULL
);

CREATE TABLE ConnectorsToWires (
  wire_id INTEGER,
  connector_id INTEGER,
  FOREIGN KEY (wire_id) REFERENCES Wires (id),
  FOREIGN KEY (connector_id) REFERENCES Connectors (id)
);

CREATE TABLE Obstacles (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  name varchar(255) NOT NULL,
  attenuation float NOT NULL
);

CREATE TABLE Channels (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  number INTEGER NOT NULL,
  band INTEGER NOT NULL,
  frequency INTEGER NOT NULL
);

CREATE TABLE Measurements (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  name varchar(255) NOT NULL,
  distance float NOT NULL,
  transmitter_id INTEGER,
  receiver_id INTEGER,
  wireT_id INTEGER,
  wireR_id INTEGER,
  connectorT_id INTEGER,
  connectorR_id INTEGER,
  channel_id INTEGER,
  FOREIGN KEY (transmitter_id) REFERENCES Devices (id),
  FOREIGN KEY (receiver_id) REFERENCES Devices (id),
  FOREIGN KEY (wireT_id) REFERENCES Wires (id),
  FOREIGN KEY (wireR_id) REFERENCES Wires (id),
  FOREIGN KEY (connectorT_id) REFERENCES Connectors (id),
  FOREIGN KEY (connectorR_id) REFERENCES Connectors (id),
  FOREIGN KEY (channel_id) REFERENCES Channels (id)
);

CREATE TABLE ObstaclesAmount (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  amount INTEGER NOT NULL,
  obstacles_id INTEGER,
  measurements_id INTEGER,
  FOREIGN KEY (obstacles_id) REFERENCES Obstacles (id),
  FOREIGN KEY (measurements_id) REFERENCES Measurements (id)
);

--ALTER TABLE WiresAttenuation ADD FOREIGN KEY (wire_id) REFERENCES Wires (id);

--ALTER TABLE ConnectorsToWires ADD FOREIGN KEY (wire_id) REFERENCES Wires (id);

--ALTER TABLE ConnectorsToWires ADD FOREIGN KEY (connector_id) REFERENCES Connectors (id);

--ALTER TABLE Measurements ADD FOREIGN KEY (transmitter_id) REFERENCES Devices (id);

--ALTER TABLE Measurements ADD FOREIGN KEY (receiver_id) REFERENCES Devices (id);

--ALTER TABLE Measurements ADD FOREIGN KEY (wireT_id) REFERENCES Wires (id);

--ALTER TABLE Measurements ADD FOREIGN KEY (wireR_id) REFERENCES Wires (id);

--ALTER TABLE Measurements ADD FOREIGN KEY (connectorT_id) REFERENCES Connectors (id);

--ALTER TABLE Measurements ADD FOREIGN KEY (connectorR_id) REFERENCES Connectors (id);

--ALTER TABLE Measurements ADD FOREIGN KEY (channel_id) REFERENCES Channels (id);

--ALTER TABLE ObstaclesAmount ADD FOREIGN KEY (obstacles_id) REFERENCES Obstacles (id);

--ALTER TABLE ObstaclesAmount ADD FOREIGN KEY (measurements_id) REFERENCES Measurements (id);