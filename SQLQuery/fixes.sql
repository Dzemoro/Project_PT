INSERT INTO Devices (name, power, gain) VALUES ('test1', 20, 16);
INSERT INTO Devices (name, power, gain) VALUES ('test2', 24, 3);

INSERT INTO Wires (name) VALUES ('H-155');
INSERT INTO Wires (name) VALUES ('H-1000');
INSERT INTo Wires (name) VALUES ('Tri-Lan 240');
INSERT INTo Wires (name) VALUES ('Tri-Lan 400');

INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (2400, 49.1, 1);
INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (2500, 49.6, 1);
INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (2750, 52, 1);
INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (5000, 77, 1);
INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (5800, 83, 1);
INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (2400, 23.2, 2);
INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (2500, 24, 2);
INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (2400, 38, 3);
INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (2500, 40.6, 3);
INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (2750, 42, 3);
INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (5000, 60, 3);
INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (5800, 65.2, 3);
INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (2500, 22.7, 4);
INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (5800, 37.6, 4);

INSERT INTO Connectors (name, attenuation) VALUES ('SMA', 0.35);
INSERT INTO Connectors (name, attenuation) VALUES ('RP-SMA', 0.35);
INSERT INTO Connectors (name, attenuation) VALUES ('N', 0.15);
INSERT INTO Connectors (name, attenuation) VALUES ('TNC', 0.18);
INSERT INTO Connectors (name, attenuation) VALUES ('RP-TNC', 0.18);

INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (1, 1);
INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (1, 2);
INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (1, 3);
INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (1, 4);
INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (1, 5);
INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (2, 3);
INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (2, 4);
INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (2, 5);
INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (3,1);
INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (3,2);
INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (3,3);
INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (3,4);
INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (3,5);
INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (4,3);
INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (4,4);
INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (4,5);
