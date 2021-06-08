-- DELETE FROM Devices;
-- DELETE FROM Wires;
-- DELETE FROM WiresAttenuation;
-- DELETE FROM Connectors;
-- DELETE FROM ConnectorsToWires;
-- DELETE FROM Obstacles;
-- DELETE FROM Channels;
-- DELETE FROM Measurements;
-- DELETE FROM ObstaclesAmount;

-- INSERT INTO Devices (name, power, gain) VALUES ('Cisco Catalyst 9115', 23.0, 3.5);
-- INSERT INTO Devices (name, power, gain) VALUES ('Cisco Catalyst 9120AX', 23.0, 4.5);
-- INSERT INTO Devices (name, power, gain) VALUES ('Cisco Aironet 1850', 22.5, 4.0);
-- INSERT INTO Devices (name, power, gain) VALUES ('TP-Link EAP330', 27.0, 6.5);
-- INSERT INTO Devices (name, power, gain) VALUES ('TP-Link EAP245', 26.0, 4.0);

-- INSERT INTO Wires (name) VALUES ('H-155');
-- INSERT INTO Wires (name) VALUES ('H-1000');
-- INSERT INTO Wires (name) VALUES ('Tri-Lan 240');
-- INSERT INTO Wires (name) VALUES ('Tri-Lan 400');

-- INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (2400, 49.1, 22);
-- INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (2500, 49.6, 22);
-- INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (2750, 52, 22);
-- INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (5000, 77, 22);
-- INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (5800, 83, 22);

-- INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (2400, 23.2, 23);
-- INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (2500, 24, 23);
-- INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (5000, 37.4, 23);

-- INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (2400, 38, 24);
-- INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (2500, 40.6, 24);
-- INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (2750, 42, 24);
-- INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (5000, 60, 24);
-- INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (5800, 65.2, 24);

-- INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (2500, 22.7, 25);
-- INSERT INTO WiresAttenuation (frequency, value, wire_id) VALUES (5800, 37.6, 25);

-- INSERT INTO Connectors (name, attenuation) VALUES ('SMA', 0.35);
-- INSERT INTO Connectors (name, attenuation) VALUES ('RP-SMA', 0.35);
-- INSERT INTO Connectors (name, attenuation) VALUES ('N', 0.15);
-- INSERT INTO Connectors (name, attenuation) VALUES ('TNC', 0.18);
-- INSERT INTO Connectors (name, attenuation) VALUES ('RP-TNC', 0.18);

-- INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (22, 27);
-- INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (22, 28);
-- INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (22, 29);
-- INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (22, 30);
-- INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (22, 31);
-- INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (23, 29);
-- INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (23, 30);
-- INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (23, 31);
-- INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (24, 27);
-- INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (24, 28);
-- INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (24, 29);
-- INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (24, 30);
-- INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (24, 31);
-- INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (25, 29);
-- INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (25, 30);
-- INSERT INTO ConnectorsToWires (wire_id, connector_id) VALUES (25, 31);

INSERT INTO Obstacles (name, attenuation_24, attenuation_5) VALUES ('Drzwi drewniane', 3.0, 7.0);
INSERT INTO Obstacles (name, attenuation_24, attenuation_5) VALUES ('Drzwi stalowe', 20.0, 30.0);
INSERT INTO Obstacles (name, attenuation_24, attenuation_5) VALUES ('Okno szklane', 3.0, 8.0);
INSERT INTO Obstacles (name, attenuation_24, attenuation_5) VALUES ('Ściana betonowa', 20.0, 30.0);
INSERT INTO Obstacles (name, attenuation_24, attenuation_5) VALUES ('Ściana z cegieł', 8.5, 15.0);
INSERT INTO Obstacles (name, attenuation_24, attenuation_5) VALUES ('Płyta gipsowo-kartonowa', 5.4, 10.1);
INSERT INTO Obstacles (name, attenuation_24, attenuation_5) VALUES ('Płyta wiórowa', 0.5, 0.8);

INSERT INTO Channels (number, band, frequency) VALUES (1, 24, 2412);
INSERT INTO Channels (number, band, frequency) VALUES (2, 24, 2417);
INSERT INTO Channels (number, band, frequency) VALUES (3, 24, 2422);
INSERT INTO Channels (number, band, frequency) VALUES (4, 24, 2427);
INSERT INTO Channels (number, band, frequency) VALUES (5, 24, 2432);
INSERT INTO Channels (number, band, frequency) VALUES (6, 24, 2437);
INSERT INTO Channels (number, band, frequency) VALUES (7, 24, 2442);
INSERT INTO Channels (number, band, frequency) VALUES (8, 24, 2447);
INSERT INTO Channels (number, band, frequency) VALUES (9, 24, 2452);
INSERT INTO Channels (number, band, frequency) VALUES (10, 24, 2457);
INSERT INTO Channels (number, band, frequency) VALUES (11, 24, 2462);
INSERT INTO Channels (number, band, frequency) VALUES (12, 24, 2467);
INSERT INTO Channels (number, band, frequency) VALUES (13, 24, 2472);
INSERT INTO Channels (number, band, frequency) VALUES (14, 24, 2484);

INSERT INTO Channels (number, band, frequency) VALUES (36, 50, 5180);
INSERT INTO Channels (number, band, frequency) VALUES (40, 50, 5200);
INSERT INTO Channels (number, band, frequency) VALUES (44, 50, 5220);
INSERT INTO Channels (number, band, frequency) VALUES (48, 50, 5240);
INSERT INTO Channels (number, band, frequency) VALUES (52, 50, 5260);
INSERT INTO Channels (number, band, frequency) VALUES (56, 50, 5280);
INSERT INTO Channels (number, band, frequency) VALUES (60, 50, 5300);
INSERT INTO Channels (number, band, frequency) VALUES (64, 50, 5320);
INSERT INTO Channels (number, band, frequency) VALUES (100, 50, 5500);
INSERT INTO Channels (number, band, frequency) VALUES (104, 50, 5520);
INSERT INTO Channels (number, band, frequency) VALUES (108, 50, 5540);
INSERT INTO Channels (number, band, frequency) VALUES (112, 50, 5560);
INSERT INTO Channels (number, band, frequency) VALUES (116, 50, 5580);
INSERT INTO Channels (number, band, frequency) VALUES (120, 50, 5600);
INSERT INTO Channels (number, band, frequency) VALUES (124, 50, 5620);
INSERT INTO Channels (number, band, frequency) VALUES (128, 50, 5640);
INSERT INTO Channels (number, band, frequency) VALUES (132, 50, 5660);
INSERT INTO Channels (number, band, frequency) VALUES (136, 50, 5680);
INSERT INTO Channels (number, band, frequency) VALUES (140, 50, 5700);
INSERT INTO Channels (number, band, frequency) VALUES (149, 50, 5745);
INSERT INTO Channels (number, band, frequency) VALUES (153, 50, 5765);
INSERT INTO Channels (number, band, frequency) VALUES (157, 50, 5785);
INSERT INTO Channels (number, band, frequency) VALUES (161, 50, 5805);
INSERT INTO Channels (number, band, frequency) VALUES (165, 50, 5825);