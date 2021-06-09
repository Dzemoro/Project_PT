import sqlite3

#Connecting to sqlite
conn = sqlite3.connect('AppDB.db')

#Creating a cursor object using the cursor() method
cursor = conn.cursor()
cursor.execute('PRAGMA encoding="UTF-8";')
#Doping EMPLOYEE table if already exists.
#cursor.execute("DROP TABLE IF EXISTS Devices")

#Creating table as per requirement
sqlM = """ SELECT * FROM Measurements;"""
sqlCh = """ SELECT * FROM Channels;"""
#sql = """ SELECT * FROM ObstaclesAmount;"""
sqlO = """ SELECT * FROM Obstacles;"""
sqlD = """ SELECT * FROM Devices;"""
sqlW = """ SELECT * FROM Wires;"""
sqlWA = """ SELECT * FROM WiresAttenuation;"""
sqlC = """ SELECT * FROM Connectors;"""
sqlCW = """ SELECT * FROM ConnectorsToWires;"""

sqlDel = """ DELETE FROM Obstacles WHERE id < 8;  """

sqlInsert = """
INSERT INTO Obstacles (name, attenuation_24, attenuation_5) VALUES ('Płyta wiórowa', 0.5, 0.8);
"""

print(sqlDel)
cursor.execute(sqlDel)
rows = cursor.fetchall()
for row in rows:
    print(row)




print("Table created successfully........")

# Commit your changes in the database
conn.commit()

#Closing the connection
conn.close()